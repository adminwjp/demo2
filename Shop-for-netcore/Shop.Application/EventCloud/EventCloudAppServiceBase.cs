using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using EventCloud.MultiTenancy;
using EventCloud.Users;
#if NET5_0
using Microsoft.AspNetCore.Identity;
#else
using Microsoft.AspNet.Identity;
#endif


namespace EventCloud
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class EventCloudAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected EventCloudAppServiceBase()
        {
            LocalizationSourceName = EventCloudConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
#if NET5_0
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
#else
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
#endif
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}