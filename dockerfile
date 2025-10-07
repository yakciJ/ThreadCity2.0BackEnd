# Stage 1: Build aplication
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ThreadCity2.0BackEnd.csproj", "./"]
RUN dotnet restore "ThreadCity2.0BackEnd.csproj"

COPY . .
WORKDIR "/src"

RUN dotnet build "ThreadCity2.0BackEnd.csproj" -c Release -o /app/build

# Stage 2: Publish application
FROM build AS publish
RUN dotnet publish "ThreadCity2.0BackEnd.csproj" -c Release -o /app/publish /p:UseAppHost=false

# stage 3: Create final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:${PORT}

# Expose port 8080.
# EXPOSE 8080

ENTRYPOINT ["dotnet", "ThreadCity2.0BackEnd.dll"]