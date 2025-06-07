# Sistema de Gestión de Suscripciones para Coro

## Descripción del Proyecto

Una aplicación web desarrollada en .NET Core para gestionar las suscripciones mensuales de los miembros de un coro. Este proyecto está diseñado como una herramienta de aprendizaje para dominar los conceptos fundamentales de .NET Core, Entity Framework y desarrollo web moderno.

## Características Principales

- ✅ Gestión de miembros del coro
- ✅ Control de suscripciones mensuales
- ✅ Seguimiento de pagos
- ✅ Dashboard con estadísticas
- ✅ Reportes de membresía
- ✅ Interfaz web responsive

## Tecnologías Utilizadas

- **Backend**: .NET 8 (LTS)
- **Base de Datos**: SQLite (desarrollo) / SQL Server (producción)
- **ORM**: Entity Framework Core
- **Frontend**: ASP.NET Core MVC + Bootstrap
- **Autenticación**: ASP.NET Core Identity
- **Testing**: xUnit + Moq

## Requisitos del Sistema

### Desarrollo
- .NET 8 SDK
- Visual Studio Code o Visual Studio 2022
- SQLite (incluido con .NET)

### Producción
- .NET 8 Runtime
- SQL Server 2019+ (opcional)

## Guía de Instalación

### 1. Clonar el Repositorio
```bash
git clone [tu-repositorio]
cd choir-subscription-manager
```

### 2. Instalar .NET 8 SDK
```bash
# Ubuntu/Debian
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0

# Verificar instalación
dotnet --version
```

### 3. Restaurar Dependencias
```bash
dotnet restore
```

### 4. Configurar Base de Datos
```bash
# Crear migración inicial
dotnet ef migrations add InitialCreate

# Aplicar migración
dotnet ef database update
```

### 5. Ejecutar la Aplicación
```bash
dotnet run
```

La aplicación estará disponible en: `https://localhost:5001`

## Estructura del Proyecto

```
ChoirSubscriptionManager/
├── src/
│   ├── ChoirSubscriptionManager.Web/          # Aplicación web principal
│   ├── ChoirSubscriptionManager.Core/         # Lógica de negocio
│   ├── ChoirSubscriptionManager.Data/         # Acceso a datos
│   └── ChoirSubscriptionManager.Shared/       # Modelos compartidos
├── tests/
│   ├── ChoirSubscriptionManager.Tests/        # Pruebas unitarias
│   └── ChoirSubscriptionManager.IntegrationTests/
├── docs/                                      # Documentación
└── scripts/                                   # Scripts de utilidad
```

## Comandos Útiles

### Desarrollo
```bash
# Ejecutar en modo desarrollo
dotnet run --project src/ChoirSubscriptionManager.Web

# Ejecutar pruebas
dotnet test

# Crear nueva migración
dotnet ef migrations add [NombreMigracion] --project src/ChoirSubscriptionManager.Data

# Actualizar base de datos
dotnet ef database update --project src/ChoirSubscriptionManager.Data
```

### Base de Datos
```bash
# Ver migraciones pendientes
dotnet ef migrations list

# Revertir migración
dotnet ef database update [MigracionAnterior]

# Generar script SQL
dotnet ef migrations script
```

## Configuración

### appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=choir_subscriptions.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

## Conceptos de Aprendizaje

Este proyecto te permitirá aprender:

1. **Arquitectura en Capas**
   - Separación de responsabilidades
   - Inversión de dependencias
   - Patrón Repository

2. **Entity Framework Core**
   - Code First
   - Migraciones
   - Relaciones entre entidades
   - LINQ

3. **ASP.NET Core MVC**
   - Controladores
   - Vistas Razor
   - Modelos de Vista
   - Validación

4. **Mejores Prácticas**
   - Inyección de dependencias
   - Manejo de errores
   - Logging
   - Testing

## Próximos Pasos

1. ✅ Configurar entorno de desarrollo
2. ⏳ Crear estructura de proyecto
3. ⏳ Implementar modelos de datos
4. ⏳ Configurar Entity Framework
5. ⏳ Crear controladores básicos
6. ⏳ Implementar vistas
7. ⏳ Agregar funcionalidades avanzadas

## Contribución

Este es un proyecto de aprendizaje. Si encuentras errores o mejoras, no dudes en crear un issue o pull request.

## Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.