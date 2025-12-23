# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything else
COPY . ./

# Publish the app
RUN dotnet publish -c Release -o out

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy published output
COPY --from=build /app/out ./

# Render uses port 8080
EXPOSE 8080

# IMPORTANT: replace with your actual DLL name
ENTRYPOINT ["dotnet", "thinkBridgeASP.netproject.dll"]
