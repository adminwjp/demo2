package com.shop.user.entity;

import javax.persistence.*;
import lombok.*;
import java.lang.*;

//@Entity(name = "t_grade")
@Data
public class Grade {
    private Long gradeId;
    private String gradeName;
    private int goodsLimit;
    private int spaceLimit;
    private String charge;
    private boolean needConfirm;
    private String description;
    private String skins;
    private String wapSkins;
    private int sortOrder;

   // private Long buyIntegral;
}
