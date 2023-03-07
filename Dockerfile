#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["domino_estrutura_de_dados.csproj", "."]
RUN dotnet restore "./domino_estrutura_de_dados.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "domino_estrutura_de_dados.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "domino_estrutura_de_dados.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "domino_estrutura_de_dados.dll"]