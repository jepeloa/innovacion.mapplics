# Guía de Configuración - Sistema de Gestión de Suscripciones para Coro

## Introducción

Esta guía te llevará paso a paso por todo el proceso de configuración del entorno de desarrollo para crear la aplicación de gestión de suscripciones del coro usando .NET Core.

---

## Paso 1: Verificar y Configurar el Sistema Base

### 1.1 Verificar Sistema Operativo
```bash
# Verificar versión de Ubuntu/Linux
lsb_release -a

# Actualizar sistema
sudo apt update && sudo apt upgrade -y
```

### 1.2 Instalar Dependencias Base
```bash
# Instalar curl y wget
sudo apt install curl wget -y

# Instalar Git (si no está instalado)
sudo apt install git -y

# Verificar Git
git --version
```

---

## Paso 2: Instalar .NET 8 SDK

### 2.1 Agregar Repositorio de Microsoft
```bash
# Descargar y instalar paquete de configuración de Microsoft
wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

# Instalar el paquete de configuración
sudo dpkg -i packages-microsoft-prod.deb

# Actualizar lista de paquetes
sudo apt update
```

### 2.2 Instalar .NET 8 SDK
```bash
# Instalar .NET 8 SDK
sudo apt install -y dotnet-sdk-8.0

# Verificar instalación
dotnet --version
# Debe mostrar algo como: 8.0.xxx

# Verificar información completa
dotnet --info
```

### 2.3 Configurar Variables de Entorno (Opcional)
```bash
# Agregar al archivo .bashrc o .zshrc
echo 'export DOTNET_ROOT=/usr/share/dotnet' >> ~/.bashrc
echo 'export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools' >> ~/.bashrc

# Recargar configuración
source ~/.bashrc
```

---

## Paso 3: Configurar Visual Studio Code

### 3.1 Instalar Visual Studio Code
```bash
# Descargar e instalar VS Code
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > packages.microsoft.gpg
sudo install -o root -g root -m 644 packages.microsoft.gpg /etc/apt/trusted.gpg.d/
sudo sh -c 'echo "deb [arch=amd64,arm64,armhf signed-by=/etc/apt/trusted.gpg.d/packages.microsoft.gpg] https://packages.microsoft.com/repos/code stable main" > /etc/apt/sources.list.d/vscode.list'

sudo apt update
sudo apt install code
```

### 3.2 Instalar Extensiones Esenciales
Abrir VS Code y instalar estas extensiones:

1. **C#** (Microsoft) - ID: ms-dotnettools.csharp
2. **C# Dev Kit** (Microsoft) - ID: ms-dotnettools.csdevkit
3. **IntelliCode for C# Dev Kit** - ID: ms-dotnettools.vscodeintellicode-csharp
4. **NuGet Package Manager** - ID: jmrog.vscode-nuget-package-manager
5. **Auto Rename Tag** - ID: formulahendry.auto-rename-tag
6. **Bracket Pair Colorizer** - ID: coenraads.bracket-pair-colorizer-2
7. **GitLens** - ID: eamodio.gitlens

### 3.3 Configurar VS Code para .NET
Crear archivo `.vscode/settings.json` en el directorio del proyecto:
```json
{
    "dotnet.completion.showCompletionItemsFromUnimportedNamespaces": true,
    "dotnet.codeLens.enableReferencesCodeLens": true,
    "omnisharp.enableEditorConfigSupport": true,
    "omnisharp.enableImportCompletion": true,
    "files.exclude": {
        "**/bin": true,
        "**/obj": true
    }
}
```

---

## Paso 4: Crear Estructura del Proyecto

### 4.1 Crear Directorio Base
```bash
# Navegar al directorio de proyectos
cd /home/javier/Proyectos/MAPPLICS/innovacion.mapplics

# Crear directorio del proyecto
mkdir ChoirSubscriptionManager
cd ChoirSubscriptionManager

# Inicializar Git
git init
```

### 4.2 Crear Estructura de Carpetas
```bash
# Crear estructura de directorios
mkdir -p src/ChoirSubscriptionManager.Web
mkdir -p src/ChoirSubscriptionManager.Core
mkdir -p src/ChoirSubscriptionManager.Data
mkdir -p src/ChoirSubscriptionManager.Shared
mkdir -p tests/ChoirSubscriptionManager.Tests
mkdir -p tests/ChoirSubscriptionManager.IntegrationTests
mkdir -p docs
mkdir -p scripts
```

### 4.3 Crear Archivo de Solución
```bash
# Crear archivo de solución
dotnet new sln -n ChoirSubscriptionManager

# La estructura debe verse así:
tree -L 3
```

---

## Paso 5: Crear Proyectos .NET

