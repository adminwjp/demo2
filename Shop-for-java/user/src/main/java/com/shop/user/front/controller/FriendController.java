package com.shop.user.front.controller;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.FriendDto;
import com.shop.user.exception.UserTypeException;
import com.shop.user.factory.UserTypeFactory;
import com.shop.user.front.service.FriendService;
import com.shop.util.CommonUtil;
import com.utility.service.dto.ResponseApi;
import com.utility.service.dto.Tuple;
import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@RestController
@Api(value = "好友信息")
@RequestMapping("/api/v1")
public class FriendController    {
    @Autowired
    FriendService frontFriendService;
    ResponseApi save(String userType, long userid, FriendDto friendDto) throws UserTypeException{
        UserTypeFactory.checkUserType(userType);
        friendDto.setUserid(userid);
        friendDto.setUserType(userType);
        if(frontFriendService.save(friendDto)>0){
            return   ResponseApi.Success;
        }
        return   ResponseApi.Fail;
    }
    @GetMapping("/{userType}/friend/add/{userid}")
    public ResponseApi  insert(@PathVariable String userType,@PathVariable long userid,@RequestBody FriendDto friendDto) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return  save(userType,userid,friendDto);
    }
    @GetMapping("/{userType}/friend/update/{userid}/{id}")
    public ResponseApi  update(@PathVariable String userType,@PathVariable long userid, @PathVariable int id,@RequestBody FriendDto friendDto) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return  save(userType,userid,friendDto);
    }
    @GetMapping("/{userType}/friend/delete/{userid}/{id}")
    public ResponseApi  delete(@PathVariable String userType,@PathVariable long userid, @PathVariable int id) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        DeleteDto deleteDto=new DeleteDto();
        deleteDto.setId(id);
        return  remove(userType,userid,deleteDto);
    }
    ResponseApi  remove(String userType, long userid,DeleteDto deleteDto ){
        deleteDto.setUserId(userid);
        deleteDto.setUserType(userType);
        if(frontFriendService.delete(deleteDto)>0){
            return   ResponseApi.Success;
        }
        return   ResponseApi.Fail;
    }
    @ApiOperation(value = "根据id 删除用户好友信息")
    @PostMapping("/{userType}/friend/delete/{userid}")
    public ResponseApi  deleteMany(@PathVariable String userType,@PathVariable long userid, @RequestBody DeleteDto deleteDto) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return  remove(userType,userid,deleteDto);
    }

    @GetMapping("/{userType}/friend/list/{userid}/{page}/{size}")
    public ResponseApi list(@PathVariable String userType,@PathVariable long userid, @PathVariable int page, @PathVariable int size) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        FriendDto getDto=new FriendDto();
        getDto.setEnablePage(true);
        page=CommonUtil.getPage(page);
        size=CommonUtil.getPage(size);
        getDto.setPage(page);
        getDto.setSize(size);
        getDto.setUserType(userType);
        getDto.setUserid(userid);
        Tuple<List<FriendDto>,Long> tuple =frontFriendService.getList(getDto);
        HashMap<String,Object> data= CommonUtil.getData(page,size,tuple);
        return   ResponseApi.success().setData(data);
    }
}
