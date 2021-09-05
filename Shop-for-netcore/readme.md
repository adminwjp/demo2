ef mapp anta nhibernate    mapp anta xml
dapper ef nh 三者 同时 使用 运行不了 ioc 定义每个接口 指定 实现 orm 
最好不要用泛型 不然 不知道用哪个 orm
未完成 大量 重复 工作  简单 操作   需要 手动 更改

# centos stream 8 暂时 不适合自动化 内存太小了 16 g (k8s 还没 启动 )不够用 一台pc + 一台 虚拟机 需要减少 一些软件启动 最好 手动发布部署(或者手动+自动部署 麻烦)
k8s  linux 部署 
jenkins(开发机器使用环境方便) linux window 部署

网络 访问 不了 麻烦 需要每次这样设置 (debian ubutun 不需要)
systemctl start firewalld
systemctl stop firewalld
# gitlab 
http://192.168.1.4:8020/
# jenkins 
http://192.168.1.4:9001/
# portainer
http://192.168.1.4:9000/
# nexus
/usr/local/nexus/bin/nexus start &
http://192.168.1.4:8081
# 修改端口
/usr/local/nexus/etc/nexus-default.properties
http://192.168.1.4:8082
启动 比较慢 需要耐心等待
怎么访问 不了 坑 看不出来错没日志? 只有以前的日志 难道 一些 端口冲突 启动失败 没日志(误认为 8082 端口 是 nexus)?
日志 在 这里 /usr/local/sonatype-work/nexus3/log 端口 问题
http://192.168.1.4:8083

# harbor
http://192.168.1.9:8010
# harbor 启动
# 重新 安装 或  启动(portainer 手动启动  需要启动多个组件 麻烦) 
/home/software/harbor/install.sh

jenkins 注意大小写
centos dotnet sdk 无法使用(使用时提示未安装) 提示已安装(安装时) 
dnf install dotnet-sdk-5.0
dnf remove dotnet-sdk-5.0
难道需要卸载 重新安装 ？
只能用 发布的版本运行
放弃 使用 docker jenkins
netstat -nptl
# 8080 k8s jenkins  8081
docker run -d -p 8081:8080   -p 50000:50000  -v jenkins:/var/jenkins_home -v /etc/localtime:/etc/localtime --name jenkins jenkins/jenkins

ee1c941bfd205333407cd1d05a8d3bc0dcf1b372a2e33ed0b0b219f1aa6427ac 容器id(搞错了)
输入的密码有误，请检查文件以确认密码正确
/var/jenkins_home/secrets/initialAdminPassword
注意 文件不存在(搞错 了 docker 路径) 什么情况 需要重新安装 容器
docker exec jenkins tail /var/jenkins_home/secrets/initialAdminPassword
9a651c82a3204474a4ef0cc4d7981021
http://192.168.1.4:8081/

# memory 6g
gitlab 2-3 g
docker 2-3 g
内存不够 cpu 爆炸

# k8s gitlab  db 内存 要给多点 不然 cpu 100%
k8s 需要 2 台 及 以上 机器(虚拟机支持)
vm 内存  添加了  cpu 100% 什么情况 最好 不要用这种 方式 关闭 修改 内存 再开机
vm cpu 跳动很大 之后会降下来
8g 勉强 够用 一旦 使用 k8s 部署内存越多 越好

# ef core map 坑 不能 直接继承 
所有属性 最好 都要 映射 不然报错 不好找 问题 
需要分开 
class A{}
class B:A{}
class AMap{} class BMap:AMap{} 异常

# 正确格式
class Base{}
class A:Base{}
class B:Base{}
class BaseMap{} class AMap:BaseMap{} class BMap:BaseMap{}
# b2c 2021
# 文件 太乱   如果 开个 小店 没必要用 微服务

# abp 框架 技术 
# vs code plugin not need install 
# 有些插件 安装 冲突 提示都没了
# 卸载 所有的 重启  重新安装 
# 所有东西 一旦 共享 变 复杂多了

# https://dotnet.microsoft.com/download/dotnet/6.0
# SDK download

# dotnet ef need runtime 
# runtime download

# dotnet wpf 
# desktop download

# sdk runtime descktop 文件大致相同 麻烦啊
# sdk 开发用 
# runtime 运行时用
# desktop 桌面运行时用

