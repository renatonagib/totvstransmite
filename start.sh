#!/bin/bash
echo "===========================Derrubando servicos=========================================="
docker-compose down -v
echo "===========================Realizando Building das aplicações============================"
docker-compose build
echo "===========================inicializando aplicações======================================"
docker-compose up -d
echo "================ Definindo variáveis de ambiente========================================="
export DBHOST=localhost
echo "================Preparando scripts para atualziação da base de dados====================="
cd Workers
dotnet ef migrations add upd1
echo "================Aplicando atualizações na base de dados=================================="
dotnet ef database update