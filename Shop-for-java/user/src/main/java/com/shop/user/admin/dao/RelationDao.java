package com.shop.user.admin.dao;

import com.shop.user.entity.Relation;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface RelationDao extends JpaRepository<Relation,Long> {

}
