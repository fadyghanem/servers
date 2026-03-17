# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj and restore first (faster + more reliable)
COPY *.csproj ./
RUN dotnet restore

# copy everything else
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

# IMPORTANT for Render
ENV ASPNETCORE_URLS=http://+:$PORT

ENTRYPOINT ["dotnet", "TaskApi.dll"]