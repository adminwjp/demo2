"""
Routes and restfuls for the flask application.
"""

from datetime import datetime
#from shop_for_flask import app, db, model
from shop_for_flask.database import Base,  engine
from shop_for_flask import app, product_model
from utility.util import  j as _json, ma
import json
import sys
import shop_for_flask.base_restfuls as  base


from flask import request

from shop_for_flask.session import Session #,  session




"""
cart restful start
"""
@app.route("/api/v1/cart/insert",methods={"POST"})
def insert_cart():
    """ 购物车添加  """
    def insert_many_cart(da):
        return da.carts
    re=base.insert_many(request,CartList(),insert_many_cart)
    return re

class CartList:
    carts=[product_model.Cartinfor()]

@app.route("/api/v1/cart/list/<int:page>/<int:size>",methods={"POST", "GET"})
def get_list_cart(page, size):
    """ 购物车查询  """
    re=base.get_list(request,product_model.Cartinfor,page ,size)
    return re

@app.route("/api/v1/cart/clear",methods={"GET"})
def clear_cart(page, size):
    """ 购物车 清空  """
    session = Session()
    #data=session.query(model.Cartinfor).limit(size).offset((page-1)*size).all()

    data=session.query(product_model.Cartinfor).delete()
    engine.dispose()  #关闭连接
    session.close()
    res={"success":True,"note":"success","code":200}
    return res

"""
cart restful end
"""

"""
catalog restful start
"""

def skip_catalog(obj,name):
    if(name=="t_catalog"):
        return True
    #v=getattr(obj,name)
    return False

def dic2class_catalog(py_data, obj):
    """
    Dict convert to Class
    通过setattr函数赋值属性，如果有值就赋值属性和值
    """
    for name in [name for name in dir(obj) if not name.startswith("_")]:
        if name not in py_data:
            if(name=="t_catalog"):
                pass
            else: 
                setattr(obj, name, None)
        else:
            value = getattr(obj, name)
            setattr(obj, name, set_value_catalog(value, py_data[name]))

def set_value_catalog(value, py_data):
    """
    设置虚拟类属性值
    """
    if str(type(value)).__contains__("."):
        # value 为自定义类
        dic2class_catalog(py_data, value)
    elif str(type(value)) == "<class 'list'>":
        # value为列表
        if value.__len__() == 0:
            # value列表中没有元素，无法确认类型
            value = py_data
        else:
            # value列表中有元素，以第一个元素类型为准
            child_value_type = type(value[0])
            value.clear()
            for child_py_data in py_data:
                child_value = child_value_type()
                child_value = set_value_catalog(child_value, child_py_data)
                value.append(child_value)
    else:
        value = py_data
    return value


def cursion_add_catalog(se,datas,p):
    if datas and len(datas) > 0:
        for x in datas:
            #"dict" object has no attribute "pid"
            # "Cataloginfor" object does not support item assignment
            #x["pid"]=p.id if p  else None
            #x.parent=p
            # Class "builtins.dict" is not mapped
            c=product_model.Cataloginfor(id=x["id"],name=x["name"],picture=x.get("picture"))
            c.id=None
            c.pid=None
            c.parent=p
            se.add(c)
            #c.parent=None
            cursion_add_catalog(se,x.get("children"),c)
    else:
        pass

@app.route("/api/v1/catalog/insert_many",methods={"POST"})
def insert_many_catalog():
    """ 多个分类添加  """
    #data=CatalogList()
    #j.dic2class(request.json,data)
    #dic2class_catalog(request.json,data)
    # 绑定外键关系
    #不自动关联
    #session.add_all(data.catalogs)
    #sort_catalog(data.catalogs)
    #for x in data.catalogs:
    #    x.pid=None
    #for x in data.catalogs:
    #    session.add(x)

    """ 分类排序 """
    #ls=[]
    catalogs=request.json["catalogs"]
    session = Session()
    cursion_add_catalog(session,catalogs,None)
    #清空 pid
    session.commit() #constraint failed
    res={"success":True,"note":"success","code":200}
    return res

class CatalogList:
    catalogs=[product_model.Cataloginfor()]

@app.route("/api/v1/catalog/list/<int:page>/<int:size>",methods={"POST", "GET"})
def get_list_catalog(page, size):
    """ 分类查询  """
    re=base.get_list(request,product_model.Cataloginfor,page ,size)
    return re

@app.route("/api/v1/catalog/all",methods={"POST", "GET"})
def get_all_catalog():
    """ 分类查询  """
    re=base.get_all(request,product_model.Cataloginfor)
    return re

from sqlalchemy import or_,and_
@app.route("/api/v1/catalog/list",methods={ "GET"})
def get_mobile_all_catalog():
    """ 分类查询  """
    def filter(data):
        return data.filter(or_(product_model.Cataloginfor.parent_id==None, product_model.Cataloginfor.parent_id==0))
    re=base.get_all(request,product_model.Cataloginfor,filter=filter)
    return re

@app.route("/api/v1/home/list",methods={ "GET"})
def get_mobile_home():
    """ 分类查询  """
    def filter(data):
        return data.filter(or_(product_model.Cataloginfor.picture==None, product_model.Cataloginfor.picture==''))
    re=base.get_all(request,product_model.Cataloginfor,filter=filter)
    data={'catagories':re.data}
    data['shop']={'phone':'027-12345678',img:''}
    data['shop']={'phone':'027-12345678',img:''}
    re.data=data
    return re

"""
catalog restful end
"""

"""
product restful start
"""



@app.route("/api/v1/product/insert_many",methods={"POST"})
def insert_many_product():
    def insert_many__products(da):
        return da.products
    re=base.insert_many(request,ProductList(),insert_many__products)
    return re


class ProductList:
    products=[product_model.Product()]

@app.route("/api/v1/product/list/<int:page>/<int:size>",methods={"POST", "GET"})
def get_list_product(page, size):
    """ 分类查询  """
    re=base.get_list(request,product_model.Product,page ,size)
    return re

@app.route("/api/v1/product/all",methods={"POST", "GET"})
def get_all_product():
    """ 分类查询  """
    re=base.get_all(request,product_model.Product)
    return re


# product restful end
