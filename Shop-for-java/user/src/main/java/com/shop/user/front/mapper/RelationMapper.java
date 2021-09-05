package com.shop.user.front.mapper;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.ShopDto;
import com.shop.user.entity.Relation;

import java.util.List;

public interface RelationMapper {
    int add(Relation relation);
    int modify(Relation relation);
    int delete(DeleteDto deleteDto);
    List<ShopDto> select(Relation getDto);
    long count(Relation getDto);
}
