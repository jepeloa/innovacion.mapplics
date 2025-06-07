# Sistema de Diseño - Coro Polyphonia
## Gestión Financiera para 58 Integrantes Activos

> **Proyecto**: Sistema de Gestión Financiera para el Coro Polyphonia
> **Contexto**: 58 integrantes activos, funcionamiento colaborativo desde 2013
> **Enfoque**: Gestión de cuotas mensuales, gastos operativos y transparencia financiera
> **Inspiración Visual**: Harmony Hub - Estilo moderno, limpio y profesional
> **Paleta Predominante**: Blanco, Dorado y Negro
> **Stack Tecnológico**: Bootstrap + jQuery para web responsive

## Contexto del Coro Polyphonia
- **58 integrantes activos** que participan colaborativamente en todas las decisiones
- **Ensayos semanales** los martes de 20:00 a 22:30 hs en salón alquilado
- **4-6 conciertos anuales** con gestión de ingresos por entradas y donaciones
- **Financiamiento mixto**: cuotas mensuales, patrocinadores y eventos
- **Gestión independiente** con necesidad de transparencia total en las finanzas

## Objetivos del Sistema de Diseño
- **Simplicidad**: Interfaz intuitiva para usuarios de todas las edades
- **Transparencia**: Visualización clara del estado financiero del coro
- **Eficiencia**: Optimizado para uso en celulares durante ensayos
- **Colaboración**: Facilitar la participación de todos los miembros en decisiones financieras

