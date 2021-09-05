package com.shop.user.front.service.impl;

import com.shop.user.dto.AddressDto;
import com.shop.user.dto.DeleteDto;
import com.shop.user.front.dto.ExistsDefaultAddressDto;
import com.shop.user.front.dto.UpdateDefaultAddressDto;
import com.shop.user.front.mapper.AddressMapper;
import com.shop.user.front.service.AddressService;
import com.utility.service.dto.Tuple;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("frontAddressService")
@Transactional("platformTransactionManager")
public class AddressServiceImpl implements AddressService {
    @Autowired
    AddressMapper addressMapper;
    //删除地址 不存在 默认地址 则 根据id 排序设置 第一个为默认地址(无论是否有地址列表)
    public  boolean  delete(DeleteDto deleteAddressDto){
       boolean remove= addressMapper.delete(deleteAddressDto)>0;//delete
       if(remove){
           ExistsDefaultAddressDto existsDefaultAddressDto= DeleteDto.toExists(deleteAddressDto);
           existsDefaultAddressDto.setAddressId(0);//该用户是否存在默认地址
           if(addressMapper.exists(existsDefaultAddressDto)==0){
               UpdateDefaultAddressDto updateDefaultAddressDto= DeleteDto.toUpdate(deleteAddressDto);
               addressMapper.setDefaultAddr(updateDefaultAddressDto);//不存在默认地址设置默认地址
           }
       }
       return remove;
    }

    //根据 id 设置 默认地址 其它默认地址则取消默认
    public  boolean setDefaultAddr(UpdateDefaultAddressDto updateDefaultAddressDto){
        boolean res=   addressMapper.setDefaultAddr(updateDefaultAddressDto)>0;//不存在则 修改默认地址
        addressMapper.setNotDefaultAddr(updateDefaultAddressDto);
        return  res;
    }
    public  boolean exists(ExistsDefaultAddressDto existsDefaultAddressDto){
        return  addressMapper.exists(existsDefaultAddressDto)>0;
    }
    public  boolean save(AddressDto address){
        int res=0;
        if(address.getAddrId()>0){
            //Long id= IdFactoryImpl.Id.getId(Address.class);
           // address.setAddrId(id);
            res=  addressMapper.modify(address);
        }else{
            res= addressMapper.add(address);
        }
        if(res>0){
            if(address.isDefaddr()){
                UpdateDefaultAddressDto updateDefaultAddressDto=new UpdateDefaultAddressDto();
                updateDefaultAddressDto.setUserType(address.getUserType());
                updateDefaultAddressDto.setUserId(address.getUserid());
                return  addressMapper.setNotDefaultAddr(updateDefaultAddressDto)>0;
            }
            //return setDefaultAddr(updateDefaultAddressDto);
            return  true;
        }
        return false;
    }

    public Tuple<List<AddressDto>,Long> getList(AddressDto getAddressDto){
        List<AddressDto> res= addressMapper.select(getAddressDto);
        long count= addressMapper.count(getAddressDto);
        return  new Tuple<List<AddressDto>,Long>(res,count);
    }
}
