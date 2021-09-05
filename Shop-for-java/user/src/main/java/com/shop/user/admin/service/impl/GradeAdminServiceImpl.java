package com.shop.user.admin.service.impl;

import com.shop.user.dto.DeleteDto;
import com.shop.user.dto.GradeDto;
import com.shop.user.dto.GradeIntegralDto;
import com.shop.user.entity.Grade;
import com.shop.user.entity.Relation;
import com.utility.service.dto.Tuple;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.*;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import javax.persistence.EntityManager;
import java.util.List;

@Service("adminGradeService")
@Transactional("jpaTransactionManager")
public class GradeAdminServiceImpl {

    EntityManager entityManager;
    JpaRepository<Grade,Long> jpaRepository;
    JpaRepository<Relation,Long> jpaRepository1;
    @Autowired
    public  GradeAdminServiceImpl(EntityManager entityManager){
        this.entityManager=entityManager;
        jpaRepository =new SimpleJpaRepository<Grade,Long>(Grade.class,entityManager);
       jpaRepository1 =new SimpleJpaRepository<Relation,Long>(Relation.class,entityManager);
    }
    public  void  save(Grade grade){
       jpaRepository.save(grade);
    }

    public  void  save(GradeIntegralDto grade){
          if(jpaRepository.existsById(grade.getSgradeId())){
              Relation relation=new Relation();
              relation.setId(grade.getId());
              relation.setValue1(grade.getSgradeId());
              relation.setValue2(grade.getBuyIntegral());
              Relation.gradeIntegral(relation);
              jpaRepository1.save(relation);
         }
    }
    public  void  delete(DeleteDto deleteDto){
        if(deleteDto.getId()>0){
            jpaRepository.deleteById(deleteDto.getId());
           final Relation relation=new Relation();
            relation.setValue1(deleteDto.getId());
           // Example<Relation> example=Example.of(relation);
            Example<Relation> example=new Example<Relation>() {
                @Override
                public Relation getProbe() {
                    return relation;
                }

                @Override
                public ExampleMatcher getMatcher() {
                    return null;
                }
            };
           List<Relation> gradeIntegrals= jpaRepository1.findAll(example);
           if(gradeIntegrals!=null){
               jpaRepository1.deleteAll(gradeIntegrals);
           }
        }
        else{
            for (Long id:deleteDto.getIds()) {
                jpaRepository.deleteById(id);
                final Relation relation=new Relation();
                relation.setValue1(deleteDto.getId());
                //Example<Relation> example=Example.of(relation);
                Example<Relation> example=new Example<Relation>() {
                    @Override
                    public Relation getProbe() {
                        return relation;
                    }

                    @Override
                    public ExampleMatcher getMatcher() {
                        return null;
                    }
                };
                List<Relation> gradeIntegrals= jpaRepository1.findAll(example);
                if(gradeIntegrals!=null){
                    jpaRepository1.deleteAll(gradeIntegrals);
                }
            }
        }
    }

    public  void  deleteGradeIntegral(DeleteDto deleteDto){
       if(deleteDto.getId()>0){
            jpaRepository1.deleteById(deleteDto.getId());

        }
        else{
            for (Long id:deleteDto.getIds()) {
                jpaRepository1.deleteById(id);
            }
        }
    }

    public Tuple<List<GradeDto>,Long> getList(GradeDto getDto){
        final  Grade grade=new Grade();
       // Example<Grade> where= Example.of(grade);
        Example<Grade> where=new Example<Grade>() {
            @Override
            public Grade getProbe() {
                return grade;
            }

            @Override
            public ExampleMatcher getMatcher() {
                return null;
            }
        };
        final  Relation relation=new Relation();
        Pageable pageable= PageRequest.of(getDto.getPage(), getDto.getSize());
        Page<Grade> grades= jpaRepository.findAll(where,pageable);

        Example<Relation> where1= new Example<Relation>() {
            @Override
            public Relation getProbe() {
                return relation;
            }

            @Override
            public ExampleMatcher getMatcher() {
                return null;
            }
        };
        Page<Relation> grade1s= jpaRepository1.findAll(where1,pageable);
        // relation data

        return  null;
    }
}