# vscode 没提示
# x86 x64 二进制 怎么弄 没有安装操作
# dotnet ef 有问题 需要 runtime
# x86 x64 安装包 下载
# https://github.com/dotnet/core/blob/main/release-notes/6.0/preview/6.0.0-preview.4.md
# sdk download
# nuget package download fail,need update nuget address
# 源 nuget.org 中不存在具有此 ID 的包
# 操 nuget 存在改包  但 build 失败 github.com sdk 配置出现问题坑 包名 写错了 (报错 位置不对 需要手动检查)
# 二进制 没有问题 处处挖
# C:\Users\Administrator\AppData\Roaming\NuGet\NuGet.Config 
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
 <config> 
    <add key="globalPackagesFolder" value="C:\\Users\\wml\\.nuget\\packages" />
 </config>
</configuration>

# D:\googledown\dotnet-sdk-6.0.100-preview.4.21255.9-win-x86

# C:\Program Files\dotnet\
# net core 环境 不同 怎么 搞的 
# spring boot 坑爹 开始 好好的之后 还原 还是错误


dotnet help

dotnet -version
dotnet run
dotnet build
dotnet clean

dotnet tool search sqlite

#  sdk 二进制
dotnet new list
# github sdk 安装包安装
dotnet new --list

# ef core
dotnet new classlib -o Shop.Domain
dotnet add package Abp

# ef data

dotnet new classlib -o Shop.Ef
dotnet add package Abp.EntityFrameworkCore
dotnet add package Z.EntityFramework.Plus.EFCore
dotnet add package Microsoft.EntityFrameworkCore.Design
# dotnet add package System.Data.SQLite
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add reference ../Shop.Domain

dotnet ef
dotnet tool install --global dotnet-ef 
#  https://aka.ms/dotnet-core-applaunch?missing_runtime=true&arch=x86&rid=win7-x86
# 无法访问此网站


# 提示  --project 最好 用绝对 路劲


dotnet ef migrations add a1 -o Migrations
dotnet ef migrations remove
 dotnet ef database update 

#  NHibernate data
dotnet new classlib -o Shop.NHibernate
dotnet add package Abp.NHibernate
dotnet add reference ../Shop.Domain

# Application
dotnet new classlib -o Shop.Application
dotnet add package  Abp.AutoMapper
dotnet add reference ../Shop.Ef
# 包“Abp.AutoMapper”与项目“D:\shop\Shop-for-netcore\Shop.Application\Shop.Application.csproj”中的 “all”框架不兼容

# Xunit
dotnet new xunit -o Shop.Xunit
dotnet add package  Castle.Windsor.MsDependencyInjection
dotnet add reference ../Shop.Application
dotnet test
# xunit not has tip namespace unkown


# aspnet core api
dotnet new webapi -o Shop.Api
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add package Serilog.AspNetCore
dotnet add package Microsoft.AspNetCore.Mvc.Versioning
dotnet add package Abp.AspNetCore
dotnet add reference ../Shop.Application
dotnet run urls="http://*:8080"

# dotnet new 不支持 asp.net 
# asp.net  core 
dotnet new viewstart -o Shop.Web
# _ViewStart.cshtml
dotnet new page -o Shop.Web
# Shop.Web.cshtml
# Shop.Web.cshtml.cs
dotnet new blazorserver -o Shop.Web
# asp.net core mvc 
dotnet new  razorcomponent  -o Shop.Web
# Shop.Web.razorc
dotnet new  viewimports   -o Shop.Web
# _ViewStart.cshtml
dotnet new  blazorwasm    -o Shop.Web
# asp.net core mvc 

# net core wpf
dotnet new wpf -o Shop.Wpf
dotnet add reference ../Shop.Application

# .gitignore
dotnet new gitignore -o Shop-for-netcore

# net core Background, asp net core worker
dotnet new worker -o Shop.Background
dotnet add reference ../Shop.Application

# nuget.config
dotnet new nugetconfig -o Shop-for-netcore

# global.json
dotnet new globaljson -o Shop-for-netcore

# sln
dotnet new sln -o Shop-for-netcore
dotnet  sln --help
dotnet  sln  add Shop.Domain
dotnet  sln  add Shop.Ef
dotnet  sln  add Shop.Application
dotnet  sln  add Shop.Xunit
dotnet  sln  add Shop.Api
dotnet  sln  add Shop.Wpf
dotnet  sln  add Shop.Background
dotnet  sln  add Template.Api


# Template.Api
dotnet new webapi -o Template.Api
dotnet add package Abp.NHibernate
dotnet add package System.Data.SQLite
dotnet add package Abp.AspNetCore
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add package Serilog.AspNetCore
dotnet add package Microsoft.AspNetCore.Mvc.Versioning

dotnet run urls="http://*:5000;http://*:5001"


dotnet new classlib -o Utility.Generator

Shop.NetApi asp.net webapi abp 模板






