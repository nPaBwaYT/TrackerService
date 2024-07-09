FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TrackerService/TrackerService.csproj", "TrackerService/"]
RUN dotnet restore "TrackerService/TrackerService.csproj"
COPY . .

WORKDIR "/src/TrackerService"
RUN dotnet build "TrackerService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TrackerService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrackerService.dll"]
