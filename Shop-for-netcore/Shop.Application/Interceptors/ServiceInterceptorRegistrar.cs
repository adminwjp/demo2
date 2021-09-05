using Castle.Core;
using Castle.MicroKernel;
using Shop.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interceptors
{
    public class ServiceInterceptorRegistrar
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        private static void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            //if (typeof(BaseAppService<,,,,,>).IsAssignableFrom(handler.ComponentModel.Implementation))
            //{
            //    handler.ComponentModel.Interceptors.Add
            //    (new InterceptorReference(typeof(ServiceInterceptor)));
            //}
            //if (handler.ComponentModel.Implementation.BaseType==typeof(BaseAppService<,,,,,>))
            //{

            //}
            if (handler.ComponentModel.Implementation
                == typeof(EmailNotifyProductAppService)
              )
            {
                handler.ComponentModel.Interceptors.Add
              (new InterceptorReference(typeof(ServiceInterceptor)));
            }
        }
    }
}
