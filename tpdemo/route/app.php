<?php
// +----------------------------------------------------------------------
// | ThinkPHP [ WE CAN DO IT JUST THINK ]
// +----------------------------------------------------------------------
// | Copyright (c) 2006~2018 http://thinkphp.cn All rights reserved.
// +----------------------------------------------------------------------
// | Licensed ( http://www.apache.org/licenses/LICENSE-2.0 )
// +----------------------------------------------------------------------
// | Author: liu21st <liu21st@gmail.com>
// +----------------------------------------------------------------------
use think\facade\Route;

Route::get('think', function () {
    return 'hello,ThinkPHP6!';
});

Route::get('hello/:name', 'index/hello');

// 设置后会自动注册7个路由规则，对应资源控制器的7个方法
//https://www.kancloud.cn/manual/thinkphp6_0/1037514
//https://www.kancloud.cn/manual/thinkphp6_0/1037501
Route::resource('test', 'Test');
//Route::resource('syj/index', 'Test');
