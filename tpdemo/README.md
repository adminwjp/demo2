ThinkPHP 6.0
===============

> 运行环境要求PHP7.1+。

## 主要新特性

* 采用`PHP7`强类型（严格模式）
* 支持更多的`PSR`规范
* 原生多应用支持
* 更强大和易用的查询
* 全新的事件系统
* 模型事件和数据库事件统一纳入事件系统
* 模板引擎分离出核心
* 内部功能中间件化
* SESSION/Cookie机制改进
* 对Swoole以及协程支持改进
* 对IDE更加友好
* 统一和精简大量用法

## 安装

~~~
composer create-project topthink/think tp 6.0.*-dev
~~~

如果需要更新框架使用
~~~
composer update topthink/framework
~~~

## 文档

[完全开发手册](https://www.kancloud.cn/manual/thinkphp6_0/content)

## 参与开发

请参阅 [ThinkPHP 核心框架包](https://github.com/top-think/framework)。

## 版权信息

ThinkPHP遵循Apache2开源协议发布，并提供免费使用。

本项目包含的第三方源码和二进制文件之版权信息另行标注。

版权所有Copyright © 2006-2019 by ThinkPHP (http://thinkphp.cn)

All rights reserved。

ThinkPHP® 商标和著作权所有者为上海顶想信息科技有限公司。

更多细节参阅 [LICENSE.txt](LICENSE.txt)

php 8.0.3
composer 需要更新 ?
安装不是最新的 6.0.3 最新 6.0.7 
thinkphp 6.0.7 
thinkphp 6.0.3 
php think version
php think run -H 0.0.0.0  -p 8003

rpc
grpc(需要安装第三方扩展) thrift(需要第三方类库(github)))
放弃 支持 http


//怎么访问
php think make:controller index@Test
restful 
php think make:controller index@Test --api
==
php think make:controller app\index\controller\Test
Route::resource('test', 'Test');


//http://192.168.1.3:8003/test
//http://192.168.1.3:8003/test/read
php think make:controller Test
restful
php think make:controller Test --api
==
php think make:controller  app\controller\Test
Route::resource('test', 'Test');

//could not find driver
//修改配置 mysql 取消注释
//php.ini

//middleware app/middleware/StaticResource.php
php think make:middleware StaticResource

composer require topthink/think-migration
php think migrate:create TpTest
php think migrate:run

需要 手动 定义 迁移格式(默认 迁移格式为 null ) 怎么自动根据模型 生成 迁移格式 
不然 原生 sql 建表 建库  

Undefined array key "hostname"
You need to enable the PDO_SQLITE extension for Phinx to run properly.
php.ini sqlite 取消注释

composer require phpenum/phpenum

https://www.kancloud.cn/manual/thinkphp6_0/1037577
swoole
https://www.swoole.com/