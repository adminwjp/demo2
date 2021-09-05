using Abp.Domain.Repositories;
using Abp.NHibernate;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Api.Models;
using Utility.Generator;

namespace Template.Api.Helpers
{
    public class TemplateHelper
    {
        public static DatabaseModel GetData()
        {
            CsharepGeneratorHelper.NameSpace = "Template.Api.EntityMappings";
            CsharepGeneratorHelper.ParseEntity(typeof(TemplateHelper).Assembly, new List<string>() { "Template.Api.Models" });
            DatabaseModel databaseModel = new DatabaseModel()
            {
                TableModels = new HashSet<TableModel>(),
                ProgramName = "Template",
                Name = "模板"
            };
            if (CsharepGeneratorHelper.ClassModels.Count > 0)
            {
                foreach (var it in CsharepGeneratorHelper.ClassModels)
                {
                    if (it.Value.Properties.Count > 0)
                    {
                        TableModel tableModel = new TableModel()
                        {
                            TablemName = it.Value.TableName,
                            ClassName = it.Value.ClassName,
                            Database=databaseModel,
                            ColumnModels = new HashSet<ColumnModel>()
                        };
                        databaseModel.TableModels.Add(tableModel);
                        foreach (var pro in it.Value.Properties)
                        {
                            ColumnModel columnModel = new ColumnModel()
                            {
                                PropertyName = pro.PropertyName,
                                CloumName = pro.ColumnName,
                                Table=tableModel,
                                Length = pro.Length
                            };
                            tableModel.ColumnModels.Add(columnModel);
                        }
                    }
                }
                return databaseModel;
            }
            return null;
        }

        public static void InitData(IApplicationBuilder app)
        {

            var databaseModel = GetData();
            if (databaseModel == null)
            {
                return;
            }
            IRepository<DatabaseModel, long?> databaseRepository = app.ApplicationServices.CreateScope().ServiceProvider.GetService<IRepository<DatabaseModel, long?>>();
            //IRepository<TableModel, long?> tableRepository = app.ApplicationServices.CreateScope().ServiceProvider.GetService<IRepository<TableModel, long?>>();
            //IRepository<ColumnModel, long?> columRepository = app.ApplicationServices.CreateScope().ServiceProvider.GetService<IRepository<ColumnModel, long?>>();
            //using  var session = scope.Session;
            // using var tx = session.BeginTransaction();
            //外键关联 不了 什么情况
            //nhibernate 添加修改 无法自动更新外键
            //级联操作 配置映射 要对
            if (databaseRepository.Count() >0)
            {
                return;
            }
            databaseRepository.Insert(databaseModel);
            return;
            //foreach (var table in databaseModel.TableModels)
            //{
            //    //table.Database = databaseModel;
            //    //table.Database = new DatabaseModel() { Id=databaseModel.Id};
            //    tableRepository.Insert(table);
            //    foreach (var col in table.ColumnModels)
            //    {
            //       // col.Table = table;
            //        //col.Table = new TableModel() { Id=table.Id};
            //        columRepository.Insert(col);
            //    }
            //}
            //tx.Commit();

        }
    }
}
