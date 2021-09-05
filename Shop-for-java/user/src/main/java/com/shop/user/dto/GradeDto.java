package com.shop.user.dto;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.shop.user.entity.Grade;
import lombok.Data;

@Data
public class GradeDto  extends Grade {

    private Long buyIntegral;
    @JsonIgnore
    boolean enablePage;
    @JsonIgnore
    int page;
    @JsonIgnore
    int size;

}
