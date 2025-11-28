# MinhaApp — APS2 (Clean Architecture + DDD)

Este repositório contém a aplicação de exemplo desenvolvida para a APS2: Clean Architecture, DDD, EF Core (SQL Server), Mapster, validações customizadas, e busca Ajax.

Resumo rápido
- Camadas: Domain, Application, Infrastructure, Api
- Mapster para mapeamento (configurado em `src/MinhaApp.Application/Mapping/AutoMapperProfile.cs`)
- EF Core com Migrations (migrations geradas em `src/MinhaApp.Infrastructure/Persistence/Migrations`)
- Busca Ajax em `Views/Categoria/Index.cshtml` (`/api/categoria/search`)

Como rodar (dev) — passos mínimos

1) Subir o SQL Server (Docker)

```bash
docker compose -f MinhaApp/docker-compose.yml up -d
```

2) Instalar `dotnet-ef` (se necessário)

```bash
export PATH="$PATH:$HOME/.dotnet/tools"
dotnet tool install --global dotnet-ef --version 8.0.0
```

3) Aplicar migrations (opcional — já apliquei no ambiente de desenvolvimento)

```bash
dotnet ef database update -p src/MinhaApp.Infrastructure -s src/MinhaApp.Api
```

4) Rodar a API

```bash
dotnet run --project src/MinhaApp.Api/MinhaApp.Api.csproj --no-launch-profile --urls "http://localhost:5000"
```

5) Testar a busca Ajax
- Acesse `http://localhost:5000/Categoria` e use a caixa de busca; ou faça um curl:

```bash
curl "http://localhost:5000/api/categoria/search?q=Exemplo"
```

Rodando testes

```bash
dotnet build MinhaApp.sln
dotnet test MinhaApp.sln
```

Alterações importantes realizadas
- Adicionado CRUD mínimo para `Produto` (controller + views + serviço + repositório)
- Registrado `ProdutoRepository` e `ProdutoAppService` no DI
- Migration inicial gerada e aplicada em container SQL Server
- Vários ajustes em testes para garantir execução automatizada

Notas
- A seed de desenvolvimento foi adicionada em `Startup.Configure` (apenas para dev).
- Ajustes de conexão em `appsettings.json` com `TrustServerCertificate=True;Encrypt=False` são apenas para desenvolvimento local no container.

