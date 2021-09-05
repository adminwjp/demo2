using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using EventCloud.Users;
#if NET5_0
using Microsoft.AspNetCore.Identity;
#endif
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace EventCloud.Authorization.Roles
{
    public class RoleManager : AbpRoleManager<Role, User>
    {
#if NET5_0
        public RoleManager(RoleStore store, IEnumerable<IRoleValidator<Role>> roleValidators, 
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<AbpRoleManager<Role, User>> logger, 
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
            RoleStore store,
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