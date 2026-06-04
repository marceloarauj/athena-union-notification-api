# Athena Union Notification

Microsserviço de notificações da plataforma Athena Students Union, responsável por receber eventos dos demais serviços e entregar notificações em tempo real aos usuários.

## Visão geral

Serviço event-driven que consome eventos publicados via RabbitMQ (Identity, Institution) e os entrega como notificações push através de SignalR. Não faz chamadas HTTP síncronas de volta aos outros serviços — toda comunicação é assíncrona.

## Funcionalidades

- **Consumo de eventos** via MassTransit + RabbitMQ
- **Entrega em tempo real** via SignalR Hub para clientes conectados
- **Persistência** de notificações em PostgreSQL com Unit of Work
- **Publicação desacoplada** — `INotificationPublisher` abstrai o canal de entrega (Hub ou outro)

## Stack

| Camada | Tecnologia |
|---|---|
| Framework | ASP.NET Core 10 |
| Mensageria | MassTransit 9 + RabbitMQ |
| Tempo real | SignalR |
| Banco de dados | PostgreSQL (porta 5432) |
| ORM | EF Core 10 |
| CQRS | MediatR (este serviço usa MediatR, não o Mediator customizado) |

## Estrutura

```
Notification/                  # Controllers, Program.cs
Notification.Application/      # Commands, Handlers, Interfaces
Notification.Domain/           # Entidades de notificação
Notification.Infrastructure/   # Consumers MassTransit, Hub SignalR, repositórios
Tests/                         # Testes de integração
```

## Repositórios relacionados

| Serviço | Repositório |
|---|---|
| Frontend | [athena-students-union-front](https://github.com/marceloarauj/athena-students-union-front) |
| Identidade (publisher) | [athena-identity](https://github.com/marceloarauj/athena-identity) |
| Escola / Turmas (publisher) | [athena-institution-service](https://github.com/marceloarauj/athena-institution-service) |
| Biblioteca compartilhada | [AthenaUnionLibrary](https://github.com/marceloarauj/AthenaUnionLibrary) |
