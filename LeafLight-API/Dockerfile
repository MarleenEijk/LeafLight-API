FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5254

ENV ASPNETCORE_URLS=http://+:5254

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["LeafLight-API/LeafLight-API.csproj", "LeafLight-API/"]
COPY ["CORE/CORE.csproj", "CORE/"]
COPY ["DATA/DATA.csproj", "DATA/"]
RUN dotnet restore "/LeafLight-API.csproj"
COPY . .
WORKDIR "/src/LeafLight-API"
RUN dotnet build "LeafLight-API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "LeafLight-API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LeafLight-API.dll"]