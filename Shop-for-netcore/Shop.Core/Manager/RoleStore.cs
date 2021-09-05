using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;

namespace Shop.Manager
{
    public class RoleStore<User, Role> : AbpRoleStore<Role, User>
            where User : AbpUser<User>
          where Role : AbpRole<User>
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