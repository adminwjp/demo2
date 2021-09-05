import re,random, time, logging,urllib.parse
from spliders.model import ThridApp,UseFlag
from spliders.common import ISplider,HelperSQLite
from utility.util.common import Base64Helper
from utility.util.http import HttpHelper

# 电商  模块

class DaMai(ISplider) :
    def __init__(self):
        self.name="大麦网"
   
    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port         
        url = "https://secure.damai.cn/VerifyShow.aspx"
        referer = "https://secure.damai.cn/reg.aspx?ru=http://www.damai.cn/"
        param = "_action=MobileIsBindSafty&mobile={0}&nationCode=86".format(thrid_app.phone)
        headers["Accept"] = "*/*";
        result=http_helper.post(url,param,referer,headers=headers)
        if(result=="1") :
            thrid_app.useflag = UseFlag.suc
        elif result=="200" :
            thrid_app.useflag = UseFlag.fail 
        elif result==("timeout") :
            thrid_app.useflag = UseFlag.times  
        else :
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app

class DangDangWang(ISplider) :
    def __init__(self):
        self.name="当当网"
   
    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port        
        headers["X-Requested-With"]= "XMLHttpRequest"
        url = "https://login.dangdang.com/p/emailandmobile_check.php";
        param = "usermobile={}".format(thrid_app.phone)
        result=http_helper.post(url,param,"",headers=headers)
        if result.find("2")>-1:
            thrid_app.useflag = UseFlag.suc
        elif result.find("3")>-1:
            thrid_app.useflag = UseFlag.fail
        elif result==("timeout") :
            thrid_app.useflag = UseFlag.times  
        else :
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app

class FanKeChengPin(ISplider) :
    def __init__(self):
        self.name="凡客诚品"
   
    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port         
        url = "https://login.vancl.com/login/XmlCheckUserName.ashx"
        referer = "https://login.vancl.com/login/Login.aspx?http://www.vancl.com/?http%3A%2F%2Fwww.vancl.com%2F"
        param = "Loginasync=true&LoginUserName={0}&UserPassword=123456&Validate=&type=web".format(thrid_app.phone)
        headers["Accept"] = "*/*"
        result=http_helper.post(url,param,referer,headers=headers)
        if result.find("账户和密码不匹配")>-1:
            thrid_app.useflag = UseFlag.suc
        elif result.find("账户不存在")>-1:
            thrid_app.useflag = UseFlag.fail
        elif result=="timeout" or result=="true" :
            thrid_app.useflag = UseFlag.times  
        else :
            # 为保证账户安全，请填写验证码,会存在这种情况
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app

class FeiNiu(ISplider) :
    def __init__(self):
        self.name="飞牛网"
   
    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port         
        url = "https://reg.feiniu.com/gateway/register"
        headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
        headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.80 Safari/537.36"
        #headers["Accept-Language"]="zh-CN,zh;q=0.8"
        #headers["Accept-Encoding"]= "gzip, deflate, sdch"
        #headers["Upgrade-Insecure-Requests"]= "1"
        #headers["Host"]= "reg.feiniu.com"
        result=http_helper.get(url,"","",headers=headers)
        CSRF_TOKEN=""
        for it in http_helper.cookie.keys():
            if it=="CSRF_TOKEN":
                CSRF_TOKEN=http_helper.cookie[it]
                break
        referer = url
        url = "https://reg.feiniu.com/check/chkUserName"
        param = "CSRF_TOKEN={0}&username={1}".format(CSRF_TOKEN,thrid_app.phone)
        result=http_helper.post(url,param,referer,headers=headers)
        if result.find("用户名已存在")>-1:
            thrid_app.useflag = UseFlag.suc
        elif result.find("用户名不存在")>-1:
            thrid_app.useflag = UseFlag.fail
        elif result=="timeout" :
            thrid_app.useflag = UseFlag.times  
        elif result.find("尝试次数过多")>-1:
            socmode.useflag = BoundingState.unknow;
            uts=time.time()
            if HelperSQLite.insert_close_ip(thrid_app.thridapp, thrid_app.ip, uts):
                logging.warn("飞牛网代理IP：{}被封，入黑名单库。".format(thrid_app.ip))
           
        else :
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app


