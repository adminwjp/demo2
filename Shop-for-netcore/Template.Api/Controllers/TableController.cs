namespace Template.Api.Controllers
{
    using Template.Api.Models;
    using Abp.Domain.Repositories;
       using Abp.NHibernate.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Template.Api.Repositories;
    using NHibernate;

    public class TableController:BaseController<TableModel>
    {
        public TableController(IRepository<TableModel, long?> respository, ISessionFactory sessionFactory) : base(respository, sessionFactory)
        {
        }
        //public  TableController(IBaseRepository<TableModel> respository, ISessionFactory sessionFactory) :base(respository,sessionFactory)
        //{
        //}
        
        protected override void InsertBefore(TableModel create){
            if (create.ColumnModels != null)
            {
                foreach (var col in create.ColumnModels)
                {
                    col.Table = create;
                }
            }
            if (create.DatabaseId.HasValue&&create.DatabaseId.Value>0){
                if(create.Database!=null){
                    create.Database.Id=create.DatabaseId;
                }else{
                     create.Database=new DatabaseModel(){Id=create.DatabaseId};
                }
            }
        }

          protected override void UpdateBefore(TableModel update){
             InsertBefore(update);
        }

        [HttpGet("get")]
        public virtual dynamic Get()
        {
            var data = respository.GetAll().Select(it => new { Label = it.TablemName, Value = it.Id }).ToList();
            return new { status = true, code = 200, data };
        }
    }
}