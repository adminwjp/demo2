package com.shop.config;

import org.springframework.jdbc.datasource.lookup.AbstractRoutingDataSource;

//https://www.cnblogs.com/youzhibing/p/7301463.html
public class DynamicDataSource  extends AbstractRoutingDataSource {
    @Override
    protected Object determineCurrentLookupKey()
    {
        return HandleDataSource.getDataSource();
    }
}