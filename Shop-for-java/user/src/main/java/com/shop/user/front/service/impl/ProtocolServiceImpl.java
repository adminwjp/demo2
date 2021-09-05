package com.shop.user.front.service.impl;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.ProtocolDto;
import com.shop.user.entity.Protocol;
import com.shop.user.front.mapper.ProtocolMapper;
import com.utility.service.dto.Tuple;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;


@Service("frontProtocolService")
@Transactional("platformTransactionManager")
public class ProtocolServiceImpl {
    @Autowired
    ProtocolMapper protocolMapper;
    public int save(Protocol protocol){
        if(protocol.getProtocolId()>0){
            return  protocolMapper.add(protocol);
        }else{
            return  protocolMapper.modify(protocol);
        }
    }
    public int delete(DeleteDto deleteDto){
        return  protocolMapper.delete(deleteDto);
    }
    public Tuple<List<Protocol>,Long> getList(Protocol getDto){
        List<Protocol> data=protocolMapper.select(getDto);
        long count=protocolMapper.count(getDto);
        return  new Tuple<List<Protocol>,Long>(data,count);
    }
    public List<ProtocolDto> getProtocols(){
        return  protocolMapper.getProtocols();
    }
    public  ProtocolDto getProtocol(long id){
        return  protocolMapper.getProtocol(id);
    }
}
