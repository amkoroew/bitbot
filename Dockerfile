FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet build "Player/Player.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Player/Player.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
EXPOSE 3000
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_HTTP_PORTS=3000
ENTRYPOINT ["dotnet", "Player.dll"]
