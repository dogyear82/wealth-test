FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./Wealth.Core/Wealth.Core.csproj Wealth.Core/
COPY ./Wealth.Infrastructure/Wealth.Infrastructure.csproj Wealth.Infrastructure/
COPY ./Wealth.Api/Wealth.Api.csproj Wealth.Api/
RUN dotnet restore Wealth.Api/Wealth.Api.csproj
COPY . .
WORKDIR /src/Wealth.Api
RUN dotnet publish -c Release -o /app/out

FROM base AS final
WORKDIR /app
COPY --from=build /app/out .
# Ensure data directory for dataset (read-only bind mount in compose)
RUN mkdir -p /app/Data
ENV Mongo__ConnectionString="mongodb://mongo:27017"
ENV Mongo__Database="wealth"
ENTRYPOINT ["dotnet", "Wealth.Api.dll"]
