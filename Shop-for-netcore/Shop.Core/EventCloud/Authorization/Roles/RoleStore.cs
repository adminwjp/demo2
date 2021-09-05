using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using EventCloud.Users;

namespace EventCloud.Authorization.Roles
{
    public class RoleStore : AbpRoleStore<Role, User>
    {
#if NET5_0
        public RoleStore(
        IUnitOfWorkManager unitOfWorkManager,
        IRepository<Role> userRoleRepository,
        IRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
        : base(
            unitOfWorkManager,
            userRoleRepository,
            rolePermissionSettingRepository)
        {
        }
#else
    public RoleStore(
            IRepository<Role> roleRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository
            ,IUnitOfWorkManager unitOfWorkManager
           )
            : base(
                roleRepository,
                userRoleRepository,
                rolePermissionSettingRepository
                ,unitOfWorkManager
                )
        {
        }
#endif

    }
}