using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;
using Utility;
using Utility.Database.Provider;
using Utility.IO;
using Utility.Json;

namespace Shop.Xunit
{
    public class StartTest
    {
        public static DbConnection Connection { get; set; }

        public void Setup()
        {

           
            ConfigHelper.DbFlag = DbFlag.MySql;
            string connectionString = "Database=jeeshop;Data Source=192.168.2.110;User Id=root;Password=wjp930514.;Old Guids=True;charset=utf8;";
          //  Connection = (DbConnection)Activator.CreateInstance(Type.GetType("MySql.Data.MySqlClient.MySqlConnection,MySql.Data"), new object[] { connectionString });
            //Connection =new MySqlConnection();
           AbstractDbProvider dbProvider = new MySqlDbProvider();
           // dbProvider.DatabaseOperator(Connection, new Utility.Database.Entries.DatabaseEntry() { Database = "ShopGift" },OperatorFlag.CreateIfNotExists);
            //var tables = dbProvider.FindTable(Connection, Connection.Database);
            //dbProvider.FindTableCache(Connection);

            //FileHelper.WriteFile(@"E:\work\csharp\src\Shop\Shop.UnitTest\table.json",JsonHelper.ToJson(tables));

            //Dictionary<string, object> datas = new Dictionary<string, object>();
            //foreach (var item in tables)
            //{
            //    var data = Connection.Query($"select * from {item}");
            //    datas.Add(item.Replace("_info", "s"), data);
            //}
            //FileHelper.WriteFile("data.json", JsonHelper.ToJson(datas));
        }




  
        public void TestMethod1()
        {
        }
    }
}
namespace Shop
{
    public class WindowServiceHelper {
        //centos 6.x 升级 版本 降低(支持 的命令较少)
        //最好直接安装 centos 8.x (支持 的命令较多)
        //docker gitlab 数据不持久 重启数据丢失 linux gitlab 支持
        //docker oracle 12 bug 开机每次启动失败 重新 安装(启动失败 重启 重新 安装容器) 容器 数据丢失 
        //linux oracle 19 开机后 损坏 没法 使用 需要 重新 安装 rpm 不支持 离线安装
        //windos mongodb, docker 存在 mongodb 启动不了
        // jenkins gitlab(吃内存) window 本地环境直接运行 
        //window docker( publisb or jar)   + （gitlab + jenkins+ nexus） (内存受不了)
        //linux docker(publisb or jar )     + （gitlab + jenkins+ nexus）(内存受不了 java  安装 maven )
        //linux (吃内存) publisb(dotnet ) or jar(java -jar)  + （gitlab + jenkins+ nexus） (内存受不了  java  安装 maven)
        //windows jenkins  linux gitlab ftp linux  ftp 连接异常没法 使用 自定义 jenkins 插件  麻烦 基于 java 实现
        //.net framework windows jenkins + gitlab  运行

        //基于项目路劲 运行 不存在咋办 已创建过咋办
        //asp.net core nssm 安装 启动 麻烦  还需复制 到 启动目录
        //java 麻烦 点 执行 的命令 WinSW 启动麻烦 还需复制 到 启动目录 重命名
        /// <summary>
        /// 创建或更新服务
        /// </summary>
        /// <param name="services"></param>
        public static void StartWindowService(List<ServiceEntry> services)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("@echo off \r\n");
            foreach (var item in services)
            {
                //判断服务是否存在
                builder.AppendFormat("sc query {0} > NUL \r\n", item.Name);
                builder.AppendFormat("IF ERRORLEVEL 1060 GOTO {0}NOTEXIST \r\n GOTO {0}EXIST \r\n", item.Name);

                //存在 服务  服务是否启动  启动 则关闭 再 删除
                builder.AppendFormat(":{0}EXIST \r\n echo not exist {0} service \r\n GOTO END \r\n", item.Name);

                //检测服务是否启动
                builder.AppendFormat("echo \"check {0} service is start?\" \r\n  sc query |find /i \"{0}\" >nul 2>nul \r\n",item.Name);
                builder.AppendFormat("if not errorlevel 1 (goto {0}Start) else goto {0}Stop \r\n",item.Name);
                
                //服务存在已启动 停止服务 删除服务 创建服务
                builder.AppendFormat(":{0}Start \r\n echo  \"{0} service exists,starting \" \r\n net stop {0} \r\n sc delete {0} \r\n goto {0}NOTEXIST \r\n GOTO END \r\n", item.Name);

                //服务存在已停止 删除服务 创建服务
                builder.AppendFormat(":{0}Stop \r\n echo  \"{0} service exists,stopped \" \r\n sc delete {0} \r\n  goto {0}NOTEXIST \r\n GOTO END \r\n", item.Name);

                //创建 服务
                builder.AppendFormat(":{0}NOTEXIST \r\n echo not exist {0} service \r\n ", item.Name);

                builder.AppendFormat("echo \"{0} service create statring\" \r\n", item.Name);
                item.ExecutePath = item.Path;
                if(item.Flag== ServiceFlag.Java)
                {
                    //这个有点麻烦 
                    //创建个 bat 
                    string javabat = "@echo off \r\n echo\"{0} java servic statring \r\n\" {1}: \r\n cd {2} \r\n java -jar {3}  ";
                    string directory = Directory.GetDirectoryRoot(item.Path);
                    Console.WriteLine(directory);
                    using var fileStream = File.OpenRead(item.Path);
                    string fileName = fileStream.Name;
                    Console.WriteLine(fileName);
                    javabat = string.Format(javabat,item.Name,directory[0],directory,item.Path);
                    item.BatPath = $"{directory}\\{item.Name}.bat";
                    FileHelper.WriteFile(item.BatPath, javabat);
                    item.ExecutePath = item.BatPath;
                }
                builder.AppendFormat(ServiceEntry.AspNetCoreService, item.Name, item.ExecutePath).Append("\r\n");
                builder.AppendFormat("echo \"{0} service create success,but auto start service\" \r\n", item.Name);

                builder.Append("GOTO END \r\n");

            }
        }

