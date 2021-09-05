package com.shop;

import lombok.Data;

@Data
public class RelationBean {
    Long id;
    Long value1;
    Long value2;
    Long value3;

    Long strValue1;
    Long strValue2;
    Long strValue3;
    RelationType relationType;

    String description;
    public  static  void  gradeIntegral(RelationBean relation){
        relation.description="sgradeId,buyIntegral";
        relation.relationType= RelationType.GradeIntegral;
    }
    public  static  void  recommendShop(RelationBean relation){
        relation.relationType= RelationType.RecommendShop;
        relation.description="recom_name,shop_id";
    }
    public  static  void  recommendProduct(RelationBean relation){
        //id(Relation)  product_id
        relation.description="recom_id,product_id";
        relation.relationType= RelationType.RecommendProduct;
    }
}

