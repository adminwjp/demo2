using Abp.Authorization.Users;
using Abp.NHibernate.EntityMappings;

namespace Abp.ZeroCore.NHibernate.EntityMappings
{
    public class UserOrganizationUnitMap : EntityMap<UserOrganizationUnit, long>
    {
        public UserOrganizationUnitMap()
            : base("AbpUserOrganizationUnits")
        {
            Map(x => x.TenantId);
            Map(x => x.UserId);
            Map(x => x.OrganizationUnitId);
            this.MapIsDeleted();
            this.MapCreationAudited();
        }
    }
}