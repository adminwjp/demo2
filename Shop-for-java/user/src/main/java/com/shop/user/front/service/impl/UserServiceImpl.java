package com.shop.user.front.service.impl;

import com.shop.dto.GetDto;
import com.shop.exception.ExistsException;
import com.shop.exception.NotExistsException;
import com.shop.user.dto.*;
import com.shop.user.front.mapper.UserMapper;
import com.shop.user.front.service.UserService;
import com.utility.service.dto.Tuple;
import com.utility.util.RegexUtil;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.regex.Pattern;

@Service("frontUserService")
@Transactional("platformTransactionManager")
public class UserServiceImpl  implements UserService {
    Log log= LogFactory.getLog(UserServiceImpl.class);
    @Autowired
    UserMapper userMapper;
    UserDto set(UserLoginOrRegisterDto user){
        UserDto userDto=new UserDto();
        userDto.setPassword(user.getPwd());
        if(user.getType()== AccountType.Account){
            userDto.setAccount(user.getAccount());
        }
        if(user.getType()== AccountType.Phone){
            userDto.setPhoneMob(user.getAccount());
        }
        if(user.getType()== AccountType.Email){
            userDto.setEmail(user.getAccount());
        }
        userDto.setUserType(user.getUserType());
        return  userDto;
    }
    UserDto set(UpdateUserPwdDto user){
        UserDto userDto=new UserDto();
        userDto.setPassword(user.getPwd());
        if(user.getType()== AccountType.Account){
            userDto.setAccount(user.getAccount());
        }
        if(user.getType()== AccountType.Phone){
            userDto.setPhoneMob(user.getAccount());
        }
        if(user.getType()== AccountType.Email){
            userDto.setEmail(user.getAccount());
        }

        return  userDto;
    }
    public UserDto login(UserLoginOrRegisterDto user) throws NotExistsException {
        UserDto userDto=set(user);
        long count=userMapper.count(userDto);
        if(count==0){
            log.warn(user.getUserType()+"==>>"+user.getAccount()+"  not exists,login fail!");
            throw  new NotExistsException();
        }
        List<UserDto> data=  userMapper.query(userDto);
        if(data!=null&&data.size()==1){
            return data.get(0);
        }
        return  null;
    }
    public boolean loginByAccount(UserLoginOrRegisterDto user){
        user.setType(AccountType.Account);
        return  loginByAccount(user);
    }
    public boolean loginByPhone(UserLoginOrRegisterDto user){
        user.setType(AccountType.Phone);
        return  loginByAccount(user);
    }
    public boolean loginByEmail(UserLoginOrRegisterDto user){
        user.setType(AccountType.Email);
        return  loginByAccount(user);
    }
    public boolean register(UserLoginOrRegisterDto user) throws ExistsException {
        UserDto userDto=set(user);
        long count=userMapper.count(userDto);
        if(count>0){
            log.warn(user.getUserType()+"==>>"+user.getAccount()+"   exists,register fail!");
            throw  new ExistsException();
        }
        userDto.setCreateTime(System.currentTimeMillis());
        return  userMapper.add(userDto);
    }
    public boolean registerByAccount(UserLoginOrRegisterDto user){
        user.setType(AccountType.Account);
        return  registerByAccount(user);
    }
    public boolean registerByPhone(UserLoginOrRegisterDto user){
        user.setType(AccountType.Phone);
        return  registerByAccount(user);
    }
    public boolean registerByEmail(UserLoginOrRegisterDto user){
        user.setType(AccountType.Email);
        return  registerByAccount(user);
    }

    public boolean exists(String account,String userType){
        UserLoginOrRegisterDto user=new UserLoginOrRegisterDto();
        if(RegexUtil.isPhone(account)){
            user.setType( AccountType.Phone);
        }
        else if(Pattern.matches("[a-z|A-Z|\\d\\.]*]",account)){
            user.setType( AccountType.Email);
        }else{
            user.setType( AccountType.Account);
        }
        user.setUserType(userType);
        user.setAccount(account);
        UserDto userDto=set(user);
        long count=userMapper.count(userDto);
        return  count>0;
    }
    public boolean existsAccount(String account,String userType){
        return  exists(account,userType);
    }
    public boolean existsPhone(String account,String userType){
        return  exists(account,userType);
    }
    public boolean existsEmail(String account,String userType){
        return  exists(account,userType);
    }
    public  boolean updatePwd(UpdateUserPwdDto userPwdDto){
        UserDto userDto=set(userPwdDto);
        userDto.setPassword(userDto.getPassword());
        long count=userMapper.queryCount(userDto);
        if(count==0){
            log.warn(userPwdDto.getUserType()+"==>>"+userPwdDto.getAccount()+" not   exists or pwd error,updatePwd fail!");
            return  false;
        }
        userDto.setUpdateTime(System.currentTimeMillis());
        userDto.setPassword(userPwdDto.getNewPwd());
        return  userMapper.modify(userDto);
    }
    public  boolean updatePwdByAccount(UpdateUserPwdDto userPwdDto){
        userPwdDto.setType(AccountType.Account);
        return  updatePwd(userPwdDto);
    }
    public boolean updatePwdByPhone(UpdateUserPwdDto userPwdDto){
        userPwdDto.setType(AccountType.Phone);
        return  updatePwd(userPwdDto);
    }
    public boolean updatePwdByEmail(UpdateUserPwdDto userPwdDto){
        userPwdDto.setType(AccountType.Email);
        return  updatePwd(userPwdDto);
    }
    public Tuple<List<UserDto>,Long> getList(UserDto getDto){
        List<UserDto> data=userMapper.select(getDto);
        long count=userMapper.count(getDto);
        return  new Tuple<List<UserDto>,Long>(data,count);
    }

}
