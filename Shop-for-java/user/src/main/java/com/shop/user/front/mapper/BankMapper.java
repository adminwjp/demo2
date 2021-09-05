package com.shop.user.front.mapper;

import com.shop.user.dto.BankDto;
import com.shop.user.dto.DeleteDto;

import java.util.List;

public interface BankMapper {
    int add(BankDto bankDto);
    int modify(BankDto bankDto);
    int delete(DeleteDto deleteDto);
    List<BankDto> select(BankDto getDto);
    long count(BankDto getDto);
}
