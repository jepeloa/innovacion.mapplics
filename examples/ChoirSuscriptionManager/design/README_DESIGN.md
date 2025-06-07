# Documentación de Diseño UI/UX - Polyphonia Hub
## Sistema de Gestión Financiera para el Coro Polyphonia

> **Proyecto**: Sistema de Gestión Financiera para el Coro Polyphonia
> **Contexto Real**: 58 integrantes, actividades colaborativas, gestión financiera simple
> **Inspiración Visual**: Harmony Hub (elementos visuales únicamente)
> **Paleta Predominante**: Blanco, Dorado y Negro
> **Stack Tecnológico**: ASP.NET Core MVC + Bootstrap + jQuery

---

## Descripción del Producto

**Polyphonia Hub** es una aplicación web diseñada específicamente para la gestión financiera del Coro Polyphonia, una agrupación coral de 58 integrantes que requiere un sistema simple y eficiente para administrar cuotas mensuales, gastos operativos y reportes financieros.

### Características Principales
- **Gestión de Cuotas**: Control de pagos mensuales de los 58 miembros
- **Control de Gastos**: Registro de gastos operativos del coro
- **Reportes Financieros**: Dashboard con métricas clave y reportes mensuales
- **Gestión de Miembros**: Administración básica de información de integrantes
- **Interfaz Simple**: Diseño intuitivo inspirado en Harmony Hub

---

## Índice de Documentación

### 📋 Documentos Principales

#### 1. `DESCRIPCION_DEL_CORO.md`
**Propósito**: Contexto real del Coro Polyphonia y sus necesidades específicas.

**Contenido**:
- Historia y características del coro
- Necesidades financieras específicas
- Perfiles de usuarios (directivos y miembros)
- Casos de uso reales

#### 2. `UI_DESCRIPTION.md` - Especificación Funcional Completa
**Propósito**: Descripción detallada de todas las funcionalidades y pantallas del sistema.

**Contenido**:
- Dashboard financiero con métricas del coro
- Gestión de cuotas mensuales
- Control de gastos operativos
- Reportes y análisis financiero
- Gestión de miembros del coro

#### 3. `USER_FLOWS.md` - Flujos de Usuario y Navegación
**Propósito**: Define los flujos de interacción específicos para los usuarios del coro.

**Contenido**:
- Flujos para directivos (administración completa)
- Flujos para miembros (consulta de estado)
- Navegación entre módulos
- Estados y transiciones

#### 4. `USER_FLOWS_DIAGRAMS.md` - Diagramas Visuales de Flujos
**Propósito**: Diagramas Mermaid que visualizan los flujos principales del sistema.

**Contenido**:
- Diagrama de login y autenticación
- Flujo de gestión de cuotas
- Flujo de registro de gastos
- Flujo de generación de reportes
- Flujo de consulta para miembros

### 🎨 Documentos de Diseño Visual

#### 5. `UI_DESIGN_SYSTEM.md` - Sistema de Diseño
**Propósito**: Fundamentos visuales y sistema de diseño base.

**Contenido**:
- Paleta de colores blanco/dorado/negro
- Tipografía y espaciado
- Variables CSS/SCSS
- Componentes base (botones, cards, badges)

#### 6. `UI_COMPONENTS.md` - Biblioteca de Componentes
**Propósito**: Catálogo completo de componentes UI específicos para el coro.

**Contenido**:
- Componentes de navegación
- Cards de información financiera
- Tablas de datos (cuotas, gastos, miembros)
- Formularios específicos del dominio
- Dashboards y métricas

#### 8. `HARMONY_HUB_INSPIRATION.md` - Guía de Inspiración Visual
**Propósito**: Cómo aplicar elementos visuales de Harmony Hub al contexto del coro.

**Contenido**:
- Análisis de estética visual
- Adaptación a gestión financiera
- Ejemplos de implementación
- Patrones de interacción

### �️ Recursos Visuales

#### 9. Carpeta `img/` - Mockups y Referencias Visuales
**Propósito**: Contiene todos los mockups y referencias visuales del sistema.

**Archivos incluidos**:
- `payments_dashboard.png`: Mockup del dashboard principal
- `suscriptions_overview.png`: Vista general de cuotas
- `suscriptions_details.png`: Detalle de cuotas por miembro
- `suscription_details_member.png`: Vista para miembros del coro
- `suscriptions_overview_admin.png`: Vista administrativa
- `suscriptions_list.png`: Lista completa de cuotas

---

## Flujo de Trabajo para Desarrolladores

### Orden de Lectura Recomendado

#### 1. **Comprensión del Contexto** (Inicio)
```bash
1. DESCRIPCION_DEL_CORO.md → Entender el contexto real del coro
2. UI_DESCRIPTION.md → Conocer las funcionalidades específicas
3. USER_FLOWS.md → Comprender la navegación y flujos
4. USER_FLOWS_DIAGRAMS.md → Visualizar los flujos principales
```

#### 2. **Configuración del Diseño** (Setup)
```bash
1. UI_DESIGN_SYSTEM.md → Configurar variables CSS/SCSS base
2. HARMONY_HUB_INSPIRATION.md → Entender el estilo visual objetivo
3. UI_COMPONENTS.md → Familiarizarse con componentes disponibles
```

