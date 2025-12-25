# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY JWTAuthSample/JWTAuthSample.csproj ./
RUN dotnet restore JWTAuthSample.csproj

# Copy the rest of the source code and build the project
COPY JWTAuthSample/. ./
RUN dotnet publish JWTAuthSample.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Start the app
ENTRYPOINT ["dotnet", "JWTAuthSample.dll"]
