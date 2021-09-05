using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Json;
using Utility.Net.Http;

namespace Utility.Sdk
{
    /// <summary>
    /// <![CDATA[https://pay.weixin.qq.com/wiki/doc/api/app/app_sl.php?chapter=9_1&index=1]]>
    /// </summary>
    public class WxPayOrderModel: BaseWxPayResult
    {
    
        /// <summary>商品描述 </summary>
        [StringLength(128)]
        public virtual string body { get; set; }
        /// <summary>商品详情 否</summary>
        [StringLength(9192)]
        public virtual string detail { get; set; }
        /// <summary>附加数据 否</summary>
        [StringLength(127)]
        public virtual string attach { get; set; }
        /// <summary>商户订单号 </summary>
        [StringLength(32)]
        public virtual string  out_trade_no{ get; set; }
        /// <summary>总金额 </summary>
        public virtual int total_fee { get; set; }
        /// <summary>终端IP </summary>
        [StringLength(64)]
        public virtual string spbill_create_ip { get; set; }
        /// <summary>交易起始时间 否 </summary>
        [StringLength(14)]
        public virtual string time_start { get; set; }
        /// <summary>交易结束时间 否</summary>
        [StringLength(14)]
        public virtual string time_expire { get; set; }
        /// <summary>订单优惠标记 否</summary>
        [StringLength(32)]
        public virtual string goods_tag { get; set; }
        /// <summary>交易类型 </summary>
        [StringLength(256)]
        public virtual string notify_url { get; set; }
        /// <summary>交易类型 </summary>
        [StringLength(16)]
        public virtual string trade_type { get; set; }
        /// <summary>指定支付方式 否</summary>
        [StringLength(32)]
        public virtual string limit_pay { get; set; }
        /// <summary>开发票入口开放标识 否</summary>
        [StringLength(8)]
        public virtual string receipt { get; set; }
        /// <summary>是否需要分账 否 </summary>
        [StringLength(16)]
        public virtual string profit_sharing { get; set; }
        /// <summary>场景信息 否 </summary>
        [StringLength(32)]
        public virtual string scene_info { get; set; }
    }
    //=== success
    public abstract class BaseWxPayResult
    {
        /// <summary>服务商的APPID </summary>
        [StringLength(32)]
        public virtual string appid { get; set; }
        /// <summary>商户号 </summary>
        [StringLength(32)]
        public virtual string mch_id { get; set; }
        /// <summary>子商户应用ID 否</summary>
        [StringLength(32)]
        public virtual string sub_appid { get; set; }
        /// <summary>子商户号  </summary>
        [StringLength(32)]
        public virtual string sub_mch_id { get; set; }

        /// <summary>设备号 否</summary>
        [StringLength(32)]
        public virtual string device_info { get; set; }
        /// <summary>随机字符串 </summary>
        [StringLength(32)]
        public virtual string nonce_str { get; set; }
        /// <summary>签名 </summary>
        [StringLength(32)]
        public virtual string sign { get; set; }
    }
    /// <summary>
    /// <![CDATA[https://pay.weixin.qq.com/wiki/doc/api/app/app_sl.php?chapter=9_12&index=2]]>
    /// </summary>
    public class WxPayModel
    {
        /// <summary>服务商的APPID </summary>
        [StringLength(32)]
        public virtual string appid { get; set; }
         /// <summary>子商户号  </summary>
        [StringLength(32)]
        public virtual string partnerid { get; set; }
        /// <summary>预支付交易会话标识 </summary>
        [StringLength(64)]
        public virtual string prepay_id { get; set; }
        /// <summary>扩展字段 </summary>
        [StringLength(128)]
        public virtual string package { get; set; }

        /// <summary>随机字符串 </summary>
        [StringLength(32)]
        public virtual string nonce_str { get; set; }
        /// <summary>时间戳 </summary>
        [StringLength(10)]
        public virtual string timestamp { get; set; }
        /// <summary>签名 </summary>
        [StringLength(64)]
        public virtual string sign { get; set; }
    }
    public class GetPayOrderModel
    {
        /// <summary>服务商的APPID </summary>
        [StringLength(32)]
        public virtual string appid { get; set; }
        /// <summary>商户号 </summary>
        [StringLength(32)]
        public virtual string mch_id { get; set; }
        /// <summary>子商户应用ID 否</summary>
        [StringLength(32)]
        public virtual string sub_appid { get; set; }
        /// <summary>子商户号  </summary>
        [StringLength(32)]
        public virtual string sub_mch_id { get; set; }

