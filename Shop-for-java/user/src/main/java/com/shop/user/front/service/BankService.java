package com.shop.user.front.service;

import com.shop.user.dto.BankDto;
import com.shop.user.dto.DeleteDto;
import com.utility.service.dto.Tuple;

import java.util.List;

public interface BankService {
    int save(BankDto bankDto);
    int delete(DeleteDto deleteDto);
    Tuple<List<BankDto>,Long> getList(BankDto getDto);
}
