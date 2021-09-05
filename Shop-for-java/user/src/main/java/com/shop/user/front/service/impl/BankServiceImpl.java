package com.shop.user.front.service.impl;

import com.shop.user.dto.BankDto;
import com.shop.user.dto.DeleteDto;
import com.shop.user.front.mapper.BankMapper;
import com.shop.user.front.service.BankService;
import com.utility.service.dto.Tuple;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("frontBankService")
@Transactional("platformTransactionManager")
public class BankServiceImpl implements BankService {
    @Autowired
    BankMapper bankMapper;
    public int save(BankDto bankDto){
        if(bankDto.getBid()>0){
            //Long id= IdFactoryImpl.Id.getId(Fr.class);
            //address.setAddrId(id);
            return   bankMapper.modify(bankDto);
        }else{
            return bankMapper.add(bankDto);
        }
    }
    public int delete(DeleteDto deleteDto){
        return  bankMapper.delete(deleteDto);
    }
    public Tuple<List<BankDto>,Long> getList(BankDto getDto){
        List<BankDto> data=  bankMapper.select(getDto);
        long count=bankMapper.count(getDto);
        return  new Tuple<List<BankDto>,Long>(data,count);
    }
}
