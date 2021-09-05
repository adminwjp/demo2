
#!/usr/bin/python3

# pip install requests
# https://www.cnblogs.com/yangbiao6/p/11826203.html
# pip install Scrapy

import requests

# import models
from app import  models

# 加密 
import hashlib

# 浏览器 模拟操作
from selenium import webdriver

import time

# ISplider interface
class ISplider:
    recruit=models.Recruit()
    # 在类的内部，使用 def 关键字来定义一个方法，与一般函数定义不同，类方法必须包含参数 self，且为第一个参数，self 代表的是类的实例。
    # self 的名字并不是规定死的，也可以使用 this，但是最好还是按照约定是用 self
    def splider(self):
        """
        to do something
        :return:
        """

class TaoBaoSplider(ISplider):

    def splider(self):
        # test baidu
        url = "https://www.baidu.com/"
        # if self.get("keyword"):
        #    url = url + "s?ie=utf-8&wd=11"
        r = requests.get(url)
        print(r)
        r.encoding = "utf-8"
        html = r.text
        print(html)
        with open("baidu.html", "w", encoding="utf-8") as f:
            f.write(html)
        #html = r.content
        # html_doc = str(html, "utf-8")  # html_doc=html.decode("utf-8","ignore")
        # print(html_doc)
        return 0



# 51job 招聘 实现接口 即 继续 登录操作一键投简历
class FiveOneJobSplider(ISplider):
    def splider(self):
        #not support 不执行时 没错误 
        #url:"https://login.51job.com/login.php?lang=c"
        url="https://login.51job.com/login.php?lang=c"
        # map
        headers = {
         "User-Agent":"Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.190 Safari/537.36",
         "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
         "Content-Type":"application/x-www-form-urlencoded" #这一步 提示需要验证码
        }

        #请求 带 cookie 
        seesion = requests.session()
        r = seesion.get(url,headers=headers)
        self.show(r)

        #登录
        param="lang=c&action=save&from_domain=i&loginname="+self.recruit.phone+"&password="+self.recruit.pwd+"&verifycode=&isread=on"
        r = seesion.post(url, param,headers=headers)
        # 提示需要验证码 识别是爬虫
        self.show(r)

        # 为何请求延迟 有时没反应
        url="https://i.51job.com/userset/ajax/whoviewme.php"
        r = seesion.post(url, "", headers=headers, timeout=5)
        #unicode 转码
        res=r.content.decode("unicode-escape")
        print(res)
        #如：
        #f="\u4f18\u8863\u5e93\u4fc3\u9500"  
        #print f  
        #print(f.decode("unicode-escape")) 
        #self.show(r)
   
    def show(this,r):
        r.encoding = "gbk"
        html = r.text
        print(html)

# 智联招聘 实现接口 即 继续 登录操作一键投简历
# 比较麻烦需要使用 滑块验证码 第三方打码平台 或 浏览器模拟 计算位置
# 这个比较麻烦 chrome 抓不到包 跳没了 fillder httpwatch(ie) 分析抓包
#  未实现
class ZhaoPinSplider(ISplider):


    def splider(self):
        url="https://www.zhaopin.com/"
        # map
        headers = {
         "User-Agent":"Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.190 Safari/537.36",
         "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
         "Content-Type":"application/x-www-form-urlencoded" 
        }

        #请求 带 cookie 
        seesion = requests.session()
      
   

