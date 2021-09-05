package com.shop.user.entity;

import javax.persistence.*;
import lombok.*;
import java.lang.*;
import java.util.Date;

//@Entity(name = "t_teambuy_log")
@Data
public class TeambuyLog {
    private long logid;
    private Long tbid;
    private Long userid;
    private Long orderId;
    private Long goodsId;
    private Long teamid;
    private String leader;
    private String people;
    private int status;
    private long created;
    private long expired;
    private long payTime;
}
