# orm

# pip install PyMySQL
# pip install sqlalchemy


import platform

print(platform.system())

if(platform.system()=="Windows"):
    print("Windows系统")
elif(platform.system()=="Linux"):
    print("Linux系统")
else:
    print("其他")

from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()
from sqlalchemy import create_engine

# sqlite://<nohostname>/<path>
# where <path> is relative:

engine = create_engine("sqlite:///e:/work/db/sqlite/company.db")


from sqlalchemy import Column, Integer, String, Boolean,DECIMAL, ForeignKey, Date, DateTime
from sqlalchemy.orm import  relationship  #创建关系
import os

class Companyifor(Base):
    __tablename__="t_company"
    id=Column(Integer,primary_key=True,autoincrement=True)
    #id=Column(Integer,primary_key=True)
    company_name = Column(String(100)) # 公司名称
    corporation = Column(String(30)) # 公司法人
    registered_capital =Column(String(100)) # 注册资本
    #registration_time =Column(Date) # 注册时间
    registration_time =Column(String(20)) # 注册时间
    address = Column(String(200)) # 地址
    business_address = Column(String(200)) # 企业地址
    mailbox = Column(String(1000)) # 邮箱
    business_scope = Column(String(2000)) # 经营范围
    #get_time =Column(Date) # 获取时间
    get_time =Column(String(20)) # 获取时间
    catalog =Column(String(100)) # 分类 
    children_catalog =Column(String(100)) # 子分类
    status =Column(String(10)) # 状态
    times =Column(String(100)) # 注册时间 范围
    create_time =Column(String(20)) # 创建时间
    update_time =Column(String(20)) # 更新时间

Base.metadata.create_all(engine, checkfirst=True)

import time ,datetime 
import pandas as pd
import numpy as np
import threading

import traceback
from sqlalchemy.orm import sessionmaker

# pip3 install  pands -i http://pypi.douban.com/simple --trusted-host pypi.douban.com
# pip3 install  xlrd -i http://pypi.douban.com/simple --trusted-host pypi.douban.com
# pip3 install  openpyxl -i http://pypi.douban.com/simple --trusted-host pypi.douban.com
# pip install DBUtils -i http://pypi.douban.com/simple --trusted-host pypi.douban.com
# pip install pymysql -i http://pypi.douban.com/simple --trusted-host pypi.douban.com
# https://blog.csdn.net/weixin_34007020/article/details/85958509?utm_medium=distribute.pc_relevant.none-task-blog-OPENSEARCH-6.control&dist_request_id=&depth_1-utm_source=distribute.pc_relevant.none-task-blog-OPENSEARCH-6.control
# Ray自称是面向AI应用的分布式计算框架，但是它的架构具有通用的分布式计算抽象
# pip intall ray   -i http://pypi.douban.com/simple --trusted-host pypi.douban.com
#python本身的设计对多线程的执行有所限制。为了数据安全设计有GIL全局解释器锁。在python中，一个线程的执行包括获取GIL、执行代码直到挂起和释放GIL。
# 每次释放GIL锁，线程之间都会进行竞争，由拿到锁的线程进入cpu执行，所以由于GIL锁的存在，python里的一个进程永远只能同时执行一个线程。
# https://www.jianshu.com/p/dd1b4077666e
#进程池
from multiprocessing import Pool,Process
from multiprocessing.managers  import BaseManager
from concurrent.futures import ThreadPoolExecutor, as_completed, wait, ALL_COMPLETED, FIRST_COMPLETED
import time,pymysql,sqlite3,queue

task_queue=queue.Queue()
result_queue=queue.Queue()

def return_task_queue():
    global task_queue
    return task_queue

def return_result_queue():
    global result_queue
    return result_queue   

class QueueManager (BaseManager):
     pass

