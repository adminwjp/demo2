//namespace Shop.Application.Services
//{
//    using Abp.Domain.Entities;
//    using Shop.Domain.Repositories;
//    using Abp.Application.Services;
//    using System;
//    using Abp.ObjectMapping;
//    using Abp.Domain.Uow;
//    using Shop.Domain.Entities;
//    using Shop.Application.Services.Dtos;
//    using System.Collections.Generic;
    
  

//    //[UnitOfWork]
//     public class MenuAppService:AppService<IMenuRepository,CreateMenuInput,
//    UpdateMenuInput,QueryMenuInput,QueryMenuOutput,Menu>
//    {
//        public MenuAppService(IMenuRepository repository, IObjectMapper objectMapper) : base(repository,objectMapper)
//        {
           
//        }
//        protected override void InsertBefore(List<CreateMenuInput> create,List<Menu> entity){
//              for(var i=0;i<create.Count;i++){
//                if(create[i].ParentId.HasValue&&create[i].ParentId.Value>0){
//                    entity[i].parent_id=create[i].ParentId;
//                    entity[i].Flag=1;
//                }
//                if(create[i].GroupId.HasValue&&create[i].GroupId.Value>0){
//                   //  entity[i].group_id=create[i].GroupId;
//                   entity[i].parent_id=create[i].GroupId;
//                    entity[i].Flag=2;
//                }
//            }
//         }
//         protected override void InsertBefore(CreateMenuInput create,Menu entity){
//             if(create.ParentId.HasValue&&create.ParentId.Value>0){
//                    entity.parent_id=create.ParentId;
//                    entity.Flag=1;
//                }
//                if(create.GroupId.HasValue&&create.GroupId.Value>0){
//                   //  entity.group_id=create.GroupId;
//                   entity.parent_id=create.GroupId;
//                    entity.Flag=2;
//                }
//         }

//         protected override void UpdateBefore(List<UpdateMenuInput> update,List<Menu> entity){
//            for(var i=0;i<update.Count;i++){
//                if(update[i].ParentId.HasValue&&update[i].ParentId.Value>0){
//                    entity[i].parent_id=update[i].ParentId;
//                    entity[i].Flag=1;
//                }
//                if(update[i].GroupId.HasValue&&update[i].GroupId.Value>0){
//                   //  entity[i].group_id=update[i].GroupId;
//                   entity[i].parent_id=update[i].GroupId;
//                    entity[i].Flag=2;
//                }
//            }
//         }

//         protected override void UpdateBefore(UpdateMenuInput update,Menu entity){
//           if(update.ParentId.HasValue&&update.ParentId.Value>0){
//                    entity.parent_id=update.ParentId;
//                    entity.Flag=1;
//                }
//                if(update.GroupId.HasValue&&update.GroupId.Value>0){
//                   //  entity.group_id=update.GroupId;
//                   entity.parent_id=update.GroupId;
//                    entity.Flag=2;
//                }
//         }

//         public virtual List<Tuple<long,String>> GetGroups(){
//             return repository.GetGroups();
//         }

//         public virtual List<Tuple<long,String>> GetMenus(){
//              return repository.GetMenus();
//         }

//         public virtual List<QueryMenuOutput> GetListMenus(){
//              var data= repository.GetListMenus();
//              var result= ObjectMapper.Map<List<QueryMenuOutput>>(data);
//              return result;
//         }
//    }
//}