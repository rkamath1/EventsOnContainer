FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["EventCatalogAPI/EventCatalogAPI.csproj", "EventCatalogAPI/"]
RUN dotnet restore "EventCatalogAPI/EventCatalogAPI.csproj"
COPY . .
WORKDIR "/src/EventCatalogAPI"
RUN dotnet build "EventCatalogAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventCatalogAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventCatalogAPI.dll"]