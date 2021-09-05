package com.shop.user.front.mapper;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.ShopDto;
import com.shop.user.entity.Region;
import com.shop.user.entity.Relation;

import java.util.List;

public interface RegionMapper {
    int add(Region region);
    int modify(Region region);
    int delete(DeleteDto deleteDto);
    List<ShopDto> select(Region getDto);
    long count(Region getDto);
}
