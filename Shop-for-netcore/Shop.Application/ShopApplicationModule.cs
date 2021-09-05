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
            //aop 缓存实现 必须是虚方法
            // ServiceInterceptorRegistrar.Initialize(IocManager.IocContainer.Kernel);
            //https://aspnetboilerplate.com/Pages/Documents/Zero/Permission-Management
            //这认证怎么玩 网关统一认证  这里可有可无认证  管理员 邮件 普通用户 邮件 怎么区分 认证授权 2 遍认证(网关认证 微服务认证)？ 需要组合框架一起使用 
            //abp 认证 必须要引入 其他框架 ? 默认为实现 没找到
            //Configuration.IocManager.Register<IAbpSession, TestSession>();
            //Configuration.ReplaceService<IPermissionChecker, CustomePermissionChecker>();//userid not found
            //Configuration.Authorization.Providers.Add<CustomeAuthorizationProvider>();

            // https://aspnetboilerplate.com/Pages/Documents/Quartz-Integration quartz 不用配置


            //cache  https://aspnetboilerplate.com/Pages/Documents/Caching
            //redis 需要 app.config 配置  信息

            //Configuration for all caches
            //Configuration.Caching.ConfigureAll(cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromHours(2);
            //});

            ////Configuration for a specific cache ICacheManager 需要配置
            //Configuration.Caching.Configure("RedisCache", cache =>
            //{
            //    cache.DefaultSlidingExpireTime = TimeSpan.FromHours(8);
            //});
            //IocManager.Register<ICacheManager, AbpRedisCacheManager>();//必须放在下面 不然报错  AbpMemoryCache 

            //authrization config
            //qq email config  https://aspnetboilerplate.com/Pages/Documents/Email-Sending 文档没找到 默认配置用不了 重新配置 覆盖 要么看源码 要么 参考 别人的文章 
            //默认写死 也可以动态  相同操作
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