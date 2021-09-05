package com.shop.user.front.mapper;

import com.shop.dto.ExistsDto;
import com.shop.dto.GetDto;
import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.FriendDto;

import java.util.List;

public interface  FriendMapper  {
    int add(FriendDto friend);
    int modify(FriendDto friend);
    int delete(DeleteDto deleteDto);
    int exists(ExistsDto existsDto);
    List<FriendDto> select(FriendDto getDto);
    long count(FriendDto getDto);
}
