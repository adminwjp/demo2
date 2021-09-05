package com.shop.user.front.mapper;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.ProtocolDto;
import com.shop.user.entity.Protocol;

import java.util.List;

public interface ProtocolMapper {
    int add(Protocol protocol);
    int modify(Protocol protocol);
    int delete(DeleteDto deleteDto);
    List<Protocol> select(Protocol getDto);
    long count(Protocol getDto);

    List<ProtocolDto> getProtocols();
    ProtocolDto getProtocol(long id);
}
