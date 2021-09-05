import re,random, time, logging,urllib.parse,html
from spliders.model import ThridApp,UseFlag
from spliders.common import ISplider,Base64Helper,HttpHelper,HelperSQLite

# 视频 模块

class Baidu(ISplider): 
    def __init__(self) :
        self.name="百度"


    def crawl(self, thrid_app):
        http_helper=HttpHelper()
        http_helper.ip=thrid_app.ip
        http_helper.port=thrid_app.port        
        headers=http_helper.get_headers()  
        url = "http://user.56.com/?do=checkMobile&account={}&callback=jsonp_callback50631_1&_=".format(thrid_app.phone)
        referer = "http://user.56.com/reg/"
        result=http_helper.get(url,"",referer=referer,headers=headers)
        if result=="timeout" :
            thrid_app.useflag = UseFlag.times
        elif(result.find("false")>-1):
            thrid_app.useflag = UseFlag.suc
        elif result.find("true")>-1:
            thrid_app.useflag = UseFlag.fail  
        else :
            thrid_app.useflag = UseFlag.unknow   
        return thrid_app