# https://blog.csdn.net/tpc4289/article/details/79281347?utm_medium=distribute.pc_relevant.none-task-blog-2%7Edefault%7EBlogCommendFromMachineLearnPai2%7Edefault-10.control&dist_request_id=1328741.46346.16170508738191371&depth_1-utm_source=distribute.pc_relevant.none-task-blog-2%7Edefault%7EBlogCommendFromMachineLearnPai2%7Edefault-10.control
def init():
    QueueManager.register("get_task_queue",callable=return_task_queue)
    QueueManager.register("get_result_queue",callable=return_result_queue)

    manager=QueueManager(address=("127.0.0.1",5001),authkey=b"abc")
    manager.start()

    task=manager.get_task_queue()
    result=manager.get_result_queue()

    for i in range(10):
        n = random.randint(0, 10000)
        print("Put task %d" % n)
        task.put(n)
 
    print("Try get results..")
    for i in range(10):
        r = result.get(timeout=10)
        print("Result:%s" % r)
    
    manager.shutdown()
    print("master exit.")
# main

# https://blog.csdn.net/wudiazu/article/details/80925692?utm_medium=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7EBlogCommendFromMachineLearnPai2%7Edefault-1.control&dist_request_id=&depth_1-utm_source=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7EBlogCommendFromMachineLearnPai2%7Edefault-1.control
"""
实现多任务的方式:
1、多进程方式    pandas error 
2、多线程方式  
3、协程方式
4、多进程+多线程 process error
"""

# pandas 多进程操作异常 进程池
# pandas\io\excel\_base.py

def save_mysql(pool, sql, args):
    """
    保存数据库 
    :param sql: 执行sql语句
    :param args: 添加的sql语句的参数 list[tuple]
    """
    try:
        db = pool.connection()  # 连接数据池
        cursor = db.cursor()  # 获取游标
        cursor.executemany(sql, args)
        db.commit()
        cursor.close()
        db.close()
    except:
        traceback.print_exc()

"""
进程池 多进程+多线程
 An attempt has been made to start a new process before the
current process has finished its bootstrapping phase.

This probably means that you are not using fork to start your
child processes and you have forgotten to use the proper idiom
in the main module:

assert self._popen is not None, "can only join a started process"
AssertionError: can only join a started process
The "freeze_support()" line can be omitted if the program
is not going to be frozen to produce an executable.
"""
def read(dir):
    start=time.time()
    print("dir:{}".format(dir))
    """
    创建数据库连接池
    :return: 连接池
    """
    pool = PooledDB(creator=sqlite3,
                    maxconnections=0,  # 连接池允许的最大连接数，0和None表示不限制连接数
                    mincached=4,  # 初始化时，链接池中至少创建的空闲的链接，0表示不创建
                    maxcached=0,  # 链接池中最多闲置的链接，0和None不限制
                    maxusage=1,  # 一个链接最多被重复使用的次数，None表示无限制
                    blocking=True  # 连接池中如果没有可用连接后，是否阻塞等待。True，等待；False，不等待然后报错
                    # mysql
                    #host="127.0.0.1",  # 此处必须是是127.0.0.1
                    #port=3306,
                    #user="root",
                    #passwd="123456",
                    #db="localhost",
                    #use_unicode=True,
                    #charset="utf8"
                    )

    dirs=os.listdir(dir)
    threadings=[]
    processes=[]
    tasks=[]
    print("父进程开始...")
    #tasks=[]
    flag=2 # 1 进程池 2 多线程 3 进程 进程  4 单线程处理 不要 开多 容易 cpu 满了 1 > 2
    # 创建进程池
    # 如果没有参数  默认大小为自己电脑的CPU核心数
    # 表示可以同时执行的进程数量
    pp=None
    executor=None
    if flag==1:
        pp = Pool(2)
    elif flag==2:
        executor = ThreadPoolExecutor(max_workers=2)
    for d in dirs:
        print("dir: {} children dir:{}".format(dir,d))
        fs=os.listdir("{0}\{1}".format(dir,d))
        def read_excel_by_file(dir,d,fs):
            
            for f in fs:
                print("children dir:{} file:{}".format(d,f))
                if flag < 5 : # flag==2 :
                    company_insert_task(dir,d,f)
                else :
                    t=executor.submit(company_insert_task, (dir,d,fs))
                    tasks.append(t)

                    #t=threading.Thread (target=company_insert_task,args= (dir,d,fs) )
                    #t.start()
                    #threadings.append(t)
            if flag >5:  # flag!=2:
                for  t in    threadings:
                    t.join()      
                threadings.clear()   

        if flag==2:
            #thread.start_new_thread ( target=read_excel_by_file,args= (dir,d,fs) )

            #t=executor.submit(read_excel_by_file, (dir,d,fs))
            #tasks.append(t)
            
            #使用map方法，无需提前使用submit方法，map方法与python标准库中的map含义相同，都是将序列中的每个元素都执行同一个函数。上面的代码就是对urls的每个元素都执行 read_excel_by_file 函数，
            # 并分配各线程池。可以看到执行结果与上面的as_completed方法的结果不同，输出顺序和 fs 列表的顺序相同
            #for data in executor.map(read_excel_by_file, fs):
            #    print("in main: read_excel_by_file {}s success".format(data)


            t=threading.Thread (target=read_excel_by_file,args= (dir,d,fs) )
            t.start()
            threadings.append(t)
        elif flag==1:
            # 创建进程,放入进程池统一管理
            pp.apply_async(read_excel_by_file,args=(dir,d,fs,))
        elif flag==3:
            # 拒绝访问。
            p = Process(target=read_excel_by_file,args= (dir,d,fs,)) 
            p.start() 
            processes.append(p)  
        else :
            read_excel_by_file(dir,d,fs)

        
    print("主线程运行中")    
    if flag==1:
        # 在调用join之前必须先关掉进程池  
        # 进程池一旦关闭  就不能再添加新的进程了
        pp.close()
        # 进程池对象调用join,会等待进程池中所有的子进程结束之后再结束父进程
        pp.join()
        print("父进程结束...")

   
    elif flag==2: 
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

        for  t in    threadings:
            t.join()   
        print("子线程运行 结束")  
    
    elif flag==3:    
        for  p in    processes:
            p.join()   
        print("子进程运行 结束")      
    
    end=time.time()
    print("dir:{} all file free {} ms ".format(dir,end-start))

