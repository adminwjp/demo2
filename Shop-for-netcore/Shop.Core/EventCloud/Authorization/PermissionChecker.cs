using Abp.Authorization;
using EventCloud.Authorization.Roles;
using EventCloud.Users;

namespace EventCloud.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
#if NETCOREAPP3_1
        public PermissionChecker(UserManager userManager)
           : base(userManager)
        {

        }
#else
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
#endif

    }
}
