using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.NHibernate;
using Microsoft.Extensions.Logging;
using NHibernate.Linq;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Json;
using Utility.Sdk;

namespace Shop.NHibernate.Repositories
{
    [UnitOfWork]
    public class OrderNHRepository: BaseNHRepository<Order>, IRepository<Order, long>
    {
        ILogger<OrderNHRepository> logger;
        public  OrderNHRepository(ISessionProvider sessionProvider, ILogger<OrderNHRepository> logger) : base(sessionProvider)
        {
            this.logger = logger;
        }
        public async Task<int> AddOrder(List<OrderDetail> orderDetails)
        {
            logger.LogInformation("用户{UserId}  创建订单开始", orderDetails[0].UserId);
            Order order = new Order() { UserId = orderDetails[0].UserId };
            var ids = new List<long>();
            var detailIds = new List<long>();

            //验证订单信息是否有误
            //do nothing

            foreach (var item in orderDetails)
            {
               await  base.Session.SaveAsync(orderDetails);
                ids.Add(item.ProductId.Value);
                detailIds.Add(item.Id);
                item.Fee += item.NowPrice * item.Number;
                order.Fee += item.Fee;
                item.Total += item.Price * item.Number;
                order.Ptotal +=item.Price* item.Number;
                order.Quantity += item.Number;
            }
            logger.LogInformation("用户{UserId}  创建订单完成 数量 {Quantity} 订单费用 {Fee} 订单原价 {Ptotal}", 
                orderDetails[0].UserId, order.Quantity, order.Fee, order.Ptotal);
           await InsertAsync(order);
           
            OrderLog orderLog = new OrderLog();
            orderLog.UserId = orderDetails[0].UserId.Value;
            orderLog.Content = "创建订单";
            orderLog.Data = JsonHelper.ToJson(new { order,orderDetails});
            await Session.SaveAsync(orderLog);
            int res=await Session.CreateSQLQuery($"update {OrderDetail.Table} set order_id=? where id in(?)")
                .SetInt64(0,order.Id).SetString(1,string.Join(",",orderDetails.Select(it=>it))).ExecuteUpdateAsync();
            if (res != orderDetails.Count)
            {
                logger.LogInformation("用户{UserId}  创建订单失败 操作回滚", orderDetails[0].UserId);
                throw new Exception("创建订单失败");
            }
            logger.LogInformation("用户{UserId}  创建订单完成", orderDetails[0].UserId);
            return 1;
        }
        
        //更新信息(删除商品订单 添加)
        public async Task<int> UpdateOrder(List<OrderDetail> orderDetails,long orderId)
        {
            Order order =await GetAsync(orderId);
            if (order == null)
            {
                logger.LogInformation("用户 {UserId} 没有 订单 无法更新订单 {orderId}", orderDetails[0].UserId, orderId);
                return -1;
            }
            logger.LogInformation("用户 {UserId} 已存在订单 更新订单 {orderId} 开始", orderDetails[0].UserId, orderId);
            var ids = JsonHelper.ToObject<List<long>>(order.ProductIds);
            var detailIds = JsonHelper.ToObject<List<long>>(order.OrderDetailsIds);
            List<OrderDetail> orderDetails1 =  Session.Query<OrderDetail>().Where(it=>it.OrderId==orderId).ToList();
          
            order.Fee = 0;
            order.Ptotal = 0;
            order.Quantity= 0;

            //验证订单信息是否有误
            //do nothing

            foreach (var item in orderDetails)
            {
                //base.Session.Save(item);
                ids.Add(item.ProductId.Value);
                detailIds.Add(item.Id);
                item.Fee += item.NowPrice * item.Number;
                order.Fee += item.Fee;
                item.Total += item.Price * item.Number;
                order.Ptotal += item.Price * item.Number;
                order.Quantity += item.Number;
                var old = orderDetails1.Find(it => it.Id == item.Id);
                if (old != null)
                {
                    old.Number = item.Number;
                    old.Fee = item.Fee;
                    old.Total = item.Total;
                    await Session.UpdateAsync(item);
                    logger.LogInformation("用户 {UserId} 已存在订单 更新订单 {orderId} (更新旧的订单详情)", orderDetails[0].UserId, orderId);
                }
                else
                {
                    await Session.SaveAsync(item);
                    logger.LogInformation("用户 {UserId} 已存在订单 更新订单 {orderId} (添加新的订单详情)", orderDetails[0].UserId, orderId);
                }
            }
            var removes = new List<long>(orderDetails1.Count);
            //linq 去重 detailIds 忘了
            foreach (var item in orderDetails1)
            {
                if (!detailIds.Exists(it => item.Id == it))
                {
                    removes.Add(item.Id);
                }
            }
            if (removes.Count > 0)
            {
                int res =await Session.CreateSQLQuery($"delete from {OrderDetail.Table} where id in(?)")
               .SetString(0, string.Join(",", removes.Select(it => it))).ExecuteUpdateAsync();
                if (res != removes.Count)
                {
                    logger.LogInformation("用户{UserId}  更新订单失败 {orderId} 操作回滚",
                        orderDetails[0].UserId, orderId);
                    throw new Exception("更新订单失败");
                }
                logger.LogInformation("用户 {UserId} 已存在订单 更新订单 {orderId} (删除旧的订单详情)", orderDetails[0].UserId, orderId);
            }
            OrderLog orderLog = new OrderLog();
            orderLog.UserId = orderDetails[0].UserId.Value;
            orderLog.Content = "更新订单";
            orderLog.Data = JsonHelper.ToJson(new { order, orderDetails });
            await Session.SaveAsync(orderLog);
            logger.LogInformation("用户 {UserId} 已存在订单 更新订单 {orderId} 完成", orderDetails[0].UserId, orderId);

            return 1;
        }
        /// <summary>
        /// 当商品价格信息(库存) 改变时 则更新用户订单价格下限
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<int> UpdateOrderByPriceOrStockChange(List<OrderDetail> orderDetails, long orderId)
        {
            Order order =await GetAsync(orderId);
            if (order == null)
            {
                logger.LogInformation("用户 {UserId} 没有 订单 无法更新订单 (当商品价格信息(库存) 改变时) {orderId} ", orderDetails[0].UserId, orderId);
                return -1;
            }
            logger.LogInformation("用户 {UserId} 已存在订单 更新订单 (当商品价格信息(库存) 改变时) {orderId} 开始 ", orderDetails[0].UserId, orderId);
            var detailIds = JsonHelper.ToObject<List<long>>(order.OrderDetailsIds);
            //验证订单信息是否有误
            //do nothing

            order.Fee = 0;
            order.Ptotal = 0;
            order.Quantity = 0;
            foreach (var item in orderDetails)
            {
                var old = detailIds.Exists(it => it == item.Id);
                if (old)
                {
                    item.Fee += item.NowPrice * item.Number;
                    order.Fee += item.Fee;
                    item.Total += item.Price * item.Number;
                    order.Ptotal += item.Price * item.Number;
                    order.Quantity += item.Number;
                    await Session.UpdateAsync(item);
                    logger.LogInformation("用户 {UserId} 已存在订单 更新订单 (当商品价格信息(库存) 改变时) {orderId} (更新旧的订单详情)", orderDetails[0].UserId, orderId);
                }
                else
                {
                    logger.LogWarning("用户 {UserId} 已存在订单 更新订单 (当商品价格信息(库存) 改变时) {orderId} (添加新的订单详情 (未添加))", orderDetails[0].UserId, orderId);
                }
            }
            
          
            OrderLog orderLog = new OrderLog();
            orderLog.UserId = orderDetails[0].UserId.Value;
            orderLog.Content = "更新订单(当商品价格信息(库存) 改变时)";
            orderLog.Data = JsonHelper.ToJson(new { order, orderDetails });
            await Session.SaveAsync(orderLog);
            logger.LogInformation("用户 {UserId} 已存在订单 更新订单(当商品价格信息(库存) 改变时) {orderId} 完成", orderDetails[0].UserId, orderId);

            return 1;
        }

