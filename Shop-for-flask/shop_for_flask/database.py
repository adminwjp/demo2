# orm

# pip install PyMySQL
# pip install sqlalchemy

# https://www.cnblogs.com/wf-skylark/p/9306326.html
# http://www.pythondoc.com/flask-sqlalchemy/index.html
# pip install flask-sqlalchemy
# pip install wheel
# pip install flask-mysqldb # 安装冲突 失败

"""

from flask_sqlalchemy import SQLAlchemy

#app.config["SQLALCHEMY_DATABASE_URI"] = "数据库类型://数据库登录名:数据库登录密码@数据库的地址:数据库的端口/数据库的名字"


# https://www.sqlite.org/download.html 已安装过
# http://www.pythondoc.com/flask-sqlalchemy/config.html#uri
#app.config["SQLALCHEMY_DATABASE_URI"]="sqlite:////work/python/shop_for_flask/mall.db"
app.config["SQLALCHEMY_DATABASE_URI"]="sqlite:///Mall.db"

#import os
#basedir=os.path.abspath(os.path.dirname(__file__))

# python flask_sqlalchemy apply_driver_hacks 
# sa_url.database = os.path.join(app.root_path, sa_url.database)  can"t set attribute
#app.config["SQLALCHEMY_DATABASE_URI"]="sqlite:///{}".format(os.path.join(basedir,"mall.db"))

app.config["SQLALCHEMY_TRACK_MODIFICATIONS"] = True
app.config["SQLALCHEMY_ECHO"] = True
db = SQLAlchemy(app)

# not support 
#from core import db
#db.app =app
#db.init_app(app)

"""


from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()
from sqlalchemy import create_engine

# sqlite://<nohostname>/<path>
# where <path> is relative:
engine = create_engine("sqlite:///E:/work\db/sqlite/Mall.db")
