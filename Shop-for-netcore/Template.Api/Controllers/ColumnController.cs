namespace Template.Api.Controllers
{
    using Template.Api.Models;
    using Abp.Domain.Repositories;
    using Abp.NHibernate.Repositories;
    using Template.Api.Repositories;
    using NHibernate;

    public class ColumnController:BaseController<ColumnModel>
    {
        public ColumnController(IRepository<ColumnModel,long?> respository, ISessionFactory sessionFactory) : base(respository, sessionFactory)
        {
        }
        //public ColumnController(IBaseRepository<ColumnModel> respository, ISessionFactory sessionFactory) :base(respository,sessionFactory)
        //{
        //}

        protected override void InsertBefore(ColumnModel create){
            if(create.TableId.HasValue&&create.TableId.Value>0){
                if(create.Table!=null){
                    create.Table.Id=create.TableId;
                }else{
                     create.Table=new TableModel(){Id=create.TableId};
                }
            }
        }

          protected override void UpdateBefore(ColumnModel update){
             InsertBefore(update);
        }
    }
}