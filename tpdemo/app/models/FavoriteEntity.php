<?php
namespace app\models;

use think\Model;

class FavoriteEntity extends Model
{
    //如果你希望给模型类添加后缀，需要设置name属性或者table属性
    protected $name = 't_favorite';
    // 设置当前模型对应的完整数据表名称
    //protected $table = 't_favorite';
    //默认主键为id，如果你没有使用id作为主键名，需要在模型中设置属性
    protected $pk = 'id';
    //https://www.kancloud.cn/manual/thinkphp6_0/1037580
    // 设置字段信息 模型对应数据表字段及类型
    protected $schema = [
        'id'          => 'int',
        'user_id'        => 'int', //收藏用户Id
        'object_id'        => 'int',//收藏对象Id
        'favorite_date'        => 'int',//收藏时间
        'is_favorite'        => 'int',//是否收藏
    ];
}

