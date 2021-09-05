package com.shop.user.dto;

public enum  UserType {
    None,
    Buyer,
    Seller,
    Agent,
    Manufacturer,
    Platform,
    Admin;
    public  static  String getUserTypes(UserType userType){
        switch (userType){
            case Agent:return  "Agent";
            case Buyer:return  "Buyer";
            case Seller:return  "Seller";
            case Manufacturer:return  "Manufacturer";
            case Platform:return  "Platform";
            case Admin:return  "Admin";
            default:return "";
        }
    }
    public  static  UserType parseUserTypes(String userType) {
        userType = userType.toLowerCase();
        if ("agent".equals(userType)) return Agent;
        if ("buyer".equals(userType)) return Buyer;
        if ("seller".equals(userType)) return Seller;
        if ("manufacturer".equals(userType)) return Manufacturer;
        if ("platform".equals(userType)) return Platform;
        if ("admin".equals(userType)) return Admin;
        return None;
        /* switch (userType.toLowerCase()){
            case  "agent":return  Agent;
            case "buyer":return  Buyer;
            case  "seller":return  Seller;
            case "manufacturer":return  Manufacturer;
            case "platform":return  Platform;
            case "admin":return  Admin;
            default:return None;
        }*/
    }
}
