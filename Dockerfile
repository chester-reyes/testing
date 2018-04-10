FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS builder
COPY . ./
RUN dotnet restore --source https://api.nuget.org/v3/index.json --source http://nuget.hautelook.net/nuget/ --source http://nuget.erp.hautelook.net/dev/nuget
RUN dotnet build -c Release -o /app

FROM builder AS publish
RUN dotnet publish -c Release -o /app

FROM base AS production
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HelloWorld.dll"]
