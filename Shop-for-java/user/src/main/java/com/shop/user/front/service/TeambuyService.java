package com.shop.user.front.service;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.TeambuyDto;
import com.utility.service.dto.Tuple;

import java.util.List;

public interface TeambuyService {
    int save(TeambuyDto teambuyDto);
    int delete(DeleteDto deleteDto);
    Tuple<List<TeambuyDto>,Long> getList(TeambuyDto getDto);
}
