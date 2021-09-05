using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Net.Http;

namespace Utility.Sdk
{
    /// <summary>
    /// Install-Package AlipaySDKNet.Standard -Version 4.6.0
    /// Install-Package AlipayEasySDK -Version 2.1.3
    /// <![CDATA[https://opendocs.alipay.com/open/54/00y8k9]]>
    /// <![CDATA[https://opendocs.alipay.com/isv/10467/xldcyq]]>
    /// <![CDATA[https://opendocs.alipay.com/open/54/103419]]>
    /// 支付能力
    /// <![CDATA[https://opendocs.alipay.com/open/00a0ut]]>
    /// 只有 demo(2016 net 需要自己打包 支持 netstandard) 接口 文档好难找 
    /// 接口文档 需要参考 demo 不知道 怎么 封装使用的 不然不知道 怎么访问的 
    /// 复制 demo 生成 netstandard 封装 跑来跑去 直接使用对方dll 调用接口 要么引用第三方库 
    /// <![CDATA[https://opendocs.alipay.com/open/028ln0?scene=common]]>
    /// </summary>
    public static class ZfbPaySdk
    {
        public static Stream GetSellerCodeStream(string app_id,string redirect_uri)
        {
            var url = "https://openauth.alipay.com/oauth2/appToAppBatchAuth.htm?app_id=服务商appid&application_type=TINYAPP,WEBAPP&redirect_uri=UrlEncode(redirect_uri)";
            return HttpHelper.GetStream(url);
        }
    }
}
