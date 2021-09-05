from sqlalchemy import Column,Boolean, Integer,BigInteger, String, Boolean, DECIMAL, ForeignKey  
from shop_for_flask.database import  Base
from sqlalchemy.orm import  relationship  #创建关系
# https://www.cnblogs.com/kiddy/p/9811508.html
# table/model
class Comment(Base):
	'''
	评论实体
	'''

	__tablename__="t_comment"
	id=Column(Integer,primary_key=True,autoincrement=True)
	parent_ids = Column(String(200)) #所有父级评论Id集合
	parent_id = Column(BigInteger) #父评论Id（一级ParentId等于0）
	comment_object_id =Column(BigInteger) #被评论对象Id
	owner_id =Column(BigInteger) #拥有者Id
	user_id = Column(BigInteger) #评论人UserId
	author = Column(String(50)) #评论人名称
	subject = Column(String(50)) #标题
	body = Column(String(500000)) #评论内容
	audit_status = Column(Integer) #审核状态
	is_anonymous= Column(Boolean) #是否匿名评论
	is_private= Column(Boolean) #是否悄悄话
	ip= Column(BigInteger) #评论人IP
	comment_date= Column(BigInteger) #评论时间

	@staticmethod
	def from_json(obj):
		dic={
			"id": obj.id,      
			"parent_ids": obj.parent_ids,
			"parent_id": obj.parent_id,
			"comment_object_id": obj.comment_object_id,
			"owner_id": obj.owner_id,
			"user_id": obj.user_id,
			"author": obj.author,
			"subject": obj.subject,
			"body": obj.body,
			"audit_status": obj.audit_status,
			"is_anonymous": obj.is_anonymous,
			"is_private": obj.is_private,
			"ip": obj.ip,
			"comment_date": obj.comment_date,
		}
		return dic

	@staticmethod
	def parse_many(dic):
		data=dic["comments"]
		if data == None:
			return None
		arr=[]
		for	i in data:
			a=Comment()
			arr.append(a)
			print(i)
			# ex 
			for key in i.keys():
				try:
					if hasattr(a,key):
						setattr(a,key,i[key])
					else:
						println("Comment hasattr "+key+" not exists")
				except:
					println("Comment attr ex")
		return arr

# 使用枚举
from enum import Enum,unique


#审核状态
@unique
class AuditStatus(Enum) :

	none=0  # 无
	fail=1  # 未通过
	auditing=2   # 待审核
	retry=3   # 需再次审核
	success=4   # 通过审核

class Review(Base):
	""" 评分实体 """
	__tablename__="t_review"
	id=Column(Integer,primary_key=True,autoincrement=True)
	parent_id = Column(BigInteger) #父评论Id（一级ParentId等于0）
	reviewed_object_id =Column(BigInteger) #被评价对象ID
	owner_id =Column(BigInteger) #拥有者Id
	user_id = Column(BigInteger) #评论人UserId
	author = Column(String(50)) #评论人名称
	subject = Column(String(50)) #标题
	body = Column(String(50)) #评论内容
	rate_number = Column(Integer) #星级评价评分
	review_rank= Column(Integer) #好中差评
	is_anonymous= Column(Boolean) #是否匿名评论
	ip= Column(BigInteger) #评论人IP
	comment_date= Column(BigInteger) #评论时间


class Review_Type(Enum):
	Positive=0 #好评
	Moderate=1 #中评
	Negative=2 #差评
class ReviewSummary(Base):
	""" 评分实体 """
	__tablename__="t_review_summary"
	id=Column(BigInteger,primary_key=True,autoincrement=True)
	reviewed_object_id =Column(BigInteger) #被评价对象ID
	owner_id =Column(BigInteger) #拥有者Id
	rate_sum = Column(Integer) #星级评价总评分
	rate_count= Column(Boolean) #星级评价人数
	positive_reivew_count= Column(BigInteger) #好评数
	moderate_reivew_count= Column(BigInteger) #中评数
	negative_reivew_count= Column(BigInteger) #差评数