## Índice
1. [Inspiración y Referencias](#inspiración-y-referencias)
2. [Paleta de Colores](#paleta-de-colores)
3. [Tipografía](#tipografía)
4. [Espaciado y Grid](#espaciado-y-grid)
5. [Componentes Base](#componentes-base)
6. [Patrones de Dashboard](#patrones-de-dashboard)
7. [Estados y Feedbacks](#estados-y-feedbacks)
8. [Responsive Design](#responsive-design)

---

## Inspiración y Referencias

### Estilo Visual Base: Harmony Hub
- **Diseño**: Moderno, limpio, profesional
- **Layout**: Dashboard-centric con métricas prominentes
- **Navegación**: Sidebar con iconografía clara
- **Cards**: Elevación sutil, bordes redondeados
- **Tipografía**: Sans-serif, jerarquía clara
- **Espaciado**: Generoso, respiración visual

### Principios de Diseño
1. **Claridad**: Información jerárquica y fácil de escanear
2. **Consistencia**: Patrones repetibles en toda la aplicación
3. **Accesibilidad**: Contraste adecuado, navegación intuitiva
4. **Eficiencia**: Flujos optimizados para tareas administrativas

---

## Principios de Diseño

### 1. Claridad y Simplicidad
- **Objetivo**: Interfaces limpias que faciliten las tareas administrativas del coro
- **Aplicación**: Uso de espacios en blanco, jerarquía visual clara, información agrupada lógicamente

### 2. Consistencia
- **Objetivo**: Experiencia uniforme entre diferentes secciones
- **Aplicación**: Patrones de navegación consistentes, componentes reutilizables, terminología uniforme

### 3. Accesibilidad
- **Objetivo**: Usable por administradores y miembros de diferentes edades y habilidades técnicas
- **Aplicación**: Contrastes adecuados, textos legibles, navegación intuitiva

### 4. Eficiencia
- **Objetivo**: Minimizar pasos para completar tareas comunes
- **Aplicación**: Accesos directos, acciones en lote, formularios optimizados

---

## Paleta de Colores

### Colores Primarios (Inspirados en Harmony Hub)
```scss
// Paleta Principal: Blanco, Dorado, Negro
$primary-white: #FFFFFF;        // Fondos principales, cards
$primary-gold: #F7C52D;         // Dorado principal (botones, acentos)
$primary-black: #1A1A1A;        // Negro principal (texto, navegación)

// Variaciones de Dorado
$gold-light: #FFF4CC;           // Fondos suaves, highlights
$gold-medium: #F7C52D;          // Botones primarios, acentos principales
$gold-dark: #E6B800;            // Hover states, bordes activos
$gold-darker: #CC9900;          // Estados pressed

// Escala de Grises (Compatible con diseño moderno)
$gray-50: #FAFAFA;              // Fondos muy claros
$gray-100: #F5F5F5;             // Fondos de cards, separadores
$gray-200: #E0E0E0;             // Bordes suaves, divisores
$gray-300: #BDBDBD;             // Bordes, placeholders
$gray-400: #9E9E9E;             // Texto deshabilitado
$gray-500: #757575;             // Texto secundario
$gray-600: #616161;             // Texto terciario
$gray-700: #424242;             // Texto importante
$gray-800: #303030;             // Texto principal
$gray-900: #1A1A1A;             // Negro principal
```

### Colores de Estado (Basados en Harmony Hub)
```scss
// Estados funcionales
$status-active: #10B981;        // Verde - Suscripción activa
$status-pending: #F59E0B;       // Amarillo - Pago pendiente
$status-expired: #EF4444;       // Rojo - Suscripción vencida
$status-inactive: #6B7280;      // Gris - Estado inactivo

// Fondos de estado (versiones suaves)
$status-active-bg: #D1FAE5;     // Fondo verde claro
$status-pending-bg: #FEF3C7;    // Fondo amarillo claro
$status-expired-bg: #FEE2E2;    // Fondo rojo claro
$status-inactive-bg: #F3F4F6;   // Fondo gris claro
```

### Aplicación de Colores
```scss
// Jerarquía visual siguiendo principios de Harmony Hub
.primary-surface { background: $primary-white; }
.accent-surface { background: $gold-light; }
.dark-surface { background: $gray-900; color: $primary-white; }

.text-primary { color: $gray-900; }
.text-secondary { color: $gray-600; }
.text-accent { color: $gold-medium; }
.text-inverse { color: $primary-white; }

// Botones
.btn-primary { background: $gold-medium; color: $primary-black; }
.btn-secondary { background: $primary-white; border: 1px solid $gold-medium; color: $primary-black; }
.btn-dark { background: $gray-900; color: $primary-white; }
```

### Colores Neutros
```css
/* Escala de grises para textos y fondos */
--gray-50: #f8fafc;
--gray-100: #f1f5f9;
--gray-200: #e2e8f0;
--gray-300: #cbd5e1;
--gray-400: #94a3b8;
--gray-500: #64748b;
--gray-600: #475569;
--gray-700: #334155;
--gray-800: #1e293b;
--gray-900: #0f172a;
```

### Uso de Colores por Contexto

#### Suscripciones Activas
- **Color**: `--success-green`
- **Uso**: Badges, iconos de estado, bordes de cards activas

#### Suscripciones Inactivas/Vencidas
- **Color**: `--warning-orange` o `--error-red` según criticidad
- **Uso**: Badges de advertencia, notificaciones de vencimiento

#### Acciones Administrativas
- **Color**: `--primary-blue`
- **Uso**: Botones principales, enlaces de navegación, headers

---

## Tipografía

### Fuentes Base (Bootstrap Typography)
```css
/* Fuente principal del sistema */
--font-family-sans: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;

/* Jerarquía de tamaños */
--font-size-xs: 0.75rem;   /* 12px */
--font-size-sm: 0.875rem;  /* 14px */
--font-size-base: 1rem;    /* 16px */
--font-size-lg: 1.125rem;  /* 18px */
--font-size-xl: 1.25rem;   /* 20px */
--font-size-2xl: 1.5rem;   /* 24px */
--font-size-3xl: 1.875rem; /* 30px */
```

### Aplicación por Contexto

#### Headers de Página
- **Tamaño**: `--font-size-3xl`
- **Peso**: `font-weight: 700` (Bold)
- **Uso**: Títulos principales ("Gestión de Suscripciones", "Dashboard")

#### Headers de Sección
- **Tamaño**: `--font-size-2xl`
- **Peso**: `font-weight: 600` (Semi-bold)
- **Uso**: Títulos de cards, secciones de formularios

#### Texto de Contenido
- **Tamaño**: `--font-size-base`
- **Peso**: `font-weight: 400` (Regular)
- **Uso**: Texto general, descripciones, contenido de tablas

#### Texto de Apoyo
- **Tamaño**: `--font-size-sm`
- **Color**: `--gray-600`
- **Uso**: Fechas, metadatos, textos de ayuda

---

## Espaciado y Grid

### Sistema de Espaciado (Bootstrap Spacing)
```css
/* Espaciado base usando rem */
--spacing-1: 0.25rem;  /* 4px */
--spacing-2: 0.5rem;   /* 8px */
--spacing-3: 0.75rem;  /* 12px */
--spacing-4: 1rem;     /* 16px */
--spacing-5: 1.25rem;  /* 20px */
--spacing-6: 1.5rem;   /* 24px */
--spacing-8: 2rem;     /* 32px */
--spacing-10: 2.5rem;  /* 40px */
--spacing-12: 3rem;    /* 48px */
```

### Aplicación de Espaciado

#### Entre Secciones Principales
- **Margen**: `--spacing-12` (48px)
- **Uso**: Separación entre dashboard cards, secciones de página

#### Entre Elementos Relacionados
- **Margen**: `--spacing-6` (24px)
- **Uso**: Entre formularios y botones, entre título y contenido

#### Padding Interno
- **Cards**: `--spacing-6` (24px)
- **Botones**: `--spacing-3` vertical, `--spacing-6` horizontal
- **Forms**: `--spacing-4` (16px)

### Grid Layout (Bootstrap Grid)
```css
/* Contenedor principal */
.main-container {
    max-width: 1200px;
    margin: 0 auto;
    padding: 0 var(--spacing-4);
}

/* Grid de dashboard */
.dashboard-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
    gap: var(--spacing-6);
}

/* Grid de formularios */
.form-grid {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: var(--spacing-4);
}
```

---

## Componentes Base

### Botones

#### Botón Primario
```css
.btn-primary-choir {
    background-color: var(--primary-blue);
    border: 1px solid var(--primary-blue);
    color: white;
    padding: var(--spacing-3) var(--spacing-6);
    border-radius: 0.375rem;
    font-weight: 500;
    transition: all 0.2s ease;
}

.btn-primary-choir:hover {
    background-color: var(--primary-blue-dark);
    border-color: var(--primary-blue-dark);
    transform: translateY(-1px);
    box-shadow: 0 4px 12px rgba(37, 99, 235, 0.3);
}
```

#### Botón Secundario
```css
.btn-secondary-choir {
    background-color: transparent;
    border: 1px solid var(--gray-300);
    color: var(--gray-700);
    padding: var(--spacing-3) var(--spacing-6);
    border-radius: 0.375rem;
    font-weight: 500;
    transition: all 0.2s ease;
}

.btn-secondary-choir:hover {
    background-color: var(--gray-50);
    border-color: var(--gray-400);
}
```

#### Botón de Éxito (Activar Suscripción)
```css
.btn-success-choir {
    background-color: var(--success-green);
    border: 1px solid var(--success-green);
    color: white;
    padding: var(--spacing-2) var(--spacing-4);
    border-radius: 0.375rem;
    font-size: var(--font-size-sm);
    font-weight: 500;
}
```

#### Botón de Advertencia (Suspender)
```css
.btn-warning-choir {
    background-color: var(--warning-orange);
    border: 1px solid var(--warning-orange);
    color: white;
    padding: var(--spacing-2) var(--spacing-4);
    border-radius: 0.375rem;
    font-size: var(--font-size-sm);
    font-weight: 500;
}
```

### Cards

#### Card Base
```css
.card-choir {
    background: white;
    border: 1px solid var(--gray-200);
    border-radius: 0.5rem;
    padding: var(--spacing-6);
    box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
    transition: all 0.2s ease;
}

.card-choir:hover {
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
    transform: translateY(-2px);
}
```

#### Card de Dashboard
```css
.dashboard-card {
    display: flex;
    flex-direction: column;
    align-items: center;
    text-align: center;
    min-height: 200px;
    justify-content: center;
}

.dashboard-card-icon {
    width: 48px;
    height: 48px;
    margin-bottom: var(--spacing-4);
    color: var(--primary-blue);
}

.dashboard-card-title {
    font-size: var(--font-size-xl);
    font-weight: 600;
    color: var(--gray-800);
    margin-bottom: var(--spacing-2);
}

.dashboard-card-value {
    font-size: var(--font-size-3xl);
    font-weight: 700;
    color: var(--primary-blue);
    margin-bottom: var(--spacing-2);
}
```

### Badges de Estado

#### Badge Activo
```css
.badge-active {
    background-color: var(--success-green);
    color: white;
    padding: var(--spacing-1) var(--spacing-3);
    border-radius: 9999px;
    font-size: var(--font-size-xs);
    font-weight: 500;
    text-transform: uppercase;
    letter-spacing: 0.05em;
}
```

#### Badge Inactivo
```css
.badge-inactive {
    background-color: var(--gray-400);
    color: white;
    padding: var(--spacing-1) var(--spacing-3);
    border-radius: 9999px;
    font-size: var(--font-size-xs);
    font-weight: 500;
    text-transform: uppercase;
    letter-spacing: 0.05em;
}
```

#### Badge Vencido
```css
.badge-expired {
    background-color: var(--error-red);
    color: white;
    padding: var(--spacing-1) var(--spacing-3);
    border-radius: 9999px;
    font-size: var(--font-size-xs);
    font-weight: 500;
    text-transform: uppercase;
    letter-spacing: 0.05em;
}
```

### Formularios

#### Input Base
```css
.input-choir {
    width: 100%;
    padding: var(--spacing-3);
    border: 1px solid var(--gray-300);
    border-radius: 0.375rem;
    font-size: var(--font-size-base);
    transition: all 0.2s ease;
}

.input-choir:focus {
    outline: none;
    border-color: var(--primary-blue);
    box-shadow: 0 0 0 3px rgba(37, 99, 235, 0.1);
}
```

#### Select Base
```css
.select-choir {
    width: 100%;
    padding: var(--spacing-3);
    border: 1px solid var(--gray-300);
    border-radius: 0.375rem;
    font-size: var(--font-size-base);
    background-color: white;
    background-image: url("data:image/svg+xml,..."); /* Flecha dropdown */
    background-repeat: no-repeat;
    background-position: right var(--spacing-3) center;
    background-size: 16px;
}
```

### Tablas

#### Tabla Base
```css
.table-choir {
    width: 100%;
    border-collapse: collapse;
    background: white;
    border-radius: 0.5rem;
    overflow: hidden;
    box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
}

.table-choir th {
    background-color: var(--gray-50);
    padding: var(--spacing-4);
    text-align: left;
    font-weight: 600;
    color: var(--gray-700);
    border-bottom: 1px solid var(--gray-200);
}

.table-choir td {
    padding: var(--spacing-4);
    border-bottom: 1px solid var(--gray-200);
    color: var(--gray-800);
}

.table-choir tr:hover {
    background-color: var(--gray-50);
}
```

---

## Patrones de Interfaz

### Navegación Principal

#### Estructura de Navegación
```html
<!-- Header con navegación -->
<nav class="navbar-choir">
    <div class="navbar-brand">
        <span class="brand-icon">🎵</span>
        <span class="brand-text">Polyphonia Hub</span>
    </div>
    <div class="navbar-menu">
        <a href="#dashboard" class="nav-link active">Dashboard</a>
        <a href="#subscriptions" class="nav-link">Suscripciones</a>
        <a href="#members" class="nav-link">Miembros</a>
        <a href="#notifications" class="nav-link">Notificaciones</a>
    </div>
    <div class="navbar-user">
        <span class="user-role">Administrador</span>
        <button class="btn-user-menu">JD</button>
    </div>
</nav>
```

#### Estilos de Navegación
```css
.navbar-choir {
    background: white;
    border-bottom: 1px solid var(--gray-200);
    padding: var(--spacing-4) var(--spacing-6);
    display: flex;
    align-items: center;
    justify-content: space-between;
    box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
}

.navbar-brand {
    display: flex;
    align-items: center;
    gap: var(--spacing-2);
    font-weight: 700;
    font-size: var(--font-size-lg);
    color: var(--primary-blue);
}

.nav-link {
    padding: var(--spacing-2) var(--spacing-4);
    color: var(--gray-600);
    text-decoration: none;
    border-radius: 0.375rem;
    transition: all 0.2s ease;
}

.nav-link:hover,
.nav-link.active {
    background-color: var(--primary-blue);
    color: white;
}
```

### Layout de Página

#### Estructura de Página Principal
```html
<div class="page-layout">
    <header class="page-header">
        <h1 class="page-title">Gestión de Suscripciones</h1>
        <div class="page-actions">
            <button class="btn-primary-choir">+ Nueva Suscripción</button>
            <button class="btn-secondary-choir">Exportar</button>
        </div>
    </header>
    
    <div class="page-content">
        <!-- Contenido principal -->
    </div>
</div>
```

#### Estilos de Layout
```css
.page-layout {
    max-width: 1200px;
    margin: 0 auto;
    padding: var(--spacing-6);
}

.page-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: var(--spacing-8);
    padding-bottom: var(--spacing-4);
    border-bottom: 1px solid var(--gray-200);
}

.page-title {
    font-size: var(--font-size-3xl);
    font-weight: 700;
    color: var(--gray-800);
    margin: 0;
}

.page-actions {
    display: flex;
    gap: var(--spacing-3);
}
```

---

## Estados y Feedback

### Estados de Carga

#### Spinner de Carga
```css
.spinner-choir {
    width: 24px;
    height: 24px;
    border: 2px solid var(--gray-200);
    border-top: 2px solid var(--primary-blue);
    border-radius: 50%;
    animation: spin 1s linear infinite;
}

@keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
}
```

#### Estado de Carga en Botones
```css
.btn-loading {
    position: relative;
    color: transparent;
}

.btn-loading::after {
    content: "";
    position: absolute;
    width: 16px;
    height: 16px;
    top: 50%;
    left: 50%;
    margin-left: -8px;
    margin-top: -8px;
    border: 2px solid transparent;
    border-top: 2px solid currentColor;
    border-radius: 50%;
    animation: spin 1s linear infinite;
}
```

### Notificaciones y Alertas

#### Alerta de Éxito
```css
.alert-success {
    background-color: rgba(5, 150, 105, 0.1);
    border: 1px solid var(--success-green);
    color: var(--success-green);
    padding: var(--spacing-4);
    border-radius: 0.375rem;
    display: flex;
    align-items: center;
    gap: var(--spacing-3);
}
```

#### Alerta de Error
```css
.alert-error {
    background-color: rgba(220, 38, 38, 0.1);
    border: 1px solid var(--error-red);
    color: var(--error-red);
    padding: var(--spacing-4);
    border-radius: 0.375rem;
    display: flex;
    align-items: center;
    gap: var(--spacing-3);
}
```

#### Alerta de Advertencia
```css
.alert-warning {
    background-color: rgba(217, 119, 6, 0.1);
    border: 1px solid var(--warning-orange);
    color: var(--warning-orange);
    padding: var(--spacing-4);
    border-radius: 0.375rem;
    display: flex;
    align-items: center;
    gap: var(--spacing-3);
}
```

### Estados Interactivos

#### Hover States
- **Botones**: Cambio de color + elevación sutil
- **Cards**: Elevación de sombra + translación vertical
- **Links**: Cambio de color + subrayado

#### Focus States
- **Inputs**: Borde azul + sombra de enfoque
- **Botones**: Outline visible para accesibilidad
- **Links**: Outline distintivo

#### Active States
- **Botones**: Presión visual (scale down)
- **Navegación**: Fondo azul + texto blanco
- **Tabs**: Borde inferior destacado

---

## Responsive Design

### Breakpoints
```css
/* Mobile */
@media (max-width: 767px) {
    .dashboard-grid {
        grid-template-columns: 1fr;
    }
    
    .page-header {
        flex-direction: column;
        gap: var(--spacing-4);
        align-items: stretch;
    }
    
    .page-actions {
        justify-content: center;
    }
}

/* Tablet */
@media (min-width: 768px) and (max-width: 1023px) {
    .dashboard-grid {
        grid-template-columns: repeat(2, 1fr);
    }
}

/* Desktop */
@media (min-width: 1024px) {
    .dashboard-grid {
        grid-template-columns: repeat(3, 1fr);
    }
}
```

### Adaptaciones Móviles
- **Navegación**: Menú hamburguesa colapsible
- **Tablas**: Scroll horizontal o cards apilables  
- **Formularios**: Inputs de ancho completo
- **Botones**: Tamaño táctil mínimo de 44px

---

*Este sistema de diseño debe ser implementado progresivamente, comenzando por los componentes base y expandiendo según las necesidades del proyecto.*
