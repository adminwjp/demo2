package com.shop;


import java.util.concurrent.ConcurrentHashMap;
import java.util.Map;
import java.util.concurrent.atomic.AtomicLong;

public interface IdFactory  {
    Long getId(Class cls);
}
