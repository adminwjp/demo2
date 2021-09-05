package com.shop.config;



import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.core.annotation.Order;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.web.servlet.config.annotation.ResourceHandlerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurationSupport;
import springfox.documentation.builders.ApiInfoBuilder;
import springfox.documentation.builders.PathSelectors;
import springfox.documentation.builders.RequestHandlerSelectors;
import springfox.documentation.service.Contact;
import springfox.documentation.spi.DocumentationType;
import springfox.documentation.spring.web.plugins.Docket;
import springfox.documentation.swagger2.annotations.EnableSwagger2;

import java.util.List;

@Configuration
@EnableSwagger2
@Order(1)
//@EnableWebMvc
//低版本 支持
//无效 404 spring boot
public class SwaggerConfig extends
        //WebMvcConfigurerAdapter
        WebMvcConfigurationSupport
{
    @Bean
    public Docket createRestApi() {
        return new Docket(DocumentationType.SWAGGER_2)
                .pathMapping("/")
                .select()
                //.apis(RequestHandlerSelectors.basePackage("com.shop"))
              // .apis(RequestHandlerSelectors.basePackage("com.shop;com.shop.user.admin.controller;com.shop.user.front.controller;com.shop.product.admin.controller;com.shop.product.front.controller"))
                // 扫描所有
                 .apis(RequestHandlerSelectors.any())

                .paths(PathSelectors.any())
                .build().apiInfo(new ApiInfoBuilder()
                        .title("Swagger")
                        .termsOfServiceUrl("/swagger-ui.html") // 将“url”换成自己的ip:port
                        .description("Swagger")
                        .version("9.0")
                        .contact(new Contact("Shop","https://blog.csdn.net/qq_38974638  ",""))
                        .license("License")
                        .licenseUrl("https://blog.csdn.net/qq_38974638/article/details/114218441")
                        .build());
    }

    @Override
    protected void addResourceHandlers(ResourceHandlerRegistry registry) {
        registry.addResourceHandler("/**").addResourceLocations("classpath:/static/");
        registry.addResourceHandler("swagger-ui.html")
                .addResourceLocations("classpath:/META-INF/resources/");
        registry.addResourceHandler("/webjars/**")
                .addResourceLocations("classpath:/META-INF/resources/webjars/");

        registry.addResourceHandler("/plugin/*")
                .addResourceLocations("classpath:/templates/plugin/");

        registry.addResourceHandler("/front/*")
                .addResourceLocations("classpath:/templates/front/");

        super.addResourceHandlers(registry);
    }

    @Override
    protected void configureMessageConverters(List<HttpMessageConverter<?>> converters) {
        //配置 json request 转换 失败
        //MappingJackson2HttpMessageConverter jackson2HttpMessageConverter=new MappingJackson2HttpMessageConverter();
        //jackson2HttpMessageConverter.setObjectMapper(ShopStart.objectMapper());
        //List<MediaType> supportedMediaTypes =new ArrayList<>();
        // Invalid token character '/' in
        //supportedMediaTypes.add(new MediaType(MediaType.APPLICATION_JSON_VALUE));
        //supportedMediaTypes.add(new MediaType("application/json"));
        //supportedMediaTypes.add(new MediaType("text/javascript"));
        //supportedMediaTypes.add(new MediaType("text/plain;charset=UTF-8"));
        //jackson2HttpMessageConverter.setSupportedMediaTypes(supportedMediaTypes);
        //converters.add(jackson2HttpMessageConverter);
        super.configureMessageConverters(converters);
    }
}
