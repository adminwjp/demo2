using System.Threading.Tasks;
using Abp.Application.Services;
using EventCloud.Users.Dto;

namespace EventCloud.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);
#if NET5_0
        Task RemoveFromRole(string userId, string roleName);
#else
        Task RemoveFromRole(long userId, string roleName);
#endif
    }
}