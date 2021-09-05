package com.shop.user.entity;

import javax.persistence.*;
import lombok.*;
import java.lang.*;
import java.util.Date;

//@Entity(name = "t_protocol")
@Data
public class Protocol {
    private Long protocolId;
    private String title;
    private Long cateId;
    private Long storeId;
    private String link;
    private String description;
    private int sortOrder;
    private boolean ifShow;
    private long addTime;
}