class GuoMeiZaiXian(ISplider) :
    def __init__(self):
        self.name="国美在线"
   
    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port         
        url = "https://login.gome.com.cn/login?intcmp=sy-public01035&type=logout"
        result=http_helper.get(url,"","",http_entity=http_entity)
        url = "https://login.gome.com.cn/logoutUrl.no";
        result=http_helper.get(url,"","",http_entity=http_entity)
        url = "https://www.gomeart.com/sso/login/delcookie.action?refreshkey=0.36739160824418987&jsonpcallback=jQuery17105634764215043557_1468916245264&_=1468916245993";
        result=http_helper.get(url,"","",http_entity=http_entity)
        url = "https://g.gome.com.cn/ec/homeus/global/gome/gadgets/removeGomeCookie.jsp?refreshkey=0.9872887413235667&jsonpcallback=jQuery17105634764215043557_1468916245265&_=1468916245997";
        result=http_helper.get(url,"","",http_entity=http_entity)
        #url = "https://login.gome.com.cn/isShowAuthenticCode.no?sendtimestamp=1468921153627"
        #result=http_helper.get(url,http_entity=http_entity)
        #ssesionid = re.match("\"ssesionId\":\"(.*?)\"}",result).groups(1)
        referer = "https://login.gome.com.cn/login?intcmp=sy-public01035&type=logout";
        url = "https://login.gome.com.cn/toLogin.no";
        param = "loginName={0}&gomeOrCoo8=gome&password=gfddgfddgf&captcha=&autoLoginMode=&chkRememberUsername=1&loginType=0&captchaType=login&login=%E7%99%BB%E5%BD%95".format(thrid_app.phone)
        result=http_helper.post(url,param,referer,http_entity=http_entity)
        if result.find("用户名或密码不匹配，请重新输入")>-1:
            thrid_app.useflag = UseFlag.suc
        elif result.find("您输入的用户名不存在，请核对后再重新输入")>-1:
            thrid_app.useflag = UseFlag.fail
        elif result=="timeout" :
            thrid_app.useflag = UseFlag.times  
        else :
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app
        """
        url = "https://reg.gome.com.cn/register/index/person";
        headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
        result=http_helper.get(url,"","",http_entity=http_entity)
        referer = url;
        url = "https://imgcode.gome.com.cn/captcha?type=register"
        result=http_helper.get(url,"","",http_entity=http_entity)
        url = "https://sm.gome.com.cn/collect/track_proxy?tid=dc-1&cid=146891845986797506&dr=https%3A%2F%2Flogin.gome.com.cn%2Flogin%3Fintcmp%3Dsy-public01035%26type%3Dlogout&sr=1920*1080&vp=1903*415&de=utf-8&sd=24-bit&ul=zh-cn&je=1&fl=21.0%20r0&t=pageview&ni=0&dl=https%3A%2F%2Freg.gome.com.cn%2Fregister%2Findex%2Fperson&dt=%E6%B3%A8%E5%86%8C&ub=0-0-0-0-0-0-0-0&cd1=direct&cd2=other&cd3=https%3A%2F%2Flogin.gome.com.cn%2Flogin%3Fintcmp%3Dsy-public01035%26type%3Dlogout&z=873856012"
        result=http_helper.get(url,"","",http_entity=http_entity)
        url = "https://sm.gome.com.cn/collect/track_proxy?tid=dc-1&cid=146891845986797506&dr=https%3A%2F%2Flogin.gome.com.cn%2Flogin%3Fintcmp%3Dsy-public01035%26type%3Dlogout&sr=1920*1080&vp=1903*415&de=utf-8&sd=24-bit&ul=zh-cn&je=1&fl=21.0%20r0&t=pageview&ni=0&dl=https%3A%2F%2Freg.gome.com.cn%2Fregister%2Findex%2Fperson&dt=%E6%B3%A8%E5%86%8C&ub=0-0-0-0-0-0-0-0&cd1=direct&cd2=other&cd3=https%3A%2F%2Flogin.gome.com.cn%2Flogin%3Fintcmp%3Dsy-public01035%26type%3Dlogout&z=1209864995"
        result=http_helper.get(url,"","",http_entity=http_entity)
        url = "https://login.gome.com.cn/um.htm?callback=callback&data=peyAndXNlcl9hZ2VudCc6J01vemlsbGEvNS4wIChXaW5kb3dzIE5UIDYuMTsgV09XNjQ7IFRyaWRlbnQvNy4wOyBTTENDMjsgLk5FVCBDTFIgMi4wLjUwNzI3OyAuTkVUIENMUiAzLjUuMzA3Mjk7IC5ORVQgQ0xSIDMuMC4zMDcyOTsgTWVkaWEgQ2VudGVyIFBDIDYuMDsgLk5FVDQuMEM7IC5ORVQ0LjBFOyBJbmZvUGF0aC4yOyBHV1g6TUFOQUdFRDsgR1dYOlFVQUxJRklFRDsgcnY6MTEuMCkgbGlrZSBHZWNrbycsJ2xhbmd1YWdlJzonemgtQ04nLCdjb2xvcl9kZXB0aCc6JzI0JywncmVzb2x1dGlvbic6JzE5MjA7MTA4MCcsJ2F2YWlsYWJsZV9yZXNvbHV0aW9uJzonMTkyMDsxMDUwJywndGltZXpvbmVfb2Zmc2V0JzonLTQ4MCcsJ3Nlc3Npb25fc3RvcmFnZSc6JzEnLCdsb2NhbF9zdG9yYWdlJzonMScsJ2luZGV4ZWRfZGInOicxJywnY3B1X2NsYXNzJzoneDg2JywnbmF2aWdhdG9yX3BsYXRmb3JtJzonV2luMzInLCdkb19ub3RfdHJhY2snOid1bmtub3duJywnaWVfcGx1Z2lucyc6J2U4ZWY0MjczNTQ1NzRjNzhmODAwYzllNDNmNGZlNWJlJywnY2FudmFzJzonZDVhOWZmMjEzYTM3MjYzYjczYjBjZDA5ZjYzMzVkNzQnLCd3ZWJnbCc6JzA0YzFlOTZkNTY4YjFhOWI4NzRjMjU2MmIwYzk5YjhkJywnYWRibG9jayc6J2ZhbHNlJywnaGFzX2xpZWRfbGFuZ3VhZ2VzJzonZmFsc2UnLCdoYXNfbGllZF9yZXNvbHV0aW9uJzonZmFsc2UnLCdoYXNfbGllZF9vcyc6J2ZhbHNlJywnaGFzX2xpZWRfYnJvd3Nlcic6J2ZhbHNlJywndG91Y2hfc3VwcG9ydCc6JzA7ZmFsc2U7ZmFsc2UnLCdqc19mb250cyc6Jzc3ZjU2MDJhYjEwY2EwZjA0MWU4NThiZTU3YWRjM2YwJywndCc6JzIwMTYtMDctMTkgMTY6NTQ6MTkuMjQxJywndHlwZSc6J3dlYicsJ3VybCc6J2h0dHBzOi8vcmVnLmdvbWUuY29tLmNuJywgfQ%3D%3D&_=1468918459242"
        result=http_helper.get(url,"","",http_entity=http_entity)
        url = "https://sm.gome.com.cn/collect/track_proxy?tid=dc-1&cid=146891845986797506&dr=https%3A%2F%2Flogin.gome.com.cn%2Flogin%3Fintcmp%3Dsy-public01035%26type%3Dlogout&sr=1920*1080&vp=1903*415&de=utf-8&sd=24-bit&ul=zh-cn&je=1&fl=21.0%20r0&t=pulse&ni=1&dl=https%3A%2F%2Freg.gome.com.cn%2Fregister%2Findex%2Fperson&dt=%E6%B3%A8%E5%86%8C&ub=1-1-0-1-1-0-0-0&cd1=direct&cd2=other&cd3=https%3A%2F%2Flogin.gome.com.cn%2Flogin%3Fintcmp%3Dsy-public01035%26type%3Dlogout&z=1239244916"
        result=http_helper.get(url,"","",http_entity=http_entity)
        url = "https://reg.gome.com.cn/register/validateExist/repulse.do"
        param = "login={0}".format(thrid_app.phone)
        headers["Accept"]  = "*/*";
        headers["Content-Type"] = "application/x-www-form-urlencoded";
        headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.80 Safari/537.36"
        result=http_helper.post(url,param,referer,http_entity=http_entity)
        if result.find("true")>-1:
            thrid_app.useflag = UseFlag.suc
        elif result.find("false")>-1:
            thrid_app.useflag = UseFlag.fail
        elif result=="timeout" :
            thrid_app.useflag = UseFlag.times  
        else :
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app
        """


