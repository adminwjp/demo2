package com.shop.user.front.mapper;

import com.shop.dto.GetDto;
import com.shop.user.dto.AddressDto;
import com.shop.user.dto.DeleteDto;
import com.shop.user.front.dto.*;

import java.util.List;

public interface AddressMapper {
    int add(AddressDto address);
    int modify(AddressDto address);
    int delete(DeleteDto deleteAddressDto);
    int setDefaultAddr(UpdateDefaultAddressDto updateDefaultAddressDto);
    int setNotDefaultAddr(UpdateDefaultAddressDto updateDefaultAddressDto);
    int exists(ExistsDefaultAddressDto existsDefaultAddressDto);
    List<AddressDto> select(AddressDto getAddressDto);
    long count(AddressDto getAddressDto);
}
