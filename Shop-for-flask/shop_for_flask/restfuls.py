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


from flask import request,abort

from shop_for_flask.session import Session #,  session
import shop_for_flask.base_restfuls as  base

"""
address restful start
"""

@app.route("/api/v1/address/insert",methods={"POST"})
def insert_address():
    """
    单个地址添加
    This is the language awesomeness API
    Call this api passing a language name and get back its features
    ---
    tags:
      - Awesomeness Language API
    parameters:
      - name: language
        in: path
        type: string
        required: true
        description: The language name
      - name: size
        in: query
        type: integer
        description: size of awesomeness
    responses:
      500:
        description: Error The language is not awesome!
      200:
        description: A language with its awesomeness
        schema:
          id: awesome
          properties:
            language:
              type: string
              description: The language name
              default: Lua
            features:
              type: array
              description: The awesomeness list
              items:
                type: string
              default: ["perfect", "simple", "lovely"]

    """
    data=model.Addressinfor()
    _json.dic2class(request.json,data)
    session = Session()
    if(data.default):
        old=session.query(model.Addressinfor).filter({model.Addressinfor.default==True}).first()
        if old:
           old.default=False # 修改默认地址
    session.add(data)
    session.commit()
    engine.dispose()  #关闭连接
    res={"success":True,"note":"success","code":200}
    return res

from mapper.object_mapper import ObjectMapper
mapper = ObjectMapper()

@app.route("/api/v1/address/update",methods={"POST"})
def update_address():
    """ 单个地址添加  """
    data=model.Addressinfor()
    #data=model.Address()
    _json.dic2class(request.json,data)
    session = Session()
    if(data.default):
        old=session.query(model.Addressinfor).filter((model.Addressinfor.default==True)).first()
        if old:
           old.default=False # 修改默认地址
    old1=session.query(model.Addressinfor).filter_by(id=request.json["id"]).first()
    old1.name=data.name
    old1.mobile=data.mobile
    old1.address_name=data.address_name
    old1.address=data.address
    old1.area=data.area
    old1.default=data.default
    session.commit()
    engine.dispose()  #关闭连接
    res={"success":True,"note":"success","code":200}
    return res

#https://docs.sqlalchemy.org/en/13/orm/tutorial.html#common-filter-operators
@app.route("/api/v1/address/list/<int:page>/<int:size>",methods={"POST", "GET"})
def get_list_address(page, size):
    """ 地址查询  """
    def get_list_address_sort(p,s):
        session = Session()
        data=session.query(model.Addressinfor).order_by(model.Addressinfor.default.desc()).slice((p - 1) * s, p * s).all()
        return data
    # ex
    #re=get_list(request,model.Addressinfor,page ,size,model.Addressinfor.default.desc())
    re=base.get_list(request,model.Addressinfor,page ,size,get_list_address_sort)
    return re

@app.route("/api/v1/address/insert_many",methods={"POST"})
def insert_many_address():
    """ 多个地址添加  """
    def insert_many__address(da):
        return da.addresses
    re=base.insert_many(request,AddressList(),insert_many__address)
    return re

class AddressList:
    addresses=[model.Addressinfor()]

"""
address restful end
"""

"""
notice restful start
"""

@app.route("/api/v1/notice/insert",methods={"POST"})
def insert_notice():
    data=model.Notice()
    return base.insert(request,data)


@app.route("/api/v1/notice/update",methods={"POST"})
def update_notice():
    data=model.Notice()
    def map(new1,old1):
        old1.times=new1.times
        old1.title=new1.title
        old1.pic=new1.pic
        old1.introduce=new1.introduce
        old1.end=new1.end
    return base.update(request,data,model.Notice,map)

#https://docs.sqlalchemy.org/en/13/orm/tutorial.html#common-filter-operators
@app.route("/api/v1/notice/list/<int:page>/<int:size>",methods={"POST", "GET"})
def get_list_notice(page, size):
    def get_list_notices_sort(p,s):
        session = Session()
        data=session.query(model.Notice).slice((p - 1) * s, p * s).all()
        return data
    re=base.get_list(request,model.Notice,page ,size,get_list_notices_sort)
    return re

@app.route("/api/v1/notice/insert_many",methods={"POST"})
def insert_many_notice():
    def insert_many__notices(da):
        return da.notices
    re=base.insert_many(request,NoticeList(),insert_many__notices)
    return re

class NoticeList:
    notices=[model.Notice()]

"""
notice restful start
"""

"""
share restful start
"""

@app.route("/api/v1/share/insert",methods={"POST"})
def insert_share():
    data=model.Share()
    return base.insert(request,data)


@app.route("/api/v1/share/update",methods={"POST"})
def update_share():
    data=model.Share()
    def map(new1,old1):
        old1.icon=new1.icon
        old1.text=new1.text
    return base.update(request,data,model.Share,map)

#https://docs.sqlalchemy.org/en/13/orm/tutorial.html#common-filter-operators
@app.route("/api/v1/share/list/<int:page>/<int:size>",methods={"POST", "GET"})
def get_list_share(page, size):
    def get_list_share_sort(p,s):
        session = Session()
        data=session.query(model.Share).slice((p - 1) * s, p * s).all()
        return data
    re=base.get_list(request,model.Share,page ,size,get_list_share_sort)
    return re

@app.route("/api/v1/share/insert_many",methods={"POST"})
def insert_many_share():
    def insert_many__shares(da):
        return da.shares
    re=base.insert_many(request,ShareList(),insert_many__shares)
    return re

class ShareList:
    shares=[model.Share()]

"""
share restful start
"""

"""
carousel restful start
"""

@app.route("/api/v1/carousel/insert",methods={"POST"})
def insert_carousel():
    data=model.Carousel()
    return base.insert(request,data)


@app.route("/api/v1/carousel/update",methods={"POST"})
def update_carousel():
    data=model.Carousel()
    def map(new1,old1):
        old1.src=new1.src
        old1.background=new1.background
    return base.update(request,data,model.Carousel,map)

#https://docs.sqlalchemy.org/en/13/orm/tutorial.html#common-filter-operators
@app.route("/api/v1/carousel/list/<int:page>/<int:size>",methods={"POST", "GET"})
def get_list_carousel_v1(page, size):
    return get_list_carousel(page,size)

def get_list_carousel(page, size):
    def get_list_address_sort(p,s):
        session = Session()
        data=session.query(model.Carousel).slice((p - 1) * s, p * s).all()
        return data
    re=base.get_list(request,model.Carousel,page ,size,get_list_address_sort,model.Carousel.id)
    return re

@app.route("/api/v1/carousel/list",methods={"post", "get"})
def get_list_carousel_by_p_s():
    page=1
    size=10
    if len(request.args)>0:
        if 'page' in request.args:
            page=request.args['page']
            page=int(page)
        if 'pi' in request.args:
            page=request.args['pi']
            page=int(page)
        if 'rows'in request.args:
            size=request.args['rows']
            size=int(size)
        if 'ps' in request.args:
            size=request.args['ps']
            size=int(size)
    return get_list_carousel(page,size)

@app.route("/api/v1/carousel/insert_many",methods={"POST"})
def insert_many_carousel():
    def insert_many__carousels(da):
        return da.carousels
    re=base.insert_many(request,CarouselList(),insert_many__carousels)
    return re

class CarouselList:
    carousels=[model.Carousel()]

"""
carousel restful start
"""

