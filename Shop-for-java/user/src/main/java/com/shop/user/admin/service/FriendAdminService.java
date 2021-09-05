package com.shop.user.admin.service;

import com.shop.user.dto.FriendDto;
import com.utility.service.dto.Tuple;

import java.util.List;

public interface FriendAdminService {
    Tuple<List<FriendDto>,Long> getList(FriendDto friendDto);
}
