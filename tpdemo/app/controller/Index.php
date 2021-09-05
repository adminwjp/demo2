<?php
namespace app\controller;

use app\BaseController;

class Index extends BaseController
{
    // config/route.php
    //http://192.168.1.3:8003/index.php/index/index
    //http://192.168.1.3:8003/index/index
    //http://192.168.1.3:8003

    public function index()
    {

        return '<style type="text/css">*{ padding: 0; margin: 0; } div{ padding: 4px 48px;} a{color:#2E5CD5;cursor: pointer;text-decoration: none} a:hover{text-decoration:underline; } body{ background: #fff; font-family: "Century Gothic","Microsoft yahei"; color: #333;font-size:18px;} h1{ font-size: 100px; font-weight: normal; margin-bottom: 12px; } p{ line-height: 1.6em; font-size: 42px }</style><div style="padding: 24px 48px;"> <h1>:) </h1><p> ThinkPHP V6<br/><span style="font-size:30px">13载初心不改 - 你值得信赖的PHP框架</span></p></div><script type="text/javascript" src="https://tajs.qq.com/stats?sId=64890268" charset="UTF-8"></script><script type="text/javascript" src="https://e.topthink.com/Public/static/client.js"></script><think id="eab4b9f840753f8e7"></think>';
    }

    // route/app.php
    //http://192.168.1.3:8003/index.php/hello/a
    //http://192.168.1.3:8003/hello/a
    public function hello($name = 'ThinkPHP6')
    {
        return 'hello,' . $name;
    }

    //http://192.168.1.3:8003/index.php/index/hello1
    //http://192.168.1.3:8003/index/hello1
    public function hello1($name = 'ThinkPHP6')
    {
        return 'hello, ThinkPHP6' ;
    }
}
