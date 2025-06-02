# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy and restore
COPY ["DogsBreed-API.csproj", "./"]
RUN dotnet restore "./DogsBreed-API.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "./DogsBreed-API.csproj" -c Release -o /app/publish

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy build output
COPY --from=build /app/publish .

# Ensure dogs.json is copied (and available at runtime)
RUN mkdir -p ./Data
COPY Data/dogs.json ./Data/dogs.json

# Expose port 3000 for Render
ENV ASPNETCORE_URLS=http://+:3000
EXPOSE 3000

ENTRYPOINT ["dotnet", "DogsBreed-API.dll"]
