package com.shop.config;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.module.SimpleModule;
import com.utility.jackson.CustomJsonEnumSerializer;
import com.utility.jackson.MyCamemlToUnderlineCaseStrategy;
import org.springframework.context.annotation.Bean;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.http.converter.StringHttpMessageConverter;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.web.servlet.HandlerAdapter;
import org.springframework.web.servlet.mvc.method.annotation.RequestMappingHandlerAdapter;

import java.nio.charset.Charset;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

public class JsonConfig {

    //json
    //https://blog.csdn.net/zmx729618/article/details/80915548



    //参考 ssm ssh 修改 试试 json 格式 无效  spring boot  不生效
//   <!-- 注解 @Controller 映射的支持  rest api response  乱码 这里 配置 才有效 其他 地方 无效  -->
    @Bean
    public StringHttpMessageConverter messageConverter(){
        StringHttpMessageConverter messageConverter=  new StringHttpMessageConverter();
        messageConverter.setDefaultCharset(Charset.forName("UTF-8"));
        return  messageConverter;
    }

    @Bean
    public MappingJackson2HttpMessageConverter jackson2HttpMessageConverter(ObjectMapper objectMapper){
        MappingJackson2HttpMessageConverter jackson2HttpMessageConverter=new MappingJackson2HttpMessageConverter();
        jackson2HttpMessageConverter.setObjectMapper(objectMapper);
        //List<MediaType> supportedMediaTypes =new ArrayList<>();
        // Invalid token character '/' in
        //supportedMediaTypes.add(new MediaType(MediaType.APPLICATION_JSON_VALUE));
        //supportedMediaTypes.add(new MediaType("application/json"));
        //supportedMediaTypes.add(new MediaType("text/javascript"));
        //supportedMediaTypes.add(new MediaType("text/plain;charset=UTF-8"));
        //jackson2HttpMessageConverter.setSupportedMediaTypes(supportedMediaTypes);
        return  jackson2HttpMessageConverter;
    }

    //@Bean
    public HandlerAdapter handlerAdapter(MappingJackson2HttpMessageConverter mappingJackson2HttpMessageConverter){
        RequestMappingHandlerAdapter adapter=new RequestMappingHandlerAdapter();
        List<HttpMessageConverter<?>> messageConverters=new ArrayList<HttpMessageConverter<?>>();
        messageConverters.add(messageConverter());
        messageConverters.add(mappingJackson2HttpMessageConverter);
        adapter.setMessageConverters(messageConverters);
        return  adapter;
    }
    @Bean
    public static ObjectMapper objectMapper(){
        ObjectMapper objectMapper=new ObjectMapper();

        SimpleModule simpleModule1 = new SimpleModule();
        //simpleModule1.addDeserializer(Enum.class, new CustomJsonEnumDeSerializer());
        simpleModule1.addSerializer(Enum.class, new CustomJsonEnumSerializer());
        objectMapper.registerModule(simpleModule1);

        objectMapper.setDateFormat(new SimpleDateFormat("yyyy-MM-dd HH:mm:ss"));
        //        <!-- 为null字段时不显示 -->
        objectMapper.setSerializationInclusion(JsonInclude.Include.NON_NULL);
        //添加此配置 不然异常
        objectMapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
        objectMapper.setPropertyNamingStrategy(new MyCamemlToUnderlineCaseStrategy());

        return  objectMapper;
    }
}
