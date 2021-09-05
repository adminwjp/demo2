java
java -version
mvn -version
|| mvn -v
mvn -B archetype:generate  -DarchetypeGroupId=org.apache.maven.archetypes  -DgroupId=com.shop  -DartifactId=Shop-for-java

mvn idea:idea

mvn test

[ERROR] No compiler is provided in this environment. Perhaps you are running on
a JRE rather than a JDK?

production
jre download
https://www.java.com/zh-CN/download/

jdk not found 

development
jdk jre download

jdk exists jre 
https://www.oracle.com/java/technologies/javase-jre8-downloads.html

JAVA_HOME
C:\Program Files\Java\jdk1.8.0_291

CLASSPATH
%JAVA_HOME%\lib\dt.jar;%JAVA_HOME%\lib\tools.jar;  

PATH
%JAVA_HOME%\bin;%JAVA_HOME%\jre\bin

mvn package

mvn clean

mvn compile
 
mvn clean &&  mvn compile && mvn package


java -jar xxx.jar

javac xxx.java
java className

vs code 

crtl + shift + p
settings.json

"workbench.startupEditor": "newUntitledFile",
"java.errors.incompleteClasspath.severity": "ignore",
"workbench.colorTheme": "Visual Studio Dark",
"java.home":"C:\\Program Files\\Java\\jdk1.8.0_291",
"java.configuration.maven.userSettings": "D:\\googledown\\apache-maven-3.8.1-bin\\conf\\settings.xml",
"maven.executable.path": "D:\\googledown\\apache-maven-3.8.1-bin\\bin\\mvn.cmd",
"maven.terminal.useJavaHome": true,
"maven.terminal.customEnv": [
    {
        "environmentVariable": "JAVA_HOME",
        "value": "C:\\Program Files\\Java\\jdk1.8.0_291"
    }
],
"extensions.autoUpdate": false,


mvn spring boot
Caused by: java.lang.ClassNotFoundException: org.springframework.boot.SpringAppl
ication

dependency not has package
spring boot plugin 

vscode code not has tip ,version not right

jpa
http://jvm123.com/doc/jpa/index.html


mvn spring-boot:run

vscode  怎么调试 网上 都是输出控制台 第三方包怎么调试

spring boot 自动 加载 如何 加载配置的 各种问题 
spring boot mybaits spring boot jpa 版本 要一致  不然 报的错 都不同
spring 单独组装

乱报错 之前 通过 还原 就不行了 差
删除 vscode java 项目 的 配置
vode java 配置 (安装插件后自动生成 eclipse java 配置文件)
还是不行

