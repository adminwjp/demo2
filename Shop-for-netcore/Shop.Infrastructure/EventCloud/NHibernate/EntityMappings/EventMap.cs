using Abp.NHibernate.EntityMappings;
using EventCloud.Events;
using System;

namespace EventCloud.NHibernate.EntityMappings
{
    public class EventMap : EntityMap<Event,Guid>
    {
        public EventMap()
               : base("AppEvents")
        {
            Id(x => x.Id).Not.Nullable().Length(20).UniqueKey("UK_Id");//唯一键 即是主键
            Map(x => x.Title).Length(Event.MaxTitleLength).Not.Nullable();
            Map(x => x.TenantId).Nullable();
            Map(x => x.Description).Length(Event.MaxDescriptionLength).Nullable();
            Map(x => x.Date).Nullable();
            Map(x => x.IsCancelled);
            Map(x => x.MaxRegistrationCount);
            HasMany(it => it.Registrations).AsBag().KeyColumn("EventId").Inverse().ForeignKeyCascadeOnDelete();       
        }
    }
}
