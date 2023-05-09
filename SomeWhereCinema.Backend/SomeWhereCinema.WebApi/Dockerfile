FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SomeWhereCinema.WebApi/SomeWhereCinema.WebApi.csproj", "SomeWhereCinema.WebApi/"]
RUN dotnet restore "SomeWhereCinema.WebApi/SomeWhereCinema.WebApi.csproj"
COPY . .
WORKDIR "/src/SomeWhereCinema.WebApi"
RUN dotnet build "SomeWhereCinema.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SomeWhereCinema.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SomeWhereCinema.WebApi.dll"]
