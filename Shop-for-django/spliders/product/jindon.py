# import os.path
# pyhton3
from pathlib import Path
from bs4 import BeautifulSoup
import json
# ModuleNotFoundError: No module named
from utility.util.http import HttpHelper
#from spliders import common
# 只能 从 外部 调用 不能调用 这个目录 无法找到上级 目录 
# vs 巨坑 改个 文件 不支持  手动 改 还修改 csproj 工程文件 还更新不过来 卸载 - 加载 才可以
dir="e:\work\crawl\html\jd"

class ShopCatalog:
    id=1
    names=[(str)]
    name=""
    # error  ShopCatalog defined
    #children=[(ShopCatalog)]
    children=[]

# 京东 信息 json 格式 数据字段 字母 需要对比 才知道 需要哪些 数据 爬取数据累
class JinDon:
    def crawl(self):
        p=Path(dir)
        #  if(p.is_dir() and p.exists()==False):
        if(p.exists()==False):
            p.mkdir(511,True,False)
            print("{0} not exists \n".format(dir))
        else :
            print("{0} exist \n".format(dir))
        
        self.__get("https://www.jd.com/","\index.html")

        # 二级分类 以及 其他 分类
        #https://dc.3.cn/category/get?&callback=getCategoryCallback
        self.__get("https://dc.3.cn/category/get?&callback=getCategoryCallback","\jd_catalog.json")
       
    def __get(self,url,path):
        index=dir+path;
        i=Path(index)
        if(i.exists()==False):
        # if(i.is_file() and i.exists()==False):
            print("{0} not exists \n".format(index))
            url="https://dc.3.cn/category/get?&callback=getCategoryCallback"
            http_helper=HttpHelper()
            headers=http_helper.get_headers()
            result=http_helper.get(url,"","",headers=headers)
            with open(index, "w", encoding="utf-8") as f:
                f.write(result)

    #没获取地址
    def parse(self,html):
        # error for encoding in detector.encodings
        #soup=BeautifulSoup(html,"html.parser")
        #soup=BeautifulSoup(html,["lxml", "xml"])
        soup=BeautifulSoup(html,"html5lib")
        #catalogs=soup.find(id="J_cate").find_all(" ul > li") # not found 
        catalogs=soup.find(id="J_cate").find_all("li",class_="cate_menu_item")
        shop_catalogs=[] #[(ShopCatalog)]
        for it in catalogs:
            aes=it.find_all("a")
            shop_catalog={"names":[],"children":[]} #ShopCatalog()
            shop_catalogs.append(shop_catalog)
            #shop_catalog.name=[(str)]
            # 每行有 1-n个
            for a in aes:
                #print(a.text)
                shop_catalog["names"].append(a.text)
            # a.text = a.get_text()
            #print(a.get_text())
            #print(it)
        secod_catalogs=soup.find(id="J_popCtn").find_all("div",class_="cate_part")
        i=0
        # 数据没有 ？ 源码 中 没有 json 里的
        for it in secod_catalogs:
            # 二级 分类 第一行 
            first=it.find("div",class_="cate_channel").find_all("a")
            shop_catalog={"children":[],"name":"","names":[]} #ShopCatalog()
            shop_catalogs[i]["children"].append(shop_catalog)
            # 每行有 1-n个
            #shop_catalog.children=[(ShopCatalog)]
            for a in aes:
               print(a.text)
               shop_catalog["names"].append(a.text)
            i=i+1
            # 二级 分类 第 > 1行 
            second=it.find("div",class_="cate_detail").find_all("dl")
            for dl in second:
                dt=it.find("dt").find("a")
                shop_catalog["name"]=dt.text
                dd=it.find("dd").find_all("a")
                shop_catalog1={"children":[],"names":[]} #ShopCatalog()
                shop_catalog["children"].append(shop_catalog1)
                for a in dd:
                     shop_catalog1["names"].append(a.text)
        #shop_catalogs.count()
        #len(shop_catalogs)
        return shop_catalogs
    
        
    def save_data(self,first,chdilren):
        i=0
        while i< len(first):
        # not support 
        # for i=0 ; i< len(first);i++ :
            #first[i]["item"]=chdilren[i] # update
            first[i]["firsts"]=chdilren[i]["firsts"]
            first[i]["seconds"]=chdilren[i]["seconds"]
            #i++ # not support
            i=i+1
        # json parse ex
        #print(json.dumps(shop_catalogs, sort_keys=False, indent=2, ensure_ascii=False))
        js=json.dumps(first,default=lambda x : x.__dict__, sort_keys=False, indent=2, ensure_ascii=False)
        #print(js)
        with open("data/jd.json","w") as f:
            f.write(js)

    #获取地址
    def parse_json(self,json):
        results=[]
        # 数据  怎么组装的没有规律 要找到 渲染 js 没必要
        # 有规律 看错 json 了
        #18 行 1级 分类
        for it in json:
            # 二级分类
            fam=it["t"]
            data={"firsts":[],"seconds":[]}
            results.append(data)
            # 家用电器 a
            # 手机/运营商/数码 b
            # 电脑 ... c
            # ....
            self.__parse_first(data,fam,it)
            pass
        return results

    def __parse_first(self,data,fam,it):
        # 家用电器
        # 二级分类
        for f in fam:
            strs=f.split("|")
            data["firsts"].append({"link":strs[0],"name":strs[1]})
            #secods=f["s.n.s"] # error
            #print(type(it))
            #dic =json.loads(f)
            #print(type(dic))
            secods=it["s"][0]["s"]
            #print(secods)
            # for s in secods:
            s=secods[0]
            strs=s["n"].split("|")
            ss={"link":strs[0],"name":strs[1],"children":[]}
            data["seconds"].append(ss)
            threes=s["s"]
            for t in threes:
                strs=t["n"].split("|")
                ts={"link":strs[0],"name":strs[1],"children":[]}
                ss["children"].append(ts)

    def parse_file(self,file):
        soup=BeautifulSoup(open(file))
        #catalogs=soup.find(id="J_cate").find_all(" ul > li")
        catalogs=soup.find(id="J_cate").find_all("li",class_="cate_menu_item")
        for it in catalogs:
            a=it.find("a")
            print(a.text)
            #print(a.get_text())
