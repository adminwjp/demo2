from pathlib import Path
# 直接 爬 别人数据 展示 可能 不稳定 最好 下载 下来 保存 
# 使用自己的接口 显示
# go gin 显示
# python 爬取 解析 (go 解析 需要用第三方库 ide 不智能 )
from bs4 import BeautifulSoup
import json
import os

wangyi='https://c.m.163.com/?referFrom='
#from utility.util.http import HttpHelper

from spliders.http import HttpHelper
# e:/work/shop
root_dir = os.path.dirname(os.path.abspath('.'))
# os.path.dirname(__file__)获取的是app.py文件的路径，也就是在项目根目录中，然后把它放在images文件夹中
root_dir = os.path.dirname(__file__)
root_dir=root_dir.replace('\\','/').replace('wy/','')
#__file__
# 路径 怎么获取的
#e:/work/shop/wy.html
wypath = os.path.join(root_dir, "wy.html")


def save():
    http=HttpHelper()
    res=http.get(wangyi,"","")
    print(res)
    # 'gbk' codec can't encode character '\xa9'  无法写入
    # https://www.cnblogs.com/themost/p/6603409.html
    wypath = os.path.join(root_dir, "wy/wy.html")
    with open(wypath,'w',encoding='utf-8')  as f:
        f.write(res)
 

def read():
    wypath = os.path.join(root_dir, "wy/wy.html")
    with open(wypath,'r',encoding='utf-8')  as f:
        return f.read()

def parse_catagory(html):
    soup=BeautifulSoup(html,"html5lib")
    lis=soup.find(class_="channel").find_all("li")
    catalogs=[] 
    for it in lis:
        a=it.find("a")
        catalog={"name":a.text,"href":a.attrs['href']} 
        catalogs.append(catalog)
    print(catalogs) # utf-8-sig
    with open(os.path.join(root_dir, "wy/wy.json"),'w',encoding='utf-8')  as f:
        #, ensure_ascii=False 防止中文unicode 乱码
        f.write(json.dumps(catalogs, ensure_ascii=False))


import time

# get all category html 
def get_category_html():
    catalogs=[] # utf-8-sig
    with open(os.path.join(root_dir, "wy/wy.json"),'r',encoding='utf-8')  as f:
        catalogs=json.loads(f.read())
    http=HttpHelper()
    for it in catalogs:
        time.sleep(0.05) #s
        res=http.get("https:"+it['href'],"",wangyi)
        import hashlib
        sha = hashlib.sha1(it['name'].encode('utf-8'))
        encrypts = sha.hexdigest()
        print(encrypts)
        #if res!='teimout':
        if res!='timeout':
            with open(os.path.join(root_dir, "wy/"+encrypts+".html"),'w',encoding='utf-8')  as f:
               f.write(res)



# ==================== parse list  html
first_names=['热门','精选']
def parse_category_html():
    catalogs=[] # utf-8-sig
    with open(os.path.join(root_dir, "wy/wy.json"),'r',encoding='utf-8')  as f:
        catalogs=json.loads(f.read())
    datas={}
    for it in catalogs:
        import hashlib
        sha = hashlib.sha1(it['name'].encode('utf-8'))
        encrypts = sha.hexdigest()
        print(encrypts)
        with open(os.path.join(root_dir, "wy/"+encrypts+".html"),'r',encoding='utf-8')  as f:
            res=f.read()
            news=[]
            if it['name'] in first_names:
                news=parsr_hot(res)
            else :
                news=parsr_tt(res)
            datas[encrypts]=news 
    with open(os.path.join(root_dir, "wy/data.json"),'w',encoding='utf-8')  as f:
        f.write(json.dumps(datas, ensure_ascii=False))
    print(datas)

# 热门 精选
def parsr_hot(html):
    soup=BeautifulSoup(html,"html5lib")
    lis=soup.find(class_="news-list").find_all("li")
    news=[] 
    for it in lis:
        div=it.find("div",class_="source")
        spans=div.find_all("span")
        img=it.find("div",class_="img")
        title=it.find("div",class_="title").find("a")
        new={"title":title.text,"href":title.attrs['href'],
                 
                 'source':spans[0].text,'published_at':spans[1].text}
        #  img.attrs.has_key(): ex
        if img:
            if 'data-img' in img.attrs:
                new['img']=img.attrs['data-img']
            else:
                new['img']=img.find('img').attrs['src']
        news.append(new)
    return news

# 头条 历史 电台 军事 航空 要闻 
# 娱乐 影视 ... 大部分相同没有一一检测 自己去看页面
def parsr_tt(html):
    soup=BeautifulSoup(html,"html5lib")
    lis=soup.find('div',class_="m-news-list").find_all("li")
    news=[] 
    for it in lis:
        time=it.find('div',class_='public-time')
        a=it.find("a")
        #title=it.find("p",class_="news-title")
        title=it.find(class_="news-title")
        if a and title and time:
            new={"title":title.text,"href":a.attrs['href'],
                 'published_at':time.text} 
        else :
            author=it.find('div',class_='author')
            pic=it.find('div',class_='m-header').find('img')
            new={"author_name":author.find(class_='name').text,"pic":pic.attrs['src'],
                 'info':it.find(class_='m-tag-box').text,'title':it.find(class_='m-viewpoint').text,
                 "href":it.find(class_='m-viewpoint').attrs['data-href'],
                   'source':it.find(class_='m-tag-box').text,#m-tag-box
                   'like_count':it.find('span',class_='like-count').text,
                   'comments_count':it.find(class_='comment').find_all('span')[1].text}
            if it.find('video'):
                new["video"]=it.find('video').attrs['src']
            else:
                imgs=it.find(class_='m-gallery').find_all('img')
                new['img']=[]
                for x in imgs:
                    new['img'].append(x.attrs['src'])
            if author.find(class_='incentive-icons').find('img'):
                new['incentive']=author.find(class_='incentive-icons').find('img').attrs['src'],
            news.append(new)
            continue
        new['img']=[]
        #if len(imgs)==1:
        #    new['img']=imgs[0].attrs['src']
        if it.find("div",class_="img-wrap") and it.find("div",class_="img-wrap").find_all('img'):
            imgs=it.find("div",class_="img-wrap").find_all('img')
            for x in imgs:
                new['img'].append(x.attrs['src'])
        if it.find('div',class_='reply-count'):
            replay_count=it.find('div',class_='reply-count').find('span')
            new['replay_count']=replay_count.text
        
        news.append(new)
    return news




