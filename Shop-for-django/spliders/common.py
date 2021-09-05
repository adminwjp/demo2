import requests

import base64 

from utility.util import db
import sqlite3

# 公共 模块

class ISplider :
    name="" #名称
    enable=False # 默认关闭

    def crawl(self, thrid_app):
        pass





sqlite3db="ip.sqlite3"

sqliteUtil=db.SqliteUtil()

# https://www.cnblogs.com/hdzbk/p/10543999.html
class HelperSQLite:
    @staticmethod
    def init_table():
        sql="""create table dm_mobile if not exists
        (mobile_number CHAR(11) PRIMARY KEY     NOT NULL,
        mobile_type TEXT,
        area_code TEXT,
        post_code TEXT,
        mobile_area TEXT
        )
        """
        conn=sqlite3.connect(ip_sqlite3db)
        c=conn.cursor()
        conn.execute(sql)
       
        sql="""create table black_ip if not exists
        (web TEXT  ,
        ip TEXT,
        uts TEXT
        )
        """
        conn.execute(sql)
        conn.commit()

    @staticmethod
    def insert_many(phone_list):
        conn=sqlite3.connect(ip_sqlite3db)
        c=conn.cursor()
        sql="insert into dm_mobile values(:mobile_number,:mobile_type,:area_code,:post_code,:mobile_area)"
        for x in phone_list:
            args={
                "mobile_number":x.mobile_number,
                "mobile_type":x.mobile_type,
                "area_code":x.area_code,
                "post_code":x.post_code,
                "mobile_area":x.mobile_area
            }
            conn.execute(sql,args)
            conn.commit()
        conn.close()

    @staticmethod
    def insert(phone):
        conn=sqlite3.connect(ip_sqlite3db)
        c=conn.cursor()
        sql="insert into dm_mobile values(:mobile_number,:mobile_type,:area_code,:post_code,:mobile_area)"
        args={
            "mobile_number":phone.mobile_number,
            "mobile_type":phone.mobile_type,
            "area_code":phone.area_code,
            "post_code":phone.post_code,
            "mobile_area":phone.mobile_area
        }
        conn.execute(sql,args)
        conn.commit()
        conn.close()

    @staticmethod
    def insert_close_ip(web, ip, uts):
        conn=sqlite3.connect(ip_sqlite3db)
        c=conn.cursor()
        sql="insert into black_ip values(:1, :2, :3)"
        args=[web,ip,uts]
        conn.execute(sql,args)
        conn.commit()
        conn.close()



