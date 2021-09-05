namespace Shop.NHibernate.EntityMappings
{
    using Abp.NHibernate.EntityMappings;
    using FluentNHibernate.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Shop.Domain.Entities;

    public class OrderShipMap:EntityMap<OrderShip,long>
    {
        public OrderShipMap():base("t_order_ship"){
           //Id(x => x.Id);
            Id(x => x.Id).Column("id");
            Map(x => x.Tel).Column("tel").Length(50);
            Map(x => x.CityCode).Column("city_code").Length(50);
            Map(x => x.City).Column("city").Length(50);
            Map(x => x.Province).Column("province").Length(50);
            Map(x => x.Sex).Column("sex").Length(50);
            Map(x => x.AreaCode).Column("area_code").Length(50);
            Map(x => x.Zip).Column("zip").Length(50);
            Map(x => x.Shipname).Column("shipname").Length(50);
            Map(x => x.OrderId).Column("order_id").Length(50);
            Map(x => x.ProvinceCode).Column("province_code").Length(50);
            Map(x => x.Remark).Column("remark").Length(50);
            Map(x => x.Phone).Column("phone").Length(50);
            Map(x => x.Shipaddress).Column("shipaddress").Length(50);
            Map(x => x.Area).Column("area").Length(50);

           //Id(x => x.Id).Not.Nullable().Length(36);//主键
           // Map(x => x.CreationTime).Nullable();
           // Map(x => x.ModificationTime).Nullable();
           // Map(x => x.DeletionTime).Nullable();
           // Map(x => x.IsDeleted).Not.Nullable();
        }
    }
}