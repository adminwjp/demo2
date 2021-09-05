package com.shop.user.front.service.impl;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.ShopDto;
import com.shop.user.entity.Relation;
import com.shop.user.front.mapper.RelationMapper;
import com.shop.user.front.mapper.ShopMapper;
import com.utility.service.dto.Tuple;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("frontRelationService")
@Transactional("platformTransactionManager")
public class RelationServiceImpl {
    @Autowired
    RelationMapper relationMapper;
    public int save(Relation relation){
        if(relation.getId()>0){
            //Long id= IdFactoryImpl.Id.getId(Fr.class);
            //address.setAddrId(id);
            return   relationMapper.modify(relation);
        }else{
            return relationMapper.add(relation);
        }
    }
    public int delete(DeleteDto deleteDto){
        return  relationMapper.delete(deleteDto);
    }
    public List<ShopDto> select(Relation getDto){
        List<ShopDto> data=  relationMapper.select(getDto);
        return  data;
    }
    public Tuple<List<ShopDto>,Long> getList(Relation getDto){
        List<ShopDto> data=  relationMapper.select(getDto);
        long count=relationMapper.count(getDto);
        return  new Tuple<List<ShopDto>,Long>(data,count);
    }
}
