FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8082

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SkillUpHub.Notification/SkillUpHub.Notification/SkillUpHub.Notification.csproj", "SkillUpHub.Notification/"]
RUN dotnet restore "SkillUpHub.Notification/SkillUpHub.Notification.csproj"
COPY ./SkillUpHub.Notification/ .
WORKDIR "/src/SkillUpHub.Notification"
RUN dotnet build "SkillUpHub.Notification.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SkillUpHub.Notification.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkillUpHub.Notification.dll"]