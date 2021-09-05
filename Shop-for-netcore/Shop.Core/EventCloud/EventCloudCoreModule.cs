using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Abp;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.IO.Extensions;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using EventCloud.Authorization.Roles;
using EventCloud.Configuration;

namespace EventCloud
{
    [DependsOn(
        //typeof(AbpKernelModule),
        typeof(AbpZeroCoreModule)
        )]
    public class EventCloudCoreModule : AbpModule
    {
        internal static class Utf8Helper
        {
            public static string ReadStringFromStream(Stream stream)
            {
                byte[] allBytes = stream.GetAllBytes();
                int num = HasBom(allBytes) ? 3 : 0;
                return Encoding.UTF8.GetString(allBytes, num, allBytes.Length - num);
            }

            private static bool HasBom(byte[] bytes)
            {
                if (bytes.Length < 3)
                {
                    return false;
                }

                if (bytes[0] != 239 || bytes[1] != 187 || bytes[2] != 191)
                {
                    return false;
                }

                return true;
            }
        }
        public static void BasePreInitialize(IAbpStartupConfiguration Configuration)
        {
            Configuration.MultiTenancy.IsEnabled = true;
            var _assembly = Assembly.GetExecutingAssembly();
            CultureInfo[] allCultureInfos = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (string item in (from resouceName in _assembly.GetManifestResourceNames()
                                     where allCultureInfos.Any((CultureInfo culture) => 
                                     resouceName.EndsWith(EventCloudConsts.LocalizationSourceName
                                     + ".xml", ignoreCase: true, null) ||
                                     resouceName.EndsWith(EventCloudConsts.LocalizationSourceName
                                     + "-" + culture.Name + ".xml",
                                     ignoreCase: true, null))
                                     select resouceName).ToList())
            {
                if (item.StartsWith("EventCloud.Localization.Source"))
                {
                    using (Stream stream = _assembly.GetManifestResourceStream(item))
                    {
                        string xmlString = Utf8Helper.ReadStringFromStream(stream);
                        //InitializeDictionary(CreateXmlLocalizationDictionary(xmlString), item.EndsWith(base.SourceName + ".xml"));
                    }
                }
            }
            var a = new DictionaryBasedLocalizationSource(
                    EventCloudConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "EventCloud.Localization.Source"
                        )
                    );
            //5.10.1 pass
            //6.3.1 我整理 出问题？(还是新出来的bug)
            //重写 错了 注意 检查 下 一般 自己忽略了(检查不出来 调试才知道)
            //PreInitialize 写成其它了 
            //(出现问题调试太麻烦 所有 都要 改成 源码 引用 不然调试 各种问题)
            //AbpKernelModule 这一步 很 关键
            //IocManager.Resolve<LocalizationManager>().Initialize();只能调用一次
            //AbpKernelModule 源码 理解 该 设置为 第一个模块
            //启动模块 为 最后 一个模块
            //依赖模块 依次 排序 插入集合 去重模块

            //哪里 调用的 event 模板 必须要 拆开使用 不能混合 dapper nh ef 
            // a.Initialize(Configuration.Localization,Configuration.IocManager);
            //err
            Configuration.Localization.Sources.Add(a);
            //pass 内存类无法调用 只能反射 
           // Configuration.IocManager.Resolve<ILocalizationManager>()

            Configuration.Settings.Providers.Add<EventCloudSettingProvider>();

            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Admin, MultiTenancySides.Host));
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Admin, MultiTenancySides.Tenant));
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Member, MultiTenancySides.Tenant));

            Clock.Provider = ClockProviders.Utc;
        }
        public virtual bool IsEventCloud { get; set; } = true;
        public override void PreInitialize()
     {
            //怎么调用2次
            if (IsEventCloud)
            {
                BasePreInitialize(Configuration);
            }
        }
        public static void BaseInitialize(IIocManager IocManager)
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
        public override void Initialize()
        {
            if (IsEventCloud)
            {
                BaseInitialize(IocManager);
            }
        }
    }
}
