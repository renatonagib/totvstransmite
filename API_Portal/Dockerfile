FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

RUN mkdir /app

WORKDIR /app

COPY API_Portal.csproj .

RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o dist

EXPOSE 80/tcp

CMD ["dotnet", "dist/API_Portal.dll"]

