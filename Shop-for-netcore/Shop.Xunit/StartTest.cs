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
        //centos 6.x ���� �汾 ����(֧�� ���������)
        //���ֱ�Ӱ�װ centos 8.x (֧�� ������϶�)
        //docker gitlab ���ݲ��־� �������ݶ�ʧ linux gitlab ֧��
        //docker oracle 12 bug ����ÿ������ʧ�� ���� ��װ(����ʧ�� ���� ���� ��װ����) ���� ���ݶ�ʧ 
        //linux oracle 19 ������ �� û�� ʹ�� ��Ҫ ���� ��װ rpm ��֧�� ���߰�װ
        //windos mongodb, docker ���� mongodb ��������
        // jenkins gitlab(���ڴ�) window ���ػ���ֱ������ 
        //window docker( publisb or jar)   + ��gitlab + jenkins+ nexus�� (�ڴ��ܲ���)
        //linux docker(publisb or jar )     + ��gitlab + jenkins+ nexus��(�ڴ��ܲ��� java  ��װ maven )
        //linux (���ڴ�) publisb(dotnet ) or jar(java -jar)  + ��gitlab + jenkins+ nexus�� (�ڴ��ܲ���  java  ��װ maven)
        //windows jenkins  linux gitlab ftp linux  ftp �����쳣û�� ʹ�� �Զ��� jenkins ���  �鷳 ���� java ʵ��
        //.net framework windows jenkins + gitlab  ����

        //������Ŀ·�� ���� ������զ�� �Ѵ�����զ��
        //asp.net core nssm ��װ ���� �鷳  ���踴�� �� ����Ŀ¼
        //java �鷳 �� ִ�� ������ WinSW �����鷳 ���踴�� �� ����Ŀ¼ ������
        /// <summary>
        /// ��������·���
        /// </summary>
        /// <param name="services"></param>
        public static void StartWindowService(List<ServiceEntry> services)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("@echo off \r\n");
            foreach (var item in services)
            {
                //�жϷ����Ƿ����
                builder.AppendFormat("sc query {0} > NUL \r\n", item.Name);
                builder.AppendFormat("IF ERRORLEVEL 1060 GOTO {0}NOTEXIST \r\n GOTO {0}EXIST \r\n", item.Name);

                //���� ����  �����Ƿ�����  ���� ��ر� �� ɾ��
                builder.AppendFormat(":{0}EXIST \r\n echo not exist {0} service \r\n GOTO END \r\n", item.Name);

                //�������Ƿ�����
                builder.AppendFormat("echo \"check {0} service is start?\" \r\n  sc query |find /i \"{0}\" >nul 2>nul \r\n",item.Name);
                builder.AppendFormat("if not errorlevel 1 (goto {0}Start) else goto {0}Stop \r\n",item.Name);
                
                //������������� ֹͣ���� ɾ������ ��������
                builder.AppendFormat(":{0}Start \r\n echo  \"{0} service exists,starting \" \r\n net stop {0} \r\n sc delete {0} \r\n goto {0}NOTEXIST \r\n GOTO END \r\n", item.Name);

                //���������ֹͣ ɾ������ ��������
                builder.AppendFormat(":{0}Stop \r\n echo  \"{0} service exists,stopped \" \r\n sc delete {0} \r\n  goto {0}NOTEXIST \r\n GOTO END \r\n", item.Name);

                //���� ����
                builder.AppendFormat(":{0}NOTEXIST \r\n echo not exist {0} service \r\n ", item.Name);

                builder.AppendFormat("echo \"{0} service create statring\" \r\n", item.Name);
                item.ExecutePath = item.Path;
                if(item.Flag== ServiceFlag.Java)
                {
                    //����е��鷳 
                    //������ bat 
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
                //�жϷ����Ƿ����
                builder.AppendFormat("sc query {0} > NUL \r\n", item.Name);
                builder.AppendFormat("IF ERRORLEVEL 1060 GOTO {0}NOTEXIST \r\n GOTO {0}EXIST \r\n", item.Name);

                //���� ����  �����Ƿ�����  ���� ��ر� �� ɾ��
                builder.AppendFormat(":{0}EXIST \r\n echo not exist {0} service \r\n GOTO END \r\n", item.Name);

                //�������Ƿ�����
                builder.AppendFormat("echo \"check {0} service is start?\" \r\n  sc query |find /i \"{0}\" >nul 2>nul \r\n", item.Name);
                builder.AppendFormat("if not errorlevel 1 (goto {0}Start) else goto {0}Stop \r\n", item.Name);

                //������������� ֹͣ���� ɾ������ ��������
                builder.AppendFormat(":{0}Start \r\n echo  \"{0} service exists,starting \" \r\n net stop {0} \r\n   GOTO END \r\n", item.Name);

                //���������ֹͣ ɾ������ ��������
                builder.AppendFormat(":{0}Stop \r\n echo  \"{0} service exists,stopped \" \r\n  GOTO END \r\n", item.Name);

              
            }
        }

        public static void DeleteWindowService(List<ServiceEntry> services)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("@echo off \r\n");
            foreach (var item in services)
            {
                //�жϷ����Ƿ����
                builder.AppendFormat("sc query {0} > NUL \r\n", item.Name);
                builder.AppendFormat("IF ERRORLEVEL 1060 GOTO {0}NOTEXIST \r\n GOTO {0}EXIST \r\n", item.Name);

                //���� ����  �����Ƿ�����  ���� ��ر� �� ɾ��
                builder.AppendFormat(":{0}EXIST \r\n echo not exist {0} service \r\n GOTO END \r\n", item.Name);

                //�������Ƿ�����
                builder.AppendFormat("echo \"check {0} service is start?\" \r\n  sc query |find /i \"{0}\" >nul 2>nul \r\n", item.Name);
                builder.AppendFormat("if not errorlevel 1 (goto {0}Start) else goto {0}Stop \r\n", item.Name);

                //������������� ֹͣ���� ɾ������ ��������
                builder.AppendFormat(":{0}Start \r\n echo  \"{0} service exists,starting \" \r\n net stop {0} \r\n sc delete {0} \r\n  GOTO END \r\n", item.Name);

                //���������ֹͣ ɾ������ ��������
                builder.AppendFormat(":{0}Stop \r\n echo  \"{0} service exists,stopped \" \r\n sc delete {0} \r\n   GOTO END \r\n", item.Name);


            }
        }
    }
    public class ServiceEntry
    {
        /// <summary>
        /// ������� ����Ҫ�� .
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
