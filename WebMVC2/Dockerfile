FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["WebMVC2/WebMVC2.csproj", "WebMVC2/"]
RUN dotnet restore "WebMVC2/WebMVC2.csproj"
COPY . .
WORKDIR "/src/WebMVC2"
RUN dotnet build "WebMVC2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebMVC2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebMVC2.dll"]