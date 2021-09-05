from datetime import datetime
#from shop_for_flask import app, db, model
from shop_for_flask.database import Base,  engine
from shop_for_flask import app, model
from utility.util import  j as _json, ma
import json
import sys



from flask import Flask, request, make_response,abort

from shop_for_flask.session import Session #,  session
import shop_for_flask.base_restfuls as  base

import os
# 上传文件优化,文件名安全的意思
from werkzeug.utils import secure_filename
# os.path.dirname(__file__)获取的是app.py文件的路径，也就是在项目根目录中，然后把它放在images文件夹中
UPLOAD_PATH = os.path.join(os.path.dirname(__file__),'images/python').replace('\\','/').replace('shop_for_flask/','').replace('Shop-for-flask/','')
if os.path.exists(UPLOAD_PATH)==False:
    os.mkdir(UPLOAD_PATH)

import uuid
# https://codingdict.com/sources/py/flask.request/4391.html
# https://zhuanlan.zhihu.com/p/70957022?from_voters_page=true
@app.route("/upload",methods={"POST"})
def upload():
    pichead = request.files.get('img')
    if pichead==None:
         return {"success":False,"note":"fail","code":204}
    filename = secure_filename(pichead.filename)     
    pichead.save(os.path.join(UPLOAD_PATH.replace('\\','/'),filename).replace('\\','/'))
    id=uuid.uuid5().hex.lower()
    data=model.Sourceinfor()
    data.id=id
    data.src=filename
    session = Session()
    session.add(data)
    session.commit()
    engine.dispose()  #关闭连接
    res={"success":True,"note":"success","code":200,id:id}
    return res

import base64
@app.route("/img/<string:id>",methods={"GET"})
def get(id):
   
    # 随便打开一张其他图片作为结果返回， base64
    #with open(file_path, 'rb') as f:
    #    res = base64.b64encode(f.read())
    #    return res
    old1=session.query(model.Sourceinfor).filter_by(id=id).first()
    if old1==None:
        abort(404)
    file_path='E:/work/shop/images/python/'+old1.src
    image_data = open(file_path, "rb").read()
    response = make_response(image_data)
    response.headers['Content-Type'] = 'image/jpg'
    return response



