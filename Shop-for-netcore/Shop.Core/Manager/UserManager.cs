using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Localization;
#if NET48
using Abp.IdentityFramework;
#endif
using Abp.Organizations;
using Abp.Runtime.Caching;
#if NET5_0
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
#endif
using System;
using System.Collections.Generic;

namespace Shop.Manager
{
    public class UserManager<User,Role> : AbpUserManager<Role, User> 
        where User: AbpUser<User>
          where Role : AbpRole<User>,new()
    {
#if NET5_0
        public UserManager(
         RoleManager<User, Role> roleManager,
         UserStore<User, Role> userStore, 
         IOptions<IdentityOptions> optionsAccessor, 
         IPasswordHasher<User> passwordHasher, 
         IEnumerable<IUserValidator<User>> userValidators, 
         IEnumerable<IPasswordValidator<User>> passwordValidators,
         ILookupNormalizer keyNormalizer,
         IdentityErrorDescriber errors, 
         IServiceProvider services, 
         ILogger<UserManager<User>> logger,
         IPermissionManager permissionManager, 
         IUnitOfWorkManager unitOfWorkManager,
         ICacheManager cacheManager, 
         IRepository<OrganizationUnit, long> organizationUnitRepository, 
         IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, 
         IOrganizationUnitSettings organizationUnitSettings,
         ISettingManager settingManager)
          : base(
                roleManager,
                userStore,
                optionsAccessor,
                passwordHasher,
                userValidators,
                passwordValidators,
                keyNormalizer,
                errors,
                services,
                logger,
                permissionManager,
                unitOfWorkManager,
                cacheManager,
                organizationUnitRepository,
                userOrganizationUnitRepository,
                organizationUnitSettings,
                settingManager)
        {
        }
#else
        public UserManager(
          UserStore<User, Role> userStore,
          RoleManager<User, Role> roleManager,
          IPermissionManager permissionManager,
          IUnitOfWorkManager unitOfWorkManager,
          ICacheManager cacheManager,
          IRepository<OrganizationUnit, long> organizationUnitRepository,
          IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
          IOrganizationUnitSettings organizationUnitSettings,
          ILocalizationManager localizationManager,
          ISettingManager settingManager,
          IdentityEmailMessageService emailService,
          IUserTokenProviderAccessor userTokenProviderAccessor)
          : base(
                (AbpUserStore<Role, User>)userStore,
                roleManager,
                permissionManager,
                unitOfWorkManager,
                cacheManager,
                organizationUnitRepository,
                userOrganizationUnitRepository,
                organizationUnitSettings,
                localizationManager,
                emailService,
                settingManager,
                userTokenProviderAccessor)
        {
        }
#endif
    }
}