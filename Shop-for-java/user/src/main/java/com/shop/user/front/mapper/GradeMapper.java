package com.shop.user.front.mapper;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.GradeDto;
import com.shop.user.dto.ShopDto;
import com.shop.user.entity.Region;

import java.util.List;

public interface GradeMapper {
    int add(GradeDto gradeDto);
    int modify(GradeDto gradeDto);
    int delete(DeleteDto deleteDto);
    List<ShopDto> select(GradeDto getDto);
    long count(GradeDto getDto);
}
