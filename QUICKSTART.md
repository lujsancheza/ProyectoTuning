# 🚀 Guía de Inicio Rápido - Turning Clean Architecture

## Verificación e Instalación Rápida

### 1️⃣ Verificar .NET está instalado
```powershell
dotnet --version
```
Debe ser .NET 10 o superior.

### 2️⃣ Restaurar dependencias
```powershell
cd c:\Users\leona\source\repos\Epistech\Test de Turing
dotnet restore turning.sln
```

### 3️⃣ Compilar la solución
```powershell
dotnet build turning.sln
```

### 4️⃣ Ejecutar la API
```powershell
dotnet run --project src\turning.API\turning.API.csproj
```

### 5️⃣ Probar health check
Abrir en navegador:
```
https://localhost:7001/api/health
```

O con PowerShell:
```powershell
Invoke-RestMethod -Uri "https://localhost:7001/api/health" -SkipCertificateCheck
```

### 6️⃣ Ver Swagger
```
https://localhost:7001/swagger
```

## 🧪 Ejecutar Pruebas

```powershell
# Todas las pruebas
dotnet test turning.sln

# Solo Domain Tests
dotnet test tests\turning.Domain.Tests\turning.Domain.Tests.csproj -v normal

# Solo Application Tests
dotnet test tests\turning.Application.Tests\turning.Application.Tests.csproj -v normal

# Con detalle
dotnet test turning.sln --logger "console;verbosity=detailed"
```

## 📁 Estructura de Carpetas

```
turning/
├── src/
│   ├── turning.Domain/                        ← Entidades, Reglas de Negocio
│   ├── turning.Application/                   ← Casos de Uso, DTOs
│   ├── turning.Infrastructure/                ← Repositorios, Persistencia
│   └── turning.API/                           ← Endpoints, Controllers
├── tests/
│   ├── turning.Domain.Tests/
│   ├── turning.Application.Tests/
│   └── turning.Infrastructure.Tests/
├── turning.sln
└── ARCHITECTURE.md                            ← Lee esto para entender la arquitectura
```

## 🔧 Proyectos Creados

| Proyecto | Tipo | Propósito |
|----------|------|----------|
| turning.Domain | Library | Lógica de negocio pura |
| turning.Application | Library | Orquestación de casos de uso |
| turning.Infrastructure | Library | Implementaciones concretas |
| turning.API | Web API | Punto de entrada REST |
| turning.Domain.Tests | Test | Pruebas del dominio |
| turning.Application.Tests | Test | Pruebas de aplicación |
| turning.Infrastructure.Tests | Test | Pruebas de integración |

## 🎬 Primer Use Case

### Crear una entidad Sample
```csharp
var sample = SampleEntity.Create("Mi Entidad", "Descripción");
```

### Usar el repositorio
```csharp
var repository = new InMemorySampleRepository();
await repository.AddAsync(sample);
var retrieved = await repository.GetByIdAsync(sample.Id);
```

## 📦 Dependencias Principales

```xml
<!-- Application -->
<PackageReference Include="FluentValidation" Version="11.9.2" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="10.0.0" />

<!-- Infrastructure -->
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.0" />

<!-- API -->
<PackageReference Include="Swashbuckle.AspNetCore" Version="7.4.0" />
<PackageReference Include="Serilog.AspNetCore" Version="8.0.0" />

<!-- Testing -->
<PackageReference Include="xunit" Version="2.8.1" />
<PackageReference Include="FluentAssertions" Version="6.12.0" />
<PackageReference Include="Moq" Version="4.20.70" />
```

## 🎯 Próximos Cambios Recomendados

1. **Implementar persistencia real** → Entity Framework Core
2. **Agregar autenticación** → JWT
3. **Crear features adicionales** → Seguir el patrón de Sample
4. **Configurar CI/CD** → GitHub Actions, Azure DevOps
5. **Containerizar** → Docker

## ❓ Comandos Útiles

```powershell
# Limpiar compilaciones previas
dotnet clean turning.sln

# Actualizar dependencias
dotnet restore turning.sln --no-cache

# Publicar release
dotnet publish src\turning.API\turning.API.csproj -c Release -o ./publish

# Crear migraciones (cuando uses EF Core)
dotnet ef migrations add InitialCreate --project src\turning.Infrastructure --startup-project src\turning.API
```

## 📞 Soporte

Lee **ARCHITECTURE.md** para entender mejor la estructura y principios aplicados.

---
**¡Listo para desarrollar con Clean Architecture! 🎉**
