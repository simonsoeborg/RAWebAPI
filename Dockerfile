#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5002/tcp
ENV ASPNETCORE_URLS http://*:5002 https://*:5002
ENV ASPNETCORE_HTTPS_PORT=5002
ENV ASPNETCORE_ENVIRONMENT docker
# updating
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RAWebAPI.csproj", "."]
RUN dotnet restore "RAWebAPI.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "RAWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RAWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RAWebAPI.dll"]
