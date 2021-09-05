using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Sdk
{
    public interface IPaySdk
    {
    }
    public class PaySdkProvider
    {
        /// <summary>
        /// 支付 
        /// </summary>
        /// <returns></returns>
        public virtual bool Pay()
        {
            return true;
        }
        /// <summary>
        /// 获取 支付交易结果
        /// </summary>
        /// <returns></returns>
        public virtual bool GetPayResult()
        {
            return true;
        }
    }
    //企业资质
    public class AlipaySdk: PaySdkProvider,IPaySdk
    {
     

    }
    public class WechatSdk : PaySdkProvider, IPaySdk
    {


    }
    //个人 资质
    public class YzfPaySdk : PaySdkProvider, IPaySdk
    {
    }
    public class _020zfPaySdk : PaySdkProvider, IPaySdk
    {
    }
    public class YungouosPaySdk : PaySdkProvider, IPaySdk
    {
    }
}
