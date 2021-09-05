# from shop_for_flask import db

import json

from sqlalchemy import Column, Integer, String, Boolean, DECIMAL, ForeignKey,DateTime,BigInteger  
from shop_for_flask.database import  Base
from sqlalchemy.orm import  relationship  #创建关系

# 5. 执行两个命令：
# 1. python manage.py makemigrations  # 将 models.py 里的更改记录下来
# 2. python manage.py migrate         # 将更改的记录翻译成 sql 语句 去 数据库执行
class Order(Base):
	__tablename__="t_order"
	id=Column(Integer,primary_key=True,autoincrement=True)
	product_ids = Column(String(500))
	total_price = Column(DECIMAL)
	number= Column(BigInteger)

class OrderDetail(Base):
	__tablename__="t_order_detail"
	id=Column(Integer,primary_key=True,autoincrement=True)
	title = Column(String(20))
	titlt2 = Column(String(20))
	favorite = Column(Boolean)
	img_list = Column(String(500))









