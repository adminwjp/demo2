import re,random, time, logging,urllib.parse
from spliders.model import ThridApp,UseFlag
from spliders.common import ISplider,HelperSQLite
from utility.util.common import Base64Helper
from utility.util.http import HttpHelper

# 视频 模块

class _56ShiPin(ISplider): 
    def __init__(self) :
        self.name="五六视频"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port  
        url = "http://user.56.com/?do=checkMobile&account={}&callback=jsonp_callback50631_1&_=".format(thrid_app.phone)
        referer = "http://user.56.com/reg/"
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("false")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("true")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class AiPai(ISplider): 
    def __init__(self) :
        self.name="爱拍网"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "http://www.aipai.com/bus/urs/usercheck.php?callback=jsonp1470814900607&&callback=checkPhoneSuc&metadata=%7B%22email%22:%22{}%22%7D".format(thrid_app.phone)
        referer = "http://www.aipai.com/signup.php"
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        code = re.match("code\":(-?\\d*)",result).groups(1)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(code=="6002"):
            thrid_app.useflag = UseFlag.suc
        elif code=="0":
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app


class AiQiYi(ISplider): 
    def __init__(self) :
        self.name="爱奇艺"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "http://passport.iqiyi.com/apis/user/check_account.action?t="
        referer = "http://www.iqiyi.com/"
        hhttp_entity.content_type = "application/x-www-form-urlencoded"
        http_entity.user_agent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.80 Safari/537.36"
        http_entity.headers["Accept-Language"]= "zh-CN,zh;q=0.8"
        http_entity.headers["Accept-Encoding"]= "gzip, deflate"
        param = "account={}&agenttype=1".format( thrid_app.phone)
        result=http_helper.post(url,param,referer=referer,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif result.find("true")>-1:
            thrid_app.useflag = UseFlag.suc
        elif result.find("false")>-1:
            thrid_app.useflag = UseFlag.fail 
        elif (result.find("网络繁忙，请稍后再试")>-1):
            thrid_app.useflag = BoundingState.unknow;
            logging.warn("爱奇艺 网络繁忙，请稍后再试");
            #uts=time.time()
            #if HelperSQLite.insert_close_ip(thrid_app.thridapp, thrid_app.ip, uts):
            #    logging.warn("爱奇艺代理IP：{}被封，入黑名单库。".format(thrid_app.ip))
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class Ku6(ISplider): 
    def __init__(self) :
        self.name="酷6网"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "http://passport.ku6.com/v3-ifreg.htm?loginNamePar={}".format(thrid_app.phone)
        referer = "http://passport.ku6.com/v3-getPasswordPhone.htm"
        http_entity.accept = "application/json, text/javascript, */*; q=0.01"
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        msgInfo = re.match("\"msgInfo\":\"(.*?)\"",result).groups(1)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif msgInfo=="ok":
            thrid_app.useflag = UseFlag.suc
        elif urllib.parse.unquote(html.unescape(msgInfo))  == "手机号已经注册":
            thrid_app.useflag = UseFlag.fail # unescape url decode
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class LeShi(ISplider): 
    def __init__(self) :
        self.name="乐视网"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "https://sso.le.com/user/checkMobileExists/mobile/{0}?jsonp=jQuery171003540707379579544_1468548915545".format(thrid_app.phone);
        referer = "https://sso.le.com/user/backpwd?ver=2.0&next_action=http%3A%2F%2Fwww.le.com%2F&email=";
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        message = re.match("\"message\":\"(.*?)\"",result).groups(1)
        # unescape url decode
        message =urllib.parse.unquote(html.unescape(message))
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif  message == "手机号已存在":
            thrid_app.useflag = UseFlag.suc
        elif message == "手机号不存在":
            thrid_app.useflag = UseFlag.fail 
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class PPTV(ISplider): 
    def __init__(self) :
        self.name="PPTV聚力"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        referer = "http://www.pptv.com/";
        url = "http://pub.aplus.pptv.com/wwwpub/weblogin/?tab=register&from=web_topnav&app="
        http_entity.accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        referer = url
        url = "http://passport.pptv.com/isPhoneExist.do?phone={0}&from=web&version=1.0.0&format=jsonp&cb=pplive_callback_0".format(thrid_app.phone)
        http_entity.accept = "*/*"
        result=http_helper.get(url,referer=referer,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif result.find("(1)")>-1:
            thrid_app.useflag = UseFlag.suc
        elif result.find("(0)")>-1:
            thrid_app.useflag = UseFlag.fail 
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class SouHuShiPin(ISplider): 
    def __init__(self) :
        self.name="搜狐视频"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "http://passport.sohu.com/apiv2/forget_password/is_available_userid"
        referer = "http://passport.sohu.com/forget_password/input_user"
        param = "userid={0}".format(thrid_app.phone)
        http_entity.accept = "application/json, text/javascript, */*; q=0.01"
        result=http_helper.post(url,param,referer=referer,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif result.find("该账号存在")>-1:
            thrid_app.useflag = UseFlag.suc
        elif result.find("账号不正确")>-1:
            thrid_app.useflag = UseFlag.fail 
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app


class TuDou(ISplider): 
    def __init__(self) :
        self.name="土豆网"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port   
        referer = "http://login.tudou.com/login.do?mini=ok&callback=miniLoginCallback&isReg=true"
        url = "http://login.tudou.com/passport/checkMobile.do?jsoncallback=jQuery172019516533566638827_1468563782280&mobile={0}".format(thrid_app.phone)
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        msg=re.match("\"code\":(\\d*),\"msg\":\"(.*?)\"",result).groups(2)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif msg=="已存在":
            thrid_app.useflag = UseFlag.suc
        elif msg=="可用":
            thrid_app.useflag = UseFlag.fail 
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class YouKu(ISplider): 
    def __init__(self) :
        self.name="优酷网"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port  
        referer = "http://www.youku.com/"
        url = "https://account.youku.com/registerView.htm?callback=&buid=youku&pid=8fb8456183734a86bfc1c15a1c761cdf&template=tempA&regModel=mobile&size=normal&jsonpCallback=jsonp_14685652612479077"
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
            return thrid_app
        formToken = re.match("\"formtoken\":\"(.*?)\"",result).groups(1)
        url = "https://account.youku.com/passport/isUserExist.json?buid=youku&pid=8fb8456183734a86bfc1c15a1c761cdf&passport={0}&formtoken={1}&template=tempA&bizType=register&region=CN&jsonpCallback=jsonp_14685646875082501".format(thrid_app.phone, formToken)
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        msg=re.match("\"code\":(\\d*),\"msg\":\"(.*?)\"",result).groups(2)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif result.find("\"exist\":true")>-1:
            thrid_app.useflag = UseFlag.suc
        elif result.find("\"exist\":false")>-1:
            thrid_app.useflag = UseFlag.fail 
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app