model hibernate 注解 已经 hmm.xml
orm jpa mybatis
admin jpa
front mybaits

 Unable to create requested service [org.hibernate.engine.jdbc.env.spi.JdbcEnvironment
 jdbc配置不正确
  Unable to resolve name [org.hibernate.dialect.SQLiteDialect]
  Could not load requested class : org.hibernate.dialect.SQLiteDialect 
  com.enigmabridge.hibernate.dialect.SQLiteDialect
  spring.jpa.hibernate.ddl-auto=create-drop pass
  spring.jpa.hibernate.ddl-auto=update err
  sqlite boolean
   Error executing DDL "alter table t_buyer_address add column addr_id bigint not null" via JDBC Statement

    Error executing DDL "alter table t_buyer_address add column defaddr boolean not null" via JDBC Statement

rror creating bean with name 'acategoryRepository' defined in com.shop.dao.AcategoryRepository
id long err
Id Long pass
spring boot jpa 默认使用注解 
复制 包名 没改 不报错 (报错地方不对)
配置 无效

Unable to resolve explicitly named mapping-file
没错 看不出来 可能 报错 地方不对 不好排查
有问题 的先 取消 mapp hbm.xml 成功后 再 一个个 排查
单独 执行有问题hbm.xml pass
 Could not get constructor for org.hibernate.persister.entity.SingleTableEntityPersister
 
 https://stackoverflow.com/questions/18042247/could-not-get-constructor-for-org-hibernate-persister-entity-singletableentitype
 I encountered this error when upgrading from jdk10 to jdk11. Adding the following dependency fixed the problem:
 无效
 <dependency>
     <groupId>org.javassist</groupId>
     <artifactId>javassist</artifactId>
     <version>3.25.0-GA</version>
 </dependency>
 
 取消映射 
 Invocation of init method failed; nested exception is java.lang.IllegalStateException: No persistence units parsed from 
 需要 配置 扫描 包
 不配置 jpa pass
 spring boot 2.5 资料 真少 
 
 Unable to build Hibernate SessionFactory; 
 nested exception is org.hibernate.MappingException: Could not get constructor for org.hibernate.persister.entity.SingleTableEntityPersister
 https://www.jianshu.com/p/2e64d5f26838
 jpa 手动 生成 getter setter 
 SO上几个解答都是说getter setter的命名不规范，但我用的lombok，没有手写的getter和setter
 lombok err
 get set pass
 
 Could not unbind factory from JNDI
 #spring.jpa.hibernate.session_factory_name=sessionFactory
 
   // localContainerEntityManagerFactoryBean.setBeanName("sessionFactory");
         // localContainerEntityManagerFactoryBean.setPersistenceUnitName("localContainerEntityManagerFactoryBean");
         // excetiion SessionFactory is null . jpa and mybaits used ex ,but jpa used pass
         // EntityManagerFactoryBuilderImpl -> build()
         // MetadataBuildingProcess.complete StandardServiceRegistry
         // spring boot SessionFactoryOptionsBuilder -> SessionFactoryImpl name is null
         localContainerEntityManagerFactoryBean.setJpaVendorAdapter(jpaVendorAdapter);
 
         // jpa and mybaits used ex
         // No PersistenceProvider specified in EntityManagerFactory configuration, and
         // chosen Per sistenceUnit
         // HibernateJpaVendorAdapter -> SpringHibernateJpaPersistenceProvider ->
         // createContainerEntityManagerFactory()
         // -> LocalContainerEntityManagerFactoryBean ->
         // createNativeEntityManagerFactory()
         // https://www.kancloud.cn/george96/springboot/613683
 
          //Map<String, Object> jpaProperties = new HashMap<String, Object>();
         //jpaProperties.put("hibernate.session_factory_name", "sessionFactory");
          //localContainerEntityManagerFactoryBean.setJpaPropertyMap(jpaProperties);
 
         // org.hibernate.ejb.HibernatePersistence
         // org.springframework.orm.jpa.vendor.SpringHibernateJpaPersistenceProvider
         //localContainerEntityManagerFactoryBean.setPersistenceProviderClass(SpringHibernateJpaPersistenceProvider.Class);
         // errror
          //localContainerEntityManagerFactoryBean.setPersistenceProvider(jpaVendorAdapter.getPersistenceProvider());
          
           nested exception is org.hibernate.MappingException: org.hibernate.dialect.identity.IdentityColumnSupportImpl
           注解配置各种问题 动一下 不知道哪里影响的 
           https://blog.csdn.net/alinekang/article/details/97391837
          sqlite 放弃 配置 容易出问题 不好改 继承 SQLiteDialect 重写  IdentityColumnSupportImpl（继承IdentityColumnSupportImpl实现）
          mysql 
          mysql driver 5.x
          mysql5.x
          create table t_acategory (cate_id bigint not null auto_increment, cate_name varchar(255), parent_id bigint, store_id bigint, sort_order integer, if_show bit, primary key (cate_id)) type=MyISAM
          
          数据库 版本跟 数据库 驱动 版本要一致?
          //MySQL5Dialect
             mysql driver 8.x
                  mysql8.x
                  
           org.hibernate.dialect.MySQL5Dialect pass
           org.hibernate.dialect.MySQLDialect err 
           
            non-compatible bean definition of same name and class [com.shop.user.admin.controller.AddressController]
            [com.shop.user.front.controller.AddressController]
       
       jar 包 容易 起冲突 ，能运行 但 jpa sql 显示不出来
       最好不要的jar 去掉    
       
       org.thymeleaf.exceptions.TemplateInputException
       https://blog.csdn.net/qq_35808136/article/details/88720973
       
       1.8
       -source 1.6 中不支持 switch 中存在字符串
       自动 生成 的 简单 能用 一旦 变动 好 麻烦
       main 最好 放在  最 外层  不然 自动 扫描 包 容易出问题    
       
       http://127.0.0.1:8080/swagger-ui.html
       
       服务 接口 控制器 名称 最好 不要 一致
       conflicts with existing  
       
       expected single matching bean but found 2: jpaTransactionManager,platformTransactionManager
       
       只能 二 选 一 ？ 事务 注解 事务 给 名称 mybaits怎么 扫描包  
       mysbaits mapper mapper.xml 文件 目录 要 一致
       
       jpa 每个 数据库 自增 不同 
       Controller ex 前端 模板 框架 有影响
       RestController
       
       validate 国际化
       https://www.cnblogs.com/kaleovon/p/8669642.html
       
       freemarker
       http://freemarker.foofun.cn/ref_directive_list.html
       https://blog.csdn.net/a15835774652/article/details/78843961
       https://springboot.io/t/topic/285
       
       怎么改
       : Exception evaluating SpringEL expression: "navs.heade" 
       navs.heade err
       navs pass
       
       thymeleaf
       #{page-layout-}${app.controller.id}#{-}${app.controller.action.id}
       操作 表达式 不支持
       
       https://www.thymeleaf.org/doc/tutorials/3.0/usingthymeleaf.html#text-inlining
       https://blog.csdn.net/qq_15042899/article/details/72885889
       
       include
       https://blog.csdn.net/believe__sss/article/details/79992408
       each index
       https://blog.csdn.net/weixin_30516243/article/details/99523925
       
       数字 格式化
       https://blog.csdn.net/qq_17152035/article/details/83344757
       
       string
       https://blog.csdn.net/qq_33535433/article/details/78876693
       
       th:text 浏览器显示不出来 文档 怎么感觉 不对 
       ${xx} 这种写法显示出来 
       th 标签 没用 文档 没用?不敢用了
       难道用的是 freemarker 先注释掉
       配置 该来 该去 忘改 了 
       freemarker 
               <p th:if="${test?string('yes', 'no')}">test is true</p>
               <p th:if="${test1?string('yes', 'no')}">test1 is false</p>
               <p th:text="${test1?string('yes', 'no')}"></p>
               <span th:text="${test1?string('span yes', 'span no')}"></span>
               <span th:utext="${test1?string('span u yes', 'span u no')}"></span>
       
       spring boot thymeleaf freemarker 同时 使用冲突
       同用 一个 工程 怎么搞
       https://www.pianshen.com/article/94841786242/
       
       国际化
       https://springboot.io/t/topic/285
       
       front mybaits freemarker
       使用开源项目 迁移的
       admin jpa thymeleaf （放弃 样式 js 不好控制需要改）
       
       go 最好 不要用 ide 有的 没提示（调试也麻烦 需要另外 下载 插件） 麻烦
       shop.exe 5001
       shop 5001
       github.com 网络不稳  麻烦
       好多东西 没有 需要 使用第三方库  
       
       https://www.metazion.net/
       
       https://tool.lu/zh_CN/json/
       
       php  Uncaught TypeError: fwrite(): Argument #1 ($stream) must be of
       
       https://stackoverflow.com/questions/66109427/fclose-argument-1-stream-must-be-of-type-resource-bool-given
       
       Un-install the composer.
       Restart your machine
       Install the composer
	   
	   php artisan optimize:clear
	   
	   无效     之前    的  可以 使用  
	   
	   java: -source 1.6 中不支持静态接口方法调用 
	   java 8
	   jdk 1.8  
	   怎么 无效 哪里 设置 
	   ide pom 一旦改变 java 12 去 了 改 的 难受 怎么默认java8啊
	   
	   原来 maven setting.xml 需要 改动
	   设置 1.8 
	   还是 无效 
	   
	   https://blog.csdn.net/qq_38058332/article/details/87975564?utm_medium=distribute.pc_relevant_download.none-task-blog-baidujs-1.nonecase&depth_1-utm_source=distribute.pc_relevant_download.none-task-blog-baidujs-1.nonecase
	  
	  https://www.cnblogs.com/yunlongn/p/11295516.html
	  
	  目前 这篇文章 才对  其它 无效
	  https://blog.csdn.net/w903328615/article/details/87861139
	  
	   spring boot 包 放置 外面
	   jar 1.2 g
	  mvn dependency:copy-dependencies
	  
	   什么玩意 还原 
	   jar 已 存在 还 尼玛  引用 
	   maven install 通过 不了 了 
	   
	   error
	     <classpathPrefix>lib/</classpathPrefix>
	     mvn lib:copy-dependencies
	   mvn copy-dependencies
	   
	   
	   pass
	   取消 jar 过大 重复包 
	   不然 运行 麻烦 部署时取消 包引用 共引用同一份 包
	   -
	   80m *5 400 m
	   400m *2 =800m  + 80m*5 =1.2g
	     <layout>ZIP</layout>
           <includes>
               <include>
                   <groupId>nothing</groupId>
                   <artifactId>nothing</artifactId>
               </include>
           </includes>
                           
	   mvn clean fail
	    mvn dependency:copy-dependencies
	   mvn install
	   
	   mvn dependency:analyze
	   
	   java -Dloader.path="dependency/" -jar user.jar  
	   
	   ide 无法使用 需要 手动 设置 启动参数
	    netstat -ano
	   netstat -ano |findstr "8080"
	   tasklist |findstr "pid"
	   taskkill /f /t /im "pid or name"
	   
	  
	   cmd
	   
	   taskkill /im xx.exe
	   
	   数据中心(生产者) 缓存 数据 放入？？
	    dubbo-service-provider
	    冲突 太多 放弃 dubbo spring boot 整合 
	    要么 使用 dubbo cloud 要么使用 spring colud
	   
	   grpc
	   aliyun找不到  需要手动 打包
	      <groupId>com.anoyi</groupId>
           <artifactId>spring-boot-starter-grpc</artifactId>
	   https://www.cnblogs.com/television/p/9454096.html
	   
	   自定义协议
	        <groupId>cn.org.faster</groupId>
                   <artifactId>spring-boot-starter-grpc</artifactId>
	   https://gitee.com/mirrors/grpc-spring-boot-starter
	   
	   https://blog.csdn.net/weixin_40395050/article/details/96971708

https://mp.baomidou.com/guide/install.html#release

mybatis-plus-boot-starter
	   