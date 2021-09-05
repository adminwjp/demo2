package com.shop.user.front.controller;

import com.shop.user.exception.UserTypeException;
import com.shop.user.dto.AddressDto;
import com.shop.user.dto.DeleteDto;
import com.shop.user.front.dto.UpdateDefaultAddressDto;
import com.shop.user.factory.UserTypeFactory;
import com.shop.user.front.service.AddressService;
import com.shop.util.CommonUtil;
import com.utility.service.dto.ResponseApi;
import com.utility.service.dto.Tuple;
import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@Api(value = "用户地址信息")
@RestController
@RequestMapping("/api/v1")
public class AddressController {
    @Autowired
    AddressService frontAddressService;
    ResponseApi  save(String userType, long userid,  AddressDto addressDto) throws UserTypeException{
        UserTypeFactory.checkUserType(userType);
        addressDto.setUserid(userid);
        addressDto.setUserType(userType);
        if(frontAddressService.save(addressDto)){
            return   ResponseApi.Success;
        }
        return   ResponseApi.Fail;
    }

    @ApiOperation(value = "添加用户地址信息")
    @PostMapping("/{userType}/address/add/{userid}")
    public ResponseApi  insert(@PathVariable String userType,@PathVariable long userid, @RequestBody AddressDto addressDto) throws UserTypeException {
        return  save(userType,userid,addressDto);
    }
    @ApiOperation(value = "设置 用户默认 地址")
    @PostMapping("/{userType}/address/default/{userid}/{id}")
    public ResponseApi  set(@PathVariable String userType,@PathVariable long userid,@PathVariable long id) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        UpdateDefaultAddressDto defaultAddressDto=new UpdateDefaultAddressDto();
        defaultAddressDto.setAddressId(id);
        defaultAddressDto.setUserId(userid);
        defaultAddressDto.setUserType(userType);
        if(frontAddressService.setDefaultAddr(defaultAddressDto)){
            return   ResponseApi.Success;
        }
        return   ResponseApi.Fail;
    }
    @ApiOperation(value = "编辑用户地址信息")
    @PostMapping("/{userType}/address/update/{userid}")
    public ResponseApi  update(@PathVariable String userType,@PathVariable long userid, @RequestBody AddressDto addressDto) throws UserTypeException {
        return  save(userType,userid,addressDto);
    }
    @ApiOperation(value = "根据id 删除用户地址信息")
    @GetMapping("/{userType}/address/delete/{userid}/{id}")
    public ResponseApi  delete(@PathVariable String userType,@PathVariable long userid, @PathVariable int id) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        DeleteDto deleteDto=new DeleteDto();
        deleteDto.setId(id);
        return  remove(userType,userid,deleteDto);
    }
    ResponseApi  remove(String userType, long userid,DeleteDto deleteDto ){
      deleteDto.setUserId(userid);
      deleteDto.setUserType(userType);
      if(frontAddressService.delete(deleteDto)){
          return   ResponseApi.Success;
      }
      return   ResponseApi.Fail;
  }
    @ApiOperation(value = "根据id 删除用户地址信息")
    @PostMapping("/{userType}/address/delete/{userid}")
    public ResponseApi  deleteMany(@PathVariable String userType,@PathVariable long userid, @RequestBody DeleteDto deleteDto) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return  remove(userType,userid,deleteDto);
    }

    @ApiOperation(value = "分页查询 用户地址信息")
    @GetMapping("/{userType}/address/list/{userid}/{page}/{size}")
    public ResponseApi list(@PathVariable String userType,@PathVariable long userid, @PathVariable int page, @PathVariable int size) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        AddressDto getDto=new AddressDto();
        page=CommonUtil.getPage(page);
        size=CommonUtil.getPage(size);
        getDto.setEnablePage(true);
        getDto.setPage(page);
        getDto.setSize(size);
        getDto.setUserType(userType);
        getDto.setUserid(userid);
        Tuple<List<AddressDto>,Long> tuple =frontAddressService.getList(getDto);
        HashMap<String,Object> data= CommonUtil.getData(page,size,tuple);
        return   ResponseApi.success().setData(data);
    }


}
