package com.shop.util;

import com.utility.service.dto.Tuple;

import java.io.File;
import java.util.HashMap;
import java.util.List;

public class CommonUtil {
    public  static  int getPage(int page){
        if(page<1){
            return  1;
        }
        if(page>100){
            return  100;
        }
        return page;
    }
    public  static  int getSize(int size){
        if(size<1){
            return  10;
        }
        if(size>100){
            return  100;
        }
        return size;
    }

    public  static  long getTotal(int page,int size,long records){
        long to = records % (long)size == 0L ? records / (long)size : records / (long)size + 1L;
        return  to;
    }

    public  static <T>  long getTotal(int page, int size, Tuple<List<T>,Long> tuple){
        long records=tuple.getItem2();
        long to = records % (long)size == 0L ? records / (long)size : records / (long)size + 1L;
        return  to;
    }


    public  static <T> HashMap<String,Object> getData(int page, int size, Tuple<List<T>,Long> tuple){
        HashMap<String,Object> data=new HashMap<String,Object>(5);
        data.put("page",page);
        data.put("size",size);
        data.put("data",tuple.getItem1());
        long records=tuple.getItem2();
        data.put("records",records);
        long to = records % (long)size == 0L ? records / (long)size : records / (long)size + 1L;
        data.put("total", to);
        return  data;
    }

    public static void resolveFile(File root, String webPackage, List<String> classNames) {
        if (!root.exists())
            return;
        File[] childs = root.listFiles();
        if (childs != null && childs.length > 0) {
            for (File child : childs) {
                if (child.isDirectory()) {
                    String parentPath = child.getParent();
                    String childPath = child.getAbsolutePath();
                    String temp = childPath.replace(parentPath, "");
                    String os = System.getProperty("os.name");
                    if(os.toLowerCase().startsWith("win")){
                        temp = temp.replace("\\", "");
                    }else{
                        temp = temp.replace("/", "");
                    }

                    resolveFile(child, webPackage + "." + temp, classNames);
                } else {
                    String fileName = child.getName();
                    if (fileName.endsWith(".class")) {
                        String name = fileName.replace(".class", "");
                        String className = webPackage + "." + name;
                        classNames.add(className);
                    }
                }
            }
        }
    }
}
