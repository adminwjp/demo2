package com.shop.user.front.mapper;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.TeambuyDto;
import com.shop.user.dto.TeambuyLogDto;

import java.util.List;

public interface TeambuyLogMapper {
    int add(TeambuyLogDto teambuyLogDto);
    int modify(TeambuyLogDto teambuyLogDto);
    int delete(DeleteDto deleteDto);
    List<TeambuyLogDto> select(TeambuyLogDto getDto);
    long count(TeambuyLogDto getDto);
}