# 拉钩 招聘 实现接口 即 继续 登录操作一键投简历
# 这个比较麻烦 chrome 抓不到包 跳没了 fillder httpwatch(ie) 分析抓包 官方下载用不了抓包 要么付费 要么太新了 跟以前操作不同
#gt_judgement 这个请求参数怎么生成的 可能服务器段生成的 浏览器模拟登录 拿 cookie
class LaGouSplider(ISplider):
    def browser_login(self):
        #需要 滑块验证码
        url="https://www.lagou.com/"
        # 默认使用武汉实际 先首页再选择城市
        url="https://www.lagou.com/wuhan/"
        browser=webdriver.PhantomJS()
        browser.get(url)
        time.sleep(1)
        with open("wuhan.html", "w", encoding="utf-8") as f:
            f.write(browser.page_source)
        # 点击 登录 进入 登录页面 老是找不到？ 不稳定
        #browser.find_element_by_xpath("//div[@id="lg_tbar"]/div[0]/div[1]/ul/li[1]/a").click()
        browser.find_element_by_xpath("//a[@class='login']").click()
        with open("l_login.html", "w", encoding="utf-8") as f:
            f.write(browser.page_source)
        #browser.find_element_by_xpath("//div[@class="forms-top-block forms-top-password"]/form/div[0]/div[0]/input").send_keys(self.recruit.phone)
        #browser.find_element_by_xpath("//div[@class="forms-top-block forms-top-password"]/form/div[1]/div[0]/input").send_keys(self.recruit.pwd)
        browser.find_element_by_xpath("//form[@class='active']/div/div/input[@type='text']").send_keys(self.recruit.phone)
        browser.find_element_by_xpath("//form[@class='active']/div/div/input[@type='password']").send_keys(self.recruit.pwd)
        #登录失败 看不出来 
        browser.find_element_by_xpath("//div[@class='login-btn login-password sense_login_password btn-green']").click()
        #not support 
        #browser.find_element_by_xpath("//div[@class="login-password"]").click()
        time.sleep(2)
        with open("l_login_suc.html", "w", encoding="utf-8") as f:
           f.write(browser.page_source)

    def splider(self):
        self.browser_login()
        return
        
        # map
        headers = {
         "User-Agent":"Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.190 Safari/537.36",
         "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
         "Content-Type":"application/x-www-form-urlencoded" 
        }

        #请求 带 cookie 
        seesion = requests.session()

        #https://www.lgstatic.com/lg-www-fed/pkg/index/page/index/main.html_aio_ba56f22.js
        #gtAppId:"66442f2f720bfc86799932d8ad2eb6c7",

        #url="https://api.geetest.com/gt_judgement?pt=0&gt=66442f2f720bfc86799932d8ad2eb6c7"
        #这个参数如何生成的
        #param="(Content)=2CAFszasBKhIgM5Mkd)Pz0MoW9nNzz3b9vXeUHrCwObk8mDQnIqZsTTzFVTaxP8iWuA4HSMMtiuwed0SlkHZOexLYJS7Pqb8BvgcU2djI0If9MRFwIBg)9EP9y(gdTruMUCGUwvYgLlnx)YlrmaoC(2j7pEpFgzBF3JfnEOnzTQZBRmRIGMsuicb(EXgSHFnctPxHm7FzxX2bhM2FGAeAledYLvAb5MSIlgplsDCcdWiyLHqO0V6VXVbFbNz2qAeXaK3fxPcp0EBmAHOwBrML50yxK17hUjq258CZqOJjGdtd0TQYXBA8ccvyOy6zxQoZpawcYI1uOUceViKFV2XpqGbBviJj8zRPsvQ3brdVG1liuW(lWPrgtSbVRxG(2L6)3Gn3p2BLctGqtrHQV8u)4WVkWdQvdsR6(HAIuLaJiitvH2gd4xcqaewYId)9Ndendwcxb)GlNOBXElN(IDtKEmr1OtY0AT0DFmCrqvrAv2tSfU(JXgaKl3haT4rpeo2MvJUFMsQWYwDbI2JH2lW9tt6DcwZnl4fASRU)gGk9vK6EqcU9n2LEyJj8UopKafc2inE(WEQjNFJ)kVUug(kfhbCNAO1VLfZpXtKHlQIOv3MtIcSZdqmDY33hUy4kJZ1p92M02hh2lq(3u2KBubMdH7ARybGIaqKZ5OTZLUv6GAQdViyRZk3FdmkttffVq8ES(xgs4KmVi5iU(W2msc3EZdJWPRaRebUd7O70oyue(lajdUHq)y6MWoLC72LM0vxL1p4E1ajADUsBbeKZDF57fBQWU4mnX6w9BhXrEHBTQ1Rnc2rDZQRWUDosaiPooaHWIuFRjvrtAV2LA3KQaXIpowlIAdxmLR0503zrCwjvmzIRTQsNOy5cJapJbU(NPtQRqPuktmE8ZVcGrsVkOv4ehZvXKfwnlBo0pPJpxKtTlkHs3qRk6e0HeWoB0HTcJDVkGbIWHaqwvNQptYU7YeWafTIaKDMPoblAc5K6jpmtg0Vfun4H3)DMN)Bo)K(yCnVX(Idnnn7RzB2rMTxU8uQYUXR(3PYlR1WL6UqUFt0Y4f0686N5h4edGBH1geQxXOnQ5o5DT6FkbHM1l6)4fgAo43b2gHfLbmxnvCwCs6Sym81uUBh1DNyV4qPBKgwBAMHOFS0Il8F3PLF81juD2gzBmQxuIFoT0fq6gDitnTmBMfQxUXua79zxXTGDjFxxK(kbSWOoZ2Ceh8d9m6dfCcVIItc)Lij(MvLo9(SPxed7N24nS9lAi3PReA4xDy9D6d3XEPE0XHtlBI091toHkYBcaPckTJoeVOXycLjXSH)kRfwjlRXgyhrNC)1mU(ojT47yykh74VN0V4adKA93qUCuUz3D8JfjH)(YzShzgZNwN2FgCxrl1qpxaP12AhoZQ(untBWO3p4cjqQtRk5fO3LKGrA9EAXUS)WgyyGIkT1smsC36J46cTVvjtIpo891M(3fwLGNHwQ3CToNohyVoD8tGyzKQBNEj9sHcyukiG)Qklyrkf384KeKxK9nReI8ROUQSqSBqEvZ5gZ4pIMrxyNlb)3TPF(Nzh076yxi94TpmuPvLkrsCnEBDiP436PzpH1w7RKn9fkIE3UsBEBwupC0i7XuY1LGTXfbyTmrUZ3H4(EAWE9SrLuuf2)vZcfPlAoy9wQ91AvGahAVAuwKx9oiZCqNcDxUoFwjvKOlJmPP50jLFw0aeaBR21EqKrSqJA7WXRvkR0NynLVrZOIRKp)nr4CcxT73P47tF0IQsWpdECU1xMzbq3zDS4aRkeZ(rtToUygKTdZmu(k2ptONLI5T3w34MxPUrvY09Uuu2L1DMLzKk428yiFctn2fqjaOoYSHVpwTRTv62d(KsP)GT8Djz6sYKANDSXaHMCPFhVMJiBetkvwUpv9KHU8rWZDEsgJVYuZNFJUIycNNZTmx7BmWohdUj2eE2VrlsyNlel9NXdkthMciBJ)7xHQqAf3oOQAdhc(fGB3)vVNcrL5twPfUN9gLArKLOsKg)Iy3bAhQr1HAbpB37BWaiSCepwIW)ks9bxR4Cxufcs1nuv(3rEdHYzdLcguLqQbJUpZJFZt1hjup399N)j1dOq1jVsRtTi0KVOiFPKIFpP9J(Pyfhtluiw53Si2lDiAKPHQSFmXy1TFjYQcrvYhK8QCby3XagHI72wMFy9ohlxgAhbfemcoN6B)sDDWogbpZ8zOgHF8XcTIrVjbVnbHA(rZ9J9JVi4e3Vhphkr40PGFEo9)jtLJ33L5x0KvRpxjZ(CqfQ43ISCwvMWIFMcVfuRsXp9)uItSiy8Ghrjxws(uoytc0uQ1aMhbJGyIrSO)uGAs)fs4muenMg3c2fIMNqpyXzIioiGQMrautkjG1dqvjI)eY09M0vN8VaNnmxKXDZifQxrbCQnhwJtJ4ZgRVrkv0S0a3Dn5xFndFy)gwcbHln8m4lNAdWRo6En1EXQRBj434oHOkAMxgXiu9KDpXkd)CBu718hCEJZIoCYdhAqYJQ1ISy)AqyFfJ(LOHfiqZ3bhv7PeCSiNOI1t)xzTkevqZ3M965B71KrM277xw1ohu8Pv3uh46qKm3QU)6TQqRL(cCK(KCxJ)u0oSxsVjF6gBVmfqh0uUhdPE0ZrmZJgr)flq3Q4tfaKPZrRlK7NiF3F(tJBucE8SIx0WPpVy9VfFnQESyOGueDITsVCX7QbuxyCRh)iP2e5UaFxglNt5yVbZ89gjgdSvOgc6pPPafxJDh8YRBDgabQjQc5R1MkwBXGJP)eBvuRRfXs)1Fr0UHKU3)8ou8dT)HphFKFDNILHKyYWo(Des6yiYcwtbZnmmuw7Ez40iSOLwRUHvMzcnETr1RyRqi8WduveOdxOmgE8SuCLleSrZcePXpbue608Y3(6Lqa4laFJHfT60iPC4yuEhw0Hi5gEBuP34ZzL(6eGOJmD4ysFP1hdn7qVR2BT(NTLzhSns1oKT)(1GilWsEjlPCp(vHqrX2VdWCxjOlIt6NU6guhG)v2oCdb25TFMAydDVNLq9gqv0IQsbXMVoK1uS(HHAYcaZ8l9bAfsexbHCxr46s3i3Gt0DOXERahpoveyL6qzEELfOKLjhgUXM3P)sLzQwY(4VMjq)rwd(dBT63Gj0XuDZvxg4WchG0SMlhpTcb5LNSsfP(VV)zouVFwFNGhRHyviFCkkR71TLzj6K0drdp7AfUdn4gZj5EEcpI7pC07uFQuZ8(8vMlOgR9nDrbQ3WdDTI9ydwXBiANmoFWASGf8tggFuew7kJEdWHz98bbVHdY3NjDAtTA2FQq9j8iuKAokPxCAKBlS(i3CYeXFPJSiJm75pgnn8JC9YLQDbj7Ufx8nZy7tLeIz22QYUHDvf8W9c9VOwSi3gfq(7LleNbFiagaacbdV3s56wgUspUtn(d1KwlKmCBK7JBZtSDVp9ltnkYqsP1(QglBOaqpL7c(VLRKze4eXT4vnEFM)Gh8WD0mdUoxa)xYPrif0WSjj3lT)p80eLz6rDV9s0yA9VsyfcsGG4V1pUqEKDYUJj(WQwB5jgY5wdzEkYih7uVjBHhaloiyBrtSnHqGJSdKhw7GGjh8KvzfY40)EehCGRDQPSLDq6zm9PiEuiwgNt)FiEdkLYP2XI2a(SRd(65uDtFh9Dpdxi70gUqBlJSpjEPgL9nb8moMxTUUTS47sGmCb5WDPhiWoyghaZg)4(HpXOB2y2HKwETQuPGsdrzCSqhk)SDoWZrFlO2Zb3JQFZzJLhMXjvDfAsn(8CYpTvUzRjyv2eS8f5ba2951f39933f572f5137be87bf52ab3ef1d38bc17f7bc037ca006a7095dda1abfe823e6de7482eb7955bbcd0b2415e98486b396501736dc66b565bbae7ecc3f87d96844d4a24bfc8e97e3301b7b2bdea3c670971dd7ad800b64bd6f435b715ac23a86b969f6b9e473abd9fbf8a423a43a0a8b742bad89e3ebd6bce8915e6"
        #r = seesion.post(url, param,headers=headers)
        # {"static_servers": "static.geetest.com,dn-staticdown.qbox.me", "challenge": "272f378ed6032bce484704d92cb9d955", "result": "success", "logo": true, "api_server": "api.geetest.com", "id": "66442f2f720bfc86799932d8ad2eb6c7", "status": "success", "product": "sensebot"}
        #match_obj = re.match(r"\"challenge\":\\s*\"(.*?)\", ", response.text, re.DOTALL)
        #if match_obj:
        #    challenge = match_obj.group(1)
        #else:
        #    print("failed to match code and token!")

        #登录
        # http://www.lgstatic.com/lg-www-fed/pkg/index/page/index/main.html_aio_ba56f22.js
        # 7245
        # F = "veenike";
        # g.isValidate && (g.password = md5(g.password), g.password = md5(F + g.password + F), a && (g = b.getParam(g, a)), $.lgAjax({
               
        url="https://passport.lagou.com/login/login.json?jsoncallback=jQuery111303853172744911583_1615743122139&isValidate=true&username=13147114320&password=6c6e44798dde1d1a240d5bde14baef55&request_form_verifyCode=&challenge=272f378ed6032bce484704d92cb9d955&_=1615743122143"
        pwd=self.get_password(self.recruit.pwd)
        url="https://passport.lagou.com/login/login.json?jsoncallback=jQuery111303853172744911583_1615743122139&isValidate=true&username="+self.recruit.phone+"&password="+pwd+"&request_form_verifyCode=&&_=1615743122143"
        r = seesion.get(url, headers=headers)
        #jQuery111303853172744911583_1615743122139({"state":1,"message":"操作成功","content":{"rows":[]}})
        #登录失败 
        print("login result : %s",r.text)

   
    def get_password(self,passwd):
       """这里对密码进行了md5双重加密 veennike 这个值是在main.html_aio_f95e644.js文件找到的 """
       passwd = hashlib.md5(passwd.encode("utf-8")).hexdigest()
       passwd = "veenike" + passwd + "veenike"
       passwd = hashlib.md5(passwd.encode("utf-8")).hexdigest()
       return passwd


class SinaSplider:
    def splider(self):
        url=""
    def forgetpwd(self):
        url="https://security.weibo.com/iforgot/loginname?entry=weibo&loginname=973513569@qq.com"
        # 需要验证码 chrome抓不到包 acb8765cf61bbec8b2980d8d98691bf5 参数怎么生成的
        url="https://security.weibo.com/iforgot/index?loginname=973513569@qq.com&entry=weibo&dt=acb8765cf61bbec8b2980d8d98691bf5&referDomain=weibo"
#tabao = TaoBaoSplider()
#tabao.splider()




