
//namespace Shop.Ef.Repositories
//{
//    using Shop.Domain.Repositories;
//    using Shop.Domain.Entities;
//    using Abp.Domain.Uow;
//#if NET48
//    using Abp.EntityFramework;
//    using Abp.EntityFramework.Repositories;
//    using System.Data.Entity;
//#else
//    using Abp.EntityFrameworkCore;
//    using Abp.EntityFrameworkCore.Repositories;
//    using Microsoft.EntityFrameworkCore;
//#endif
//    using Abp.Linq.Expressions;
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Linq.Expressions;
//    using Abp.Domain.Entities.Auditing;

//    public class MenuRepository:BaseRepository<Menu>,IMenuRepository
//    {
//        public MenuRepository(IDbContextProvider<ShopDbContext> dbContextProvider) : base(dbContextProvider)
//        {

//        }
//        public virtual List<Tuple<long,String>> GetGroups(){
//           return  base.GetAll().Where(it=>it.Flag==1) 
//           .Select(it=>new Tuple<long,String>(it.Id,it.Name)).ToList();
//        }

//        public virtual List<Tuple<long,String>> GetMenus(){
//             return base.GetAll().Where(it=>it.Flag==2)
//           .Select(it=>new Tuple<long,String>(it.Id,it.Name)).ToList();
//        }

//        public virtual List<Menu> GetListMenus(){
//            // return GetTreeList(GetQueryableByTree().ToList());
//            return TreeList(base.GetAll().Where(it=>it.IsDeleted).ToList());
//        }
 
//        protected virtual List<Menu> TreeList(List<Menu> data){
//            List<Menu> list=new List<Menu>();
//            //exists or not exists
//            Dictionary<long?,Menu> menus=new Dictionary<long?,Menu>();
//            // not exists
//            Dictionary<long?,Menu> childrens=new Dictionary<long?,Menu>();
//            HashSet<long?> menuIds=new HashSet<long?>();//not exists
//            data.ForEach(it=>{
//                if(it.Flag==1){
//                    list.Add(it);//group
//                }else if(it.Flag==2){
//                    //menu
//                    Menu group=list.Find(m=>m.Id==it.parent_id);
//                    menus.Add(it.Id,it);
//                    if(group==null){
//                        menuIds.Add(it.Id);
//                    }
//                    else{
//                        group.Menus=group.Menus??new List<Menu>();
//                        group.Menus.Add(it); 
//                    }
//                }
//                else {
//                    Menu menu=menus.ContainsKey(it.parent_id)?
//                    menus[it.parent_id]:null;
//                    if(menu==null){
//                        childrens.Add(it.Id,it);
//                    }
//                    else{
//                        menu.Children=menu.Children??new List<Menu>();
//                        menu.Children.Add(it); 
//                    }
//                }
//            });
//            //children
//            if(childrens.Count>0){
//                 foreach(KeyValuePair<long?, Menu> it in childrens)  {
//                    Menu menu=menus.ContainsKey(it.Value.parent_id)?
//                    menus[it.Value.parent_id]:null;
//                    if(menu==null){
//                        //nothing
//                    }
//                    else{
//                        menu.Children=menu.Children??new List<Menu>();
//                        menu.Children.Add(it.Value); 
//                    }
//                 }
//            }
//            //menu
//            if(menuIds.Count>0){
//                 foreach(var it in menuIds)  {
//                     Menu group=list.Find(m=>m.Id==it);
//                    if(group==null){
//                     //nothing
//                    }
//                    else{
//                        group.Menus=group.Menus??new List<Menu>();
//                        group.Menus.Add(menus[it]); 
//                    }
//                 }
//            }
//            return list;
//        }
//        //error vs code tip
//        protected virtual IQueryable<dynamic> GetQueryableByTree(){
//        //      var menus=base.GetAll().Where(it=>!it.parent_id.HasValue||it.parent_id.Value==0)
//        //    .Include(it=>it.Children).AsQueryable();
           
//        //    var data= base.GetAllList(it=>!it.group_id.HasValue||it.group_id.Value==0)
//        //    //.Include(it=>it.Menus)
//        //    .GroupJoin(menus,it=>it.Id,it=>it.group_id,
//        //    (group,menu)=>new {group=group,menu=menu.DefaultIfEmpty()})
//        //    .AsQueryable();
//        //    return data;
//        return null;
//        }
//        //error
//        protected virtual List<Menu> GetTreeList(List<dynamic> data){
//            List<Menu> list=new List<Menu>();
//            data.ForEach(it=>{
//                Menu menu=list.Find(m=>m.Id==it.group.Id);
//                if(menu==null){
//                    menu=it.group as Menu;
//                    list.Add(menu); 
//                    menu.Menus=new List<Menu>();
//                }
//                menu.Menus.Add(it.menu as Menu); 
//            });
//            return list;
//        }
        
//        public override Tuple<List<Menu>,long> GetList(int page,int size){
//           //var data= GetQueryableByTree()
//           //.Skip((page-1)*size).Take(size).ToList();
//           var count=base.Count();
//           //List<Menu> list=GetTreeList(data);
//           List<Menu> list=TreeList(base.GetAll().Skip((page-1)*size).
//           Take(size).ToList());
//           return new Tuple<List<Menu>, long>(list,count);
//        }
//    }
//}