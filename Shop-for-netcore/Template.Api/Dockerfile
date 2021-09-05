#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["Template.Api/Template.Api.csproj", "Template.Api/"]
COPY ["Utility.Generator/Utility.Generator.csproj", "Utility.Generator/"]
# docker 不支持 上级 查找文件 只 支持 向下 查找文件 这怎么 搞 shared
COPY ["../../utility/Utility-for-net/Utility.Db/Utility.Db.csproj", "../../utility/Utility-for-net/Utility.Db/"]
COPY ["../../utility/Utility-for-net/Utility.Simple/Utility.Simple.csproj", "../../utility/Utility-for-net/Utility.Simple/"]
RUN dotnet restore "Template.Api/Template.Api.csproj"
COPY . .
WORKDIR "/src/Template.Api"
RUN dotnet build "Template.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Template.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.Api.dll"]