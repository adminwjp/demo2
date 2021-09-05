<?php
namespace app\model;

use think\Model;

class Catalog extends Model
{
    //如果你希望给模型类添加后缀，需要设置name属性或者table属性
    protected $name = 't_catalog';
    // 设置当前模型对应的完整数据表名称
    //protected $table = 't_catalog';
    //默认主键为id，如果你没有使用id作为主键名，需要在模型中设置属性
    protected $pk = 'id';
    //https://www.kancloud.cn/manual/thinkphp6_0/1037580
    // 设置字段信息 模型对应数据表字段及类型
    protected $schema = [
        'id'          => 'int',
        'name'        => 'string', //名称
        'code'        => 'string',//编码
        'orders'      => 'int',//排序
        'pid'       => 'long',//父 编号
        'link'       => 'string',//底部导航 链接
        'remark'       => 'string',//描述
        'image_id'       => 'long',//素材路劲
        'seller_id'       => 'long',//卖家 id 代理商 卖家时有效
        'flag'       => 'long',//1 菜单 (显示导航)  2 二级 菜单 3 底部导航
        'create_time' => 'datetime',
        'update_time' => 'datetime',
    ];
}

