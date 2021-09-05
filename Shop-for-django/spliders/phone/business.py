import re,random, time, logging,urllib.parse
from spliders.model import ThridApp,UseFlag
from spliders.common import ISplider,HelperSQLite
from utility.util.common import Base64Helper
from utility.util.http import HttpHelper,HttpEntity

# 创业 业务 模块

class _3158(ISplider) :
    def __init__(self):
        self.name="招商加盟网"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()        
        url = "https://id.3158.cn/v1/signup/?return_url=http://www.3158.cn/news/"
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        http_entity.accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
        result=http_helper.get(url,"","",http_entity)
        account=Base64Helper.encodestring(thridApp.phone)
        # urlencode example "中文"
        # account=account.encode("gb2312-8")  # b"\xd6\xd0\xce\xc4"
        account=urllib.parse.quote(account) #%D6%D0%CE%C4
        # urldecode
        # account=urllib.parse.unquote(account) 
        url = "https://id.3158.cn/account/isexists/?account={0}&callback=_3158_SSOClient.is_exists_callback&format=jsonp&_=1472708771202&r={1}".format(account,random.random())
        result=http_helper.get(url,"","",http_entity)
        response=result.encode("hex") # un hex
        #result=result.decode("hex") # hex
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif response.find("帐号不存在")>-1  :
            thrid_app.useflag = UseFlag.fail
        elif response.find("帐号存在")>-1 :
            thrid_app.useflag = UseFlag.suc
        else :
            thrid_app.useflag = UseFlag.unknow
        return thrid_app

class ChuangYeBang(ISplider) :
    def __init__(self):
        self.name="创业邦"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        http_entity.accept = "application/json, text/javascript, */*; q=0.01"
        http_entity.headers["X-Requested-With"]= "XMLHttpRequest"
        http_entity.content_type = "application/x-www-form-urlencoded; charset=UTF-8"
        http_entity.user_agent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.80 Safari/537.36"

        """
        referer = "http://www.cyzone.cn/"
        url = "http://www.cyzone.cn/index.php?m=member&c=index&a=register"
        param = "email={0}&password=333333333".format(thrid_app.phone)
        result=http_helper.post(url,param,referer,http_entity)
        msg=re.match("\"msg\":\"(.*?)\",",result).groups(1)
        msg=msg.encode("hex") # un hex
        if (msg.Contains("注册成功")):
            thrid_app.useflag = UseFlag.fail
        elif (msg.Contains("注册失败用户名已经存在")):
            thrid_app.useflag = UseFlag.suc
        elif (result=="timeout"):
            thrid_app.useflag = UseFlag.times
        else:
            thrid_app.useflag = UseFlag.unknow;
        return thrid_app;
        """


        url = "http://www.cyzone.cn/index.php?m=member&c=index&a=login"
        referer = "http://www.cyzone.cn/"
        param = "email={0}&password=123456&cookietime=1&dosubmit=1".format(thrid_app.phone)
        result=http_helper.post(url,param,referer,http_entity)
        response=result.encode("hex") # un hex
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif (response.find("不存在")>-1):
            thrid_app.useflag = UseFlag.fail
        elif (response.find("密码错误")>-1 or response.find("登录成功")>-1):
            thrid_app.useflag = UseFlag.suc
        else :
            thrid_app.useflag = UseFlag.unknow
        return thrid_app

