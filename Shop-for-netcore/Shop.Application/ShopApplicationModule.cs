namespace Shop
{
    using Abp.AutoMapper;
    using Abp.MailKit;
    using Abp.Modules;
    using Abp.Quartz;
    using Abp.Runtime.Caching;
    using Abp.Runtime.Caching.Redis;
    using EventCloud;
    using Shop.Application.Services;
    using System;
    using System.Reflection;
   [DependsOn(
        typeof(ShopCoreModule),
        //typeof(ShopDataModule),
        typeof(AbpAutoMapperModule)
        // typeof(AbpRedisCacheModule),
        // typeof(AbpMailKitModule),
        // typeof(AbpQuartzModule)
        )]
    public class ShopApplicationModule: AbpModule
    {
        public override void PreInitialize()
        {
            // Configuration.IocManager.Register<IInterceptor, ServiceInterceptor>();
            //aop ����ʵ�� �������鷽��
            // ServiceInterceptorRegistrar.Initialize(IocManager.IocContainer.Kernel);
            //https://aspnetboilerplate.com/Pages/Documents/Zero/Permission-Management
            //����֤��ô�� ����ͳһ��֤  ������п�����֤  ����Ա �ʼ� ��ͨ�û� �ʼ� ��ô���� ��֤��Ȩ 2 ����֤(������֤ ΢������֤)�� ��Ҫ��Ͽ��һ��ʹ�� 
            //abp ��֤ ����Ҫ���� ������� ? Ĭ��Ϊʵ�� û�ҵ�
            //Configuration.IocManager.Register<IAbpSession, TestSession>();
            //Configuration.ReplaceService<IPermissionChecker, CustomePermissionChecker>();//userid not found
            //Configuration.Authorization.Providers.Add<CustomeAuthorizationProvider>();

            // https://aspnetboilerplate.com/Pages/Documents/Quartz-Integration quartz ��������


            //cache  https://aspnetboilerplate.com/Pages/Documents/Caching
            //redis ��Ҫ app.config ����  ��Ϣ

            //Configuration for all caches
            //Configuration.Caching.ConfigureAll(cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromHours(2);
            //});

            ////Configuration for a specific cache ICacheManager ��Ҫ����
            //Configuration.Caching.Configure("RedisCache", cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromHours(8);
            //});
            //IocManager.Register<ICacheManager, AbpRedisCacheManager>();//����������� ��Ȼ����  AbpMemoryCache 

            //authrization config
            //qq email config  https://aspnetboilerplate.com/Pages/Documents/Email-Sending �ĵ�û�ҵ� Ĭ�������ò��� �������� ���� Ҫô��Դ�� Ҫô �ο� ���˵����� 
            //Ĭ��д�� Ҳ���Զ�̬  ��ͬ����
           // Configuration.Settings.Providers.Add<EmailSettingProvider>();

        }
        public override void Initialize()
        {
           //IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            // System.InvalidOperationException : Both ErrorMessageResourceType and ErrorMessageResourceName need to be set on this attribute.
            // Abp.Runtime.Validation.AbpValidationException : Method arguments are not valid! See ValidationErrors for details.
            Configuration?.Validation?.Validators?.Clear();
            Configuration?.Validation?.IgnoredTypes?.Clear();
        }
    }
}