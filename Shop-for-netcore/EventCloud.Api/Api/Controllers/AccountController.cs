using System;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.UI;
#if NET5_0
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using JwtAuthSample;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
#else
using Abp.WebApi.Controllers;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
#endif
using EventCloud.Api.Models;
using EventCloud.Authorization;
using EventCloud.MultiTenancy;
using EventCloud.Users;
using Abp.Web.Models;
using System.Text;


namespace JwtAuthSample
{
    /**
     "JwtSettings":{
    "Issuer":"http://localhost:5000",
    "Audience":"http://localhost:5000",
    "SecretKey":"Hello-key-----wyt"
  }
     */
    public class JwtSettings
    {
        //token是谁颁发的
        public string Issuer { get; set; } = "http://localhost:5000";
        //token可以给哪些客户端使用
        public string Audience { get; set; } = "http://localhost:5000";
        //加密的key
        public string SecretKey { get; set; } = "Hello-key-----wyt";

    }
}
namespace EventCloud.Api.Controllers
{
   
    public class AccountController :
       #if NET5_0
         AbpController
        #else
                AbpApiController
        #endif
    {
       

        private readonly UserManager _userManager;
        private readonly LogInManager _logInManager;
#if !(NET5_0)
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        static AccountController()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }
#else
        private JwtSettings _jwtSettings;
#endif

        public AccountController(UserManager userManager, LogInManager logInManager
#if NET5_0
            , IOptions<JwtSettings> _jwtSettingsAccesser
#endif
            )
        {
            _userManager = userManager;
            _logInManager = logInManager;
#if NET5_0
            _jwtSettings = _jwtSettingsAccesser.Value;
#endif
        }

        public async Task<AjaxResponse> Authenticate(LoginModel loginModel)
        {
            CheckModelState();

            var loginResult = await GetLoginResultAsync(
                loginModel.UsernameOrEmailAddress,
                loginModel.Password,
                loginModel.TenancyName
                );
#if !(NET5_0)
            var ticket = new AuthenticationTicket(loginResult.Identity, new AuthenticationProperties());
#else
            var ticket = new AuthenticationTicket(new System.Security.Claims
                .ClaimsPrincipal(loginResult.Identity), new AuthenticationProperties(), JwtBearerDefaults.AuthenticationScheme);
#endif
            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));
#if !(NET5_0)
            return new AjaxResponse(OAuthBearerOptions.AccessTokenFormat.Protect(ticket));
#else
            //对称秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            //签名证书(秘钥，加密算法)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //生成token  [注意]需要nuget添加Microsoft.AspNetCore.Authentication.JwtBearer包，并引用System.IdentityModel.Tokens.Jwt命名空间
            var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, loginResult.Identity.Claims
                , currentUtc.Date, ticket.Properties.ExpiresUtc.Value.Date, creds);

            return new AjaxResponse(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
#endif
        }
        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

     
        private Exception CreateExceptionForFailedLoginAttempt(AbpLoginResultType result, string usernameOrEmailAddress, string tenancyName)
        {
            switch (result)
            {
                case AbpLoginResultType.Success:
                    return new ApplicationException("Don't call this method with a success result!");
                case AbpLoginResultType.InvalidUserNameOrEmailAddress:
                case AbpLoginResultType.InvalidPassword:
                    return new UserFriendlyException(L("LoginFailed"), L("InvalidUserNameOrPassword"));
                case AbpLoginResultType.InvalidTenancyName:
                    return new UserFriendlyException(L("LoginFailed"), L("ThereIsNoTenantDefinedWithName{0}", tenancyName));
                case AbpLoginResultType.TenantIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("TenantIsNotActive", tenancyName));
                case AbpLoginResultType.UserIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress));
                case AbpLoginResultType.UserEmailIsNotConfirmed:
                    return new UserFriendlyException(L("LoginFailed"), "Your email address is not confirmed. You can not login"); //TODO: localize message
                default: //Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(L("LoginFailed"));
            }
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException("Invalid request!");
            }
        }
    }
}