# detail
# detail html
def get_detail_html():
    datas=[]
    with open(os.path.join(root_dir, "wy/data.json"),'r',encoding='utf-8')  as f:
        datas=json.loads(f.read())
    http=HttpHelper()
    for it in datas:
        its=datas[it]
        for x in its:
            # 爬取 好慢 线程 无效 GIL 多进程 分布式 多进程
            time.sleep(0.1) #s
            href=(x['href'] if x['href'].startswith('http') else ("https"+x['href']))
            res=http.get(href,"","")
            import hashlib
            sha = hashlib.sha1(href.encode('utf-8'))
            encrypts = sha.hexdigest()
            print(encrypts)
            #if res!='teimout':
            if res!='timeout':
                with open(os.path.join(root_dir, "wy/details/"+encrypts+".html"),'w',encoding='utf-8')  as f:
                   f.write(res)

# 解析分类 
html=read()
parse_catagory(html)

# 一旦抓取失败解析也有问题 
#get_category_html()

# 解析 各 分类 列表数据
#parse_category_html()

#get_detail_html()

import time ,datetime 
import numpy as np
import threading
from concurrent.futures import ThreadPoolExecutor, as_completed, wait, ALL_COMPLETED, FIRST_COMPLETED



#进程池
from multiprocessing import Pool,Process
from multiprocessing.managers  import BaseManager
class TaskHelper:
     threadings=[]
     tasks=[]
     processes=[]
     pp=None # Pool
     threadings=[]
     tasks=[]
     executor=None # ThreadPoolExecutor
     def thread(self):
         pass

     def thread_pool(self,num=2):
         self.executor = ThreadPoolExecutor(max_workers=num)
         #thread.start_new_thread ( target=read_excel_by_file,args= (dir,d,fs) )
         #t=executor.submit(read_excel_by_file, (dir,d,fs))
         #tasks.append(t)
            
         #使用map方法，无需提前使用submit方法，map方法与python标准库中的map含义相同，都是将序列中的每个元素都执行同一个函数。上面的代码就是对urls的每个元素都执行 read_excel_by_file 函数，
         # 并分配各线程池。可以看到执行结果与上面的as_completed方法的结果不同，输出顺序和 fs 列表的顺序相同
         #for data in executor.map(read_excel_by_file, fs):
         #    print("in main: read_excel_by_file {}s success".format(data)
         t=threading.Thread (target=read_excel_by_file,args= (dir,d,fs) )
         t.start()
         self.threadings.append(t)

     
      
     def exit_thread_pool(self):
        # 反应有点慢 最好 控制线程 数 还以为程序出现问题 手动 退出不了 只能 杀死进程
        # 消息 队列 一边读一边 写
        
        """
        as_completed()方法是一个生成器，在没有任务完成的时候，会阻塞，在有某个任务完成的时候，
        会yield这个任务，就能执行for循环下面的语句，然后继续阻塞住，循环到所有的任务结束。从结果也可以看出，先完成的任务会先通知主线程
        """
        #for future in as_completed(tasks):
        #    data = future.result()
        #    print("in main: read_excel_by_file {}s success".format(data))

        """
        wait方法接收3个参数，等待的任务序列、超时时间以及等待条件。等待条件return_when默认为ALL_COMPLETED，表明要等待所有的任务都结束。
        可以看到运行结果中，确实是所有任务都完成了，主线程才打印出main。等待条件还可以设置为FIRST_COMPLETED，表示第一个任务完成就停止等待
        """
        #wait(tasks, return_when=ALL_COMPLETED)

        for  t in    self.threadings:
            t.join()   
        print("子线程运行 结束") 

     def process(self):
        # 拒绝访问。
        p = Process(target=read_excel_by_file,args= (dir,d,fs,)) 
        p.start() 
        self.processes.append(p)  

     def exit_process(self):
        for  p in    self.processes:
            p.join()   
        print("子进程运行 结束") 
     def process_pool(self,num=2):
        self.pp = Pool(num)
        # 创建进程,放入进程池统一管理
        #pp.apply_async(read_excel_by_file,args=(dir,d,fs,))
     
     def exit_process_pool(self):
        if self.pp==None:
            return
        # 在调用join之前必须先关掉进程池  
        # 进程池一旦关闭  就不能再添加新的进程了
        self.pp.close()
        # 进程池对象调用join,会等待进程池中所有的子进程结束之后再结束父进程
        self.pp.join()
        print("父进程结束...")

