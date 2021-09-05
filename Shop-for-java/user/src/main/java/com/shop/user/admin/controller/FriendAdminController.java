package com.shop.user.admin.controller;

import com.shop.user.admin.service.FriendAdminService;
import com.shop.user.dto.FriendDto;
import com.shop.user.exception.UserTypeException;
import com.shop.user.factory.UserTypeFactory;
import com.shop.util.CommonUtil;
import com.utility.service.dto.ResponseApi;
import com.utility.service.dto.Tuple;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.HashMap;
import java.util.List;

@RequestMapping("/api/v1/admin")
@RestController
public class FriendAdminController {
    @Autowired
    FriendAdminService adminFriendService;
    @GetMapping("/{userType}/friend/list/{page}/{size}")
    public ResponseApi list(@PathVariable String userType, @PathVariable int page, @PathVariable int size) throws UserTypeException {
        UserTypeFactory.checkUserType(userType);
        FriendDto getDto=new FriendDto();
        getDto.setEnablePage(true);
        page= CommonUtil.getPage(page);
        size=CommonUtil.getPage(size);
        getDto.setPage(page);
        getDto.setSize(size);
        getDto.setUserType(userType);
        Tuple<List<FriendDto>,Long> tuple =adminFriendService.getList(getDto);
        HashMap<String,Object> data= CommonUtil.getData(page,size,tuple);
        return   ResponseApi.success().setData(data);
    }
}
