import re,random, time, logging,urllib.parse
from spliders.model import ThridApp, UseFlag
from spliders.common import ISplider, Base64Helper, HttpHelper, HelperSQLite



# 旅游 模块

class LvMaMa(ISplider):
    def __init__(self):
        self.name="驴妈妈"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url="http://login.lvmama.com/nsso/ajax/checkUniqueField.do"
        param="mobile={0}".format(thrid_app.phone)
        http_entity.accept = "application/json, text/javascript, */*; q=0.01"
        result=http_helper.post(url,param,"http://login.lvmama.com/nsso/register/registering.do",http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("false")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("true")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app


class QCross(ISplider):
    def __init__(self):
        self.name="穷游"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port   
        url="http://login.qyer.com/qcross/login/auth.php?action=logincheck&input=86-{0}&type=phone&timer={1}".format(thrid_app.phone,random.random())
        result=http_helper.get(url,"","http://login.qyer.com/?action=getmobilepass",http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("ok")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("400005")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class QuNa(ISplider):
    def __init__(self):
        self.name="去哪儿"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port   
        url="https://user.qunar.com/passport/register.jsp?ret=http%3A%2F%2Fwww.qunar.com%2F"
        result=http_helper.get(url,"","",http_entity=http_entity)
        url = "https://user.qunar.com/ajax/validator.jsp"
        param="method={0}&prenum=86&vcode=null".format(thrid_app.phone)
        result=http_helper.post(url,param,url,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("用户已存在")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("用户不存在")>-1:
            thrid_app.useflag = UseFlag.fail  
        elif (result.find("安全系统检测到异常访问")>-1):
            uts=time.time()
            if HelperSQLite.insert_close_ip(thrid_app.thridapp, thrid_app.ip, uts):
                logging.warn("去哪代理IP：{}被封，入黑名单库。".format(thrid_app.ip))
            socmode.useflag = BoundingState.unknow;
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app


class TuNiu(ISplider):
    def __init__(self):
        self.name="途牛"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port  
        url="https://passport.tuniu.com/register/isPhoneAvailable"
        param="intlCode=0086&tel={0}".format(thrid_app.phone)
        result=http_helper.post(url,param,"",http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("-1")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("0")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class Uber(ISplider):
    def __init__(self):
        self.name="优步"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url="https://login.uber.com.cn/forgot-password"
        result=http_helper.get(url,param,"",http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
            return thrid_app
        token = re.match("<input type=\"hidden\" name=\"_csrf_token\" value=\"(.*?)\">",result).groups(1)
        param="_csrf_token={0}&email=%2B86{1}".format(urllib.parse.quote(token),thrid_app.phone)
        result=http_helper.post(url,param,url,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("账户已与邮箱绑定, 请用邮箱重置")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("无法重置密码。请尝试用电子邮件重置密码")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class XinXinLvYou(ISplider):
    def __init__(self):
        self.name="欣欣旅游"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url="http://www.cncn.com/reg_cncn.php?inajax=1&action=checkmobile&mobile={0}".format(thrid_app.phone)
        result=http_helper.get(url,"","http://www.cncn.com/reg_cncn.php",http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("此手机号已被注册")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("succeed")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app


class YiLong(ISplider):
    def __init__(self):
        self.name="艺龙"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port  
        url= "https://secure.elong.com/passport/isajax/Register/ValidateMobileOrEmail?_={1}&mobile={0}&language=cn&viewpath=~%2Fviews%2Fmyelong%2Fpassport%2FRegister.aspx".format(thrid_app.phone,random.random())
        http_entity.headers["X-Requested-With"]= "XMLHttpRequest"
        result=http_helper.get(url,"","https://secure.elong.com/passport/register_cn.html?rnd=20160729101638",http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("1")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("0")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class ZhongXinLvYou(ISplider):
    def __init__(self):
        self.name="众信旅游"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port   
        url= "https://u.uzai.com/reg/Validation?callback=jQuery111003271422423094825_1469066668090&clientid=txtPhoneMail&txtPhoneMail={0}&_={1}".format(thrid_app.phone,random.random())
        result=http_helper.get(url,"","https://u.uzai.com/register",http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("手机已注册")>-1 or result.find("会员名已注册")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("手机未注册")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app