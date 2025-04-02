# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
RUN apt update && apt install nodejs npm -y
RUN mkdir -p ~/.aspnet/https
WORKDIR /src

COPY ["skibidi_gamebook.Server/skibidi_gamebook.Server.csproj", "skibidi_gamebook.Server/"]
COPY ["skibidi_gamebook.client/skibidi_gamebook.client.esproj", "skibidi_gamebook.client/"]
RUN dotnet restore "skibidi_gamebook.Server/skibidi_gamebook.Server.csproj"
COPY . .
RUN dotnet build "skibidi_gamebook.Server.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "skibidi_gamebook.Server.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "skibidi_gamebook.Server.dll"]
