package com.shop.dto;

import lombok.Data;

@Data
public class GetDto {
    String userType;
    long userId;
    int page;
    int size;
}