# https://blog.csdn.net/weixin_39867212/article/details/111070604
# engine 中创建的连接  多线程 只能操作 单个 安全 Session

# 多线程 下 操作不安全
# 不支持多个(不能太多) 单个支持 
# sqlalchemy.orm.exc.UnmappedInstanceError: Class "sqlalchemy.orm.decl_api.DeclarativeMeta" is not mapped; was a class (__main__.Companyifor) supplied where an instance was required?
def company_insert_task(dir,d,f):

    arr=[Companyifor]
    read_company_excel(arr,dir,d,f) # 读取 几 千 条数据 有点慢

    return 
    session_factory = sessionmaker(bind=engine)
    from sqlalchemy.orm import scoped_session
    # 创建Session类实例
    Session=scoped_session(session_factory) 
    #some_session = session_factory()
    #100
    l=len(arr)
    rows=100
    eindex=rows
    sindex=0
    if eindex>l:
        eindex=l-1
    while eindex<l:
        some_session=Session()
        some_session.add_all(arr[sindex:eindex]) # type object "Companyifor" has no attribute "_sa_instance_state"
        # 当前更改只是在session中，需要使用commit确认更改才会写入数据库
        some_session.commit()
        #engine.dispose()  #关闭连接
        some_session.close()
        eindex=eindex+rows
        sindex=sindex+rows
        if eindex>l:
            eindex=l-1
            break
    if eindex+1==l:
        some_session=Session()
        some_session.add_all(arr[sindex:eindex]) # type object "Companyifor" has no attribute "_sa_instance_state"
        # 当前更改只是在session中，需要使用commit确认更改才会写入数据库
        some_session.commit()
        #engine.dispose()  #关闭连接
        some_session.close()   
           
    some_session.remove()
    arr.clear()
    print("批量插入成功")
    #print("{} {} {}".format(df[3:0],df[3:1],df[3:2]))
    #df=df.head()
    #print(df)

