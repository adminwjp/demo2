namespace Shop.Domain.Entities
{
    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
	using Abp.Domain.Values;
	using Abp.Events.Bus;

    public class Order:IEntity<long>
    {
		public virtual long Id { get; set; }
		public virtual long? CartId{get;set;}
		public virtual string ProductIds { get; set; }
		public virtual string OrderDetailsIds { get; set; }

		public virtual int Status { get; set; }
		public virtual int Score { get; set; }
		/// <summary>
		/// 订单原价
		/// </summary>
		public virtual decimal? Ptotal { get; set; }
		public virtual decimal UpdateAmount { get; set; }
		/// <summary>
		/// 快递公司名称
		/// </summary>
		public virtual string ExpressCompanyName { get; set; }
		public virtual int PayType { get; set; }
		/// <summary>
		/// 回扣
		/// </summary>
		public virtual decimal? Rebate { get; set; }
		/// <summary>
		/// 携带
		/// </summary>
		public virtual int Carry { get; set; }
		/// <summary>
		/// 最低库存
		/// </summary>
		public virtual string LowStocks { get; set; }
		/// <summary>
		/// 退货理由
		/// </summary>
		public virtual string RefundStatus { get; set; }
		/// <summary>
		/// 订单费用
		/// </summary>
		public virtual decimal? Fee { get; set; }
		/// <summary>
		/// 其他要求
		/// </summary>
		public virtual string OtherRequirement { get; set; }
		/// <summary>
		/// 支付状态
		/// </summary>
		public virtual int Paystatus { get; set; }
		public virtual string Remark { get; set; }
		public virtual bool ClosedComment { get; set; }
		public virtual string ExpressNo { get; set; }
		public virtual string ExpressName { get; set; }
		public virtual int Quantity { get; set; }
		public virtual string ConfirmSendProductRemark { get; set; }
		public virtual string ExpressCode { get; set; }
	
		public virtual string Account { get; set; }
		public virtual long? UserId{get;set;}
		
		public virtual decimal? Amount { get; set; }
		public virtual bool IsTransient(){
            return true;
        }
    }

	public class SellerOrder: Order
	{

    }
    public class OrderDetail : IEntity<long>
	{
		public const string Table = "t_order_detail";
		public virtual long Id { get; set; }
		public virtual long? ProductId { get; set; }
		public virtual decimal? Fee { get; set; }
		public virtual bool IsComment { get; set; }

		//卖家
		public virtual long? SellerId { get; set; }
		public virtual long? UserId { get; set; }
		public virtual string ProductName { get; set; }
		public virtual string GiftId { get; set; }
		public virtual long OrderId { get; set; }
		public virtual int Orders { get; set; }
		public virtual string SpecInfo { get; set; }

		public virtual int Score { get; set; }
		public virtual int Number { get; set; }
		public virtual string LowStocks { get; set; }

		public virtual decimal? Price { get; set; }
		public virtual decimal? NowPrice { get; set; }
		public virtual decimal? Total { get; set; }
		 public virtual bool IsTransient(){
            return true;
        }
		 

	}
	public enum OrderStatus
    {
		None,
		Success,
		Fail,
		Waiting
	}
    public class OrderPay : IEntity<long>
	{
		public virtual long Id { get; set; }
		public virtual long OrderId { get; set; }
		public virtual DateTime ConfirmDate { get; set; }
		public virtual string TradeNo { get; set; }
		public virtual string Remark { get; set; }
		public virtual string PayMethod { get; set; }
		public virtual decimal? PayAmount { get; set; }
		public virtual long ConfirmUser { get; set; }
		public virtual long SellerId { get; set; }
		public virtual long? UserId { get; set; }
		public virtual PayOrderStatus PayStatus { get; set; }
		 public virtual bool IsTransient(){
            return true;
        }

	}
	public enum PayOrderStatus
    {
		None,
		Success,
		Fail,
		Waiting
    }


	public class OrderLog : IEntity<long>
	{
		public virtual long Id { get; set; }
		public virtual string OrderId { get; set; }
		public virtual string Content { get; set; }
		public virtual string Data { get; set; }
		public virtual string AccountType { get; set; }
		public virtual string Account { get; set; }
		public virtual long UserId { get; set; }
		public virtual bool IsTransient()
		{
			return true;
		}
	}

    public class OrderShip : IEntity<long>
	{
		public virtual long Id { get; set; }
		public virtual string Tel { get; set; }
		public virtual string CityCode { get; set; }
		public virtual string City { get; set; }
		public virtual string Province { get; set; }
		public virtual string Sex { get; set; }
		public virtual string AreaCode { get; set; }
		public virtual string Zip { get; set; }
		public virtual string Shipname { get; set; }
		public virtual string OrderId { get; set; }
		public virtual string ProvinceCode { get; set; }
		public virtual string Remark { get; set; }
		public virtual string Phone { get; set; }
		public virtual string Shipaddress { get; set; }
		public virtual string Area { get; set; }
		public virtual bool IsTransient(){
            return true;
        }
	}
}