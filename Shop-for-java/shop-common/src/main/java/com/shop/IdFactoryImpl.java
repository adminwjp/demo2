package com.shop;

import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicLong;
import java.util.Map;

public class IdFactoryImpl implements IdFactory {
    public  static  IdFactory Id=new IdFactoryImpl();
    public  final  static Map<Class,Long> ids=new ConcurrentHashMap<Class,Long>(200);

    public Long getId(Class cls){
        Long id=ids.get(cls);
        Long temp= new AtomicLong().addAndGet(id);
        ids.put(cls,temp);
        return  temp;
    }


}
