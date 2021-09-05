using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq;
using Abp.Organizations;
using EventCloud.Authorization.Roles;

namespace EventCloud.Users
{
    public class UserStore : AbpUserStore<Role, User>
    {
#if NET5_0
        public UserStore(
          IUnitOfWorkManager unitOfWorkManager, 
          IRepository<User, long> userRepository,
          IRepository<Role> roleRepository, 
          //IAsyncQueryableExecuter asyncQueryableExecuter,
          IRepository<UserRole, long> userRoleRepository, 
          IRepository<UserLogin, long> userLoginRepository,
          IRepository<UserClaim, long> userClaimRepository, 
          IRepository<UserPermissionSetting, long> userPermissionSettingRepository, 
          IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
          IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository
       )
       : base(
             unitOfWorkManager,
             userRepository,
             roleRepository,
             //asyncQueryableExecuter,
             userRoleRepository,
             userLoginRepository,
             userClaimRepository,
             userPermissionSettingRepository,
             userOrganizationUnitRepository,
             organizationUnitRoleRepository)
        {
        }
#else
public UserStore(
           IRepository<User, long> userRepository,
           IRepository<UserLogin, long> userLoginRepository,
           IRepository<UserRole, long> userRoleRepository,
           IRepository<Role> roleRepository,
           IRepository<UserPermissionSetting, long> userPermissionSettingRepository,
           IUnitOfWorkManager unitOfWorkManager,
           IRepository<UserClaim, long> userClaimStore,
           IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, 
           IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository
       )
       : base(
             userRepository,
             userLoginRepository,
             userRoleRepository,
             roleRepository,
             userPermissionSettingRepository,
             unitOfWorkManager,
             userClaimStore,
             userOrganizationUnitRepository,
             organizationUnitRoleRepository)
        {
        }
#endif

    }
}