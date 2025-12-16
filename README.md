# 🚀 Nome do Seu Projeto

> Uma API robusta desenvolvida para demonstrar a aplicação de padrões avançados de arquitetura em .NET 8.

![Status do Projeto](https://img.shields.io/badge/STATUS-FINALIZADO-green) ![.NET](https://img.shields.io/badge/.NET-8.0-purple)

## 🎯 Objetivo
Este projeto foi desenvolvido como um laboratório prático para consolidar conhecimentos em arquitetura de software, focando na separação de responsabilidades (CQRS) e performance de banco de dados (abordagem híbrida EF Core + Dapper).

## 🏗️ Arquitetura e Design Patterns
O projeto segue os princípios do **DDD (Domain-Driven Design)**:

* **API Layer:** Pontos de entrada RESTful.
* **Application Layer:** Casos de uso orquestrados via **MediatR** (CQRS).
* **Domain Layer:** Entidades, Value Objects e Regras de Negócio puras.
* **Infrastructure Layer:** Persistência de dados e integrações externas.

### Por que EF Core *e* Dapper?
Utilizei uma abordagem híbrida para obter o melhor dos dois mundos:
1.  **EF Core (Commands):** Para operações de escrita (INSERT, UPDATE, DELETE), garantindo integridade e facilidade no mapeamento de entidades complexas.
2.  **Dapper (Queries):** Para operações de leitura (SELECT), focado em performance bruta e baixo overhead de memória.

## 🛠️ Tecnologias
* **Core:** .NET 8, C#
* **Persistência:** Entity Framework Core (Writes), Dapper (Reads)
* **Orquestração:** MediatR (Padrão Mediator)
* **Mapeamento:** AutoMapper
* **Banco de Dados:** SQL Server (ou o que você usou)

## ⚙️ Como Executar
1. Clone o repositório.
2. Configure a `ConnectionString` no `appsettings.json`.
3. Execute as migrações: `dotnet ef database update`.
4. Rode a aplicação: `dotnet run`.
