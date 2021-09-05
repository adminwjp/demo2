# from shop_for_flask import db

import json

from sqlalchemy import Column, Integer, String, Boolean, DECIMAL, ForeignKey,DateTime,BigInteger  
from shop_for_flask.database import  Base
from sqlalchemy.orm import  relationship  #创建关系

import decimal
import re

#decimal.Decimal(obj.price)
class Cartinfor(Base):
	__tablename__="t_cart"
	id=Column(Integer,primary_key=True,autoincrement=True)
	image = Column(String(200))
	attr_val = Column(String(20))
	stock =Column(Integer)
	title =Column(String(20))
	price = Column(DECIMAL)
	now_price = Column(DECIMAL)
	is_check = Column(Boolean)
	number = Column(Integer)
	product_id=Column(BigInteger)
	add_time=Column(BigInteger)
	last_time=Column(BigInteger)
	@staticmethod
	def json_str(obj):
		dic={
			"id": obj.id,      
			"image": obj.image,
			"attr_val": obj.attr_val,
			"stock": obj.stock,
			"title": obj.title,
			# ex
			#"price":decimal.Decimal(obj.price)  if  obj.price.isdecimal() else obj.price  ,
			"number": obj.number,
			"is_check": obj.is_check,
			"add_time": obj.add_time,
			"last_time": obj.last_time,
		}
		#dic["price"]=re.findall(r"\d{1,}?\.\d{2}", str(obj.price)), 
		p=str(obj.price).split('.')
		dic["price"]=p[0] + '.' + p[1][:2] #re.match(r"(\d{1,}?\.\d{2,2})", str(obj.price)).group(1)  ,
		#dic["now_
		#price"]=None if obj.now_price==None else re.findall(r"\d{1,}?\.\d{2}", str(obj.now_price)), 
		p=None if obj.now_price==None else (str(obj.now_price).split('.'))
		if p!=None:
			dic["now_price"]= p[0] + '.' + p[1][:2]   # re.match(r"(\d{1,}?\.\d{2,2})", str(obj.now_price )).group(1)  ,
		else :
			dic["now_price"]=''
		return dic

#decimal.Decimal(obj.price)
class Cataloginfor(Base):
	__tablename__="t_catalog"
	id=Column(Integer,primary_key=True,autoincrement=True)
	parent_id = Column(BigInteger,ForeignKey("t_catalog.id"))
	parent =  relationship("Cataloginfor",remote_side=[id],backref="t_catalog", cascade="all", lazy="joined") 
	children=[]
	#parent =  relationship("Cataloginfor",,backref="t_catalog_of_t_catalog") 
	name = Column(String(20))
	picture =Column(String(100))
	picture_id=Column(BigInteger)
	@staticmethod
	def json_str(obj):
		dic={
			"id": obj.id,      
			"parent_id": obj.parent_id,
			"name": obj.name,
			"picture": obj.picture,
			"children": obj.children,
		}
		return dic



class Product(Base):
	__tablename__="t_product"
	id=Column(Integer,primary_key=True,autoincrement=True)
	title = Column(String(50))
	price = Column(DECIMAL)
	now_price = Column(DECIMAL)
	sales = Column(BigInteger)
	image = Column(String(50))
	image2 = Column(String(50))
	image3 = Column(String(50))
	catalog_id = Column(BigInteger)

	@staticmethod
	def json_str(ob):
		dic={}
		dic["id"] = ob.id 
		dic["title"]=ob.title
		dic["price"]=re.match(r"(\d{1,}?\.\d{2,2})", str(ob.price)).group(1)
		dic["now_price"]=None if ob.now_price==None else re.findall(r"\d{1,}?\.\d{2}", str(ob.now_price))
		dic["sales"]=ob.sales
		dic["image"]=ob.image
		dic["image2"]=ob.image2
		dic["image3"]=ob.image3
		return dic


