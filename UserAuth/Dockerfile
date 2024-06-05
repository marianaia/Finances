FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["UserAuth.csproj", "UserAuth/"]
RUN dotnet restore "UserAuth/UserAuth.csproj"
WORKDIR "/src/UserAuth"
COPY . .
RUN dotnet build "UserAuth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserAuth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserAuth.dll"]