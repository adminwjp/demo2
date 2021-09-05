using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using EventCloud.Authorization.Roles;
#if NET5_0
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
#else
using Abp.IdentityFramework;
using Abp.Localization;
#endif
using System;
using System.Collections.Generic;

namespace EventCloud.Users
{
    public class UserManager : AbpUserManager< Role, User>
    {
#if NET5_0
        public UserManager(
         RoleManager roleManager,
         UserStore userStore, 
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
          UserStore userStore,
          RoleManager roleManager,
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