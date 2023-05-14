# syntax=docker/dockerfile:1

## import microsoft offical dotnet7 jdk docker image 
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env

## setup working dir as webapi dir
WORKDIR /SomeWhereCinema.WebApi.DotNet7

# copy the project init file to docker image builder
COPY SomeWhereCinema.WebApi.DotNet7/*.csproj .
# use dotnet to restore everything
RUN dotnet restore

# copy whole project into docker image builder
## the path is from current workdir which is webapi up to solution dir and copy everything
COPY ../. .

## run publish commend with pasth point to webapi project
RUN dotnet publish ./SomeWhereCinema.WebApi.DotNet7/*.csproj -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

WORKDIR /publish

COPY --from=build-env /publish .

ENV ASPNETCORE_URLS="http://0.0.0.0:7000"
EXPOSE 80

ENTRYPOINT ["dotnet", "SomeWhereCinema.WebApi.DotNet7.dll"]

