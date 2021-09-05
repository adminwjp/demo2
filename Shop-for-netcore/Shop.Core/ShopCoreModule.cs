namespace Shop
{
    using Abp.Modules;
    using Abp.Zero;
    using EventCloud;
    using System.Reflection;

    [DependsOn(typeof(AbpZeroCoreModule))]
    //¼Ì³Ð »° Ö´ÐÐ 2±é
    public class ShopCoreModule: AbpModule//EventCloudCoreModule
    {
        public override void PreInitialize()
        {
            EventCloudCoreModule.BasePreInitialize(Configuration);
        }
        public override void Initialize()
        {
            EventCloudCoreModule.BaseInitialize(IocManager);
        }
    }
}