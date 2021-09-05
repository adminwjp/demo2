using Abp.MultiTenancy;
using FluentNHibernate.Mapping;

namespace Abp.ZeroCore.NHibernate.EntityMappings
{
    public class TenantFeatureSettingMap : SubclassMap<TenantFeatureSetting>
    {
        public TenantFeatureSettingMap()
        {
            DiscriminatorValue("TenantFeatureSetting");

            Map(x => x.TenantId);
        }
    }
}