#### 3. **Implementación** (Desarrollo)
```bash
# Para cada página/componente:
1. Consultar USER_FLOWS.md → ¿Cómo funciona este flujo?
2. Revisar UI_COMPONENTS.md → ¿Qué componentes necesito?
3. Aplicar UI_DESIGN_SYSTEM.md → ¿Colores, espaciado, tipografía?
4. Referenciar HARMONY_HUB_INSPIRATION.md → ¿Cómo debe verse?
```

---

## Características Técnicas del Sistema

### Módulos Principales
1. **Dashboard Financiero**: Resumen de ingresos, gastos y métricas del coro
2. **Gestión de Cuotas**: Control de pagos mensuales de los 58 miembros
3. **Control de Gastos**: Registro y categorización de gastos operativos
4. **Reportes**: Generación de reportes financieros mensuales y anuales
5. **Gestión de Miembros**: Administración básica de información de integrantes

### Roles de Usuario
- **Directivos**: Acceso completo a todas las funcionalidades
- **Miembros**: Consulta de su estado de cuotas y información personal

### Stack Tecnológico
- **Backend**: ASP.NET Core MVC
- **Frontend**: Bootstrap 5 + jQuery
- **Base de Datos**: SQLite (desarrollo) / SQL Server (producción)
- **Patrones**: Repository Pattern, Entity Framework Core

---

## Variables CSS/SCSS Base

### Configuración para Polyphonia Hub
```scss
// Paleta específica para el Coro Polyphonia
$polyphonia-palette: (
  // Colores principales
  'primary-white': #FFFFFF,
  'primary-gold': #F7C52D,
  'primary-black': #1A1A1A,
  
  // Variaciones funcionales
  'gold-light': #FFF4CC,
  'gold-medium': #F7C52D,
  'gold-dark': #E6B800,
  'gold-accent': #CC9900,
  
  // Grises para texto y fondos
  'gray-50': #FAFAFA,
  'gray-100': #F5F5F5,
  'gray-200': #E0E0E0,
  'gray-300': #BDBDBD,
  'gray-500': #757575,
  'gray-700': #424242,
  'gray-900': #1A1A1A,
  
  // Estados para finanzas
  'income': #10B981,      // Verde para ingresos
  'expense': #EF4444,     // Rojo para gastos
  'pending': #F59E0B,     // Naranja para pendientes
  'info': #3B82F6         // Azul para información
);

// Mixins específicos para gestión financiera
@mixin financial-card {
  background: map-get($polyphonia-palette, 'primary-white');
  border: 1px solid #E5E7EB;
  border-radius: 12px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  padding: 1.5rem;
  transition: all 0.3s ease;
  
  &:hover {
    box-shadow: 0 8px 25px rgba(0, 0, 0, 0.15);
    transform: translateY(-2px);
  }
}

@mixin currency-display {
  font-family: 'Segoe UI', system-ui, sans-serif;
  font-weight: 600;
  font-variant-numeric: tabular-nums;
  color: map-get($polyphonia-palette, 'primary-black');
}
```

---

## Checklist de Implementación

### ✅ Configuración Base para Polyphonia Hub
- [ ] Variables CSS/SCSS configuradas según el sistema de diseño
- [ ] Paleta blanco/dorado/negro implementada
- [ ] Tipografía específica para datos financieros
- [ ] Sistema de iconografía para gestión financiera

### ✅ Componentes Específicos del Coro
- [ ] Dashboard con métricas financieras del coro
- [ ] Tabla de miembros con estado de cuotas
- [ ] Cards de resumen financiero
- [ ] Formularios de registro de gastos
- [ ] Reportes visuales con gráficos

### ✅ Funcionalidad Financiera
- [ ] Visualización de estado de cuotas por miembro
- [ ] Registro y categorización de gastos
- [ ] Cálculo automático de balances
- [ ] Generación de reportes mensuales
- [ ] Notificaciones de pagos pendientes

### ✅ Experiencia de Usuario
- [ ] Navegación intuitiva inspirada en Harmony Hub
- [ ] Estados de carga para operaciones financieras
- [ ] Confirmaciones para operaciones críticas
- [ ] Feedback visual para acciones completadas
- [ ] Responsive design para acceso móvil

---

## Recursos Adicionales

### Archivos de Referencia Visual (Carpeta `img/`)
- `img/payments_dashboard.png`: Mockup del dashboard principal
- `img/suscriptions_overview.png`: Vista general de cuotas
- `img/suscriptions_details.png`: Detalle de cuotas por miembro
- `img/suscription_details_member.png`: Vista para miembros del coro
- `img/suscriptions_overview_admin.png`: Vista administrativa
- `img/suscriptions_list.png`: Lista completa de cuotas

### Documentación Disponible
La documentación se ha simplificado y enfocado en los archivos esenciales para el desarrollo.

---

## Información del Proyecto

**Coro Polyphonia**
- 58 integrantes activos
- Actividades colaborativas regulares
- Necesidades de gestión financiera simple y eficiente
- Enfoque en transparencia y facilidad de uso

**Última Actualización**: Junio 2025
**Versión**: 2.1 - Documentación simplificada y optimizada
**Estado**: Lista para desarrollo - Estructura limpia y enfocada
