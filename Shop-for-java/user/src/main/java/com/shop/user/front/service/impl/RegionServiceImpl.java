package com.shop.user.front.service.impl;

import com.shop.user.entity.Region;
import com.utility.service.dto.Tuple;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service("frontRegionService")
@Transactional("platformTransactionManager")
public class RegionServiceImpl {
    public List<Region> getList(){
        return  null;
    }
}
