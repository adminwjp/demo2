using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Http;
using System.Text;
using Utility;
using Utility.Ef;
using Utility.IO;
using Utility.Json;

namespace Shop.Xunit
{
    //可读性 太差 容易出错  直接 用 实体解决   api 调用 不了 关联 时 没 id id 自动 生成 的 

    public class ProductApiTest
    {
        public static string ApiUrl = "http://192.168.2.110:8081";
        public static   JsonSerializerSettings JsonSerializer = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = JsonContractResolver.JsonResolverObject,
            DateFormatString = "yyyy-MM-dd HH:mm:ss"
        };

        public  DbConnection Connection { get; set; }
        //id int 要给为 guid 最后改
  
        public void LoadData()
        {
            ConfigHelper.DbFlag = DbFlag.MySql;
            string connectionString = "Database=ShopProduct;Data Source=192.168.2.110;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
            /* Connection=(DbConnection)Activator.CreateInstance(Type.GetType("MySql.Data.MySqlClient.MySqlConnection,MySql.Data"), new object[] { connectionString });

             AbstractDbProvider dbProvider = new MySqlDbProvider();
             var tables = dbProvider.FindTable(Connection, Connection.Database);
             foreach (var item in tables)
             {
                 Console.WriteLine(item);

             }*/

         





            //string mjson = FileHelper.ReadFile(@"E:\work\csharp\src\Shop\Shop.UnitTest\mobile.data.json");
        }

            private static void Init(JObject @object,string key,string controller,ref List<Dictionary<string, object>> result )
        {
            List<Dictionary<string, object>> datas = new List<Dictionary<string, object>>();
            JArray cs = (JArray)@object[key];
            foreach (var item in cs)
            {
                var da = JsonHelper.ToObject<Dictionary<string, object>>(item.ToString());
                datas.Add(da);
            }
            if(key== "t_catalog")
            {

            }
            using HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"{ApiUrl}/api/v1/admin/{controller}/insert");
            foreach (var item in datas)
            {
                string j = JsonHelper.ToJson(item, JsonSerializer);
                string r = httpClient.Send(new HttpRequestMessage() { 
                    Method= HttpMethod.Post ,
                    Content = new StringContent(j, Encoding.UTF8, Utility.Net.Http.ContentTypeConstant.APPLICATION_JSON)
                }).Content
                     .ReadAsStringAsync().GetAwaiter().GetResult();
                Console.WriteLine(r);
            }
        }
    }
}
