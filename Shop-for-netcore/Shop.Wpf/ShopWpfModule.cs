using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Wpf
{
    [DependsOn(typeof(ShopApplicationModule))]
     public class ShopWpfModule : AbpModule {

        public override void PreInitialize()
        {
            base.PreInitialize();
        }
        public override void Initialize()
        {
            base.Initialize();
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
