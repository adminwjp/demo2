package com.shop.user.front.service.impl;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.ShopDto;
import com.shop.user.front.mapper.ShopMapper;
import com.shop.user.front.service.StoreService;
import com.utility.service.dto.Tuple;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("frontStoreService")
@Transactional("platformTransactionManager")
public class StoreServiceImpl implements StoreService {
    @Autowired
    ShopMapper shopMapper;
    public int save(ShopDto shopDto){
        if(shopDto.getShopId()>0){
            //Long id= IdFactoryImpl.Id.getId(Fr.class);
            //address.setAddrId(id);
            return   shopMapper.modify(shopDto);
        }else{
            return shopMapper.add(shopDto);
        }
    }
    public int delete(DeleteDto deleteDto){
        return  shopMapper.delete(deleteDto);
    }
    public Tuple<List<ShopDto>,Long> getList(ShopDto getDto){
        List<ShopDto> data=  shopMapper.select(getDto);
        long count=shopMapper.count(getDto);
        return  new Tuple<List<ShopDto>,Long>(data,count);
    }
}
