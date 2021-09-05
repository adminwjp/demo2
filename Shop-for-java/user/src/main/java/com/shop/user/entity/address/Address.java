package com.shop.user.entity.address;

import javax.persistence.*;
import lombok.*;
import org.hibernate.annotations.GenericGenerator;

import java.lang.*;


//@Data
@MappedSuperclass
public abstract class Address {
	@Id
	//mysql
	@GeneratedValue(generator="increment",strategy = GenerationType.IDENTITY)

	//@GeneratedValue(generator="native",strategy = GenerationType.AUTO)
    @Column(name="addr_id")
    private Long addrId;
    private Long userid;
    private String consignee;
    @Column(name="region_id")
    private String regionId;
    @Column(name="region_name")
    private String regionName;
    private String address;
    private String zipcode;
    @Column(name="phone_tel")
    private String phoneTel;
    @Column(name="phone_mob")
    private String phoneMob;
    private boolean defaddr;
    @Version
	long timestamp;
    
    public Long getAddrId() {
		return addrId;
	}
	public void setAddrId(Long addrId) {
		this.addrId = addrId;
	}
	public Long getUserid() {
		return userid;
	}
	public void setUserid(Long userid) {
		this.userid = userid;
	}
	public String getConsignee() {
		return consignee;
	}
	public void setConsignee(String consignee) {
		this.consignee = consignee;
	}
	public String getRegionId() {
		return regionId;
	}
	public void setRegionId(String regionId) {
		this.regionId = regionId;
	}
	public String getRegionName() {
		return regionName;
	}
	public void setRegionName(String regionName) {
		this.regionName = regionName;
	}
	public String getAddress() {
		return address;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	public String getZipcode() {
		return zipcode;
	}
	public void setZipcode(String zipcode) {
		this.zipcode = zipcode;
	}
	public String getPhoneTel() {
		return phoneTel;
	}
	public void setPhoneTel(String phoneTel) {
		this.phoneTel = phoneTel;
	}
	public String getPhoneMob() {
		return phoneMob;
	}
	public void setPhoneMob(String phoneMob) {
		this.phoneMob = phoneMob;
	}
	public boolean isDefaddr() {
		return defaddr;
	}
	public boolean getDefaddr() {
		return defaddr;
	}
	public void setDefaddr(boolean defaddr) {
		this.defaddr = defaddr;
	}
	public long getTimestamp() {
		return timestamp;
	}

	public void setTimestamp(long timestamp) {
		this.timestamp = timestamp;
	}


    



}
