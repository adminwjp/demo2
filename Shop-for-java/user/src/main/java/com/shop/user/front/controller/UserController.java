package com.shop.user.front.controller;

import com.shop.exception.ExistsException;
import com.shop.exception.NotExistsException;
import com.shop.user.dto.*;
import com.shop.user.exception.UserTypeException;
import com.shop.user.factory.UserTypeFactory;
import com.shop.user.front.service.ProtocolService;
import com.shop.user.front.service.StoreService;
import com.shop.user.front.service.UserService;
import com.shop.util.CommonUtil;
import com.utility.service.dto.ResponseApi;
import com.utility.service.dto.Tuple;
import io.swagger.annotations.Api;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@Api(value = "用户信息")
@RequestMapping("/api/v1")
@RestController
public class UserController {
    @Autowired
    UserService frontUserService;
    @Autowired
    ProtocolService frontProtocolService;
    @Autowired
    StoreService frontStoreService;
    @PostMapping("/shop/add")
    public ResponseApi addShop(@RequestBody ShopDto storeDto)  {
         int res=frontStoreService.save(storeDto);
        return res>0?  ResponseApi.Success:ResponseApi.Fail;
    }

    @PostMapping("/shop/delete")
    public ResponseApi deletListShop(DeleteDto deleteDto)  {
       int res =frontStoreService.delete(deleteDto);
        return res>0?  ResponseApi.Success:ResponseApi.Fail;
    }

    @GetMapping("/shop/updade")
    public ResponseApi updateShop(@RequestBody ShopDto storeDto)  {
        int res=frontStoreService.save(storeDto);
        return res>0?  ResponseApi.Success:ResponseApi.Fail;
    }

    @GetMapping("/shop/delete")
    public ResponseApi deleteShop(@PathVariable long id)  {
        DeleteDto deleteDto=new DeleteDto();
        deleteDto.setId(id);
        int res =frontStoreService.delete(deleteDto);
        return res>0?  ResponseApi.Success:ResponseApi.Fail;
    }

    @GetMapping("/shop/list/{page}/{size}")
    public ResponseApi listShop(@PathVariable int page, @PathVariable int size)  {
        ShopDto getDto=new ShopDto();
        getDto.setEnablePage(true);
        page= CommonUtil.getPage(page);
        size=CommonUtil.getPage(size);
        getDto.setPage(page);
        getDto.setSize(size);
        Tuple<List<ShopDto>,Long> tuple =frontStoreService.getList(getDto);
        HashMap<String,Object> data= CommonUtil.getData(page,size,tuple);
        return   ResponseApi.success().setData(data);
    }
    @GetMapping("/protocol/list")
    public ResponseApi protocol()  {
            List<ProtocolDto> protocolDtos =frontProtocolService.getProtocols();
            return  ResponseApi.success().setData(protocolDtos);
    }
    ResponseApi logins(String userType, UserLoginOrRegisterDto userLoginOrRegisterDto,boolean login) throws UserTypeException, NotExistsException, ExistsException {
        UserTypeFactory.checkUserType(userType);
        userLoginOrRegisterDto.setUserType(userType);
       if(login){
           UserDto user=frontUserService.login(userLoginOrRegisterDto);
           if(user!=null){
               return   ResponseApi.Success;
           }
       }else{
           if(frontUserService.register(userLoginOrRegisterDto)){
               return   ResponseApi.Success;
           }
       }
        return   ResponseApi.Fail;
    }
    @PostMapping("/{userType}/login")
    public ResponseApi login(@PathVariable String userType,@RequestBody UserLoginOrRegisterDto user) throws UserTypeException, NotExistsException, ExistsException {
        UserTypeFactory.checkUserType(userType);
        return logins(userType,user,true);
    }

    @PostMapping("/{userType}/account/login")
    public ResponseApi loginByAccount(@PathVariable String userType,@RequestBody UserLoginOrRegisterDto user) throws UserTypeException, NotExistsException, ExistsException {
        UserTypeFactory.checkUserType(userType);
        return logins(userType,user,true);
    }

    @PostMapping("/{userType}/phone/login")
    public ResponseApi loginByPhone(@PathVariable String userType,@RequestBody UserLoginOrRegisterDto user) throws UserTypeException, NotExistsException, ExistsException {
        UserTypeFactory.checkUserType(userType);
        return logins(userType,user,true);
    }

