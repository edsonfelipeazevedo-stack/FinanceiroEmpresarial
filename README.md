# FinanceiroEmpresarial

Sistema de gestão financeira empresarial desenvolvido em **.NET 8**, com API REST, integração a banco de dados SQL Server, e suporte a cadastro de categorias e transações.

## 📋 Sumário
1. [Visão Geral](#-visão-geral)  
2. [Pré-requisitos](#-pré-requisitos)  
3. [Instalação](#-instalação)  
4. [Configuração](#-configuração)  
5. [Execução](#-execução)  
6. [Testes](#-testes)  
7. [Endpoints da API](#-endpoints-da-api)  
8. [Próximos Passos](#-próximos-passos)  
9. [Contribuição](#-contribuição)  
10. [Licença](#-licença)  

---

## 📖 Visão Geral
O **FinanceiroEmpresarial** é um sistema modular para controle de finanças empresariais, permitindo:  
- Cadastro e gerenciamento de **categorias**.  
- Registro e consulta de **transações** (receitas e despesas).  
- Relatórios por categoria.  
- Integração com **SQL Server**.  

---

## 🛠 Pré-requisitos
Certifique-se de ter instalado:
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)  
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)  
- [SQL Server 2019+](https://www.microsoft.com/sql-server) e **SQL Server Management Studio (SSMS)**  
- [Postman](https://www.postman.com/) para testes de API  

---

## 📥 Instalação
```bash
# Clonar o repositório
git clone https://github.com/seuusuario/FinanceiroEmpresarial.git

# Acessar a pasta do projeto
cd FinanceiroEmpresarial

# Restaurar pacotes
dotnet restore
```

---

## ⚙ Configuração
1. No arquivo **appsettings.json**, configure a string de conexão:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=FinanceiroEmpresarialDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

2. Executar as migrações do banco:
```bash
dotnet ef database update
```

---

## 🚀 Execução
Para rodar a aplicação:
```bash
dotnet run --project FinanceiroEmpresarial.API
```
A API estará disponível em:  
```
https://localhost:7278
```


---

## 📡 Endpoints da API

### Categorias
- **GET** `/api/categorias` → Lista todas as categorias.  
- **POST** `/api/categorias` → Cria uma nova categoria.  
  ```json
  {
    "nome": "Alimentação",
    "tipo": "Despesa"
  }
  ```

### Transações
- **GET** `/api/transacoes` → Lista todas as transações.  
- **POST** `/api/transacoes` → Cria uma nova transação.  
  ```json
  {
    "descricao": "Compra de materiais",
    "valor": 250.00,
    "data": "2025-08-13",
    "categoriaId": 1
  }
  ```