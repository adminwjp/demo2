package com.shop.user.entity.friend;

import javax.persistence.*;
import lombok.*;
import org.hibernate.annotations.GenericGenerator;

import java.lang.*;
import java.util.Date;

//BuyerFriend SellerFriend  AgentFriend  ManufacturerFriend
//@Entity(name = "t_friend")
@Data
@MappedSuperclass
public abstract class Friend {
	@Id
    //mysql
    @GeneratedValue(generator="increment",strategy = GenerationType.IDENTITY)
    //@GeneratedValue(generator="native",strategy = GenerationType.AUTO)
    private Long id;
    private Long userid;
    @Column(name = "friend_id")
    private Long friendId;
    @Column(name = "add_time")
    private long addTime;


   

}
