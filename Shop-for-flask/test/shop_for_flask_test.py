import json
import unittest
from shop_for_flask import app, model,product_model,order_model,comment_model
class ShopFlaskModel:
    addresses:[model.Addressinfor]
    carts:[product_model.Cartinfor]
    catalogs:[product_model.Cataloginfor]
    
    notices:[model.Notice]
    carousels:[model.Carousel]
    shares:[model.Share]
    products:[product_model.Product]

import os
# 上传文件优化,文件名安全的意思
from werkzeug.utils import secure_filename
# os.path.dirname(__file__)获取的是app.py文件的路径，也就是在项目根目录中，然后把它放在images文件夹中
UPLOAD_PATH = os.path.join(os.path.dirname(__file__),'config/data.json').replace('\\','/').replace('shop_for_flask/','').replace('test/','')
#if os.path.exists(UPLOAD_PATH)==False:
#    os.mkdir(UPLOAD_PATH)

from utility.util import  j as _json, ma

# test form  body ex 
class ShopFlaskTest(unittest.TestCase):
    shopFlaskModel:ShopFlaskModel =ShopFlaskModel()
    #shopFlaskModel ={}
    def setUp(self):
        app.testing = True
        self.client = app.test_client()
        with open(UPLOAD_PATH,"r") as r:
            #_json.dic2class(r.read(),self.shopFlaskModel)
            #self.shopFlaskModel=json.loads(r.read())
            self.shopFlaskModel=json.loads(r.read())

    def test_addresses(self):
        response = app.test_client().get('/api/v1/address/list/1/10')
        json_data = response.data
        json_dict = json.loads(json_data)
        if json_dict["data"]==None or len(json_dict["data"])==0:

            # ex
            #response1 = app.test_client().post('/address/insert_many',data=self.shopFlaskModel.addresses)
            #'list' object has no attribute 'items
            response1 = app.test_client().post('/api/v1/address/insert_many', content_type='application/json',data=json.dumps({'addresses':self.shopFlaskModel['addresses']}))
            json_data1 = response1.data
            json_dict1 = json.loads(json_data1)
            self.assertEqual(json_dict1['success'], True, 'add addresses suc')

    def test_carts(self):
        response = app.test_client().get('/api/v1/cart/list/1/10')
        json_data = response.data
        json_dict = json.loads(json_data)
        if json_dict["data"]==None or len(json_dict["data"])==0:
            response1 = app.test_client().post('/api/v1/cart/insert', content_type='application/json',data=json.dumps({'carts':self.shopFlaskModel['carts']}))
            json_data1 = response1.data
            json_dict1 = json.loads(json_data1)
            self.assertEqual(json_dict1['success'], True, 'add carts suc')

    def test_catalogs(self):
        response = app.test_client().get('/api/v1/catalog/list/1/10')
        json_data = response.data
        json_dict = json.loads(json_data)
        if json_dict["data"]==None or len(json_dict["data"])==0:
            response1 = app.test_client().post('/api/v1/catalog/insert_many', content_type='application/json',data=json.dumps({'catalogs':self.shopFlaskModel['catalogs']}))
            json_data1 = response1.data
            json_dict1 = json.loads(json_data1)
            self.assertEqual(json_dict1['success'], True, 'add catalogs suc') 


    def test_notices(self):
        response = app.test_client().get('/api/v1/notice/list/1/10')
        json_data = response.data
        json_dict = json.loads(json_data)
        if json_dict["data"]==None or len(json_dict["data"])==0:
            response1 = app.test_client().post('/api/v1/notice/insert_many', content_type='application/json',data=json.dumps({'notices':self.shopFlaskModel['notices']}))
            json_data1 = response1.data
            json_dict1 = json.loads(json_data1)
            self.assertEqual(json_dict1['success'], True, 'add notices suc')

    def test_carousels(self):
        response = app.test_client().get('/api/v1/carousel/list/1/10')
        json_data = response.data
        json_dict = json.loads(json_data)
        if json_dict["data"]==None or len(json_dict["data"])==0:
            response1 = app.test_client().post('/api/v1/carousel/insert_many', content_type='application/json',data=json.dumps({'carousels':self.shopFlaskModel['carousels']}))
            json_data1 = response1.data
            json_dict1 = json.loads(json_data1)
            self.assertEqual(json_dict1['success'], True, 'add carousels suc')

    def test_shares(self):
        response = app.test_client().get('/api/v1/share/list/1/10')
        json_data = response.data
        json_dict = json.loads(json_data)
        if json_dict["data"]==None or len(json_dict["data"])==0:
            response1 = app.test_client().post('/api/v1/share/insert_many', content_type='application/json',data=json.dumps({'shares':self.shopFlaskModel['shares']}))
            json_data1 = response1.data
            json_dict1 = json.loads(json_data1)
            self.assertEqual(json_dict1['success'], True, 'add shares suc')
 
    def test_products(self):
        response = app.test_client().get('/api/v1/product/list/1/10')
        json_data = response.data
        json_dict = json.loads(json_data)
        if json_dict["data"]==None or len(json_dict["data"])==0:
            response1 = app.test_client().post('/api/v1/product/insert_many', content_type='application/json',data=json.dumps({'products':self.shopFlaskModel['products']}))
            json_data1 = response1.data
            json_dict1 = json.loads(json_data1)
            self.assertEqual(json_dict1['success'], True, 'add products suc')

    def atest_empty_username_password(self):
        """测试用户名与密码为空的情况[当参数不全的话，返回errcode=-2]"""
        response = app.test_client().post('/login', data={})
        json_data = response.data
        json_dict = json.loads(json_data)
 
        self.assertIn('errcode', json_dict, '数据格式返回错误')
        self.assertEqual(json_dict['errcode'], -2, '状态码返回错误')
 
        # TODO 测试用户名为空的情况
 
        # TODO 测试密码为空的情况
 
    def atest_error_username_password(self):
        """测试用户名和密码错误的情况[当登录名和密码错误的时候，返回 errcode = -1]"""
        response = app.test_client().post('/login', data={"username": "aaaaa", "password": "12343"})
        json_data = response.data
        json_dict = json.loads(json_data)
        self.assertIn('errcode', json_dict, '数据格式返回错误')
        self.assertEqual(json_dict['errcode'], -1, '状态码返回错误')
 
        # TODO 测试用户名错误的情况
 
        # TODO 测试密码错误的情况
 
if __name__ == '__main__':
    unittest.main()