        /// <summary>微信订单号 二选一</summary>
        [StringLength(32)]
        public virtual string transaction_id { get; set; }
        /// <summary>商户订单号 二选一</summary>
        [StringLength(32)]
        public virtual string out_trade_no { get; set; }

        /// <summary>随机字符串 </summary>
        [StringLength(32)]
        public virtual string nonce_str { get; set; }
        /// <summary>签名 </summary>
        [StringLength(32)]
        public virtual string sign { get; set; }
    }
    public class WxPayResult : BaseWxPayResult
    {   
        /// <summary>业务结果 SUCCESS/FAIL </summary>
        [StringLength(16)]
        public virtual string return_code { get; set; }

        /// <summary>业务结果 SUCCESS/FAIL </summary>
        [StringLength(16)]
        public virtual string result_code { get; set; }
        /// <summary>错误代码 </summary>
        [StringLength(32)]
        public virtual string err_code { get; set; }

        //=== success
        /// <summary>错误代码描述 </summary>
        [StringLength(128)]
        public virtual string err_code_des { get; set; }

        /// <summary>交易类型 </summary>
        [StringLength(16)]
        public virtual string trade_type { get; set; }
        /// <summary>预支付交易会话标识 </summary>
        [StringLength(64)]
        public virtual string prepay_id { get; set; }


    }
    /// <summary>
    /// <![CDATA[https://pay.weixin.qq.com/wiki/doc/api/app/app_sl.php?chapter=9_2&index=4]]>
    /// </summary>
    public class GetPayOrderResult: GetPayOrderModel
    {  
        /// <summary>业务结果 SUCCESS/FAIL </summary>
        [StringLength(16)]
        public virtual string return_code { get; set; }

        /// <summary>业务结果 SUCCESS/FAIL </summary>
        [StringLength(16)]
        public virtual string result_code { get; set; }
        /// <summary>错误代码 </summary>
        [StringLength(32)]
        public virtual string err_code { get; set; }

        //=== success
        /// <summary>错误代码描述 </summary>
        [StringLength(128)]
        public virtual string err_code_des { get; set; }


        /// <summary>交易状态 SUCCESS/FAIL </summary>
        [StringLength(32)]
        public virtual string trade_state { get; set; }

    }
    public static class WxPaySdk
    {
        public static bool PayByOdrder(WxPayOrderModel wxPayOrder)
        {
            var url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            var result = HttpHelper.PostJson(url, JsonHelper.ToJson(wxPayOrder));
            WxPayResult payResult = JsonHelper.ToObject<WxPayResult>(result);
            
            return ("SUCCESS").Equals(payResult.return_code);
        }
        /// <summary>
        /// 在APP端调起支付的参数列表，注意：该支付参数的签名是服务商在后台生成的，用的是服务商的API密钥
        /// 无法使用
        /// </summary>
        /// <param name="wxPay"></param>
        /// <returns></returns>
        public static bool Pay(WxPayModel wxPay)
        {
            throw new NotSupportedException();
        }
        public static bool NotityPayResult(WxPayModel wxPay)
        {
            //var url = "https://pay.weixin.qq.com/wxpay/pay.action";
            throw new NotSupportedException();
        }
        /// <summary>
        /// 交易成功
        /// </summary>
        /// <param name="getPayOrder"></param>
        /// <returns></returns>
        public static bool GetPayOrder(GetPayOrderModel getPayOrder)
        {
            var url = "https://api.mch.weixin.qq.com/pay/orderquery";
            var result = HttpHelper.PostJson(url, JsonHelper.ToJson(getPayOrder));
            GetPayOrderResult getPayOrderResult = JsonHelper.ToObject<GetPayOrderResult>(result);
            //交易成功判断条件： return_code、result_code和trade_state都为SUCCESS
            return ("SUCCESS").Equals(getPayOrderResult.result_code)
               || ("SUCCESS").Equals(getPayOrderResult.return_code)
               || ("SUCCESS").Equals(getPayOrderResult.trade_state);
        }
        public static bool ClosePayOrder(GetPayOrderModel getPayOrder)
        {
            getPayOrder.transaction_id = "";
             var url = "https://api.mch.weixin.qq.com/pay/closeorder";
            var result = HttpHelper.PostJson(url, JsonHelper.ToJson(getPayOrder));
            WxPayResult wxPayResult = JsonHelper.ToObject<WxPayResult>(result);
            return ("SUCCESS")
                .Equals(wxPayResult.return_code);
        }
    }
}
