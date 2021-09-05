package com.shop.config;

import com.alibaba.fastjson.support.spring.FastJsonHttpMessageConverter;

//import com.utility.EnumConverterFactory;
import org.springframework.context.MessageSource;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.support.ResourceBundleMessageSource;
import org.springframework.core.annotation.Order;
import org.springframework.format.FormatterRegistry;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.validation.beanvalidation.LocalValidatorFactoryBean;
import org.springframework.web.servlet.config.annotation.EnableWebMvc;
import org.springframework.web.servlet.config.annotation.InterceptorRegistry;
import org.springframework.web.servlet.config.annotation.ResourceHandlerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import org.springframework.web.servlet.i18n.LocaleChangeInterceptor;
import org.springframework.web.servlet.i18n.SessionLocaleResolver;

import java.util.List;


@Order(0)
@EnableWebMvc
@Configuration
//高版本支持  Order 不使用 不生效 配置文件 或 其他 优先级 高
public class SpringMvcConfigure implements WebMvcConfigurer {

    //验证内容的国际化
   // @Autowired
    private MessageSource messageSource;

  /*  @Override
    public Validator getValidator() {
        return localValidatorFactoryBean();
    }*/

   // @Bean
    public LocalValidatorFactoryBean localValidatorFactoryBean() {
        LocalValidatorFactoryBean validator = new LocalValidatorFactoryBean();
        validator.setValidationMessageSource(messageSource);
        return validator;
    }

    @Bean(name = "messageSource")
    public ResourceBundleMessageSource messageSource(){
        ResourceBundleMessageSource messageSource = new ResourceBundleMessageSource();
        messageSource.setBasenames("message/messages");
        return messageSource;
    }

    @Bean(name = "localeChangeInterceptor")
    public LocaleChangeInterceptor localeChangeInterceptor(){
        // 实现语言切换的拦截器
        return new LocaleChangeInterceptor();
    }

    @Bean(name = "localeResolver")
    public SessionLocaleResolver localeResolver(){
        return new SessionLocaleResolver();
    }

    @Override
    public void addInterceptors(InterceptorRegistry registry) {
        // 通过拦截器来完成语言环境的切换（可以设置专门的拦截路径）
        registry.addInterceptor(localeChangeInterceptor());
    }

    /**
     * 配置消息转换器
     * @param converters
     */
    @Override
    public void configureMessageConverters(List<HttpMessageConverter<?>> converters) {
        FastJsonHttpMessageConverter fastJsonHttpMessageConverter = new FastJsonHttpMessageConverter();
        MappingJackson2HttpMessageConverter jackson2HttpMessageConverter=new MappingJackson2HttpMessageConverter();
        jackson2HttpMessageConverter.setObjectMapper(JsonConfig.objectMapper());
        //List<MediaType> supportedMediaTypes =new ArrayList<>();
        // Invalid token character '/' in
        //supportedMediaTypes.add(new MediaType(MediaType.APPLICATION_JSON_VALUE));
        //supportedMediaTypes.add(new MediaType("application/json"));
        //supportedMediaTypes.add(new MediaType("text/javascript"));
        //supportedMediaTypes.add(new MediaType("text/plain;charset=UTF-8"));
        //jackson2HttpMessageConverter.setSupportedMediaTypes(supportedMediaTypes);
        //converters.add(jackson2HttpMessageConverter);
        converters.add(jackson2HttpMessageConverter);
    }

    @Override
    public void addFormatters(FormatterRegistry registry) {
        //解析json用的是jackson，用不到spring的Formatter和Converter之类的机制，所以改他们没有效果
        //registry.addConverterFactory(new IntegerCodeToEnumConverterFactory());
        //registry.addConverterFactory(new StringCodeToEnumConverterFactory());
        //解析json用的是jackson 无效
     //   registry.addConverterFactory(new EnumConverterFactory());
    }

    @Override
    public void addResourceHandlers(ResourceHandlerRegistry registry) {
        registry.addResourceHandler("/**").addResourceLocations("classpath:/static/");
        //registry.addResourceHandler("/**").addResourceLocations("classpath:/templates/");

        registry.addResourceHandler("/index.html")
                .addResourceLocations("classpath:/META-INF/resources/webjars/springfox-swagger-ui/");
        //2.9.2 access success
        registry.addResourceHandler("/swagger-ui.html")
                .addResourceLocations("classpath:/META-INF/resources/");



        registry.addResourceHandler("/webjars/**")
                .addResourceLocations("classpath:/META-INF/resources/webjars/");

        //registry.addResourceHandler("/plugin/**/**")
         //       .addResourceLocations("classpath:/templates/");
        //404
        //registry.addResourceHandler("/plugin/**/**")
        //        .addResourceLocations("classpath:/plugin/");

        //registry.addResourceHandler("/front/**")
         //       .addResourceLocations("classpath:/static/front/");

    }
}
