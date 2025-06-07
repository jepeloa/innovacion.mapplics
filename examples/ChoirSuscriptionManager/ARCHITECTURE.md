# Arquitectura del Sistema - Gestión de Suscripciones para Coro

## Visión General

El sistema está diseñado siguiendo una **arquitectura en capas (Layered Architecture)** que promueve la separación de responsabilidades y facilita el mantenimiento y testing del código.

## Estructura de Capas

### 1. Capa de Presentación (Presentation Layer)
**Proyecto**: `ChoirSubscriptionManager.Web`

```
Controllers/          # Controladores MVC
├── HomeController.cs
├── MembersController.cs
├── SubscriptionsController.cs
└── ReportsController.cs

Views/               # Vistas Razor
├── Home/
├── Members/
├── Subscriptions/
└── Shared/

Models/              # ViewModels
├── MemberViewModel.cs
├── SubscriptionViewModel.cs
└── DashboardViewModel.cs
```

**Responsabilidades**:
- Manejo de peticiones HTTP
- Presentación de datos al usuario
- Validación de entrada
- Navegación y routing

### 2. Capa de Lógica de Negocio (Business Layer)
**Proyecto**: `ChoirSubscriptionManager.Core`

```
Services/            # Servicios de negocio
├── IMemberService.cs
├── MemberService.cs
├── ISubscriptionService.cs
├── SubscriptionService.cs
├── IPaymentService.cs
└── PaymentService.cs

Models/              # Modelos de dominio
├── Member.cs
├── Subscription.cs
├── Payment.cs
└── SubscriptionStatus.cs

Interfaces/          # Contratos de servicios
├── IUnitOfWork.cs
└── IRepository.cs
```

**Responsabilidades**:
- Implementación de reglas de negocio
- Validación de datos
- Coordinación entre diferentes entidades
- Transformación de datos

### 3. Capa de Acceso a Datos (Data Access Layer)
**Proyecto**: `ChoirSubscriptionManager.Data`

```
Context/             # Contexto de Entity Framework
└── ChoirDbContext.cs

Repositories/        # Implementación de repositorios
├── Repository.cs
├── MemberRepository.cs
├── SubscriptionRepository.cs
└── PaymentRepository.cs

Configurations/      # Configuraciones de EF
├── MemberConfiguration.cs
├── SubscriptionConfiguration.cs
└── PaymentConfiguration.cs

Migrations/          # Migraciones de base de datos
```

**Responsabilidades**:
- Acceso a la base de datos
- Mapeo objeto-relacional
- Implementación de consultas
- Gestión de transacciones

### 4. Capa de Modelos Compartidos (Shared Layer)
**Proyecto**: `ChoirSubscriptionManager.Shared`

```
DTOs/                # Data Transfer Objects
├── MemberDto.cs
├── SubscriptionDto.cs
└── PaymentDto.cs

Enums/               # Enumeraciones
├── SubscriptionType.cs
├── PaymentStatus.cs
└── MemberRole.cs

Constants/           # Constantes del sistema
└── AppConstants.cs
```

## Patrones de Diseño Implementados

### 1. Repository Pattern
```csharp
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
```

**Beneficios**:
- Abstrae el acceso a datos
- Facilita el testing con mocks
- Centraliza la lógica de consultas

### 2. Unit of Work Pattern
```csharp
public interface IUnitOfWork : IDisposable
{
    IMemberRepository Members { get; }
    ISubscriptionRepository Subscriptions { get; }
    IPaymentRepository Payments { get; }
    Task<int> SaveChangesAsync();
}
```

**Beneficios**:
- Garantiza consistencia transaccional
- Reduce el número de conexiones a BD
- Simplifica el manejo de transacciones

### 3. Dependency Injection
```csharp
// Program.cs
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
```

**Beneficios**:
- Bajo acoplamiento
- Facilita el testing
- Mejora la mantenibilidad

## Modelo de Datos

### Entidades Principales

#### Member (Miembro)
```csharp
public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime JoinDate { get; set; }
    public bool IsActive { get; set; }
    
    // Relaciones
    public ICollection<Subscription> Subscriptions { get; set; }
}
```

#### Subscription (Suscripción)
```csharp
public class Subscription
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal MonthlyFee { get; set; }
    public SubscriptionStatus Status { get; set; }
    
    // Relaciones
    public Member Member { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
```

#### Payment (Pago)
```csharp
public class Payment
{
    public int Id { get; set; }
    public int SubscriptionId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; }
    public string PaymentMethod { get; set; }
    
    // Relaciones
    public Subscription Subscription { get; set; }
}
```

### Relaciones entre Entidades

```
Member (1) -----> (N) Subscription (1) -----> (N) Payment
```

- Un miembro puede tener múltiples suscripciones
- Una suscripción pertenece a un miembro
- Una suscripción puede tener múltiples pagos
- Un pago pertenece a una suscripción

## Flujo de Datos

### 1. Flujo de Consulta (Query Flow)
```
Usuario → Controller → Service → Repository → DbContext → Base de Datos
```

### 2. Flujo de Comando (Command Flow)
```
Usuario → Controller → Service → UnitOfWork → Repository → DbContext → Base de Datos
```

## Configuración de Entity Framework

### DbContext
```csharp
public class ChoirDbContext : DbContext
{
    public DbSet<Member> Members { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
```

### Configuraciones de Entidades
```csharp
public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(m => m.LastName).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Email).IsRequired().HasMaxLength(100);
        
        builder.HasMany(m => m.Subscriptions)
               .WithOne(s => s.Member)
               .HasForeignKey(s => s.MemberId);
    }
}
```

## Consideraciones de Seguridad

### 1. Validación de Datos
- Validación en el cliente (JavaScript)
- Validación en el servidor (Data Annotations)
- Validación de negocio (Services)

### 2. Protección contra Ataques
- CSRF Protection (Anti-forgery tokens)
- SQL Injection Prevention (EF Core + Parameterized queries)
- XSS Prevention (HTML encoding)

### 3. Autenticación y Autorización
- ASP.NET Core Identity
- Role-based authorization
- JWT tokens (para APIs futuras)

## Escalabilidad y Rendimiento

### 1. Estrategias de Caching
```csharp
// Memory Cache para datos frecuentemente consultados
services.AddMemoryCache();

// Distributed Cache para entornos multi-servidor
services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});
```

### 2. Optimización de Consultas
- Uso de `Include()` para eager loading
- Proyecciones con `Select()` para reducir datos
- Paginación para listados grandes

### 3. Async/Await
- Todas las operaciones de I/O son asíncronas
- Mejora la escalabilidad de la aplicación

## Testing Strategy

### 1. Unit Tests
- Servicios de negocio
- Repositorios (con InMemory database)
- Controladores (con mocks)

### 2. Integration Tests
- Flujos completos de la aplicación
- Base de datos real en memoria
- Testing de APIs

### 3. Herramientas
- xUnit para framework de testing
- Moq para mocking
- FluentAssertions para assertions más legibles

## Próximas Mejoras

### Fase 2: Funcionalidades Avanzadas
- Notificaciones por email
- Reportes en PDF
- Dashboard con gráficos
- Importación/Exportación de datos

### Fase 3: Tecnologías Adicionales
- SignalR para notificaciones en tiempo real
- API REST para aplicaciones móviles
- Microservicios architecture
- Docker containerization

## Conclusión

Esta arquitectura proporciona una base sólida para el aprendizaje de .NET Core, implementando las mejores prácticas y patrones de diseño más utilizados en la industria. La separación clara de responsabilidades facilita el mantenimiento, testing y escalabilidad de la aplicación.