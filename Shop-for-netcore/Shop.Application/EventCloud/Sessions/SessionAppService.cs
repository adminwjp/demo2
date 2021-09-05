using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Authorization;
using Abp.ObjectMapping;
using EventCloud.Sessions.Dto;

namespace EventCloud.Sessions
{
    [AbpAuthorize]
    public class SessionAppService : EventCloudAppServiceBase, ISessionAppService
    {
        public SessionAppService(IObjectMapper objectMapper)
        {
            ObjectMapper = objectMapper;
        }
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput
            {
                // User = (await GetCurrentUserAsync()).MapTo<UserLoginInfoDto>()
                User = ObjectMapper.Map<UserLoginInfoDto>(await GetCurrentUserAsync())
            };
            

            if (AbpSession.TenantId.HasValue)
            {
                //output.Tenant = (await GetCurrentTenantAsync()).MapTo<TenantLoginInfoDto>();
                output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
            }

            return output;
        }
    }
}