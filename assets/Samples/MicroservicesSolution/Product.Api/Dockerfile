# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution and project files
COPY Product.Api.sln .
COPY Product.Api/*.csproj ./Product.Api/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the application files
COPY Product.Api ./Product.Api/

# Build the application in Release mode
RUN dotnet publish -c Release -o out

# Use a smaller runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/out .

# Expose port 80 for the application
EXPOSE 80

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "Product.Api.dll"]
