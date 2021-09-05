"""
Definition of urls for DjangoWeb.
"""

from datetime import datetime
from django.urls import path
from django.contrib import admin
from django.contrib.auth.views import LoginView, LogoutView
from app import forms, views, restfuls


urlpatterns = [
    path("", views.home, name="home"),
    path("contact/", views.contact, name="contact"),
    path("about/", views.about, name="about"),
    path("test/", views.test, name="test"),
    path("ex/", views.ex, name="ex"),
    path("recruit/", views.recruit, name="recruit"),
    path("notice/insert_many", restfuls.insert_many_notice,name="insert_many_notice"),
    path("notice/list", restfuls.get_list_notice,name="list_notice"),
    path("carousel/insert_many", restfuls.insert_many_carousel,name="insert_many_carousel"),
    path("carousel/list", restfuls.get_list_carousel,name="list_carousel"),
    path("share/insert_many", restfuls.insert_many_share,name="insert_many_share"),
    path("share/list", restfuls.get_list_share,name="list_share"),
    path("product/insert_many", restfuls.insert_many_product,name="insert_many_product"),
    path("product/list", restfuls.get_list_product,name="list_product"),
    
    path("login/",
         LoginView.as_view
         (
             template_name="app/login.html",
             authentication_form=forms.BootstrapAuthenticationForm,
             extra_context=
             {
                 "title": "Log in",
                 "year" : datetime.now().year,
             }
         ),
         name="login"),
    path("logout/", LogoutView.as_view(next_page="/"), name="logout"),
    path("admin/", admin.site.urls),
]
