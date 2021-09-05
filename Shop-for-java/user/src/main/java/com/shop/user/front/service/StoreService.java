package com.shop.user.front.service;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.ShopDto;
import com.utility.service.dto.Tuple;

import java.util.List;

public interface StoreService {
    int save(ShopDto storeDto);
    int delete(DeleteDto deleteDto);
    Tuple<List<ShopDto>,Long> getList(ShopDto getDto);
}
