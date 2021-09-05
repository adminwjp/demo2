package com.shop.user.front.service;

import com.shop.dto.GetDto;
import com.shop.user.dto.AddressDto;
import com.shop.user.dto.DeleteDto;
import com.shop.user.front.dto.*;
import com.utility.service.dto.Tuple;

import java.util.List;

public interface AddressService {
    //删除地址 不存在 默认地址 则 根据id 排序设置 第一个为默认地址(无论是否有地址列表)
      boolean  delete(DeleteDto deleteAddressDto);
    //根据 id 设置 默认地址 其它默认地址则取消默认
      boolean setDefaultAddr(UpdateDefaultAddressDto updateDefaultAddressDto);
      boolean exists(ExistsDefaultAddressDto existsDefaultAddressDto);
      boolean save(AddressDto address);
     Tuple<List<AddressDto>,Long> getList(AddressDto getAddressDto);
}
