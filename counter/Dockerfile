# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-ltsc2022 AS build-env
WORKDIR /App

# Copy only the project file(s) first to leverage Docker's layer caching
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application
COPY . ./
# Build and publish the project
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-ltsc2022
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "counter.dll"]
