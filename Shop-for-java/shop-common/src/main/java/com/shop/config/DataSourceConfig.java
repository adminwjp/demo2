package com.shop.config;

import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.boot.jdbc.DataSourceBuilder;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.sqlite.SQLiteConfig;
import org.sqlite.SQLiteDataSource;
import javax.sql.DataSource;

import com.zaxxer.hikari.HikariDataSource;

import java.util.HashMap;
import java.util.Map;

@Configuration
public class DataSourceConfig {
    // ption: Unable to find sutable method for driverClassName
    // sqlite not support
    class SQLiteDataSourceWrapper extends SQLiteDataSource {
        /**
         * Default constructor.
         */
        public SQLiteDataSourceWrapper() {
            super();
        }

        /**
         * Creates a data source based on the provided configuration.
         * 
         * @param config The configuration for the data source.
         */
        public SQLiteDataSourceWrapper(SQLiteConfig config) {
            super(config);
        }

        public void driverClassName(String driverClassName) {

        }
    }

    DataSource sqliteDataSource() {

        DataSourceBuilder dataSourceBuilder = DataSourceBuilder.create();
        dataSourceBuilder.driverClassName("org.sqlite.JDBC");
        // sqlite文件路径，可以是绝对路径也可以是相对路径

        dataSourceBuilder.url("jdbc:sqlite:d:\\\\test.db");
        // spring boot jpa support ,but spring boot jpa mybaits not support
        // Class<?>
        // cla=org.springframework.boot.autoconfigure.sql.init.DataSourceInitializationConfiguration.Class
        // dataSourceBuilder.type(SQLiteDataSource.class);

        // excetiion SessionFactory is null . jpa and mybaits used ex ,but jpa used pass
        // jpa excetiion SessionFactory is null 。before pass ,but now fail
        dataSourceBuilder.type(HikariDataSource.class);
        return dataSourceBuilder.build();
    }

    // @Bean(destroyMethod = "", name = "master")
    public DataSource masterDataSource() {
        return sqliteDataSource();
    }

    // @Bean(destroyMethod = "", name = "slave")
    public DataSource slaveDataSource() {
        return sqliteDataSource();
    }

    // Failed to load driver class org.sqlite.JDBC from HikariDataSource
    @Bean(destroyMethod = "", name = "dynamicDataSource")
    @ConfigurationProperties("spring.datasource.sqlite")
    public DataSource sqliteDataSource1() {
        //return  sqliteDataSource();
       return DataSourceBuilder.create().build();
    }

    // @Autowired
    // @Bean(name = "dynamic1")
     public DataSource dynamicDataSource(@Qualifier("master") DataSource master,
     @Qualifier("slave") DataSource slave) {
     Map<Object, Object> targetDataSources = new HashMap<Object, Object>();
     targetDataSources.put("master", master);
     targetDataSources.put("slave", slave);
     DynamicDataSource dynamicDataSource = new DynamicDataSource();
     dynamicDataSource.setDefaultTargetDataSource(master);
     dynamicDataSource.setTargetDataSources(targetDataSources);
     return dynamicDataSource;
    }
}