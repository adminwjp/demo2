using Abp.NHibernate.EntityMappings;
using EventCloud.Events;

namespace EventCloud.NHibernate.EntityMappings
{
    public class EventRegistrationMap:EntityMap<EventRegistration>
    {
        public EventRegistrationMap()
                  : base("AppEventRegistrations")
        {
            Id(x => x.Id);// 主键
            Map(x => x.TenantId).Nullable();
            HasOne(it => it.Event).ForeignKey("EventId");
            HasOne(it => it.User).ForeignKey("UserId");
            Map(x => x.CreationTime);
            Map(x => x.CreatorUserId).Nullable();
        }
    }
}
