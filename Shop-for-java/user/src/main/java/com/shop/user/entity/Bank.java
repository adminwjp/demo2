package com.shop.user.entity;

import javax.persistence.*;
import lombok.*;
import java.lang.*;

//@Entity(name = "t_bank")
@Data
public class Bank {
    private Long bid;
    private Long userid;
    private String bankName;
    private String shortName;
    private String accountName;
    private String openBank;
    private String type;
    private Integer num;



}
