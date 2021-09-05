package com.shop.user.admin.service.impl;

import com.shop.SpringContextUtil;
import com.shop.user.admin.service.AddressAdminService;
import com.shop.user.dto.AddressDto;
import com.shop.user.dto.UserDto;
import com.shop.user.dto.UserType;
import com.shop.user.entity.address.*;
import com.utility.service.dto.Tuple;
import com.utility.util.MapperUtils;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import javax.persistence.EntityManager;
import java.util.List;


@Service("adminAddressService")
@Transactional("jpaTransactionManager")
public class AddressAdminServiceImpl  implements AddressAdminService {

    public Tuple<List<AddressDto>,Long> getList(AddressDto addressDto){

        UserType userType=UserType.parseUserTypes(addressDto.getUserType());
        switch (userType){
            case Manufacturer:return  getList(addressDto, ManufacturerAddress.class);
            case Seller:return  getList(addressDto, SellerAddress.class);
            case Buyer: return  getList(addressDto, BuyerAddress.class);
            case Agent:   return  getList(addressDto, AgentAddress.class);
            case Admin:break;
            case Platform:   return  getList(addressDto, PlatformAddress.class);
            case None:
                break;
        }
        return new Tuple<List<AddressDto>,Long>(null,0l);
    }

    static <T extends Address> Tuple<List<AddressDto>,Long> getList(AddressDto addressDto, Class<T> cls){
        EntityManager entityManager= SpringContextUtil.getApplicationContext().getBean(EntityManager.class);
        JpaRepository<T,Long>  jpaRepository =new SimpleJpaRepository<T,Long>(cls,entityManager);
        Long count=jpaRepository.count();
        List<T> data=jpaRepository.findAll();
        List<AddressDto> addressDtos=null;
        if(data!=null){
            addressDtos= MapperUtils.mapper(data,cls,AddressDto.class);
        }
        return new Tuple<List<AddressDto>,Long>(addressDtos,count);

    }
}
