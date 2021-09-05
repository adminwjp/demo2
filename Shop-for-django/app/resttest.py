import django
from django.test import TestCase

from datetime import datetime
from django.shortcuts import render
from django.http import HttpRequest, HttpResponse, HttpResponseNotFound
import json
from django.views.decorators.csrf import csrf_exempt
from app import models
from django.core.paginator import Paginator


from utility.util import j
from util import djan as djan_go
import requests

# TODO: Configure your database in settings.py and sync before running tests.
# python manage.py test  app.resttest
class RestTest(TestCase):
    """Tests for the application rests."""

    if django.VERSION[:2] >= (1, 7):
        # Django 1.7 requires an explicit setup() when running tests in PTVS
        @classmethod
        def setUpClass(cls):
            super(ViewTest, cls).setUpClass()
            django.setup()

    def test_update_data(self):
        # 地址 下不下来 造成 uni-app 渲染出现问题
        # 更新 购物车 远程 地址 更新到本地
        url="http://192.168.1.3:8000"
        # notice
        response = self.client.get("/notice/list")
        # product
        response = self.client.get("/product/list")
        pass

    def test_test(self):
        """Tests the test rest."""
        response = self.client.get("/test")
        self.assertContains(response, "test", 1, 200)

    def test_ex(self):
        """Tests the ex rest."""
        response = self.client.get("/ex")
        self.assertContains(response, "ex", 3, 200)

    def test_notice_list(self):
        """Tests the notice rest."""
        response = self.client.get("/notice/list")
        self.assertContains(response, "code", 3, 200)
    
    def test_carousel_list(self):
        """Tests the carousel rest."""
        response = self.client.get("/carousel/list")
        self.assertContains(response, "code", 3, 200)

    def test_share_list(self):
        """Tests the share rest."""
        response = self.client.get("/share/list")
        self.assertContains(response, "code", 3, 200)

    def test_product_list(self):
        """Tests the product rest."""
        response = self.client.get("/product/list")
        self.assertContains(response, "code", 3, 200)