        public int UpdateOrderStatus(long orderId,int status)
        {
            return 1;
        }
        public async Task<int> PayOrder(long orderId,Order order,string payWay)
        {
            if (orderId < 1)
            {
                order =await GetAsync(orderId);
                if (order == null)
                {
                    logger.LogInformation("用户 {UserId} 没有 订单 无法支付该订单 {orderId} ", order.UserId, order.Id);
                    return -1;
                }
            }
            if (payWay == "wx")
            {
                var res=WxPaySdk.PayByOdrder(new WxPayOrderModel() { });
                if (!res)
                {
                    logger.LogInformation("用户 {UserId}   无法支付该订单(微信支付) {orderId} ", order.UserId, order.Id);
                    return -1;
                }
            }
            OrderPay orderPay = new OrderPay() {
                OrderId = order.Id,
                UserId=order.UserId,
                ConfirmDate = DateTime.Now,
                PayAmount = order.Fee,
                ConfirmUser = order.UserId.Value,
                PayStatus= PayOrderStatus.None,
                PayMethod=payWay,
                Remark="支付订单"
            };
            //生成 交易 号
            //do nothing

            //orderPay.TradeNo = "";


            await Session.SaveAsync(orderPay);
            return 1;
        }
        public async Task<int> UpdatePayOrderTradeNo(long orderPayId, string payWay)
        {
            OrderPay orderPay = await Session.GetAsync<OrderPay>(orderPayId);
            if (orderPay == null)
            {
                logger.LogInformation("用户    获取该支付订单 {orderPayId} 失败 ", orderPayId);
                return -1;
            }
            logger.LogInformation("用户 {UserId}   获取该支付订单 {orderPayId} 成功 ", orderPay.UserId, orderPayId);
            if(orderPay.PayStatus== PayOrderStatus.Success)
            {
                return 1;
            }
            if (payWay == "wx")
            {
                //参数 获取 do nothing
                var res = WxPaySdk.GetPayOrder(new GetPayOrderModel() { });
                if (!res)
                {
                    logger.LogInformation("用户 {UserId}   获取该支付订单(微信支付)状态 {orderPayId} 交易失败 ", orderPay.UserId, orderPayId);
                    if(orderPay.PayStatus!= PayOrderStatus.None)
                    {
                        int r1 = Session.Query<OrderPay>().Where(it => it.Id == orderPayId).Update(it => new OrderPay() { PayStatus = PayOrderStatus.Waiting });
                        logger.LogInformation("用户 {UserId}   获取该支付订单(微信支付)状态 {orderPayId}  更新状态信息 {msg} ", orderPay.UserId, orderPayId, r1 > 1 ? "成功" : "失败");
                    }
                    return -1;
                }
                logger.LogInformation("用户 {UserId}   获取该支付订单(微信支付)状态 {orderPayId} 交易成功 ", orderPay.UserId, orderPayId);
                int r= Session.Query<OrderPay>().Where(it => it.Id == orderPayId).Update(it =>new OrderPay() { PayStatus=PayOrderStatus.Success});
                logger.LogInformation("用户 {UserId}   获取该支付订单(微信支付)状态 {orderPayId} 交易成功 更新信息 {msg} ", orderPay.UserId, orderPayId, r>1? "成功": "失败");
                return r;
            }
            return -1;
        }


        public int SellerOrder(long orderId)
        {
            return 1;
        }
    }
}
