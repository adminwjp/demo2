package com.shop.user.admin.service.impl;

import com.shop.SpringContextUtil;
import com.shop.user.admin.service.UserAdminService;
import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.ShopDto;
import com.shop.user.dto.UserDto;
import com.shop.user.dto.UserType;
import com.shop.user.entity.Shop;
import com.shop.user.entity.user.*;
import com.utility.service.dto.Tuple;
//import com.utility.spring.SpringContextUtil;
import com.utility.util.MapperUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import javax.persistence.EntityManager;
import java.util.List;
@Service("adminUserService")
@Transactional("jpaTransactionManager")
public class UserAdminServiceImpl implements UserAdminService {
    @Autowired
    EntityManager entityManager;

    public   void saveShop(Shop shop){
        JpaRepository<Shop,Long>  jpaRepository =new SimpleJpaRepository<Shop,Long>(Shop.class,entityManager);
        jpaRepository.save(shop);
    }
    public   void deleteShop(DeleteDto deleteDto){
        JpaRepository<Shop,Long>  jpaRepository =new SimpleJpaRepository<Shop,Long>(Shop.class,entityManager);
       if(deleteDto.getId()>0){
           jpaRepository.deleteById(deleteDto.getId());
       }
       else{
           for (Long id:deleteDto.getIds()) {
               jpaRepository.deleteById(id);
           }
       }
    }
    public  Tuple<List<ShopDto>,Long> getShopList(ShopDto getDto){
       JpaRepository<Shop,Long>  jpaRepository =new SimpleJpaRepository<Shop,Long>(Shop.class,entityManager);
        Long count=jpaRepository.count();
        List<Shop> data=jpaRepository.findAll();
        List<ShopDto> shopDtos=null;
        if(data!=null){
            shopDtos= MapperUtils.mapper(data,Shop.class,ShopDto.class);
        }
        return new Tuple<List<ShopDto>,Long>(shopDtos,count);

    }
    public Tuple<List<UserDto>,Long> getList(UserDto userDto){

        //JpaRepository.class SimpleJpaRepository.class
        //ex
       // JpaRepository<Buyer,Long> jpaRepository= SpringContextUtil.getApplicationContext().getBean(JpaRepository.class);

        UserType userType=UserType.parseUserTypes(userDto.getUserType());
        switch (userType){
            case Manufacturer:return  getList(userDto, Manufacturer.class);
            case Seller:return  getList(userDto, Seller.class);
            case Buyer: return  getList(userDto, Buyer.class);
            case Agent:   return  getList(userDto, Agent.class);
            case Admin:break;
            case Platform:   return  getList(userDto, Platform.class);
            case None:
                break;
        }
        return new Tuple<List<UserDto>,Long>(null,0l);
    }

    static <T extends User> Tuple<List<UserDto>,Long> getList(UserDto userDto,Class<T> cls){

        EntityManager entityManager= SpringContextUtil.getApplicationContext().getBean(EntityManager.class);
        JpaRepository<T,Long>  jpaRepository =new SimpleJpaRepository<T,Long>(cls,entityManager);
        Long count=jpaRepository.count();
        List<T> data=jpaRepository.findAll();
        List<UserDto> userDtos=null;
        if(data!=null){
            userDtos= MapperUtils.mapper(data,cls,UserDto.class);
        }
        return new Tuple<List<UserDto>,Long>(userDtos,count);

    }

}
