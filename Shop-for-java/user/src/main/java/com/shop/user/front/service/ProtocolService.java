package com.shop.user.front.service;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.ProtocolDto;
import com.shop.user.entity.Protocol;
import com.utility.service.dto.Tuple;

import java.util.List;

public interface ProtocolService {
    int save(Protocol protocol);
    int delete(DeleteDto deleteDto);
    Tuple<List<Protocol>,Long> getList(Protocol getDto);
    List<ProtocolDto> getProtocols();
    ProtocolDto getProtocol(long id);
}
