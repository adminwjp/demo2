package com.shop.user.front.service;

import com.shop.exception.ExistsException;
import com.shop.exception.NotExistsException;
import com.shop.user.dto.*;
import com.utility.service.dto.Tuple;
import com.utility.util.RegexUtil;

import java.util.List;
import java.util.regex.Pattern;

public interface UserService {
    public UserDto login(UserLoginOrRegisterDto user) throws NotExistsException ;
    public boolean loginByAccount(UserLoginOrRegisterDto user);
    public boolean loginByPhone(UserLoginOrRegisterDto user);
    public boolean loginByEmail(UserLoginOrRegisterDto user);
    public boolean register(UserLoginOrRegisterDto user) throws ExistsException;
    public boolean registerByAccount(UserLoginOrRegisterDto user);
    public boolean registerByPhone(UserLoginOrRegisterDto user);
    public boolean registerByEmail(UserLoginOrRegisterDto user);

    public boolean exists(String account,String userType);
    public boolean existsAccount(String account,String userType);
    public boolean existsPhone(String account,String userType);
    public boolean existsEmail(String account, String userType);
    public  boolean updatePwd(UpdateUserPwdDto userPwdDto);
    public  boolean updatePwdByAccount(UpdateUserPwdDto userPwdDto);
    public boolean updatePwdByPhone(UpdateUserPwdDto userPwdDto);
    public boolean updatePwdByEmail(UpdateUserPwdDto userPwdDto);
    public Tuple<List<UserDto>,Long> getList(UserDto getDto);
}
