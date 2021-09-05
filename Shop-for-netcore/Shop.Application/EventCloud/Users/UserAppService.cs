using System.Threading.Tasks;
using Abp.Authorization;
using EventCloud.Users.Dto;

namespace EventCloud.Users
{
    /* THIS IS JUST A SAMPLE. */
    public class UserAppService : EventCloudAppServiceBase, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly IPermissionManager _permissionManager;

        public UserAppService(UserManager userManager, IPermissionManager permissionManager)
        {
            _userManager = userManager;
            _permissionManager = permissionManager;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await _userManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);

            await _userManager.ProhibitPermissionAsync(user, permission);
        }

        //Example for primitive method parameters.
#if NET5_0
        public async Task RemoveFromRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            CheckErrors(await _userManager.RemoveFromRoleAsync(user, roleName));
        }
#else
        public async Task RemoveFromRole(long userId, string roleName)
        {
            CheckErrors(await _userManager.RemoveFromRoleAsync(userId, roleName));
        }
#endif

    }
}