class HuaWei(ISplider) :
    def __init__(self):
        self.name="华为商城"
   
    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port       
        url = "https://hwid1.vmall.com/CAS/portal/userRegister/regbyphone.html?service=http://www.vmall.com/account/caslogin&loginChannel=26000000&reqClientType=26"
        result=http_helper.get(url,"","",http_entity=http_entity)
        pageToken = re.match("pageToken:\"(.*?)\"",result).groups(1)
        referer = url
        url = "https://hwid1.vmall.com/CAS/ajaxHandler/isExsitUser?random="
        http_entity.accept = "application/json, text/javascript, */*; q=0.01"
        param = "userAccount=0086{0}&pageToken={1}".format(thrid_app.phone, pageToken)
        result=http_helper.post(url,param,referer,http_entity=http_entity)
        flag = re.match("\"existAccountFlag\":\"(\\d*)\"",result).groups(1)
        if(flag=="1") :
            thrid_app.useflag = UseFlag.suc
        elif flag=="0" :
            thrid_app.useflag = UseFlag.fail 
        elif result==("timeout") :
            thrid_app.useflag = UseFlag.times  
        else :
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app

class HuiCongWang(ISplider) :
    def __init__(self):
        self.name="慧聪网"
   
    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port        
        url = "http://my.b2b.hc360.com/my/turbine/action/company.RegisterAction/eventsubmit_doCheckbindmodile/doCheckbindmodile"
        referer = "http://my.b2b.hc360.com/my/turbine/template/firstview,reg_buy.html?sourcetypeid=3&skey=2013new"
        param = "mobile={0}".format(thrid_app.phone)
        param = "mobileCodeKey=register&smsType=0&mobile={0}".format(thrid_app.phone)
        http_entity.accept = "text/plain, */*; q=0.01"
        #http_helper.revice_encoding="gb2312"
        result=http_helper.post(url,param,referer,http_entity=http_entity)
        flag = re.match("\"existAccountFlag\":\"(\\d*)\"",result).groups(1)
        if(flag=="1") :
            thrid_app.useflag = UseFlag.suc
        elif flag=="0" :
            thrid_app.useflag = UseFlag.fail 
        elif result==("timeout") :
            thrid_app.useflag = UseFlag.times  
        else :
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app