class HuangYe(ISplider) :
    def __init__(self):
        self.name="黄页88"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "http://my.huangye88.com/newmember.html?mobile={0}".format(thrid_app.phone)
        referer = "http://my.huangye88.com/newmember.html"
        result=http_helper.get(url,"",referer,http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif result.find("帐号不存在")>-1  :
            thrid_app.useflag = UseFlag.fail
        elif result.find("帐号存在")>-1 :
            thrid_app.useflag = UseFlag.suc
        else :
            thrid_app.useflag = UseFlag.unknow
        return thrid_app

class IDarkHorse(ISplider) :
    def __init__(self):
        self.name="i黑马"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "http://www.iheima.com/user/register"
        result=http_helper.get(url,"","",http_entity)
        token = re.match("name=\"csrf-token\" content=\"(.*?)\">",result).group(1)
        type = re.match("立即注册(?:.*?)<input type=\"hidden\" name=\"type\" value=\"(.*?)\" />", result).groups(1)
        url = "http://www.iheima.com/user/register";
        http_entity.headers["X-CSRF-Token"]= token
        http_entity.headers["X-Requested-With"]= "XMLHttpRequest"
        http_entity.headers["X-PJAX"]= "true"
        http_entity.headers["X-PJAX-Container"]= "=#w1"
        http_entity.content_type = "multipart/form-data; boundary=---------------------------7e026f1f14b08e4"
        http_entity.content_type = "text/html, */*; q=0.01"
        http_entity.cookie["Hm_lpvt_9723485e19f163e8e518ca694e959cb9"]="1469948476"
        referer = "http://www.iheima.com/user/register";
        param = "-----------------------------7e0873514b08e4\nContent-Disposition: form-data; name=\"_csrf\"\n\n{0}\n-----------------------------7e0873514b08e4\nContent-Disposition: form-data; name=\"User[mobile]\"\n\n{1}\n-----------------------------7e0873514b08e4\nContent-Disposition: form-data; name=\"User[code]\"\n\n\n-----------------------------7e0873514b08e4\nContent-Disposition: form-data; name=\"type\"\n\n{2}\n-----------------------------7e0873514b08e4--".format(token,thrid_app.phone,type);
        result=http_helper.post(url,param,referer,http_entity)  
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif result == "1":
            thrid_app.useflag = UseFlag.suc
        elif (result == "0"):
            thrid_app.useflag = UseFlag.fail
        else:
            thrid_app.useflag = UseFlag.unknow
        return thrid_app

class JiKePark(ISplider) :
    def __init__(self):
        self.name="极客公园"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "https://account.geekpark.net/login";
        result = http_helper.get(url,"","",http_entity)
        token = re.match("<meta name=\"csrf-token\" content=\"(.*?)\"",result).groups(1)
        url = "https://account.geekpark.net/check_exist?user%5Bemail%5D={0}".format(thrid_app.phone)
        http_entity.headers["X-CSRF-Token"]= token
        result = http_helper.get(url,"","",http_entity)
        exist = re.match("exist\":(.*?),",result).groups(1)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif exist == "true":
            thrid_app.useflag = UseFlag.suc
        elif (exist == "false"):
            thrid_app.useflag = UseFlag.fail
        else:
            thrid_app.useflag = UseFlag.unknow
        return thrid_app

class ShiJieGongChangWang(ISplider) :
    def __init__(self):
        self.name="世界工厂网"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "https://i.gongchang.com/login/reg/checkmobilenew/?v={0}&mobile={0}".format(thrid_app.phone);
        referer = "https://i.gongchang.com/reg.html";
        http_entity.accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
        result = http_helper.get(url,"",referer=referer,http_entity=http_entity)
        http_entity.accept = "*/*";
        # http_entity.headers["X-Requested-With"]= "XMLHttpRequest"
        # http_entity.user_agent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.113 Safari/537.36"
        #param = "v={0}&mobile={0}".format(thrid_app.phone)
        result = http_helper.get(url,"",referer=referer,http_entity=http_entity)
        #response=result.encode("hex") # un hex
        #response = re.match("status\":(.*?),",result).groups(1)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
            uts=time.time()
            if HelperSQLite.insert_close_ip(thrid_app.thridapp, thrid_app.ip, uts):
                logging.warn("世界工厂网代理IP：{}被封，入黑名单库。".format(thrid_app.ip))
        elif result == "false":
            thrid_app.useflag = UseFlag.suc
        elif (result == "true"):
            thrid_app.useflag = UseFlag.fail
        else:
            thrid_app.useflag = UseFlag.unknow
        return thrid_app


class TianShiHui(ISplider) :
    def __init__(self):
        self.name="天使汇"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        referer = "http://angelcrunch.com/auth/";
        url = " http://angelcrunch.com/auth/j/login?callback=jQuery11120718105893349275_1472721002633&o=%7B%22account%22%3A%22{0}%22%2C%22password%22%3A%22123456%22%7D&_=".format(thrid_app.phone)
        result = http_helper.get(url,"",referer=referer,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif result == "密码错误":
            thrid_app.useflag = UseFlag.suc
        elif (result == "帐号不存在"):
            thrid_app.useflag = UseFlag.fail
        else:
            thrid_app.useflag = UseFlag.unknow
        return thrid_app

class TuMuOnline(ISplider) :
    def __init__(self):
        self.name="土木在线"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        referer="http://passport.co188.com/regist/getpwd/step_one.html"
        url = "http://passport.co188.com/regist/valid/username.html?username={0}&type=1&r={1}".format(thrid_app.phone,random.random())
        result = http_helper.get(url,"",referer=referer,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif result == "0":
            thrid_app.useflag = UseFlag.suc
        elif (result == "1"):
            thrid_app.useflag = UseFlag.fail
        else:
            thrid_app.useflag = UseFlag.unknow
        return thrid_app

class WorldFactory(ISplider) :
    def __init__(self):
        self.name="世界工厂网"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "https://i.gongchang.com/reg.html"
        http_entity.accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
        result = http_helper.get(url,http_entity=http_entity)
        referer = url;
        url = "https://i.gongchang.com/login/reg/checkmobilenew/?v={0}&mobile={0}".format(thrid_app.phone);
        headers["Accept"] = "*/*";
        result = http_helper.get(url,"",referer=referer,headers=headers)
        status = re.match("status\":(.*?),",result).groups(1)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif status == "true":
            thrid_app.useflag = UseFlag.suc
        elif (status == "false"):
            thrid_app.useflag = UseFlag.fail
        else:
            thrid_app.useflag = UseFlag.unknow
        return thrid_app

class ZhongChouWang(ISplider) :
    def __init__(self):
        self.name="众筹网"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        
        url = "http://sso.zhongchoujia.com/AjaxHandler.ashx"
        param = "Action=ZCJ.UserAjax.IsMobileReg&tel={}".format(thrid_app.phone)
        result = http_helper.post(url,param,"",http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif result.find("已注册")>-1:
            thrid_app.useflag = UseFlag.suc
        elif result.find("可以注册")>-1:
            thrid_app.useflag = UseFlag.fail
        else:
            thrid_app.useflag = UseFlag.unknow
        return thrid_app

class ZhongChouZhiJia(ISplider) :
    def __init__(self):
        self.name="众筹之家"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "https://www.zczj.com/passport/reg";
        #headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
        #headers["Upgrade-Insecure-Requests"] = "1"
        #headers["Accept-Encoding"] = "gzip, deflate, sdch"
        #headers["Accept-Language"] = "zh-CN,zh;q=0.8"
        result = http_helper.post(url,"","",http_entity=http_entity)
        referer = url
        url = "https://www.zczj.com/passport/IsExistUserName"
        param = "Account={0}&username={0}".format(thrid_app.phone)
        #headers["Accept"] = "application/json, text/javascript, */*; q=0.01"
        #headers["Content-Type"]  = "application/x-www-form-urlencoded; charset=UTF-8"
        result = http_helper.post(url,param,referer,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif result=="false":
            thrid_app.useflag = UseFlag.suc
        elif result=="true":
            thrid_app.useflag = UseFlag.fail
        else:
            thrid_app.useflag = UseFlag.unknow
        return thrid_app

class ZuLong(ISplider) :
    def __init__(self):
        self.name="筑龙网"

    def crawl(self, thrid_app) :
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        
        url = "http://passport.zhulong.com/user/checkMobile?mobile=1"
        referer = "http://passport.zhulong.com/user/reg"
        param = "phone={}".format(thrid_app.phone)
        result = http_helper.post(url,param,referer,http_entity=http_entity)
        err_no = re.match("errNo\":(-?\\d*)",result).groups(1)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif err_no=="-8":
            thrid_app.useflag = UseFlag.suc
        elif err_no=="0":
            thrid_app.useflag = UseFlag.fail
        else:
            thrid_app.useflag = UseFlag.unknow
        return thrid_app