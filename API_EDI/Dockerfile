FROM microsoft/dotnet:2.1-sdk

RUN mkdir /app

WORKDIR /app

COPY API_EDI.csproj .

RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o dist

EXPOSE 80/tcp

CMD ["dotnet", "dist/API_EDI.dll"]

