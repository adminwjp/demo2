//#if NET5_0
using Abp.ZeroCore.NHibernate.EntityMappings;
//#else
//using Abp.Zero.NHibernate.EntityMappings;
//#endif
using EventCloud.Users;

namespace EventCloud.NHibernate.EntityMappings
{
    public class UserMap: AbpUserMap<User>
    {
    }
}
