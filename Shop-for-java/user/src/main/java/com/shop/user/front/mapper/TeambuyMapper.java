package com.shop.user.front.mapper;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.TeambuyDto;

import java.util.List;

public interface TeambuyMapper {
    int add(TeambuyDto bankDto);
    int modify(TeambuyDto bankDto);
    int delete(DeleteDto deleteDto);
    List<TeambuyDto> select(TeambuyDto getDto);
    long count(TeambuyDto getDto);
}
