package com.shop.user.front.mapper;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.ShopDto;

import java.util.List;

public interface ShopMapper {
    int add(ShopDto storeDto);
    int modify(ShopDto storeDto);
    int delete(DeleteDto deleteDto);
    List<ShopDto> select(ShopDto getDto);
    long count(ShopDto getDto);
}
