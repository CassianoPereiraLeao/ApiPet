# ApiPet – API de Doação de Animais

Esta API foi desenvolvida para facilitar o processo de adoção de animais, permitindo o cadastro de animais disponíveis para adoção e a gestão de informações relacionadas.

## 🛠️ Requisitos

- .NET 9.0+
- BCrypt.Net-Next
- Microsoft.AspNetCore.OpenApi v9.0.7
- Microsoft.EntityFrameworkCore v9.0.8
- Microsoft.EntityFrameworkCore.Design v9.0.8
- Microsoft.EntityFrameworkCore.Tools v9.0.8
- Microsoft.EntityFrameworkCore.Sqlite.Core v9.0.8
- SQLitePCLRaw.bundle_e_sqlite3

## 📦 Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/CassianoPereiraLeao/ApiPet.git
   cd ApiPet


2. Restaure as dependências:

    ```bash
    dotnet restore


3. Aplique as migrações para configurar o banco de dados:

    ```bash
    dotnet ef database update


4. Inicie a aplicação:

    ```bash
    dotnet run


A API estará disponível em https://localhost:5001.

🧪 Testes

Para rodar os testes automatizados:

dotnet test

📄 Documentação da API

A documentação interativa da API pode ser acessada através do Swagger:

https://localhost:5001/swagger

🔐 Segurança

A API utiliza autenticação baseada em tokens JWT para proteger os endpoints. Certifique-se de incluir o token no cabeçalho Authorization das requisições:

Authorization: Bearer <seu_token_aqui>

🧩 Estrutura do Projeto

Domain: Contém as entidades principais do sistema.

Infra: Implementações específicas de infraestrutura, como acesso ao banco de dados.

Migrations: Scripts de migração do Entity Framework.

OwnedTypes: Tipos de valor compartilhados entre entidades.

Results: Tipos de resposta padronizados para as APIs.

Routes: Definições de rotas da API.

Token: Lógica relacionada à geração e validação de tokens JWT.