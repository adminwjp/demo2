using Shop.Application.Services;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Application.Services.Dtos;
using Utility.IO;
using Utility.Json;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Services.Dtos;
using Shop.Domain.Repositories;
using MySqlConnector;
using Utility.Database.Provider;
using Utility.Database;
using Dapper;
using Utility.Database.Driver;
using Utility.Database.Adapater;
using Utility.Helpers;

namespace Shop.Xunit
{
    public class DataTest
    {
        ITestOutputHelper tempOutput;
        string path = InitTest.path + "/Shop.Xunit/";
        public DataTest(ITestOutputHelper tempOutput)
        {
            this.tempOutput = tempOutput;
        }
        //generator java
        [Fact]
        public virtual void GetTableStructure()
        {
            var connStr = "Database=shopwind;Data Source=127.0.0.1;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
            var conn = new MySqlConnection(connStr);
            DbAdapater dbAdapater = new DbAdapater();
            var tabs = dbAdapater.GetTables(conn, "shopwind",SqlType.MySql);
            Dictionary<string, string> classes = new Dictionary<string, string>();
            StringBuilder builder = new StringBuilder(1000);
            //java entity
            foreach (var tab in tabs)
            {
                builder.Append("package com.shop.entity;\r\n\r\n");
                builder.Append("import javax.persistence.*;\r\n");
                builder.Append("import lombok.*;\r\n");
                builder.Append("import java.lang.*;\r\n");
                builder.Append("\r\n");

                var ta = tab.Table.Replace("swd_", "");
                builder.Append("@Entity(name = \"t_"+ ta+"\")\r\n");
                builder.Append("@Data\r\n");
                var t = StringHelper.Parse(ta, StringFormat.InitialLetterLowerCaseUpper);
                builder.Append("public class "+ t + " {\r\n");
                foreach (var col in tab.Columns)
                {
                    var co = StringHelper.Parse(col.Column, StringFormat.InitialLetterLowerCaseUpper);
                    co = StringHelper.Parse(co, StringFormat.InitialLetterLower);
                    builder.Append("    private String " + co+";\r\n");
                }
                builder.Append("}\r\n");
                classes.Add(t, builder.ToString());
                builder.Clear();
            }

            var path = "E:/work/shop/Shop-for-spring-boot/src/main/java/com/shop/entity";
            FileHelper.CreateDirectory(path);
            foreach (var cla in classes)
            {
                FileHelper.WriteFile(path+"/"+cla.Key+".java",cla.Value);
            }
        }
        //不懂表数据 怎么关联的 组合 数据麻烦 头痛
        //[Fact]
        public virtual void GetDbData()
        {
            //var t = typeof(MySqlConnection);
           // Type type = Type.GetType(t.AssemblyQualifiedName);
            //MySqlConnectorDatabaseDriverV1.Empty.VersionName = ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=d33d3e53aa5f8c92";
            var connStr = "Database=shopwind;Data Source=127.0.0.1;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
            var conn = new MySqlConnection(connStr);
            var tabs= AbstractDbProvider.FindTable(conn, "shopwind",SqlType.MySql);
            Dictionary<string, dynamic> datas = new Dictionary<string, dynamic>();
            var emptyList = new List<dynamic>();
            foreach (var tab in tabs)
            {
                var list=conn.Query($"select * from {tab}");
                datas.Add(tab, list ?? emptyList);
            }

            // Connection is not open
            //conn.ChangeDatabase("mall");
            conn.Close();
            connStr = "Database=mall;Data Source=127.0.0.1;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
            conn = new MySqlConnection(connStr);
            var mtabs = AbstractDbProvider.FindTable(conn, "mall", SqlType.MySql);
            Dictionary<string, dynamic> mdatas = new Dictionary<string, dynamic>();
            foreach (var tab in mtabs)
            {
                var list = conn.Query($"select * from {tab}");
                mdatas.Add(tab, list ?? emptyList);
            }
            FileHelper.WriteFile(InitTest.path+ "/Shop.Xunit/Json/shopwind.json", JsonHelper.ToJson(datas));
            FileHelper.WriteFile(InitTest.path + "/Shop.Xunit/Json/mall.json", JsonHelper.ToJson(mdatas));
        }

       // [Fact]
        public void TestShopData()
        {
        
        }
    }
}
