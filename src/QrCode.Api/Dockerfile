FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY src/QrCode.Api/QrCode.Api.csproj ./QrCode.Api/
RUN dotnet restore ./QrCode.Api/QrCode.Api.csproj

COPY src/QrCode.Api/. ./QrCode.Api/

WORKDIR /app/QrCode.Api
RUN dotnet publish -c Release -o /app/out /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "QrCode.Api.dll"]