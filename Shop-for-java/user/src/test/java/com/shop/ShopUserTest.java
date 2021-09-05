package com.shop;

import com.shop.user.entity.user.Buyer;
import com.utility.template.TemplateGenerator;
import com.utility.util.FileUtil;
import com.utility.util.ReflectionUtil;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.test.context.junit4.SpringRunner;

import java.lang.reflect.Field;
import java.util.List;
import java.util.Set;

@RunWith(SpringRunner.class)
//@SpringBootTest(classes = ShopApplication.class, webEnvironment = SpringBootTest.WebEnvironment.RANDOM_PORT)
//@SpringBootTest(classes = Application.class)

//@RunWith(SpringJUnit4ClassRunner.class)
//@ContextConfiguration(classes = {JPAConfig.class})
//@RunWith(SpringRunner.class)
@SpringBootTest
public class ShopUserTest {
    static  String path="E:/work/shop/Shop-for-spring-boot";
    @Autowired
    JpaRepository<Buyer,Long> repository;
    @Test
    public  void  TestJpa(){
        if(repository!=null){
            System.out.println(11);
        }
    }
    //@Test
    public  void  testHibernatXml(){
        Class clas= Buyer.class;
        //奇怪 同一个 包 加载成功 不同包 加载字段 失败 逻辑问题
        Field[] fields=clas.getDeclaredFields();
        if(fields.length==0){
            fields=clas.getFields();
        }
        ClassLoader loader=clas.getClassLoader();
        String pac=clas.getPackage().getName();
       // ModelParse.init();
        scanPackageToHibernateMapping(pac,loader);
    }
    public static     void scanPackageToHibernateMapping(String pack, ClassLoader loader){
        Set<Class<?>> classes = ReflectionUtil.getClasses(pack);
        for (Class cla:classes) {

        }

        Class<?>[] classes1=new Class<?>[classes.size()];
        //List<String> strs= TemplateGenerator.Empty.mapp(classes.toArray(classes1));
        List<String> strs= TemplateGenerator.Empty.mapp(classes.toArray(classes1),TemplateGenerator.TemplateFlag.MybatisXml);
        int l=classes1.length;
        for (int i=0;i<l;i++){
            String str=strs.get(i);
            String cla=classes1[i].getSimpleName();
            FileUtil.write(path+"/src/main/resources/mapper/"+cla+"Mapper.xml",str,false);
        }
        strs= TemplateGenerator.Empty.mapp(classes.toArray(classes1),TemplateGenerator.TemplateFlag.HibernateXml);
        for (int i=0;i<l;i++){
            String str=strs.get(i);
            String cla=classes1[i].getSimpleName();
            FileUtil.write(path+"/src/main/resources/hbm/"+cla+".hbm.xml",str,false);
        }
    }
}
