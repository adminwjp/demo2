# from shop_for_flask import db

import json

from sqlalchemy import Column, Integer, String, Boolean, DECIMAL, ForeignKey,DateTime,BigInteger  
from shop_for_flask.database import  Base
from sqlalchemy.orm import  relationship  #创建关系
# https://www.cnblogs.com/kiddy/p/9811508.html
# table/model

"""
class Address(db.Model):
	__tablename__="t_address"
	#_tablename_="t_address"
	id=db.Column(db.Integer,primary_key=True,autoincrement=True)
	name = db.Column(db.String(20))
	mobile = db.Column(db.String(15))
	address_name = db.Column(db.String(100))
	address = db.Column(db.String(100))
	area = db.Column(db.String(50))
	default = db.Column(Boolean)
"""

class Userinfor(Base):
	__tablename__="t_user"
	id=Column(Integer,primary_key=True,autoincrement=True)
	name = Column(String(20))
	email = Column(String(15))
	phone =Column(String(100))
	pwd =Column(String(500))
	token =Column(String(500))
	refresh_token =Column(String(500))
	expried=Column(Integer)
	expried_date=Column(Integer)
	refresh_expried=Column(Integer)
	refresh_expried_date=Column(Integer)
	@staticmethod
	def json_str(obj):
		dic={
			"id": obj.id,      
			"name": obj.name,
			"phone": obj.phone,
			"email": obj.email,
			"token": obj.token,
			"refresh_token": obj.refresh_token,
			"expried": obj.expried,
			"expried_date": obj.expried_date,
			"refresh_expried": obj.refresh_expried,
			"refresh_expried_date": obj.refresh_expried_date,
		}
		return dic



class Sourceinfor(Base):
	__tablename__="t_source"
	id=Column(String(36),primary_key=True)
	src = Column(String(100))
	object_id = Column(String(100))
	buket_name =Column(String(100))
	@staticmethod
	def json_str(obj):
		dic={
			"id": obj.id,      
			"src": obj.src,
			"object_id": obj.object_id,
			"buket_name": obj.buket_name,
		}
		return dic



class Addressinfor(Base):
	__tablename__="t_address"
	id=Column(Integer,primary_key=True,autoincrement=True)
	name = Column(String(20))
	mobile = Column(String(15))
	address_name =Column(String(100))
	address =Column(String(100))
	area = Column(String(50))
	default = Column(String(50))

	@staticmethod
	def json_str(obj):
		dic={
			"id": obj.id,      
			"name": obj.name,
			"mobile": obj.mobile,
			"address_name": obj.address_name,
			"address": obj.address,
			"lyricists": obj.name,
			"area": obj.area,
			"default": obj.default=="1",
		}
		return dic

	@staticmethod
	def parse_many(dic):
		data=dic["addresses"]
		if data == None:
			return None
		arr=[]
		for	i in data:
			a=Addressinfor()
			arr.append(a)
			print(i)
			# ex 
			for key in i.keys():
				setattr(a,key,i[key])
		return arr

import decimal
import re



class Notice(Base):
	__tablename__="t_notice"
	id=Column(Integer,primary_key=True,autoincrement=True)
	times = Column(Integer)
	title = Column(String(20))
	pic =Column(String(100))
	introduce = Column(String(500))
	end = Column(Boolean)

	@staticmethod
	def json_str(ob):
		dic={}
		dic["id"] = ob.id 
		dic["times"]=str(ob.times)
		dic["title"]=ob.title
		dic["pic"]=ob.pic
		dic["introduce"]=ob.introduce
		dic["end"]=ob.end
		return dic



class Carousel(Base):
	__tablename__="t_carousel"
	id=Column(Integer,primary_key=True,autoincrement=True)
	src = Column(String(100))
	background = Column(String(20))
	src_id = Column(String(36))
	@staticmethod
	def json_str(ob):
		dic={}
		dic["id"] = ob.id 
		dic["src"]=ob.src
		dic["src_id"]=ob.src_id
		dic["background"]=ob.background
		return dic


class Share(Base):
	__tablename__="t_share"
	id=Column(Integer,primary_key=True,autoincrement=True)
	icon = Column(String(100))
	text = Column(String(20))
	@staticmethod
	def json_str(ob):
		dic={}
		dic["id"] = ob.id 
		dic["icon"]=ob.icon
		dic["text"]=ob.text
		return dic




# model
#"""
class Address:
	#id=0
	name=""
	mobile=""
	address_name=""
	address=""
	area=""
	default=False
#"""
