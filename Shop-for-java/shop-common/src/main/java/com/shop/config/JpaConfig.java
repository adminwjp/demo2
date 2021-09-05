package com.shop.config;

import org.hibernate.SessionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.boot.autoconfigure.orm.jpa.JpaProperties;
import org.springframework.boot.orm.jpa.EntityManagerFactoryBuilder;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.orm.hibernate5.LocalSessionFactoryBean;
import org.springframework.orm.jpa.JpaTransactionManager;
import org.springframework.orm.jpa.JpaVendorAdapter;
import org.springframework.orm.jpa.LocalContainerEntityManagerFactoryBean;
import org.springframework.orm.jpa.vendor.HibernateJpaVendorAdapter;
import org.springframework.transaction.annotation.EnableTransactionManagement;
import org.springframework.util.ResourceUtils;

import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;
import java.io.File;
import java.util.*;

//https://blog.csdn.net/tiantang_1986/article/details/90294553
//jpa before pass,but now fail
//https://blog.csdn.net/qq877728715/article/details/105193271/
//https://blog.csdn.net/chukun123/article/details/82861361
//jpa mybaits used exception jpa used pass
//@Order(1)
@Configuration
@EnableJpaRepositories(basePackages = {
        "com.shop.user.admin.service.impl.*",
        "com.shop.order.admin.service.impl.*",
        "com.shop.product.admin.service.impl.*",
        "com.shop.admin.service.impl.*",
        "com.shop.marketing.admin.service.impl.*",
}, transactionManagerRef = "jpaTransactionManager", entityManagerFactoryRef = "localContainerEntityManagerFactoryBean")
@EnableTransactionManagement
public class JpaConfig {

    public  static  String[] hbmPath=new String[]{
            "classpath:hbm/Acategory.hbm.xml",
            "classpath:hbm/Cashcard.hbm.xml"
    };
    @Autowired(required = true)
   JpaProperties jpaProperties;

    // @Primary
    // @Bean(name = "entityManagerFactoryPrimary")
     public EntityManagerFactory entityManagerFactory(@Qualifier(value =
     "dynamicDataSource") DataSource dataSource, JpaVendorAdapter
     jpaVendorAdapter,
     EntityManagerFactoryBuilder builder) {
     return
     this.localContainerEntityManagerFactoryBean(dataSource,jpaVendorAdapter).getObject();
     }

      //@Bean
      public SessionFactory sessionFactory(@Qualifier(value ="dynamicDataSource") DataSource dataSource) {
        // SessionFactoryImpl
      //LocalSessionFactoryBean EntityManagerFactory
        LocalSessionFactoryBean
      localSessionFactoryBean = new LocalSessionFactoryBean();
      localSessionFactoryBean.setDataSource(dataSource);
       //localSessionFactoryBean.setMappingLocations("classpath:hbm/*.hbm.xml");
       return localSessionFactoryBean.getObject();
      }




    @Autowired
    @Bean
    public JpaTransactionManager jpaTransactionManager(@Qualifier(value = "dynamicDataSource") DataSource dataSource,
            EntityManagerFactory entityManagerFactory) {
        JpaTransactionManager jpaTransactionManager = new JpaTransactionManager();
        jpaTransactionManager.setEntityManagerFactory(entityManagerFactory);
        jpaTransactionManager.setDataSource(dataSource);
        return jpaTransactionManager;
    }

    //@Bean
    //@Primary
    LocalContainerEntityManagerFactoryBean localContainerEntityManagerFactoryBean( @Qualifier(value = "dynamicDataSource") DataSource dataSource,EntityManagerFactoryBuilder builder) {
        return builder.dataSource(dataSource)
                .packages("com.shop.*")
                //.properties(jpaProperties.getProperties())
                .build();
    }

    // jpa mybaits 逻辑 理不清 需要调试 先 jpa pass 再调试
    // spring boot jpa mybaits 版本不一致
    // 版本一致 exception is
    // org.springframework.boot.jdbc.UnsupportedDataSourcePropertyExce
    // ption: Unable to find sutable method for driverClassName
    // sqlite not support
    @Autowired
    @Bean
    LocalContainerEntityManagerFactoryBean localContainerEntityManagerFactoryBean(
            @Qualifier(value = "dynamicDataSource") DataSource dataSource
            // ,EntityManagerFactoryBuilder builder) {
            , JpaVendorAdapter jpaVendorAdapter) {
        // ) {
        LocalContainerEntityManagerFactoryBean localContainerEntityManagerFactoryBean =
                // builder.dataSource(dataSource).build();
                new LocalContainerEntityManagerFactoryBean();
        //localContainerEntityManagerFactoryBean.setJpaPropertyMap(jpaProperties.getProperties());
        localContainerEntityManagerFactoryBean.setDataSource(dataSource);
        localContainerEntityManagerFactoryBean.setPackagesToScan("com.shop.user.*");
        //test
        //localContainerEntityManagerFactoryBean.setMappingResources(new String[]{"classpath:hbm/Acategory.hbm.xml"});
        //自动加载 该目录 下 映射 文件
        localContainerEntityManagerFactoryBean.setMappingResources(hbmPath);
      try {
          System.getProperty("user.dir");
        //获取classes目录绝对路径
         // String path = ClassUtils.getDefaultClassLoader().getResource("").getPath();

          String path = ResourceUtils.getURL("classpath:").getPath();
          File hbm = new File(path,"hbm/");
          Set<String> temps=new HashSet<String>(200);
          distinctFile(hbm,temps);
          hbm = new File(path,"hbm/user");
          distinctFile(hbm,temps);
          hbm = new File(path,"hbm/order");
          distinctFile(hbm,temps);
          hbm = new File(path,"hbm/product");
          distinctFile(hbm,temps);
          hbm = new File(path,"hbm/marketing");
          distinctFile(hbm,temps);
          if(temps.size()>0){
              String[] news=new String[temps.size()];
              news=temps.toArray(news);
             // localContainerEntityManagerFactoryBean.setMappingResources(news);
          }
          //localContainerEntityManagerFactoryBean.setMappingResources(new String[]{"classpath:hbm"});
      }catch (Exception ex){
          ex.printStackTrace();
      }

        localContainerEntityManagerFactoryBean.setJpaVendorAdapter(jpaVendorAdapter);
        return localContainerEntityManagerFactoryBean;
    }
    void distinctFile(File hbm ,Set<String> temps){
        if(hbm.isDirectory()){
            String[] files=hbm.list();
            System.out.println(files.length);
            for (int i=0;i<files.length;i++){
                if(files[i].endsWith("hbm.xml")){
                    temps.add(files[i]);
                }
            }
        }
    }
    @Bean
    public JpaVendorAdapter jpaVendorAdapter() {
        HibernateJpaVendorAdapter hibernateJpaVendorAdapter = new HibernateJpaVendorAdapter();
        hibernateJpaVendorAdapter.setGenerateDdl(true);
        hibernateJpaVendorAdapter.setShowSql(true);
        //hibernateJpaVendorAdapter.setDatabasePlatform("org.hibernate.dialect.SQLiteDialect");
        //hibernateJpaVendorAdapter.setDatabasePlatform("com.enigmabridge.hibernate.dialect.SQLiteDialect");
        //hibernateJpaVendorAdapter.setGenerateDdl(jpaProperties.isGenerateDdl());
        //hibernateJpaVendorAdapter.setShowSql(jpaProperties.isShowSql());
        hibernateJpaVendorAdapter.setDatabasePlatform(jpaProperties.getDatabasePlatform());
        return hibernateJpaVendorAdapter;
    }
}