class ProductComment(Base):
	'''
	评论实体
	'''

	__tablename__="t_product_comment"
	id=Column(Integer,primary_key=True,autoincrement=True)
	parent_ids = Column(String(200)) #所有父级评论Id集合
	parent_id = Column(BigInteger) #父评论Id（一级ParentId等于0）
	comment_object_id =Column(BigInteger) #被评论对象Id
	owner_id =Column(BigInteger) #拥有者Id
	user_id = Column(BigInteger) #评论人UserId
	author = Column(String(50)) #评论人名称
	subject = Column(String(50)) #标题
	body = Column(String(500000)) #评论内容
	audit_status = Column(Integer) #审核状态
	is_anonymous= Column(Boolean) #是否匿名评论
	is_private= Column(Boolean) #是否悄悄话
	ip= Column(BigInteger) #评论人IP
	comment_date= Column(BigInteger) #评论时间

	@staticmethod
	def from_json(obj):
		dic={
			"id": obj.id,      
			"parent_ids": obj.parent_ids,
			"parent_id": obj.parent_id,
			"comment_object_id": obj.comment_object_id,
			"owner_id": obj.owner_id,
			"user_id": obj.user_id,
			"author": obj.author,
			"subject": obj.subject,
			"body": obj.body,
			"audit_status": obj.audit_status,
			"is_anonymous": obj.is_anonymous,
			"is_private": obj.is_private,
			"ip": obj.ip,
			"comment_date": obj.comment_date,
		}
		return dic

class ShopComment(Base):
	'''
	评论实体
	'''

	__tablename__="t_shop_comment"
	id=Column(Integer,primary_key=True,autoincrement=True)
	parent_ids = Column(String(200)) #所有父级评论Id集合
	parent_id = Column(BigInteger) #父评论Id（一级ParentId等于0）
	comment_object_id =Column(BigInteger) #被评论对象Id
	owner_id =Column(BigInteger) #拥有者Id
	user_id = Column(BigInteger) #评论人UserId
	author = Column(String(50)) #评论人名称
	subject = Column(String(50)) #标题
	body = Column(String(500000)) #评论内容
	audit_status = Column(Integer) #审核状态
	is_anonymous= Column(Boolean) #是否匿名评论
	is_private= Column(Boolean) #是否悄悄话
	ip= Column(BigInteger) #评论人IP
	comment_date= Column(BigInteger) #评论时间

	@staticmethod
	def from_json(obj):
		dic={
			"id": obj.id,      
			"parent_ids": obj.parent_ids,
			"parent_id": obj.parent_id,
			"comment_object_id": obj.comment_object_id,
			"owner_id": obj.owner_id,
			"user_id": obj.user_id,
			"author": obj.author,
			"subject": obj.subject,
			"body": obj.body,
			"audit_status": obj.audit_status,
			"is_anonymous": obj.is_anonymous,
			"is_private": obj.is_private,
			"ip": obj.ip,
			"comment_date": obj.comment_date,
		}
		return dic

class OrderComment(Base):
	'''
	评论实体
	'''

	__tablename__="t_shop_comment"
	id=Column(Integer,primary_key=True,autoincrement=True)
	parent_ids = Column(String(200)) #所有父级评论Id集合
	parent_id = Column(BigInteger) #父评论Id（一级ParentId等于0）
	comment_object_id =Column(BigInteger) #被评论对象Id
	owner_id =Column(BigInteger) #拥有者Id
	user_id = Column(BigInteger) #评论人UserId
	author = Column(String(50)) #评论人名称
	subject = Column(String(50)) #标题
	body = Column(String(500000)) #评论内容
	audit_status = Column(Integer) #审核状态
	is_anonymous= Column(Boolean) #是否匿名评论
	is_private= Column(Boolean) #是否悄悄话
	ip= Column(BigInteger) #评论人IP
	comment_date= Column(BigInteger) #评论时间

	@staticmethod
	def from_json(obj):
		dic={
			"id": obj.id,      
			"parent_ids": obj.parent_ids,
			"parent_id": obj.parent_id,
			"comment_object_id": obj.comment_object_id,
			"owner_id": obj.owner_id,
			"user_id": obj.user_id,
			"author": obj.author,
			"subject": obj.subject,
			"body": obj.body,
			"audit_status": obj.audit_status,
			"is_anonymous": obj.is_anonymous,
			"is_private": obj.is_private,
			"ip": obj.ip,
			"comment_date": obj.comment_date,
		}
		return dic