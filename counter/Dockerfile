# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-ltsc2022 AS build-env
WORKDIR /App

# Copy the project file
COPY counter/counter.csproj ./counter/
WORKDIR /App/counter
RUN dotnet restore

# Copy the rest of the application
COPY counter/ ./
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-ltsc2022
WORKDIR /App
COPY --from=build-env /App/counter/out .
ENTRYPOINT ["dotnet", "counter.dll"]
