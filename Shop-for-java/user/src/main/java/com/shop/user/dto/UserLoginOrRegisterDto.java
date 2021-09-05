package com.shop.user.dto;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.Data;

@Data
public class UserLoginOrRegisterDto {
    @JsonIgnore
    String userType;
    String account;
    String pwd;
    String code;
    AccountType type;
}
