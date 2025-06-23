# API CRUD de Clientes

 Este projeto é uma API feita em ASP.NET Core para gerenciar clientes e seus endereços, usando boas práticas de organização de código.

## O que você pode fazer
- Cadastrar, consultar, atualizar e remover clientes
- Cada cliente tem: nome, e-mail (único), telefone (opcional) e endereço completo

## Como rodar
1. Tenha o .NET 6 ou superior instalado
2. Baixe o projeto e entre na pasta `ApiCrudClientes`
3. No terminal, rode:
   ```bash
   dotnet restore
   dotnet run
   ```
4. Abra o navegador em [http://localhost:5072/swagger](http://localhost:5072/swagger) para testar os endpoints

## Exemplos de JSON para testes

### Cadastro de um cliente (POST /api/clientes)
```json
{
  "nome": "Maria Silva",
  "email": "maria@email.com",
  "telefone": "11999999999",
  "endereco": {
    "rua": "Rua das Flores",
    "numero": "123",
    "cidade": "São Paulo",
    "estado": "SP",
    "cep": "01000-000"
  }
}
```

### Cadastro de vários clientes (array para testes em massa)
```json
[
  {
    "nome": "João Souza",
    "email": "joao@email.com",
    "telefone": "11988888888",
    "endereco": {
      "rua": "Rua A",
      "numero": "10",
      "cidade": "Campinas",
      "estado": "SP",
      "cep": "13000-000"
    }
  },
  {
    "nome": "Ana Lima",
    "email": "ana@email.com",
    "telefone": "11977777777",
    "endereco": {
      "rua": "Rua B",
      "numero": "20",
      "cidade": "Ribeirão Preto",
      "estado": "SP",
      "cep": "14000-000"
    }
  }
]
```

## Observações
- O banco é em memória: os dados somem ao parar a aplicação
- As validações (campos obrigatórios, e-mail único) já estão prontas
