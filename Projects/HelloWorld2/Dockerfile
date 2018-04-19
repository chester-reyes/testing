FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /app

# copy source and test projects as distinct layers
COPY . ./
RUN dotnet restore ./HelloWorld.sln --source https://api.nuget.org/v3/index.json 

# copy everything else and build
RUN dotnet publish ./src/HelloWorld/HelloWorld.csproj -c Release -o ./output --no-restore

# build runtime image
FROM microsoft/aspnetcore:2.0 as runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "HelloWorld.dll"]

