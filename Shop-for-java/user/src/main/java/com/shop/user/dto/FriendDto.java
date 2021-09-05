package com.shop.user.dto;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.shop.SqlType;
import com.shop.user.entity.friend.Friend;
import lombok.Data;

@Data
public class FriendDto extends Friend {
    @JsonIgnore
    String sqlType= SqlType.Sql;
    @JsonIgnore
    String userType;
    @JsonIgnore
    boolean enablePage;
    @JsonIgnore
    int page;
    @JsonIgnore
    int size;
}
