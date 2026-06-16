# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar archivos de solución
COPY *.sln .
COPY Lab13-HenryVentura/Lab13-HenryVentura.csproj Lab13-HenryVentura/
COPY Lab13-HenryVentura.Domain/Lab13-HenryVentura.Domain.csproj Lab13-HenryVentura.Domain/
COPY Lab13-HenryVentura.Application/Lab13-HenryVentura.Application.csproj Lab13-HenryVentura.Application/
COPY Lab13-HenryVentura.Infrastructure/Lab13-HenryVentura.Infrastructure.csproj Lab13-HenryVentura.Infrastructure/

# Restaurar dependencias
RUN dotnet restore

# Copiar todo el código
COPY . .

# Publicar
RUN dotnet publish Lab13-HenryVentura/Lab13-HenryVentura.csproj -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Lab13-HenryVentura.dll"]