<?php

use think\migration\Migrator;
use think\migration\db\Column;

class TpTest extends Migrator
{
    /**
     * Change Method.
     *
     * Write your reversible migrations using this method.
     *
     * More information on writing migrations is available here:
     * http://docs.phinx.org/en/latest/migrations.html#the-abstractmigration-class
     *
     * The following commands can be used in this method and Phinx will
     * automatically reverse them when rolling back:
     *
     *    createTable
     *    renameTable
     *    addColumn
     *    renameColumn
     *    addIndex
     *    addForeignKey
     *
     * Remember to call "create()" or "update()" and NOT "save()" when working
     * with the Table class.
     */
    public function change()
    {

        //https://www.kancloud.cn/manual/thinkphp6_0/1118028
        // create the table

        $favorite  =  $this->table('t_favorite'
        //,['id'=>'id']
        //, ['id' => false,'primary_key' => ['id']]
        );
        $favorite
            //->addColumn('id', 'int',array('comment'=>'收藏id'))
            ->addColumn('user_id', 'integer',array('comment'=>'用户id'))
            ->addColumn('object_id', 'integer',array('comment'=>'收藏对象id'))
            ->addColumn('is_favorite', 'integer',array('comment'=>'是否收藏 默认收藏'))
            ->addColumn('favorite_date', 'integer',array('comment'=>'收藏时间'))
            ->create();


        $product_favorite  =  $this->table('t_product_favorite'
        //,['id'=>'id']
        //, ['id' => false,'primary_key' => ['id']]
        );
        $product_favorite
            //->addColumn('id', 'int',array('comment'=>'收藏id'))
            ->addColumn('user_id', 'integer',array('comment'=>'用户id'))
            ->addColumn('product_id', 'integer',array('comment'=>'收藏商品id'))
            ->addColumn('is_favorite', 'integer',array('comment'=>'是否收藏 默认收藏'))
            ->addColumn('favorite_date', 'integer',array('comment'=>'收藏时间'))
            ->addColumn('last_date', 'integer',array('comment'=>'最后收藏时间'))
            ->create();




        $shop_favorite  =  $this->table('t_shop_favorite'
        //   ,['id'=>'id']
        //, ['id' => false,'primary_key' => ['id']]
        );
        $shop_favorite
            //->addColumn('id', 'int',array('comment'=>'收藏id'))
            ->addColumn('user_id', 'integer',array('comment'=>'用户id'))
            ->addColumn('shop_id', 'integer',array('comment'=>'收藏店铺id'))
            ->addColumn('is_favorite', 'integer',array('comment'=>'是否收藏 默认收藏'))
            ->addColumn('favorite_date', 'integer',array('comment'=>'收藏时间'))
            ->addColumn('last_date', 'integer',array('comment'=>'最后收藏时间'))
            ->create();
    }
}
