package com.shop.user.front.service.impl;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.*;
import com.shop.user.front.mapper.*;
import com.shop.user.front.service.TeambuyService;
import com.utility.service.dto.Tuple;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("frontTeambuyService")
@Transactional("platformTransactionManager")
public class TeambuyServiceImpl implements TeambuyService {
    @Autowired
    TeambuyMapper teambuyMapper;
   // @Autowired
   // TeambuyLogMapper teambuyLogMapper;
    public int save(TeambuyDto teambuyDto){
        if(teambuyDto.getId()>0){
            //Long id= IdFactoryImpl.Id.getId(Fr.class);
            //address.setAddrId(id);
            return   teambuyMapper.modify(teambuyDto);
        }else{
            return teambuyMapper.add(teambuyDto);
        }
    }
    public int delete(DeleteDto deleteDto){
        return  teambuyMapper.delete(deleteDto);
    }
    public Tuple<List<TeambuyDto>,Long> getList(TeambuyDto getDto){
        List<TeambuyDto> data=  teambuyMapper.select(getDto);
        long count=teambuyMapper.count(getDto);
        return  new Tuple<List<TeambuyDto>,Long>(data,count);
    }
}
