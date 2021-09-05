package com.shop.user.entity;

import javax.persistence.*;
import lombok.*;
import java.lang.*;

//@Entity(name = "t_teambuy")
@Data
public class Teambuy {
    private long id;
    private Long goodsId;
    private String title;
    private int status;
    private Long storeId;
    private String people;
    private String specs;
}
