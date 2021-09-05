using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
#if NET5_0
using Microsoft.AspNetCore.Identity;
#endif
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Shop.Manager
{
    public class RoleManager<User, Role> : AbpRoleManager<Role, User>
           where User : AbpUser<User>
          where Role : AbpRole<User>, new()
    {
#if NET5_0
        public RoleManager(RoleStore<User, Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, 
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<User, Role>> logger, 
            IPermissionManager permissionManager, ICacheManager cacheManager, IUnitOfWorkManager unitOfWorkManager, 
            IRoleManagementConfig roleManagementConfig, IRepository<OrganizationUnit, long> organizationUnitRepository, 
            IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository)
           : base(store, roleValidators, keyNormalizer, errors, logger, 
                 permissionManager, cacheManager, unitOfWorkManager, roleManagementConfig, 
                 organizationUnitRepository, organizationUnitRoleRepository
                 )
        {
            
        }
#else

        public RoleManager(
            RoleStore<User, Role> store,
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            ICacheManager cacheManager,
            IUnitOfWorkManager unitOfWorkManager , 
            IRepository<OrganizationUnit, long> organizationUnitRepository, 
            IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository)
            : base(
                store,
                permissionManager,
                roleManagementConfig,
                cacheManager,
                unitOfWorkManager,
                organizationUnitRepository,
                organizationUnitRoleRepository)
        {
        }
#endif
    }

}