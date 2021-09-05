"""
Definition of restful.
"""

from datetime import datetime
from django.shortcuts import render
from django.http import HttpRequest, HttpResponse, HttpResponseNotFound, StreamingHttpResponse
import json
from django.views.decorators.csrf import csrf_exempt
from app import models
from django.core.paginator import Paginator

from utility.util import j
from util import djan as djan_go
from os.path import isdir, dirname, join
from os import mkdir
from DjangoWeb.settings import BASE_DIR

# https://www.cnblogs.com/FortisCK/p/11620250.html
def upload_excel(request):
 if request.method == "POST":
     # 创建用来存储上传文件的文件夹
     uploadDir = BASE_DIR+"/upload"
     if not isdir(uploadDir):
         mkdir(uploadDir)
     # 获取上传的文件
     uploadedFile = request.FILES.get("Scores")
     if not uploadedFile:
         return render(request, "index.html", {"msg":"没有选择文件"})
     if not uploadedFile.name.endswith(".xlsx"):
         if not uploadedFile.name.endswith(".xls"):
             return render(request, "index.html", {"msg":"必须选择xlsx或xls文件"})
     # 上传
     dstFilename = join(uploadDir, uploadedFile.name)
     with open(dstFilename, "wb") as fp:
         for chunk in uploadedFile.chunks():
             fp.write(chunk)
     # 读取excel文件并转化为html格式
     pdData = pd.read_excel(dstFilename)
     pdhtml = pdData.to_html()
     context = {}
     context["form"] = pdhtml
     context["msg"] = "上传成功"
     return render(request, "index.html", context)
 else:
     return render(request, "index.html",{"msg":None})

def upload(request):
    if request.method == "POST":
        myFile = request.FILES.get("myfile",None)
        #print myFile,"++++++++++++++++++++++"
        if not myFile:
            return HttpResponse("no files for upload!")
        destination = open(os.path.join(BASE_DIR,myFile.name),"wb+")

        for chunk in myFile.chunks():
            destination.write(chunk)
            #print destination,"----------------------"
        destination.close()
        return HttpResponse("upload success")

def download(request,file_name):
    def file_iterator(file_name,chunk_size=512):
        #print file_name,"******************"
        with open(file_name, "rb") as f:
            if f:
                yield f.read(chunk_size)
                print("下载完成") 
            else:
                print("未完成下载") 

    the_file_name = "D:/home/task/media/"+ file_name
    #print the_file_name,"1111111111111111111111"
    response = StreamingHttpResponse(file_iterator(the_file_name))

    response["Content-Type"] = "application/octet-stream"
    response["Content-Disposition"] = "attachement;filename='{0}'".format(file_name)
    return response

@csrf_exempt   #对此试图函数添加csrf装饰器，使得此函数的post请求免验证tooken
def insert_many_notice(request):
    """Renders the notice ."""
    if request.method == "POST":
        def insert_many_notice_suc(da):
           return da.notices
        data=NoticeList()
        re=djan_go.insert_many(request,data,models.Notice,insert_many_notice_suc)
        return re
    return HttpResponseNotFound("None")

class NoticeList:
    notices=[models.Notice()]

def insert_notice(request):
    re=djan_go.insert(request,models.Notice)
    return re

def get_list_notice(request):
    """ 地址查询  """
    def json_str_notice(x):
        it=models.Notice.json_str(x)
        return it
    re=djan_go.get_list(request,models.Notice,json_str_notice)
    return re

def update_notice(request):
    re=djan_go.update(request,models.Notice,{"name__contains":"xx"},{"name":"xx"})
    return re

def delete_notice(request):
    re=djan_go.delete(request,models.Notice)
    return re

@csrf_exempt 
def insert_many_carousel(request):
    if request.method == "POST":
        def insert_many_carousel_suc(da):
           return da.notices
        data=CarouselList()
        re=djan_go.insert_many(request,data,models.Carousel,insert_many_carousel_suc)
        return re
    return HttpResponseNotFound("None")

class CarouselList:
    carousels=[models.Carousel()]

def insert_carousel(request):
    re=djan_go.insert(request,models.Carousel)
    return re

def get_list_carousel(request):
    def json_str_carousel(x):
        it=models.Carousel.json_str(x)
        return it
    re=djan_go.get_list(request,models.Carousel,json_str_carousel)
    return re

def update_carousel(request):
    re=djan_go.update(request,models.Carousel,{"name__contains":"xx"},{"name":"xx"})
    return re

def delete_carousel(request):
    re=djan_go.delete(request,models.Carousel)
    return re



@csrf_exempt 
def insert_many_share(request):
    if request.method == "POST":
        def insert_many_share_suc(da):
           return da.shares
        data=ShareList()
        re=djan_go.insert_many(request,data,models.Share,insert_many_share_suc)
        return re
    return HttpResponseNotFound("None")

class ShareList:
    shares=[models.Share()]

def insert_share(request):
    re=djan_go.insert(request,models.Share)
    return re

def get_list_share(request):
    def json_str_share(x):
        it=models.Share.json_str(x)
        return it
    re=djan_go.get_list(request,models.Share,json_str_share)
    return re

def update_share(request):
    re=djan_go.update(request,models.Share,{"name__contains":"xx"},{"name":"xx"})
    return re

def delete_share(request):
    re=djan_go.delete(request,models.Share)
    return re


@csrf_exempt 
def insert_many_product(request):
    if request.method == "POST":
        def insert_many_product_suc(da):
           return da.products
        data=ProductList()
        re=djan_go.insert_many(request,data,models.Product,insert_many_product_suc)
        return re
    return HttpResponseNotFound("None")

class ProductList:
    products=[models.Product()]

def insert_product(request):
    re=djan_go.insert(request,models.Product)
    return re

def get_list_product(request):
    def json_str_product(x):
        it=models.Product.json_str(x)
        return it
    re=djan_go.get_list(request,models.Product,json_str_product)
    return re

def update_product(request):
    re=djan_go.update(request,models.Product,{"name__contains":"xx"},{"name":"xx"})
    return re

def delete_product(request):
    re=djan_go.delete(request,models.Product)
    return re


        
  