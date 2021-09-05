from shop_for_flask import app, model,product_model,order_model,comment_model
from shop_for_flask.database import Base,  engine
# from sqlalchemy
# init table
# python flask_sqlalchemy apply_driver_hacks 
# sa_url.database = os.path.join(app.root_path, sa_url.database)  can"t set attribute
# flask_sqlalchemy sa_url.database can"t set attribute mysql sqlite 
# flask_sqlalchemy 要么 改它 源码 
# sqlalchemy 要么 改它 源码 
# sqlalchemy from sqlalchemy.engine.url import make_url
#sqlalchemy  sqlalchemy.engine.url  721行 
# {}   util.namedtuple Url
# sqlite sqlalchemy, 不要使用 flask_sqlalchemy bug
#db.create_all()   # 用来创建table，一般在初始化的时候调用

Base.metadata.create_all(engine, checkfirst=True)

from sqlalchemy.orm import sessionmaker
from flask import request
from utility.util import  j as _json, ma
from sqlalchemy import func



# engine是2.2中创建的连接
Session = sessionmaker(bind=engine)

# 创建Session类实例
#session = Session()
class SessionFactory(object):
    def foo(self):
        pass


    