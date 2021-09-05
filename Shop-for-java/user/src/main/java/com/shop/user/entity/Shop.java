package com.shop.user.entity;

import javax.persistence.*;
import lombok.*;
import java.lang.*;
import java.math.BigDecimal;
import java.text.Bidi;
import java.util.Date;

//@Entity(name = "t_shop")
@Data
public class Shop {
    private Long shopId;
    private String shopName;
    private String ownerName;
    private Long identityCard;
    private Long regionId;
    private String regionName;
    private String address;
    private String zipcode;
    private String tel;
    private String sgrade;
    private String applyRemark;
    private String creditValue;
    private BigDecimal praiseRate;
    private String domain;
    private Integer state;
    private String closeReason;
    private Long addTime;
    private Long endTime;
    private String certification;
    private Integer sortOrder;
    private String recommended;
    private String theme;
    private String wapTheme;
    private String storeBanner;
    private String wapStoreBanner;
    private String storeLogo;
    private String description;
    private String identityFront;
    private String identityBack;
    private String businessLicense;
    private String imQq;
    private String imWw;
    private String navColor;
    private String navShowStyle;
    private String hotSearch;
    private String businessScope;
    private String onlineService;
    private String hotline;
    private String storeSlides;
    private String wapStoreSlides;
    private String longitude;
    private String latitude;
    private String zoom;


}