### 5.1 Crear Proyecto Web (ASP.NET Core MVC)
```bash
# Crear proyecto web
cd src/ChoirSubscriptionManager.Web
dotnet new mvc
cd ../..

# Agregar a la solución
dotnet sln add src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj
```

### 5.2 Crear Proyecto Core (Class Library)
```bash
# Crear proyecto de lógica de negocio
cd src/ChoirSubscriptionManager.Core
dotnet new classlib
cd ../..

# Agregar a la solución
dotnet sln add src/ChoirSubscriptionManager.Core/ChoirSubscriptionManager.Core.csproj
```

### 5.3 Crear Proyecto Data (Class Library)
```bash
# Crear proyecto de acceso a datos
cd src/ChoirSubscriptionManager.Data
dotnet new classlib
cd ../..

# Agregar a la solución
dotnet sln add src/ChoirSubscriptionManager.Data/ChoirSubscriptionManager.Data.csproj
```

### 5.4 Crear Proyecto Shared (Class Library)
```bash
# Crear proyecto de modelos compartidos
cd src/ChoirSubscriptionManager.Shared
dotnet new classlib
cd ../..

# Agregar a la solución
dotnet sln add src/ChoirSubscriptionManager.Shared/ChoirSubscriptionManager.Shared.csproj
```

### 5.5 Crear Proyectos de Testing
```bash
# Crear proyecto de unit tests
cd tests/ChoirSubscriptionManager.Tests
dotnet new xunit
cd ../..

# Crear proyecto de integration tests
cd tests/ChoirSubscriptionManager.IntegrationTests
dotnet new xunit
cd ../..

# Agregar a la solución
dotnet sln add tests/ChoirSubscriptionManager.Tests/ChoirSubscriptionManager.Tests.csproj
dotnet sln add tests/ChoirSubscriptionManager.IntegrationTests/ChoirSubscriptionManager.IntegrationTests.csproj
```

---

## Paso 6: Configurar Referencias entre Proyectos

### 6.1 Referencias del Proyecto Web
```bash
# Desde la raíz del proyecto
dotnet add src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj reference src/ChoirSubscriptionManager.Core/ChoirSubscriptionManager.Core.csproj

dotnet add src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj reference src/ChoirSubscriptionManager.Data/ChoirSubscriptionManager.Data.csproj

dotnet add src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj reference src/ChoirSubscriptionManager.Shared/ChoirSubscriptionManager.Shared.csproj
```

### 6.2 Referencias del Proyecto Core
```bash
dotnet add src/ChoirSubscriptionManager.Core/ChoirSubscriptionManager.Core.csproj reference src/ChoirSubscriptionManager.Shared/ChoirSubscriptionManager.Shared.csproj
```

### 6.3 Referencias del Proyecto Data
```bash
dotnet add src/ChoirSubscriptionManager.Data/ChoirSubscriptionManager.Data.csproj reference src/ChoirSubscriptionManager.Shared/ChoirSubscriptionManager.Shared.csproj
```

### 6.4 Referencias de Testing
```bash
# Unit Tests
dotnet add tests/ChoirSubscriptionManager.Tests/ChoirSubscriptionManager.Tests.csproj reference src/ChoirSubscriptionManager.Core/ChoirSubscriptionManager.Core.csproj

dotnet add tests/ChoirSubscriptionManager.Tests/ChoirSubscriptionManager.Tests.csproj reference src/ChoirSubscriptionManager.Data/ChoirSubscriptionManager.Data.csproj

# Integration Tests
dotnet add tests/ChoirSubscriptionManager.IntegrationTests/ChoirSubscriptionManager.IntegrationTests.csproj reference src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj
```

---

## Paso 7: Instalar Paquetes NuGet Necesarios

### 7.1 Paquetes para el Proyecto Web
```bash
# Entity Framework y base de datos
dotnet add src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj package Microsoft.EntityFrameworkCore.SqlServer
dotnet add src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj package Microsoft.EntityFrameworkCore.Sqlite
dotnet add src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj package Microsoft.EntityFrameworkCore.Tools

# AutoMapper
dotnet add src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj package AutoMapper.Extensions.Microsoft.DependencyInjection

# Serilog para logging
dotnet add src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj package Serilog.AspNetCore
dotnet add src/ChoirSubscriptionManager.Web/ChoirSubscriptionManager.Web.csproj package Serilog.Sinks.File
```

### 7.2 Paquetes para el Proyecto Data
```bash
# Entity Framework Core
dotnet add src/ChoirSubscriptionManager.Data/ChoirSubscriptionManager.Data.csproj package Microsoft.EntityFrameworkCore
dotnet add src/ChoirSubscriptionManager.Data/ChoirSubscriptionManager.Data.csproj package Microsoft.EntityFrameworkCore.SqlServer
dotnet add src/ChoirSubscriptionManager.Data/ChoirSubscriptionManager.Data.csproj package Microsoft.EntityFrameworkCore.Sqlite
```