        public static void StopWindowService(List<ServiceEntry> services)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("@echo off \r\n");
            foreach (var item in services)
            {
                //判断服务是否存在
                builder.AppendFormat("sc query {0} > NUL \r\n", item.Name);
                builder.AppendFormat("IF ERRORLEVEL 1060 GOTO {0}NOTEXIST \r\n GOTO {0}EXIST \r\n", item.Name);

                //存在 服务  服务是否启动  启动 则关闭 再 删除
                builder.AppendFormat(":{0}EXIST \r\n echo not exist {0} service \r\n GOTO END \r\n", item.Name);

                //检测服务是否启动
                builder.AppendFormat("echo \"check {0} service is start?\" \r\n  sc query |find /i \"{0}\" >nul 2>nul \r\n", item.Name);
                builder.AppendFormat("if not errorlevel 1 (goto {0}Start) else goto {0}Stop \r\n", item.Name);

                //服务存在已启动 停止服务 删除服务 创建服务
                builder.AppendFormat(":{0}Start \r\n echo  \"{0} service exists,starting \" \r\n net stop {0} \r\n   GOTO END \r\n", item.Name);

                //服务存在已停止 删除服务 创建服务
                builder.AppendFormat(":{0}Stop \r\n echo  \"{0} service exists,stopped \" \r\n  GOTO END \r\n", item.Name);

              
            }
        }

        public static void DeleteWindowService(List<ServiceEntry> services)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("@echo off \r\n");
            foreach (var item in services)
            {
                //判断服务是否存在
                builder.AppendFormat("sc query {0} > NUL \r\n", item.Name);
                builder.AppendFormat("IF ERRORLEVEL 1060 GOTO {0}NOTEXIST \r\n GOTO {0}EXIST \r\n", item.Name);

                //存在 服务  服务是否启动  启动 则关闭 再 删除
                builder.AppendFormat(":{0}EXIST \r\n echo not exist {0} service \r\n GOTO END \r\n", item.Name);

                //检测服务是否启动
                builder.AppendFormat("echo \"check {0} service is start?\" \r\n  sc query |find /i \"{0}\" >nul 2>nul \r\n", item.Name);
                builder.AppendFormat("if not errorlevel 1 (goto {0}Start) else goto {0}Stop \r\n", item.Name);

                //服务存在已启动 停止服务 删除服务 创建服务
                builder.AppendFormat(":{0}Start \r\n echo  \"{0} service exists,starting \" \r\n net stop {0} \r\n sc delete {0} \r\n  GOTO END \r\n", item.Name);

                //服务存在已停止 删除服务 创建服务
                builder.AppendFormat(":{0}Stop \r\n echo  \"{0} service exists,stopped \" \r\n sc delete {0} \r\n   GOTO END \r\n", item.Name);


            }
        }
    }
    public class ServiceEntry
    {
        /// <summary>
        /// 服务最好 不好要有 .
        /// </summary>
        public string Name { get; set; }
        public string Path { get; set; }
        public string ExecutePath { get; set; }
        public string BatPath { get; set; }
        public ServiceFlag Flag { get; set; }
        public const string AspNetCoreService = "sc create {0} -binpath \"{1}\" start=auto ";
    }
    [Flags]
    public enum ServiceFlag
    {
        CSharp=0x0,
        Java=0x1
    }
}
