FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Market.API/Market.API.csproj", "src/Market.API/"]
RUN dotnet restore "src/Market.API/Market.API.csproj"
COPY . .
WORKDIR "/src/src/Market.API"
RUN dotnet build "Market.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Market.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Market.API.dll"]
