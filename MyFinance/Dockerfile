FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyFinance.csproj", "MyFinance/"]
RUN dotnet restore "MyFinance/MyFinance.csproj"
WORKDIR "/src/MyFinance"
COPY . .
RUN dotnet build "MyFinance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyFinance.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyFinance.dll"]