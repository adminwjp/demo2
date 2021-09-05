using Castle.DynamicProxy;
using Abp.Net.Mail;
using Abp.Runtime.Caching;
using StackExchange.Redis;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Abp.Runtime.Caching.Redis;
using Abp.Runtime.Caching.Memory;

namespace Shop.Interceptors
{
    public class ServiceInterceptor : IInterceptor
    {
        protected CacheBase cache;
        //protected ICacheManager cacheManager;
        protected IDatabase database;
        protected ILogger logger;
        protected IEmailSender emailSender;

        public ServiceInterceptor(ICacheManager cacheManager, IAbpRedisCacheDatabaseProvider abpRedisCacheDatabaseProvider, ILogger<ServiceInterceptor> logger, IEmailSender emailSender)
        {
            ICache cacheTemp = cacheManager.GetCache("RedisCache");
            if (cacheTemp is AbpRedisCache)
            {
                this.cache = (AbpRedisCache)cacheTemp;//AbpMemoryCache
            }
            else
            {
                this.cache = (AbpMemoryCache)cacheTemp;//AbpMemoryCache
            }
            this.database = abpRedisCacheDatabaseProvider.GetDatabase();
            this.logger = logger;
            this.emailSender = emailSender;
        }
        public void Intercept(IInvocation invocation)
        {
            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Executing the actual method
            invocation.Proceed();
            //添加修改
            if (IsAsyncMethod(invocation.Method))
            {
                var taks1 = ((Task)invocation.ReturnValue);
                try
                {
                    //We should wait for finishing of the method execution
                    var task2 = ((Task)invocation.ReturnValue)
                       .ContinueWith(task =>
                       {
                           Execute(invocation, stopwatch);
                       });
                    Task.WaitAll(taks1, task2);
                }
                catch (System.Exception e)
                {
                    logger.LogError(e, "aop reutrn task exception");
                }

            }
            else
            {
                Execute(invocation, stopwatch);
            }

        }
        public void Execute(IInvocation invocation, Stopwatch stopwatch)
        {
            //After method execution
            if (invocation.MethodInvocationTarget.Name.Equals(""))
            {

            }else
            {

            }
            stopwatch.Stop();
            logger.LogInformation(
                "MeasureDurationInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                );
        }
        public static bool IsAsyncMethod(MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }
    }
}
