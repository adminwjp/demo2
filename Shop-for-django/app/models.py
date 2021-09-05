#!/usr/bin/python3

"""
Definition of models.
"""

from django.db import models
# 使用枚举
from enum import Enum

# Create your models here.

# 打包 二进制(linux) 部署 参考
# https://www.cnblogs.com/dwBurning/p/pythonbuild.html 
# user model 用户模型
class User:
    # 类有一个名为 __init__() 的特殊方法（构造方法），该方法在类实例化时会自动调用
    def __init__(self):
       self.data = []
    # 定义基本属性
    account=""   # 账号
    pwd:""   # 密码



# https://www.cnblogs.com/chaoqi/p/10561008.html
# https://www.cnblogs.com/mosson/p/5806823.html
# https://www.cnblogs.com/baili-luoyun/p/11075588.html


# 5. 执行两个命令：
# 1. python manage.py makemigrations  # 将 models.py 里的更改记录下来
# 2. python manage.py migrate         # 将更改的记录翻译成 sql 语句 去 数据库执行

class OrderDetail(models.Model):
    id = models.AutoField(primary_key=True)
    title=models.CharField(max_length=20)
    titlt2=models.CharField(max_length=20)
    favorite=models.NullBooleanField()
    img_list=models.CharField(max_length=500)
    class Meta:
        db_table = "t_order_detail"  # 表名

class Notice(models.Model):
    #id = models.IntegerField()
    id = models.AutoField(primary_key=True)
    times=models.DateTimeField(max_length=32)
    title=models.CharField(max_length=20)
    pic=models.CharField(max_length=100)
    introduce=models.CharField(max_length=500)
    end=models.NullBooleanField()
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

    class Meta:
        db_table = "t_notice"  # 表名


class Carousel(models.Model):
    id = models.AutoField(primary_key=True)
    src=models.CharField(max_length=100)
    background=models.CharField(max_length=20)
    @staticmethod
    def json_str(ob):
        dic={}
        dic["id"] = ob.id 
        dic["src"]=ob.src
        dic["background"]=ob.background
        return dic

    class Meta:
        db_table = "t_carousel"  # 表名

class Share(models.Model):
    id = models.AutoField(primary_key=True)
    icon=models.CharField(max_length=100)
    text=models.CharField(max_length=20)
    @staticmethod
    def json_str(ob):
        dic={}
        dic["id"] = ob.id 
        dic["icon"]=ob.icon
        dic["text"]=ob.text
        return dic

    class Meta:
        db_table = "t_share"  # 表名


class Product(models.Model):
    id = models.AutoField(primary_key=True)
    title=models.CharField(max_length=50)
    price=models.DecimalField(max_digits=5,decimal_places=2)
    sales=models.IntegerField()
    image=models.CharField(max_length=100)
    image2=models.CharField(max_length=100)
    image3=models.CharField(max_length=100)
    catalog_id = models.IntegerField()
    @staticmethod
    def json_str(ob):
        dic={}
        dic["id"] = ob.id 
        dic["title"]=ob.title
        dic["price"]=str(ob.price)
        dic["sales"]=ob.sales
        dic["image"]=ob.image
        dic["image2"]=ob.image2
        dic["image3"]=ob.image3
        return dic

    class Meta:
        db_table = "t_product"  # 表名
