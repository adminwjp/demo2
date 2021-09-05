package com.shop;

import com.shop.config.JpaConfig;
import com.shop.config.MybaitsConfig;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.EnableEurekaClient;
import org.springframework.web.bind.annotation.GetMapping;

@SpringBootApplication
//@EnableAutoConfiguration
//@EnableDiscoveryClient//此注解将自动发现服务并注册服务
@EnableEurekaClient
//有些注解 起冲突
//@ComponentScan(basePackageClasses =
 //       com.utility.spring.SpringContextUtil.class)
//@EnableSwagger2
public class ShopUserApplication {
    public static void main(String[] args) throws ClassNotFoundException {
        System.out.println("Hello World!");
       /* String pack= TeambuyLog.class.getPackage().getName();
        File f = new File(TeambuyLog.class.getResource("/").getPath());
        String totalPath = f.getAbsolutePath();
        List<String> cls=new ArrayList<>(100);
        CommonUtil.resolveFile(f,pack,cls);
        for (int i = 0; i < cls.size(); i++) {
            Class cla=Class.forName(cls.get(i));
            if( cla== User.class
            || cla== Address.class
                    || cla== Friend.class){
                continue;
            }
            IdFactoryImpl.ids.put(cla,0l);
        }*/
        MybaitsConfig.mappLocation="com/shop/user/front/mapper/*.xml";
        JpaConfig.hbmPath=new String[]{
                "classpath:hbm/user/Bank.hbm.xml"
        };
        SpringApplication.run(ShopUserApplication.class, args);
    }
    @GetMapping("check")
    public  String check(){
        return "check success";
    }
}
