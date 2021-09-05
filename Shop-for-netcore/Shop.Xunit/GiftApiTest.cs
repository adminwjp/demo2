using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Utility.IO;
using Utility.Json;

namespace Shop.Xunit
{
    public class GiftApiTest
    {
        public static string ApiUrl = "http://192.168.2.110:8083";

        //id int 要给为 guid 最后改
        //[TestMethod] 
        public void LoadData()
        {
            string json = FileHelper.ReadFile(@"E:\work\csharp\src\Shop\Shop.UnitTest\data.json");
            JObject @object = JObject.Parse(json);
            //using HttpClient httpClient = new HttpClient();
           // httpClient.BaseAddress = new Uri($"{ApiUrl}/api/v1/admin/gift/insert");
          
          
            foreach (var item in (JArray)@object["t_gift"])
            {
                string j = JsonHelper.ToJson(JsonHelper.ToObject<Dictionary<string,object>>(item.ToString()), JsonHelper.JsonSerializerSettings);
                Console.WriteLine(j);
                /* string r =  httpClient.Send(new HttpRequestMessage()
                 {
                     Method = HttpMethod.Post,
                     Content = new StringContent(j, Encoding.UTF8, Utility.Net.Http.ContentTypeConstant.APPLICATION_JSON)
                 })
                     .Content.ReadAsStringAsync().GetAwaiter().GetResult();*/
                string r = Utility.Net.Http.HttpHelper.PostJson($"{ApiUrl}/api/v1/admin/gift/insert",j);
                Console.WriteLine(r);
            }
        }
    }
}
