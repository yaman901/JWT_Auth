FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY JWTAuthSample/JWTAuthSample.csproj .
RUN dotnet restore JWTAuthSample.csproj

COPY JWTAuthSample/. .
RUN dotnet build JWTAuthSample.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish JWTAuthSample.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JWTAuthSample.dll"]
