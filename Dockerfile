FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /app

RUN dotnet tool install --global dotnet-ef