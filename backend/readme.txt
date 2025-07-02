/backend/
├── MyProject.API/                 # Web API вхідна точка (Controllers, Middlewares)
│   ├── Controllers/
│   ├── Middleware/
│   ├── Program.cs
│   └── appsettings.json
│
├── MyProject.Application/         # Бізнес-логіка (DTOs, Interfaces, Services)
│   ├── Interfaces/
│   ├── DTOs/
│   └── Services/
│
├── MyProject.Infrastructure/      # Реалізація інтерфейсів (EF Core, Redis, External APIs)
│   ├── Data/
│   │   ├── MyDbContext.cs
│   │   └── Migrations/
│   ├── Repositories/
│   └── Redis/
│
├── MyProject.Domain/              # Сутності, enum-и, правила (core-логіка)
│   ├── Entities/
│   └── Enums/
│
├── MyProject.Tests/               # Тести (xUnit + Moq)
│   └── Services/
│
├── docker-compose.yml
├── MyProject.sln
└── README.md