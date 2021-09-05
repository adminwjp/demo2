namespace Template.Api.Controllers
{
        using Template.Api.Models;
    using Abp.Domain.Repositories;
       using Abp.NHibernate.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Template.Api.Helpers;
    using System.Linq;
    using Template.Api.Repositories;
    using NHibernate;

    public class DatabaseController:BaseController<DatabaseModel>
    {
        public DatabaseController(IRepository<DatabaseModel, long?> respository, ISessionFactory sessionFactory) : base(respository, sessionFactory)
        {
        }
        //public DatabaseController(IBaseRepository<DatabaseModel> respository, ISessionFactory sessionFactory) :base(respository,sessionFactory)
        //{
        //}
        protected override void InsertBefore(DatabaseModel create)
        {
            if (create != null&&create.TableModels!=null)
            {
                foreach (var tab in create.TableModels)
                {
                    tab.Database = create;
                    if (tab.ColumnModels != null)
                    {
                        foreach (var col in tab.ColumnModels)
                        {
                            col.Table = tab;
                        }
                    }
                }
            }
            base.InsertBefore(create);
        }
        [HttpGet("init")]
        public virtual dynamic Init()
        {
            var data = TemplateHelper.GetData();
            //ex  ids for this class must be manually assigned before calling save(): Template.Api.Models.DatabaseModel
           // respository.Insert(data);
            //TemplateHelper.InitData(respository.Session);
            return new { success = true };
        }

        [HttpGet("get")]
        public virtual dynamic Get()
        {
            var data= respository.GetAll().Select(it => new { Label = it.Name, Value = it.Id }).ToList();
            return new { status = true ,code=200, data };
        }
    }
}