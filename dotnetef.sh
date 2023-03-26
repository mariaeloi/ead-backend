#!/bin/bash
echo "Executando dotnet restore"
dotnet restore

echo "Instalando o dotnet-ef cli"
dotnet tool install --global dotnet-ef
export PATH="$PATH:/root/.dotnet/tools"

echo "Criando banco de dados, caso não exista"
cd Infra
dotnet ef -v --startup-project ../Api database update

echo "Iniciando a aplicação"
cd ..
dotnet dev-certs https
dotnet dev-certs https --trust
cd Api
dotnet run