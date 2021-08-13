# Desafio Totvs

Desafio proposto pela Totvs para uma vaga de desenvolvedor back-end

## Descrição

Criar uma API Rest de cadastro de veículos para armazenar os veículos utilizados pela
empresa. O cadastro deverá conter os seguintes dados:
- Nome
- Marca
- Modelo
- Data de fabricação
- Consumo Médio de combustível dentro de cidade (KM/L)
- Consumo Médio de combustível em rodovias (KM/L)

Criar uma API para realizar o cálculo de previsão de gastos.
Deverá receber como parâmetro as seguintes informações:

- Preço da gasolina R$
- Total de km que será percorrido dentro da cidade
- Total de km que será percorrido em rodovias

O retorno deverá ser uma lista ranqueada dos veículos da empresa levando em
consideração o valor gasto com combustível.O retorno deverá ter os seguintes dados:

- Nome
- Marca
- Modelo
- Ano
- Quantidade de combustível gasto
- Valor total gasto com combustível
## Environment

Para rodar esse projeto é necessário ter instalado

- **.NET 5 SDK**
- **Docker**


## Start Backend Project

```
git clone https://github.com/maiconjobim/DesafioTotvs.git

cd DesafioTotvs

docker-compose up -d
```
