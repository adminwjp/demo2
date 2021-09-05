package com.shop.user.front.service;

import com.shop.dto.ExistsDto;
import com.shop.dto.GetDto;
import com.shop.user.dto.FriendDto;
import com.shop.user.dto.DeleteDto;
import com.utility.service.dto.Tuple;

import java.util.List;

public interface FriendService {
    int save(FriendDto friend);
    int delete(DeleteDto deleteDto);
    int exists(ExistsDto existsDto);
    Tuple<List<FriendDto>,Long> getList(FriendDto getDto);
}
