# API - Calculadora de Juros
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/grecojoao/InterestCalculator/blob/master/LICENSE) 

## ⚡ Sobre o projeto

API Calculadora de juros é uma aplicação back-end desenvolvida para o cálculo de juros em memória.

A aplicação possui o Endpoint: "/calculajuros", que recebe por parâmetro o valor inicial e a quantidade de meses, calculando o valor final de juros através do cálculo de juros compostos.

````
valorFinal = valorInicial * ((1 + taxaJuros) ^ quantidadeMeses);
````



## :rocket: Tecnologias
- C#, ASP.NET Core(5.0)
- Docker

## :bomb: Implantação em produção
- [Microsoft Azure](https://interestcalculator.azurewebsites.net/swagger)

## 📝 Como executar o projeto
Pré-requisitos: 
- ASP.NET Core Runtime 5.0.6 ou 
- SDK 5.0.203(desenvolvimento)

````bash
# clonar o repositório
git clone https://github.com/grecojoao/InterestCalculator.git

# entrar na pasta da API
cd InterestCalculator/InterestCalculator.API

# executar o projeto
dotnet watch run
````

- Windows: Docker Desktop WSL 2
- Linux: Docker Desktop

````bash
# clonar a imagem docker
docker pull grecojoao/interestcalculatorapi

# executar a imagem docker
docker run grecojoao/interestcalculatorapi
````