    @PostMapping("/{userType}/email/login")
    public ResponseApi loginByEmail(@PathVariable String userType,@RequestBody UserLoginOrRegisterDto user) throws UserTypeException, NotExistsException, ExistsException {
        UserTypeFactory.checkUserType(userType);
        return logins(userType,user,true);
    }

    @PostMapping("/{userType}/register")
    public ResponseApi register(@PathVariable String userType,@RequestBody UserLoginOrRegisterDto user) throws UserTypeException, NotExistsException, ExistsException {
        UserTypeFactory.checkUserType(userType);
        return logins(userType,user,false);
    }

    @PostMapping("/{userType}/account/register")
    public ResponseApi registerByAccount(@PathVariable String userType,@RequestBody UserLoginOrRegisterDto user) throws UserTypeException, NotExistsException, ExistsException {
        UserTypeFactory.checkUserType(userType);
        return logins(userType,user,false);
    }

    @PostMapping("/{userType}/phone/register")
    public ResponseApi registerByPhone(@PathVariable String userType,@RequestBody UserLoginOrRegisterDto user) throws UserTypeException, NotExistsException, ExistsException {
        UserTypeFactory.checkUserType(userType);
        return logins(userType,user,false);
    }

    @PostMapping("/email/register")
    public ResponseApi registerByEmail(@PathVariable String userType,@RequestBody UserLoginOrRegisterDto user) throws UserTypeException, NotExistsException, ExistsException {
        UserTypeFactory.checkUserType(userType);
        return logins(userType,user,false);
    }

    ResponseApi  ex(String userType,String account){
        if(frontUserService.exists(account,userType)){
                return   ResponseApi.Success;
        }
        return   ResponseApi.Fail;
    }
    @GetMapping("/{userType}/exists/{account}/{type}")
    public ResponseApi exists(@PathVariable String userType,@PathVariable  String account,@PathVariable AccountType type) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return ex(userType,account);
    }
    @GetMapping("/{userType}/account/exists/{account}")
    public ResponseApi existsAccount(@PathVariable String userType,@PathVariable  String account) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return ex(userType,account);
    }
    @GetMapping("/{userType}/phone/exists/{account}")
    public ResponseApi existsPhone(@PathVariable String userType,@PathVariable  String account) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return ex(userType,account);
    }
    @GetMapping("/{userType}/email/exists/{account}")
    public ResponseApi existsEmail(@PathVariable String userType,@PathVariable  String account) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return ex(userType,account);
    }
    ResponseApi  upPwd( String userType,UpdateUserPwdDto user){
        user.setUserType(userType);
       if(frontUserService.updatePwd(user)){
           return   ResponseApi.Success;
       }
       return   ResponseApi.Fail;
   }
    @PostMapping("/{userType}/update_pwd")
    public ResponseApi updatePwd(@PathVariable String userType,@RequestBody UpdateUserPwdDto user) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return upPwd(userType,user);
    }

    @PostMapping("/{userType}/account/update_pwd")
    public ResponseApi updatePwdByAccount(@PathVariable String userType,@RequestBody UpdateUserPwdDto user) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return upPwd(userType,user);
    }

    @PostMapping("/{userType}/phone/update_pwd")
    public ResponseApi updatePwdByPhone(@PathVariable String userType,@RequestBody UpdateUserPwdDto user) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return upPwd(userType,user);
    }

    @PostMapping("/{userType}/email/update_pwd")
    public ResponseApi updatePwdByEmail(@PathVariable String userType,@RequestBody UpdateUserPwdDto user) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        return upPwd(userType,user);
    }

    @GetMapping("/{userType}/list/{page}/{size}")
    public ResponseApi list(@PathVariable String userType, @PathVariable int page, @PathVariable int size) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        UserDto getDto=new UserDto();
        getDto.setEnablePage(true);
        page= CommonUtil.getPage(page);
        size=CommonUtil.getPage(size);
        getDto.setPage(page);
        getDto.setSize(size);
        getDto.setUserType(userType);
        Tuple<List<UserDto>,Long> tuple =frontUserService.getList(getDto);
        HashMap<String,Object> data= CommonUtil.getData(page,size,tuple);
        return   ResponseApi.success().setData(data);
    }
}