# 多线程 下 操作不安全
#some_session = session_factory()

#
# SQLite DateTime type only accepts Python datetime and date objects as input.
# SQLite Date type only accepts Python datetime and date objects as input.
def company_insert_one_task(it):
    session_factory = sessionmaker(bind=engine)
    from sqlalchemy.orm import scoped_session
    # 创建Session类实例
    Session=scoped_session(session_factory)

    some_session=Session()
    some_session.add(it)
    #some_session.add_all(it) # type object "Companyifor" has no attribute "_sa_instance_state"
    # 当前更改只是在session中，需要使用commit确认更改才会写入数据库
    some_session.commit()
    engine.dispose()  #关闭连接

    some_session.close()
    Session.remove()
    print("插入成功")
    #print("{} {} {}".format(df[3:0],df[3:1],df[3:2]))
    #df=df.head()
    #print(df)  

def read_company_excel(arr,dir,d,f):
    names=f.split("-")
    catalog=names[0]
    children_catalog=names[1]
    status=names[2]
    times=""
    t=d
    if len(names)==5:
        times="{}-{}".format(names[3],names[4].replace(".xlsx",""))
    df =pd.read_excel(r"{}\{}\{}".format(dir,d,f),0, header=2)
    col_count = df.shape[1]
    row_count = df.shape[0]
    print("row :{} col:{}".format(row_count,col_count))
    i=3
    while i<row_count:
        if i>3:
            df =pd.read_excel(r"{}\{}\{}".format(dir,d,f),0, header=i)
        #columns=df[i].columns # error
        columns=df.columns # pass index
        #columns=df.columns[i] # pass str
        #columns=df[i:col_count] # pass DataFrame
        #columns=df.rows[i].columns # error
        # 读取 列
        #columns=df[:col_count] # pass DataFrame
        #print(type(columns))
        columns=columns.to_numpy() # array
        #print(type(columns))
        #print(len(columns)) #6
        companyifor =Companyifor()
        companyifor.catalog=catalog # 分类 
        companyifor.children_catalog=children_catalog # 子分类
        companyifor.status=status # 状态
        companyifor.times=times  # 注册时间 范围
        try:
            read_company_excel_to_object(arr,companyifor,columns,t)
        except:
            #print("out of bounds for {}".format(len(columns)))
            print("ex  out of bounds for {}".format(i))   
        finally:
            pass 
        print(i)
        i=i+1


def read_company_excel_to_object(arr,companyifor,columns,t):
    l=len(columns)
    print(l)
    try:
        if l==0:
            print("nothing ")
            return
        if l>=1 :
            companyifor.company_name=columns[0]  # 公司名称
        if l>=2 :
            companyifor.corporation=columns[1] # 公司法人
        if l>=3 :
            companyifor.registered_capital= columns[2]  # 注册资本
        if l>=4 :
            #print(columns[3])
            companyifor.registration_time=datetime.datetime.strptime(columns[3],"%Y-%m-%d")  # 注册时间
        if l>=5 :
            companyifor.address=columns[4] # 地址
        if l>=6 :
            companyifor.business_address=columns[5]  # 企业地址
        if l>=7 :
            companyifor.mailbox=columns[6] # 邮箱
        if l>=8 :
            companyifor.business_scope=columns[7] # 经营范围

        companyifor.get_time=datetime.datetime.strptime(t,"%Y%m%d") # 获取时间

        companyifor.create_time=time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())  # 创建时间 2222-12-31 23:59:59
        #companyifor.update_time=time.strftime("%Y-%m-%d %H:%M:%S", time.localtime()) # 更新时间
        company_insert_one_task(companyifor)
        #arr.append(companyifor)
    except:
       print("ex nothing {}".format(columns))    
    finally:
        pass

if __name__ == "__main__":
    #freeze_support()
    read("E:\work\csharp\companyexcel")	 
 