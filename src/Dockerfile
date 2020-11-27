#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

WORKDIR /root/.nuget/NugetFeed
COPY NugetFeed ./
COPY ./NugetFeed/NuGet.Config /root/.nuget/NuGet/NuGet.Config

WORKDIR /app/publish/Pages
COPY src/Pages ./

WORKDIR /src
COPY ["src/Ext.Net.Examples.csproj", "src/"]
RUN dotnet restore "src/Ext.Net.Examples.csproj"
COPY . .
WORKDIR "/src/Ext.Net.Examples"
RUN dotnet build "Ext.Net.Examples.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ext.Net.Examples.csproj" -c Release -o /app/publish

WORKDIR /app/publish
RUN find . \( -name "Ext.Net.*.Debug.dll" -o -name "Ext.Net.*.Rtl.*.dll" \) -exec truncate -s 0 {} \;

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ext.Net.Examples.dll"]