class JingDong(ISplider) :
    def __init__(self):
        self.name="京东"
   
    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port         
        url = "https://reg.jd.com/reg/person?ReturnUrl=http%3A%2F%2Fwww.jd.com"
        referer = "https://www.jd.com/"
        http_entity.accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
        result=http_helper.get(url,"",referer=referer,headers=headers)
        url = "https://reg.jd.com/validateuser/isMobileEngaged?phone=%2B0086{0}&mobile=%2B0086{0}&_=1467712781555".format(thrid_app.phone)
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        success = re.match("{\"success\":(.*?)}",result).groups(1)
        if(success=="1") :
            thrid_app.useflag = UseFlag.suc
        elif success=="0" :
            thrid_app.useflag = UseFlag.fail 
        elif result==("timeout") :
            thrid_app.useflag = UseFlag.times  
        else :
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app

class JuMeiYouPin(ISplider) :
    def __init__(self):
        self.name="聚美优品"
   
    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port         
        url = "https://reg.jd.com/reg/person?ReturnUrl=http%3A%2F%2Fwww.jd.com"
        referer = "https://www.jd.com/"
        http_entity.accpet = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
        result=http_helper.get(url,"",referer=referer,headers=headers)
        url = "https://reg.jd.com/validateuser/isMobileEngaged?phone=%2B0086{0}&mobile=%2B0086{0}&_=1467712781555".format(thrid_app.phone)
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        success = re.match("{\"success\":(.*?)}",result).groups(1)
        if(success=="1") :
            thrid_app.useflag = UseFlag.suc
        elif success=="0" :
            thrid_app.useflag = UseFlag.fail 
        elif result==("timeout") :
            thrid_app.useflag = UseFlag.times  
        else :
            thrid_app.useflag = UseFlag.unknow  
        return  thrid_app