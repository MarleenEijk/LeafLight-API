FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./LeafLight-API/LeafLight-API.csproj"
RUN dotnet publish "./LeafLight-API/LeafLight-API.csproj"

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "LeafLight-API.dll"]