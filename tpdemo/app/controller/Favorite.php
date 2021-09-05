<?php
declare (strict_types = 1);

namespace app\controller;

use app\models\FavoriteEntity;
use think\Request;

class Favorite
{
    public function initialize()
    {
        header('Access-Control-Allow-Origin:*');
        header('Access-Control-Allow-Methods:OPTIONS,GET,POST');
        header('Access-Control-Max-Age:60');
        header('Access-Control-Allow-Headers:x-requested-with,content-type,user-agent,auth,x-agent,Origin,hea');
        header('Content-Type:application/json;charset=utf-8');
    }
    /**
     * 显示资源列表
     *
     * @return \think\Response
     */
    public function index()
    {
        //
    }

    /**
     * 显示创建资源表单页.
     *
     * @return \think\Response
     */
    public function create()
    {
        //
        $user_id  = (int) $this->request->param('user_id');
        $object_id = (int) $this->request->param('object_id');
        FavoriteEntity::create(array(
            //'id'          => 'int',
            'user_id'        => $user_id , //收藏用户Id
            'object_id'        =>  $object_id,//收藏对象Id
            'favorite_date'        => time(),//收藏时间
            'is_favorite'        => 1,//是否收藏
        ));
        return json(array(
            'msg'=>"success",
            'code'=>200
       ));
    }

    /**
     * 保存新建的资源
     *
     * @param  \think\Request  $request
     * @return \think\Response
     */
    public function save(Request $request)
    {
        //
        $id  = (int) $this->request->param('id');
        $user_id  = (int) $this->request->param('user_id');
        $object_id = (int) $this->request->param('object_id');
        $is_favorite = (int) $this->request->param('is_favorite');
        FavoriteEntity::update(array(
            //'id'          => 'int',
            'user_id'        => $user_id , //收藏用户Id
            'object_id'        =>  $object_id,//收藏对象Id
            'favorite_date'        => time(),//收藏时间
            'is_favorite'        => $is_favorite,//是否收藏
        ),['id'=>$id]);
        return json(array(
            'msg'=>"success",
            'code'=>200
        ));
    }

    /**
     * 显示指定的资源
     *
     * @param  int  $id
     * @return \think\Response
     */
    public function read($id)
    {
        //
        $f=FavoriteEntity::where(array('id'=>$id))->find();
        return json(array(
            'msg'=>"success",
            'data'=>$f,
            'code'=>200
        ));
    }

    /**
     * 显示编辑资源表单页.
     *
     * @param  int  $id
     * @return \think\Response
     */
    public function edit($id)
    {
        //
    }

    /**
     * 保存更新的资源
     *
     * @param  \think\Request  $request
     * @param  int  $id
     * @return \think\Response
     */
    public function update(Request $request, $id)
    {
        //
        return $this->save($request);
    }

    /**
     * 删除指定资源
     *
     * @param  int  $id
     * @return \think\Response
     */
    public function delete($id)
    {
        //
        $f=FavoriteEntity::where(array('id'=>$id))->delete();
        if ($f){
            return json(array(
                'msg'=>"success",
                'code'=>200
            ));
        }
        return json(array(
            'msg'=>"fail",
            'code'=>400
        ));
    }
}
