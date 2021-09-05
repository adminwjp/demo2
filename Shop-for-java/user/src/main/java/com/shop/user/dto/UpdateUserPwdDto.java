package com.shop.user.dto;

import lombok.Data;

@Data
public class UpdateUserPwdDto extends UserLoginOrRegisterDto {

    String newPwd;
}
