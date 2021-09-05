import re,random, time, logging,urllib.parse
from spliders.model import ThridApp,UseFlag
from spliders.common import ISplider,HelperSQLite
from utility.util.common import Base64Helper
from utility.util.http import HttpHelper,HttpEntity

# 汽车 模块
class _58(ISplider):
    def __init__(self):
        self.name="五八车"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url="https://bbs.58che.com/api.php?m=ajax&c=user&a=check_mobile"
        param="mobile={}&rand=1615817296463".format(thrid_app.phone)
        # {"ret":0,"msg":"\u6210\u529f","data":""}
        result=http_helper.post(url,param,"",http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("1")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("0")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app


class CarHome(ISplider) :
    def __init__(self):
        self.name="汽车之家"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
          
        referer="http://account.autohome.com.cn/password/find?backurl="
        url="http://account.autohome.com.cn/password/checkusername"
        param="username={}&usertype=2&".format(thrid_app.phone)
        # {"result":null,"returncode":2010203,"message":"该用户名不存在"}
        result=http_helper.post(url,param,referer,http_entity=http_entity)
        code=re.match("returncode\":(\\d*)",result).groups(1)
        if result=="timeout":
            thrid_app.useflag = UseFlag.times 
        elif code=="0":
            thrid_app.useflag = UseFlag.suc   
        elif code=="2010203":
            thrid_app.useflag = UseFlag.fail    
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app


class ErShouCarShop(ISplider) :
    def __init__(self):
        self.name="二手车城"

    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        referer="http://www.cn2che.com/register.html"
        url="http://www.cn2che.com/Handle/remotejs.asmx/CheckedPhoneOrEmail"
        param="phone={}".format(thrid_app.phone)
        # <?xml version="1.0" encoding="utf-8"?>
        #<remoteobject xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://tempuri.org/">
        #  <Msg />
        #  <Result>1</Result>
        #</remoteobject>
        result=http_helper.post(url,param,referer,http_entity=http_entity)
        code=re.match("<Result>(-?\\d*)</Result>",result).groups(1)
        if result=="timeout":
            thrid_app.useflag = UseFlag.times
        if code=="-1":
            thrid_app.useflag = UseFlag.suc 
        elif code=="1":
            thrid_app.useflag = UseFlag.fail   
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class Sina(ISplider) :
    def __init__(self):
        self.name="新浪微博"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        referer="https://weibo.com/signup/signup.php"
        url="https://weibo.com/signup/v5/formcheck?type=mobilesea&zone=0086&value={}&from=&__rnd=1615818114113".format(thrid_app.phone)
        # {"code":"100000","data":{"id":"","state":true,"type":"ok",
        # "code":"100000","action":"io","msg":"","iodata":""},"msg":""}
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        if(result=="timeout"):
            thrid_app.useflag = UseFlag.times
        elif(result.find("该手机号已注册")>-1):
            thrid_app.useflag = UseFlag.suc 
        elif result.find("100000")>-1:
            thrid_app.useflag = UseFlag.fail 
        elif result.find("注册过于频繁")>-1:
            uts=time.time()
            if HelperSQLite.insert_close_ip(thrid_app.thridapp, thrid_app.ip, uts):
                logging.warn("新浪微博代理IP：{}被封，入黑名单库。".format(thrid_app.ip))
            thrid_app.useflag = UseFlag.unknow    
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class TengXunQiChe(ISplider) :
    def __init__(self):
        self.name="腾讯汽车"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        referer = "https://aq.qq.com/cn2/findpsw/pc/pc_find_pwd_input_account?source_id=1035"
        url = "https://aq.qq.com/cn2/findpsw/pc/pc_find_pwd_analysis_account_ajax?aq_account={}".format(thrid_app.phone)
        http_entity.accept = "application/json, text/javascript, */*"
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        url = "https://aq.qq.com/cn2/findpsw/pc/pc_find_pwd_get_uin_by_input_ajax?aq_account={}".format(thrid_app.phone)
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        if(result=="timeout"):
            thrid_app.useflag = UseFlag.times
        elif(result.find("1")>-1):
            thrid_app.useflag = UseFlag.suc 
        elif result.find("-1")>-1:
            thrid_app.useflag = UseFlag.fail 
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class TPYQiChe(ISplider) :
    def __init__(self):
        self.name="太平洋汽车"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "http://passport3.pcauto.com.cn/passport3/api/validate_mobile.jsp?mobile={}&req_enc=UTF-8".format(thrid_app.phone)
        referer = "http://my.pcauto.com.cn/passport/mobileRegister.jsp"
        result=http_helper.post(url,{},referer=referer,http_entity=http_entity)
        status = re.match("status\":(\\d*),",result).groups(1)
        if(result=="timeout"):
            thrid_app.useflag = UseFlag.times
        elif(status=="43"):
            thrid_app.useflag = UseFlag.suc 
        elif status=="0":
            thrid_app.useflag = UseFlag.fail 
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class WangShangCheShi(ISplider) :
    def __init__(self):
        self.name="网上车市"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "https://service.cheshi.com/user/ajax/login_ajax.php?act=checkUsername&username={}".format(thrid_app.phone)
        referer = "https://service.cheshi.com/user/getpassword.php"
        result=http_helper.get(url,"",referer=referer,http_entity=http_entity)
        if(result=="timeout"):
            thrid_app.useflag = UseFlag.unknow
            uts=time.time()
            if HelperSQLite.insert_close_ip(thrid_app.thridapp, thrid_app.ip, uts):
                logging.warn("网上车市代理IP：{}被封，入黑名单库。".format(thrid_app.ip))
        elif(result=="1"):
            thrid_app.useflag = UseFlag.suc 
        elif result=="0":
            thrid_app.useflag = UseFlag.fail 
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

class YiChe(ISplider) :
    def __init__(self):
        self.name="易车网"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port 
        url = "http://i.yiche.com/ajax/authenservice/MobileCode.ashx"
        referer = "http://i.yiche.com/authenservice/RegisterSimple/MobileRegister.html"
        param = "mobileCodeKey=register&smsType=0&mobile={}".format(thrid_app.phone)
        result=http_helper.post(url,param,referer=referer,http_entity=http_entity)
        status = re.match("mobile\":\\{\"status\":(.*?),\"message\":\"\",\"key\":\"(.*?)\"",result).groups(1)
        if(result=="timeout"):
            thrid_app.useflag = UseFlag.times
        elif(status=="exist"):
            thrid_app.useflag = UseFlag.suc 
        elif status=="":
            thrid_app.useflag = UseFlag.fail 
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app