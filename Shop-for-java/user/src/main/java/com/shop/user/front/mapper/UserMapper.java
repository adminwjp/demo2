package com.shop.user.front.mapper;


import com.shop.dto.ExistsDto;
import com.shop.dto.GetDto;
import com.shop.user.dto.UpdateUserPwdDto;
import com.shop.user.dto.UserDto;
import com.shop.user.dto.UserLoginOrRegisterDto;

import java.util.List;

public interface UserMapper {
    boolean add(UserDto user);
    boolean modify(UserDto user);
    boolean exists(ExistsDto existsDto);
    //or
    List<UserDto> select(UserDto getDto);
    //and
    List<UserDto> query(UserDto getDto);
    long count(UserDto getDto);

    long queryCount(UserDto getDto);
}
