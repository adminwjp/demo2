package com.shop.user.service;

import com.auth0.jwt.JWT;
import com.auth0.jwt.algorithms.Algorithm;

//https://www.jianshu.com/p/e88d3f8151db
public class UserJwtService {
    public  static  String  getToken(long userid,String pwd){
        String token= JWT.create().withAudience(String.valueOf(userid))
                .sign(Algorithm.HMAC256(pwd));
        return token;
    }
}
