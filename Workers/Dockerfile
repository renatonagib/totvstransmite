FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

RUN mkdir /app

WORKDIR /app

COPY Workers.csproj .

RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o dist

CMD ["dotnet", "dist/Workers.dll"]