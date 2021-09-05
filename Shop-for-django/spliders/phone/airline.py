import re,random, time, logging,urllib.parse
from spliders.model import ThridApp,UseFlag
from spliders.common import ISplider,HelperSQLite
from utility.util.common import Base64Helper
from utility.util.http import HttpHelper



# 航空 模块

class CYB(ISplider) :
    def __init__(self):
        self.name="创业邦"
   
    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url="https://api1.cyzone.cn/v1/member/login/submit"
        param="account={}&channel=1&remme=1&password=123456".format(thrid_app.phone)
        # {"code":130101,"msg":"帐号或密码错误","info":"帐号或密码错误"}
        #注册 找回密码 都需要 验证码 (手机或邮箱)
        result=http_helper.post(url,param,"",http_entity)
        if(result.find("y")>-1) :
            thrid_app.useflag = UseFlag.suc
        elif result.find("n")>-1 :
            thrid_app.useflag = UseFlag.fail 
        elif result==("timeout") :
            thrid_app.useflag = UseFlag.times  
        else :
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app


class ShenZhen(ISplider):
    def __init__(self):
        self.name="深圳航空"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url="http://sf.shenzhenair.com/szffp-web/identify/goStepTwoSF"
        param="{0}'memberAccount':'{1}','accountType':'MOBILE'{2}".format("{",self.account,"}")
        # {"memberNumber":null,"userName":null,"firstName":null,"lastName":null,"cnFirstName":null,"
        # cnLastName":null,"niNo":null,"mobile":null,"operType":null,"identifyFlag":null,"errorCode":"0080050001",
        # "errorDesc":"查询条件无法查询到账户信息","sfMobile":null,"wxToken":null,"crmmemberId":null}
        #注册 找回密码 都需要 验证码 (手机或邮箱)
        result=http_helper.post_json(url,param,"",http_entity)
        if result.find("该账户已经存在，请重新输入")>-1 :
            thrid_app.useflag = UseFlag.suc 
        elif result.find("查询条件无法查询到账户信息")>-1 :
            thrid_app.useflag = UseFlag.fail 
        elif result=="timeout" :
            thrid_app.useflag = UseFlag.times      
        else :
            thrid_app.useflag = UseFlag.unknow
        return  thrid_app  


class HuaXia(ISplider) :
    def __init__(self):
        self.name="华夏航空"

    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url="https://www.chinaexpressair.com/yss/loginSubmit"
        param="username={}&password=123456".format(self.account)
        # <span class="iconfont form-error space10" style="display:none;">账号未注册，请先注册！</span>
        #登录 需要 滑块验证码 
        #注册 找回密码 都需要 验证码 (手机)
        result=http_helper.post(url,param,"",http_entity)
        msg=re.match("<span\\s*class=\"iconfont\\s*form-error\\s*space10\"\\s*style=\"display:none;\">(.*?)</span>",result).groups(1)
        if(msg.find("账户已注册")>-1) :
            thrid_app.useflag = UseFlag.suc  
        elif msg.find("账号未注册，请先注册！")>-1 :
            thrid_app.useflag = UseFlag.fail
        elif result==("timeout") :
            thrid_app.useflag = UseFlag.times      
        else :
            thrid_app.useflag = UseFlag.unknow
        return  thrid_app


class HaiNan(ISplider) :
    def __init__(self):
        self.name="海南航空"

    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        # 登录 注册 返回大量 json 需要比较
        url="https://new.hnair.com/hainanair/ibe/profile/processLoginJSON.do?ConversationID="
        param="captcha%2FverificationType=dingxiang&captcha%2FverificationCode={}%3A604f65c9MnrezdYsrOLDaxsnzASP6W7ybmFVziW1&credentials%2FloginUsername={}&credentials%2FloginPassword=123456&loginMethodType=loginByPwd".format("",self.account)
        result=http_helper.post(url,param,"",http_entity)
        #登录提示 找不到与手机 1314711xxxx 一致的有效会员,请用其他方式(卡号、身份证、护照、电子邮箱)验证
        #登录 需要 滑块验证码 
        #注册 找回密码 都需要 验证码 (手机)
        #注册 get
        url="https://new.hnair.com/hainanair/ibe/profile/checkRegisterProfileDataJSON.do?ConversationID=&check%2FmobilePhone={}".format(self.account)
        # post
        url="https://new.hnair.com/hainanair/ibe/profile/checkUserBindFfp.do?"
        param="accountInput={}&infoType=realname&infoValue=123&checkcodes=W%7CT%7CE%7C&timestamp={}".format(self.accaccount,time.time())
        result=http_helper.post(url,param,"",http_entity)
        #{"errorCode":"L1001"} 验证失败！请输入正确的信息
        if result.find("")>-1 :
            thrid_app.useflag = UseFlag.suc  
        elif result.find("")>-1 :
            thrid_app.useflag = UseFlag.fail
        elif result=="timeout" :
            thrid_app.useflag = UseFlag.times      
        else :
            thrid_app.useflag = UseFlag.unknow
        return  thrid_app
