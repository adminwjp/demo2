package com.shop.user.entity.user;

import javax.persistence.*;
import lombok.*;
import org.hibernate.annotations.GenericGenerator;

import java.lang.*;
import java.util.Date;

//@Entity(name = "t_user")
@Data
@MappedSuperclass
public abstract class User {
	@Id
    //mysql
    @GeneratedValue(generator="increment",strategy = GenerationType.IDENTITY)
   // @GeneratedValue(generator="native",strategy = GenerationType.AUTO)
    private Long userid;
    private String username;
    private String nickname;
    private String email;
    String account;
    private String password;
    @Column(name = "password_reset_token")
    private String passwordResetToken;
    @Column(name = "real_name")
    private String realName;
    private String gender;
    private long birthday;
    @Column(name = "phone_tel")
    private String phoneTel;
    @Column(name = "phone_mob")
    private String phoneMob;
    @Column(name = "im_qq")
    private String imQq;
    @Column(name = "im_ww")
    private String imWw;
    @Column(name = "create_time")
    private long createTime;
    @Column(name = "update_time")
    private long updateTime;
    @Column(name = "last_login")
    private String lastLogin;
    @Column(name = "last_ip")
    private String lastIp;
    private String logins;
    private String ugrade;
    private String portrait;
    private String activation;
    private String locked;
    private String imforbid;
    @Column(name = "auth_key")
    private String authKey;
    private String token;
    @Column(name = "expire_time")
    private long expireTime;

    private String scene;
    private String ip;
    private String address;

    @Column(name = "store_id")
    private Long storeId;
    private String privs;

}
