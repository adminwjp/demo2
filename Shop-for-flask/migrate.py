from shop_for_flask import app
# https://blog.csdn.net/leleprogrammer/article/details/118709463
from flask_migrate import Migrate, MigrateCommand
from flask_script import Manager
from core import db

manager = Manager(app)
migrate = Migrate(app, db)
manager.add_command('db', MigrateCommand)
manager.run()

# 这个  迁移 没用 运行 异常 默认 运行 支持迁移 但表结构 改变 了 可能 出现 问题(字段 类型改变...)  删除 库 重新 创建
# python migrate.py db init 

# python migrate.py db migrate 

# python migrate.py db upgrade 
