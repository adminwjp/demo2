"""
Definition of views.
"""

from datetime import datetime
from django.shortcuts import render
from django.http import HttpRequest, HttpResponse
import json
from app import  splider

def home(request):
    """Renders the home page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        "app/index.html",
        {
            "title":"Home Page",
            "year":datetime.now().year,
        }
    )


def contact(request):
    """Renders the contact page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        "app/contact.html",
        {
            "title":"Contact",
            "message":"Your contact page.",
            "year":datetime.now().year,
        }
    )

def about(request):
    """Renders the about page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        "app/about.html",
        {
            "title":"About",
            "message":"Your application description page.",
            "year":datetime.now().year,
        }
    )


# rest api 使用django 太重了 接口使用rest_framework，rest_framework是一套基于Django 的 REST 框架，是一个强大灵活的构建 Web API 的工具包
# https://www.cnblogs.com/sixrain/p/9138442.html
def test(request):
    return HttpResponse(u"test")

def ex(request):
    raise Exception("test ex")
    return HttpResponse("test ex")

# 招聘
# http://192.168.1.3:8000/recruit/?account=1&pwd=2&flag=1
def recruit(request):
    #local variable "ctx" referenced before assignment
    #ctx:{} 
    ctx={}
    # https://www.runoob.com/django/django-form.html
    # 请求中使用的HTTP方法的字符串表示。全大写表示
    if request.method == "GET":
        print("get")
        # 参数 必须存在 pass
        #ctx["account"]=request.GET["account"]
        #ctx["pwd"]=request.GET["pwd"]
        #ctx["flag"]=request.GET["flag"]
        # 参数 可传
        ctx["account"]=request.GET.get("account")
        ctx["pwd"]=request.GET.get("pwd")
        ctx["flag"]=request.GET.get("flag")
        # 绑定数据失败
        #ctx["flag"]:request.GET["flag"]
    elif request.method == "POST":
        print("post")
    #not support
    #data={note:"fail",success:0,code:400}
    data={"note":"fail","success":False,"code":400}
    #not support
    #data.note="success"
    data["note"]="success"
    data["success"]=True
    data["code"]=200
    print(ctx)
    if ctx["flag"]=="1":
       fiveOneJobSplider =spliders.FiveOneJobSplider()
       fiveOneJobspliders.recruit.phone=ctx["account"]
       fiveOneJobspliders.recruit.pwd=ctx["pwd"]
       fiveOneJobspliders.splider()
    elif ctx["flag"]=="2":
       # 进 不来 ？
       laGouSplider =spliders.LaGouSplider()
       laGouspliders.recruit.phone=ctx["account"]
       laGouspliders.recruit.pwd=ctx["pwd"]
       laGouspliders.splider()
    encodedjson = json.dumps(data)
    #decodejson = json.loads(encodedjson)
    return HttpResponse(encodedjson)