# syntax=docker/dockerfile:1

## import microsoft offical dotnet7 jdk docker image 
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

ENV ASPNETCORE_URLS="http://0.0.0.0:7000"
EXPOSE 80

FROM node:16-alpine