#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DesafioTotvs.Api/DesafioTotvs.Api.csproj", "DesafioTotvs.Api/"]
RUN dotnet restore "DesafioTotvs.Api/DesafioTotvs.Api.csproj"
COPY . .
WORKDIR "/src/DesafioTotvs.Api"
RUN dotnet build "DesafioTotvs.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioTotvs.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioTotvs.Api.dll"]