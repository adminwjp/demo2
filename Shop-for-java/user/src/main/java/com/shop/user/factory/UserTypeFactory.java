package com.shop.user.factory;

import com.shop.user.exception.UserTypeException;

import java.util.HashMap;
import java.util.Map;

public class UserTypeFactory {
    static  final Map<String,String> userTypes=new HashMap<String,String>(10);
    public  static  void  Init(){
        if(userTypes.size()==0){
            userTypes.put("buyer","buyer");
            userTypes.put("seller","seller");
            userTypes.put("agent","agent");
            userTypes.put("manufacturer","manufacturer");
            userTypes.put("platform","platform");
            userTypes.put("admin","admin");
        }
    }
    public  static  void checkUserType( String userType) throws UserTypeException {
        userType=userType.toLowerCase();
        Init();
        if(!userTypes.containsKey(userType)){
            throw new UserTypeException("userType err,only is buyer or seller or agent or manufacturer");
        }
     /*   switch (userType){
            case "buyer":
                break;
            case "seller":
                break;
            case "agent":
                break;
            case "manufacturer":
                break;
            default:
                throw new UserTypeException("userType err,only is buyer or seller or agent or manufacturer");
        }*/
    }
}
