package com.shop.user.admin.service;

import com.shop.user.dto.AddressDto;
import com.utility.service.dto.Tuple;

import java.util.List;

public interface AddressAdminService {
    Tuple<List<AddressDto>,Long> getList(AddressDto addressDto);
}
