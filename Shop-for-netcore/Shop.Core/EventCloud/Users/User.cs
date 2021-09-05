using System;
using Abp.Authorization.Users;
using Abp.Extensions;
#if NET5_0
using Microsoft.AspNetCore.Identity;
#else
using Microsoft.AspNet.Identity;
#endif

namespace EventCloud.Users
{
    public class User : AbpUser<User>
    {
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                IsEmailConfirmed = true,
                IsActive = true
            };
#if NET5_0
            user.Password = new PasswordHasher<User>().HashPassword(user, password);
#else
            user.Password = new PasswordHasher().HashPassword(password);
#endif
            return user;
        }
    }
}