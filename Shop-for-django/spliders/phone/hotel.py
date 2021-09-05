import re,random, time, logging,urllib.parse
from spliders.model import ThridApp,UseFlag
from spliders.common import ISplider,HelperSQLite
from utility.util.common import Base64Helper
from utility.util.http import HttpHelper

# 酒店 模块

class HanTingHotel(ISplider):
    def __init__(self):
        self.name="汉庭酒店"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_entity=HttpEntity() 
        #http_entity.proxies['http']=thrid_app.ip+':'+thrid_app.port  
        url="http://www.huazhu.com/"
        headers["Referer"]  = "http://login.lvmama.com/nsso/register/registering.do"
       
        http_entity.accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"
        http_entity.user_agent="Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.80 Safari/537.36"
        result=http_helper.get(url,"","",http_entity=http_entity)
        url = "https://passport.huazhu.com//SignUp?redirectUrl=http://www.huazhu.com"
        result=http_helper.get(url,"","",http_entity=http_entity)
        param="mobile={0}".format(thrid_app.phone)
        result=http_helper.post(url,param,url,http_entity=http_entity)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("false")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("true")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app