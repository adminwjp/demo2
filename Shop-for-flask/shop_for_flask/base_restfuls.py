"""
Routes and restfuls for the flask application.
"""

from datetime import datetime
#from shop_for_flask import app, db, model
from shop_for_flask.database import Base,  engine
from shop_for_flask import app, model
from utility.util import  j as _json, ma
import json
import sys

from flask import request
import sqlalchemy
from sqlalchemy import distinct

from shop_for_flask.session import Session #,  session
Session=Session
#session=session
# 注意 flask 添加东西 后 需要重新启动 麻烦 不像 django 一样 自动 运行
#请求  python 太灵活 了 怎么 控制  手动控制

@app.route("/test")
def test():
    return "test"

@app.route("/ex")
def ex():
    raise Exception("test ex")
    return "ex"


def insert(request,data):
    """ 单个添加  """
    _json.dic2class(request.json,data)
    session = Session()
    session.add(data)
    session.commit()
    engine.dispose()  #关闭连接
    res={"success":True,"note":"success","code":200}
    return res


def update(request,data,mod,map):
    """ 单个添加  """
    _json.dic2class(request.json,data)
    session = Session()
    old1=session.query(mod).filter_by(id=request.json["id"]).first()
    map(data,old1)
    session.commit()
    engine.dispose()  #关闭连接
    res={"success":True,"note":"success","code":200}
    return res

#https://docs.sqlalchemy.org/en/13/orm/tutorial.html#common-filter-operators
def get_list(request,mod,page, size,sort=None,count_field=None,filter=None):
    """ 查询  """
    if size>0 and size<10:
        pass
    else :
        size=10
    if page>0 and page<1000 :
        pass
    else :
        page=1
    session = Session()
    #data=session.query(mod).limit(size).offset((page-1)*size).all()
    data=None
    if sort:
       # ex
       #data=session.query(mod).order_by(sort).slice((page - 1) * size, page * size).all()
       data=sort(page,size)
    else:
        if filter:
            #data=session.query(mod).filter_by(filter).limit(size).offset((page-1)*size).all()
            data=filter(session.query(mod)).limit(size).offset((page-1)*size).all()
        else:
            data=session.query(mod).limit(size).offset((page-1)*size).all()
    count=get_count(count_field,session=session)
    engine.dispose()  #关闭连接
    #session.close()
    arr=[]
    for x in data:
        it=mod.json_str(x)
        arr.append(it)
    res={"success":True,"note":"success","code":200,"data":arr,'records':count,'page':page,'size':size}
    return res

def get_count(field,filter=None,session=None):
    session =session if session else Session()
    if filter==None:
        return  session.query(sqlalchemy.func.count(distinct(field))).scalar()
    # return  session.query(sqlalchemy.func.count(distinct(field))).filter(filter).scalar()
    return filter(session.query(sqlalchemy.func.count(distinct(field)))).scalar()
def get_all(request,mod,count_field=None,filter=None):
    """ 查询  """
    session = Session()
    if filter:
        #data=session.query(mod).filter(filter).all()
        data=filter(session.query(mod)).all()
        count=get_count(count_field,filter,session=session)
    else:
        data=session.query(mod).all()
        count=get_count(count_field,session=session)
    
    engine.dispose()  #关闭连接
    #session.close()
    arr=[]
    for x in data:
        it=mod.json_str(x)
        arr.append(it)
    #  123.00 -> 123.0000000000
    res={"success":True,"note":"success","code":200,"data":arr,'records':count}
    return res

def insert_many(request,data,listSuc):
    """ 多个添加  """

    """
    postForm=request.form
    print(postForm)
    queryStrings=request.args
    print(queryStrings)
    postBody=request.values
    print(postBody)
    """

    # body json
    """
    print(request.form) # ImmutableMultiDict([])
    print(request.data) # b"{}" #unicode 乱码
    print(request.method)  # POST
    print(request.values) # CombinedMultiDict([ImmutableMultiDict([]), ImmutableMultiDict([])])
    print(request.headers)
    print(request.args) # ImmutableMultiDict([])
    print(request.json) #{}
    """
    #dic=json.dumps(request.json)
    #print(type(request.json))
    #data=model.Address.parse_many(request.json)

    _json.dic2class(request.json,data)
    #return data # ex 
    # unicde ensure_ascii=False  json.dumps()方法将dict的数据转换为string数据，然后将string写入到文本中，
    # 但是json.dumps()方法会默认将其中unicode码以ascii编码的方式输入到string。
    # orm entity "mappingproxy" object has no attribute "__dict__"
    #js= json.dumps(data,default=lambda x : x.__dict__, sort_keys=False, indent=2, ensure_ascii=False) 
    #js= json.dumps(data.__dict__) #ex
    ls=listSuc(data)
    session = Session()
    session.add_all(ls)
    # 当前更改只是在session中，需要使用commit确认更改才会写入数据库
    session.commit()
    res={"success":True,"note":"success","code":200}
    # 自定义 实体不支持 嵌套 dict 不支持
    return res
