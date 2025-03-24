FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5238

ENV ASPNETCORE_URLS=http://+:5238

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["skibidi_gamebook.Server/skibidi_gamebook.Server.csproj", "skibidi_gamebook.Server/"]
RUN dotnet restore "skibidi_gamebook.Server/skibidi_gamebook.Server.csproj"
COPY . .
WORKDIR "/src/skibidi_gamebook.Server"
RUN dotnet build "skibidi_gamebook.Server.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "skibidi_gamebook.Server.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "skibidi_gamebook.Server.dll"]