### 7.3 Paquetes para Testing
```bash
# Paquetes para Unit Tests
dotnet add tests/ChoirSubscriptionManager.Tests/ChoirSubscriptionManager.Tests.csproj package Microsoft.EntityFrameworkCore.InMemory
dotnet add tests/ChoirSubscriptionManager.Tests/ChoirSubscriptionManager.Tests.csproj package Moq
dotnet add tests/ChoirSubscriptionManager.Tests/ChoirSubscriptionManager.Tests.csproj package FluentAssertions

# Paquetes para Integration Tests
dotnet add tests/ChoirSubscriptionManager.IntegrationTests/ChoirSubscriptionManager.IntegrationTests.csproj package Microsoft.AspNetCore.Mvc.Testing
dotnet add tests/ChoirSubscriptionManager.IntegrationTests/ChoirSubscriptionManager.IntegrationTests.csproj package Microsoft.EntityFrameworkCore.InMemory
```

---

## Paso 8: Verificar Configuración

### 8.1 Compilar Solución Completa
```bash
# Restaurar paquetes NuGet
dotnet restore

# Compilar toda la solución
dotnet build

# Verificar que no hay errores
echo "Si no hay errores, la configuración fue exitosa!"
```

### 8.2 Ejecutar Proyecto Web
```bash
# Navegar al proyecto web
cd src/ChoirSubscriptionManager.Web

# Ejecutar la aplicación
dotnet run

# Debe mostrar algo como:
# info: Microsoft.Hosting.Lifetime[14]
#       Now listening on: https://localhost:5001
#       Now listening on: http://localhost:5000
```

### 8.3 Verificar en el Navegador
- Abrir navegador y navegar a: `https://localhost:5001`
- Debe mostrar la página de inicio de ASP.NET Core MVC

---

## Paso 9: Configuración de Entity Framework

### 9.1 Instalar Entity Framework CLI Tools
```bash
# Instalar herramientas EF globalmente
dotnet tool install --global dotnet-ef

# Verificar instalación
dotnet ef --version
```

### 9.2 Configurar Connection String
Editar `src/ChoirSubscriptionManager.Web/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=choir_subscriptions.db",
    "SqlServerConnection": "Server=(localdb)\\mssqllocaldb;Database=ChoirSubscriptionManager;Trusted_Connection=true;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

---

## Paso 10: Configurar Git

### 10.1 Crear .gitignore
```bash
# Crear archivo .gitignore específico para .NET
cat > .gitignore << 'EOF'
# Build results
[Dd]ebug/
[Dd]ebugPublic/
[Rr]elease/
[Rr]eleases/
x64/
x86/
build/
bld/
[Bb]in/
[Oo]bj/

# Visual Studio temporary files
*.suo
*.user
*.userosscache
*.sln.docstates
*.userprefs

# Entity Framework
*.mdf
*.ldf
*.ndf

# SQLite database files
*.db
*.db-*

# Logs
logs/
*.log

# Runtime data
pids
*.pid
*.seed
*.pid.lock

# VS Code
.vscode/
!.vscode/settings.json
!.vscode/tasks.json
!.vscode/launch.json
!.vscode/extensions.json

# JetBrains IDEs
.idea/

# Node.js (si usas herramientas frontend)
node_modules/
npm-debug.log*

# OS generated files
.DS_Store
.DS_Store?
._*
.Spotlight-V100
.Trashes
ehthumbs.db
Thumbs.db
EOF
```

### 10.2 Configuración Inicial de Git
```bash
# Configurar Git (si no está configurado)
git config --global user.name "Tu Nombre"
git config --global user.email "tu.email@ejemplo.com"

# Agregar archivos al repositorio
git add .
git commit -m "Initial project setup with .NET Core structure"
```

---

## Paso 11: Crear Scripts de Utilidad

### 11.1 Script de Build
```bash
# Crear archivo scripts/build.sh
mkdir -p scripts
cat > scripts/build.sh << 'EOF'
#!/bin/bash
echo "🔧 Building Choir Subscription Manager..."

# Restore packages
echo "📦 Restoring NuGet packages..."
dotnet restore

# Build solution
echo "🏗️ Building solution..."
dotnet build --configuration Release

echo "✅ Build completed successfully!"
EOF

chmod +x scripts/build.sh
```

### 11.2 Script de Testing
```bash
# Crear archivo scripts/test.sh
cat > scripts/test.sh << 'EOF'
#!/bin/bash
echo "🧪 Running tests for Choir Subscription Manager..."

