# Documentação api doação de animais

## Requisitos da api
- .NET 9.0+
- BCrypt.Net-Next
- Microsoft.AspNetCore.OpenApi v9.0.7
- Microsoft.EntityFrameworkCore v9.0.8
- Microsoft.EntityFrameworkCore.Design v9.0.8
- Microsoft.EntityFrameworkCore.Tools v9.0.8
- Microsoft.EntityFrameworkCore.Sqlite.Core v9.0.8
- SQLitePCLRaw.bundle_e_sqlite3 v3.0.1
- Swashbuckle.AspNetCore v9.0.3

## Explicações rápidas
- OwnedTypes: Pasta onde eu guardo meu tipos próprios para validação
- Results: Usado para o Task<Result> para melhor retorno
- Domain: Todas as informações que vierem do front ou do back passarão por alterações aqui
- Infra: Todas as comunicações com o banco de dados serão controladas por aqui
- Routes: Controle das rotas para melhor visualização
- Migrations: Migrações feitas pelo entity framework