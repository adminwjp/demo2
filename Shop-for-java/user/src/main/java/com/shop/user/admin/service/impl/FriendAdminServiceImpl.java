package com.shop.user.admin.service.impl;

import com.shop.SpringContextUtil;
import com.shop.user.admin.service.FriendAdminService;
import com.shop.user.dto.AddressDto;
import com.shop.user.dto.FriendDto;
import com.shop.user.dto.UserType;
import com.shop.user.entity.friend.*;
import com.utility.service.dto.Tuple;
import com.utility.util.MapperUtils;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import javax.persistence.EntityManager;
import java.util.List;

@Service("adminFriendService")
@Transactional("jpaTransactionManager")
public class FriendAdminServiceImpl  implements FriendAdminService {
    public Tuple<List<FriendDto>,Long> getList(FriendDto friendDto){

        UserType userType=UserType.parseUserTypes(friendDto.getUserType());
        switch (userType){
            case Manufacturer:return  getList(friendDto, ManufacturerFriend.class);
            case Seller:return  getList(friendDto, SellerFriend.class);
            case Buyer: return  getList(friendDto, BuyerFriend.class);
            case Agent:   return  getList(friendDto, AgentFriend.class);
            case Admin:break;
            case Platform:   return  getList(friendDto, PlatformFriend.class);
            case None:
                break;
        }
        return new Tuple<List<FriendDto>,Long>(null,0l);
    }

    static <T extends Friend> Tuple<List<FriendDto>,Long> getList(FriendDto friendDto, Class<T> cls){
        EntityManager entityManager= SpringContextUtil.getApplicationContext().getBean(EntityManager.class);
        JpaRepository<T,Long> jpaRepository =new SimpleJpaRepository<T,Long>(cls,entityManager);
        Long count=jpaRepository.count();
        List<T> data=jpaRepository.findAll();
        List<FriendDto> friendDtos=null;
        if(data!=null){
            friendDtos= MapperUtils.mapper(data,cls,FriendDto.class);
        }
        return new Tuple<List<FriendDto>,Long>(friendDtos,count);

    }
}