# Run unit tests
echo "🔬 Running unit tests..."
dotnet test tests/ChoirSubscriptionManager.Tests/

# Run integration tests
echo "🔗 Running integration tests..."
dotnet test tests/ChoirSubscriptionManager.IntegrationTests/

echo "✅ All tests completed!"
EOF

chmod +x scripts/test.sh
```

### 11.3 Script de Database Migration
```bash
# Crear archivo scripts/migrate.sh
cat > scripts/migrate.sh << 'EOF'
#!/bin/bash
echo "🗃️ Managing database migrations..."

if [ "$1" = "add" ] && [ -n "$2" ]; then
    echo "➕ Adding new migration: $2"
    dotnet ef migrations add $2 --project src/ChoirSubscriptionManager.Data --startup-project src/ChoirSubscriptionManager.Web
elif [ "$1" = "update" ]; then
    echo "🔄 Updating database..."
    dotnet ef database update --project src/ChoirSubscriptionManager.Data --startup-project src/ChoirSubscriptionManager.Web
elif [ "$1" = "list" ]; then
    echo "📋 Listing migrations..."
    dotnet ef migrations list --project src/ChoirSubscriptionManager.Data --startup-project src/ChoirSubscriptionManager.Web
else
    echo "Usage: ./migrate.sh [add|update|list] [migration_name]"
    echo "Examples:"
    echo "  ./migrate.sh add InitialCreate"
    echo "  ./migrate.sh update"
    echo "  ./migrate.sh list"
fi
EOF

chmod +x scripts/migrate.sh
```

---

## Paso 12: Verificación Final

### 12.1 Checklist de Configuración
Ejecuta los siguientes comandos para verificar que todo está configurado correctamente:

```bash
# ✅ Verificar .NET SDK
dotnet --version

# ✅ Verificar estructura del proyecto
ls -la src/

# ✅ Verificar que la solución compila
dotnet build

# ✅ Verificar que las herramientas EF funcionan
dotnet ef --version

# ✅ Verificar que el proyecto web se ejecuta
cd src/ChoirSubscriptionManager.Web
dotnet run --urls=http://localhost:5000 &
sleep 5
curl -s http://localhost:5000 > /dev/null && echo "✅ Web server is working!" || echo "❌ Web server failed"
pkill -f "dotnet run"
cd ../..
```

### 12.2 Estructura Final del Proyecto
```
ChoirSubscriptionManager/
├── src/
│   ├── ChoirSubscriptionManager.Web/       # ASP.NET Core MVC
│   ├── ChoirSubscriptionManager.Core/      # Business Logic
│   ├── ChoirSubscriptionManager.Data/      # Data Access
│   └── ChoirSubscriptionManager.Shared/    # Shared Models
├── tests/
│   ├── ChoirSubscriptionManager.Tests/     # Unit Tests
│   └── ChoirSubscriptionManager.IntegrationTests/
├── docs/                                   # Documentation
├── scripts/                                # Utility Scripts
├── ChoirSubscriptionManager.sln           # Solution File
├── .gitignore
└── README.md
```

---

## Próximos Pasos

¡Felicitaciones! Has configurado exitosamente tu entorno de desarrollo. Ahora puedes proceder con:

1. **Implementar los modelos de dominio** en `ChoirSubscriptionManager.Shared`
2. **Configurar Entity Framework** en `ChoirSubscriptionManager.Data`
3. **Crear servicios de negocio** en `ChoirSubscriptionManager.Core`
4. **Desarrollar controladores y vistas** en `ChoirSubscriptionManager.Web`

---

## Solución de Problemas Comunes

### Problema: "dotnet command not found"
**Solución**:
```bash
# Verificar PATH
echo $PATH | grep dotnet

# Si no está, agregar manualmente
export PATH=$PATH:/usr/share/dotnet
```

### Problema: Error al compilar por dependencias
**Solución**:
```bash
# Limpiar y restaurar
dotnet clean
dotnet restore
dotnet build
```

### Problema: Entity Framework tools no funcionan
**Solución**:
```bash
# Reinstalar herramientas EF
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
```

### Problema: Puerto 5001 ocupado
**Solución**:
```bash
# Usar puerto diferente
dotnet run --urls=http://localhost:8080
```

---

## Recursos Adicionales

- **Documentación Oficial de .NET**: https://docs.microsoft.com/dotnet/
- **ASP.NET Core Tutorials**: https://docs.microsoft.com/aspnet/core/tutorials/
- **Entity Framework Core**: https://docs.microsoft.com/ef/core/
- **C# Programming Guide**: https://docs.microsoft.com/dotnet/csharp/

¡Tu entorno de desarrollo está listo para comenzar a crear tu aplicación de gestión de suscripciones del coro!