package com.shop.user.front.service.impl;

import com.shop.dto.ExistsDto;
import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.FriendDto;
import com.shop.user.front.mapper.FriendMapper;
import com.shop.user.front.service.FriendService;
import com.utility.service.dto.Tuple;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("frontFriendService")
@Transactional("platformTransactionManager")
public class FriendServiceImpl implements FriendService {
    @Autowired
    FriendMapper friendMapper;
    public int save(FriendDto friend){
        if(friend.getId()>0){
            //Long id= IdFactoryImpl.Id.getId(Fr.class);
            //address.setAddrId(id);
            return   friendMapper.modify(friend);
        }else{
            return friendMapper.add(friend);
        }
    }
    public int delete(DeleteDto deleteDto){
        return  friendMapper.delete(deleteDto);
    }
    public int exists(ExistsDto existsDto){
        return  friendMapper.exists(existsDto);
    }
    public Tuple<List<FriendDto>,Long> getList(FriendDto getDto){
        List<FriendDto> data=  friendMapper.select(getDto);
        long count=friendMapper.count(getDto);
        return  new Tuple<List<FriendDto>,Long>(data,count);
    }
}
