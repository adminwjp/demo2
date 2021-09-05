package com.shop.user.admin.service;

import com.shop.user.dto.UserDto;
import com.utility.service.dto.Tuple;

import java.util.List;

public interface UserAdminService {
    Tuple<List<UserDto>,Long> getList(UserDto userDto);
}
