package com.shop.dto;

import lombok.Data;

import java.util.List;

@Data
public class DeleteDto {
    String userType;
    long userId;
    List<Long> ids;//post
    long id;//get

}
