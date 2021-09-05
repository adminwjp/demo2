package com.shop.user.front.dto;

import com.shop.SqlType;
import lombok.Data;

@Data
public class UpdateDefaultAddressDto {
    String sqlType= SqlType.Mysql;
    String userType;
    long userId;
    long addressId;
    boolean isDefault;
    public  static  ExistsDefaultAddressDto  toExists(UpdateDefaultAddressDto updateDefaultAddressDto){
        ExistsDefaultAddressDto existsDefaultAddressDto=new ExistsDefaultAddressDto();
        existsDefaultAddressDto.userType=updateDefaultAddressDto.userType;
        existsDefaultAddressDto.userId=updateDefaultAddressDto.userId;
        existsDefaultAddressDto.addressId=updateDefaultAddressDto.addressId;
        existsDefaultAddressDto.isDefault=updateDefaultAddressDto.isDefault;
        return  existsDefaultAddressDto;
    }
}
