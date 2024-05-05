# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build /App/out .

# Expose ports
EXPOSE 5000
EXPOSE 5001
EXPOSE 8080

ENTRYPOINT ["dotnet", "ala_alsanea_ebda3soft_demo.dll"]