from django.http import HttpRequest, HttpResponse, HttpResponseNotFound
import json
from django.views.decorators.csrf import csrf_exempt
from django.core.paginator import Paginator

from utility.util import j as _json

def insert_many(request,data,mo,listFun):
    dic = json.loads(request.body.decode("utf-8"))
    _json.dic2class(dic,data)
    ls=listFun(data) # list
    #ob.objects.bulk_create(**dic[ls])
    mo.objects.bulk_create(ls)
    res={"success":True,"note":"success","code":200}
    js=json.dumps(res)
    return HttpResponse(js)

def insert(request,mo):
    if request.method == "POST":
         dic = json.loads(request.body.decode("utf-8"))
         mo.objects.create(**dic)
         res={"success":True,"note":"success","code":200}
         js=json.dumps(res)
         return HttpResponse(js)
    return HttpResponseNotFound("None")

def get_list(request,mo,jsonFun):
    if request.method == "POST":
        return HttpResponseNotFound("None")
    page=request.GET.get("page")
    size=request.GET.get("size")
    page=int(page)
    size=int(size)
    if size>0 and size<10:
        pass
    else :
        size=10
    if page>0 and page<1000 :
        pass
    else :
        page=1
    data= mo.objects.all()[(page - 1) * size: page * size]
    #da=models.Carousel.objects.all() #.order_by("-times")
    #da_list= Paginator(da,page) # 进行分页
    #page_da = da_list.page(size) # 返回对应页码
    #page_da.page_range.
    #page_range = set_page(page_da.page_range,page)

    arr=[]
    for x in data:
       it=jsonFun(x)
       arr.append(it)
    res={"success":True,"note":"success","code":200,"data":arr}
    js=json.dumps(res,default=lambda x : x.__dict__, sort_keys=False, indent=2, ensure_ascii=False)
    return HttpResponse(js)

def update(request,mo,query,edit):
    if request.method == "POST":
         dic = json.loads(request.body.decode("utf-8"))
         mo.objects.filter(query).update(edit)
         res={"success":True,"note":"success","code":200}
         js=json.dumps(res)
         return HttpResponse(js)
    return HttpResponseNotFound("None")

def delete(request,mo):
    if request.method == "POST":
         return HttpResponseNotFound("None")
    id=request.GET.get("id")
    mo.filter(id=id).delete()
    res={"success":True,"note":"success","code":200}
    js=json.dumps(res)
    return HttpResponse(js) 
