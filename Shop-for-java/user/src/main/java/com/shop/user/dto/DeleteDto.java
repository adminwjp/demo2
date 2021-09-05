package com.shop.user.dto;

import com.shop.user.front.dto.ExistsDefaultAddressDto;
import com.shop.user.front.dto.UpdateDefaultAddressDto;
import lombok.Data;
import java.util.List;

@Data
public class DeleteDto {
    String userType;
    long userId;
    List<Long> ids;//post
    long id;//get
    boolean isDefault;
    public  static ExistsDefaultAddressDto toExists(DeleteDto deleteAddressDto){
        ExistsDefaultAddressDto existsDefaultAddressDto=new ExistsDefaultAddressDto();
        to(existsDefaultAddressDto,deleteAddressDto);
        return  existsDefaultAddressDto;
    }

    public  static <T extends UpdateDefaultAddressDto> void  to(T obj,DeleteDto deleteAddressDto){
        obj.setUserType(deleteAddressDto.userType);
        obj.setUserId(deleteAddressDto.userId);
        obj.setAddressId(deleteAddressDto.id);
        obj.setDefault(true);
    }
    public  static UpdateDefaultAddressDto toUpdate(DeleteDto deleteAddressDto){
        UpdateDefaultAddressDto updateDefaultAddressDto=new UpdateDefaultAddressDto();
        to(updateDefaultAddressDto,deleteAddressDto);
        return  updateDefaultAddressDto;
    }
}
