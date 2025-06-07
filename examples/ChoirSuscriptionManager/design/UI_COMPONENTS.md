# Biblioteca de Componentes - Coro Polyphonia
## Gestión Financiera para 58 Integrantes Activos

> **Proyecto**: Sistema de Gestión Financiera del Coro Polyphonia
> **Contexto**: 58 integrantes activos, gestión colaborativa, transparencia financiera
> **Inspiración Visual**: Harmony Hub - Moderno, limpio, profesional
> **Paleta**: Blanco, Dorado y Negro (predominantes)
> **Framework**: Bootstrap + jQuery compatible
> **Enfoque**: Gestión de cuotas mensuales, gastos operativos, reportes transparentes
> 
> **Nota**: Los componentes están diseñados específicamente para la gestión financiera del Coro Polyphonia (58 miembros), inspirados visualmente en Harmony Hub pero adaptados para las necesidades reales del coro: control de cuotas, categorización de gastos, reportes de transparencia y gestión colaborativa.

## Índice de Componentes Específicos
1. [Componentes de Layout](#componentes-de-layout)
2. [Componentes de Navegación](#componentes-de-navegación)
3. [Componentes de Datos Financieros](#componentes-de-datos-financieros)
4. [Componentes de Formularios](#componentes-de-formularios)
5. [Componentes de Feedback](#componentes-de-feedback)
6. [Componentes de Dashboard Financiero](#componentes-de-dashboard-financiero)
7. [Componentes Específicos del Coro](#componentes-específicos-del-coro)

---

## Componentes de Layout

### 1. Main Container
```html
<!-- Contenedor principal de la aplicación -->
<div class="app-container">
  <aside class="sidebar">
    <!-- Navegación lateral -->
  </aside>
  <main class="main-content">
    <header class="page-header">
      <!-- Header de página -->
    </header>
    <div class="page-content">
      <!-- Contenido de la página -->
    </div>
  </main>
</div>
```

```scss
.app-container {
  display: grid;
  grid-template-columns: 250px 1fr;
  min-height: 100vh;
  background: $gray-50;
  
  @media (max-width: 768px) {
    grid-template-columns: 1fr;
  }
}

.main-content {
  display: flex;
  flex-direction: column;
  overflow: hidden;
}

.page-content {
  flex: 1;
  padding: $space-6;
  overflow-y: auto;
}
```

### 2. Card Layout
```html
<!-- Card base reutilizable -->
<div class="card">
  <div class="card-header">
    <h3 class="card-title">Título de la Card</h3>
    <div class="card-actions">
      <button class="btn-icon">
        <i class="icon-more"></i>
      </button>
    </div>
  </div>
  <div class="card-content">
    <!-- Contenido de la card -->
  </div>
  <div class="card-footer">
    <!-- Acciones o información adicional -->
  </div>
</div>
```

```scss
.card {
  background: $primary-white;
  border-radius: 12px;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1), 0 1px 2px rgba(0, 0, 0, 0.06);
  border: 1px solid $gray-200;
  overflow: hidden;
  transition: box-shadow 0.2s ease;
  
  &:hover {
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
  }
  
  .card-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: $space-6;
    border-bottom: 1px solid $gray-200;
    
    .card-title {
      margin: 0;
      font-size: $font-size-lg;
      font-weight: $font-weight-semibold;
      color: $gray-900;
    }
  }
  
  .card-content {
    padding: $space-6;
  }
  
  .card-footer {
    padding: $space-4 $space-6;
    background: $gray-50;
    border-top: 1px solid $gray-200;
  }
}
```

---

## Componentes de Navegación

### 1. Sidebar Navigation
```html
<!-- Navegación lateral inspirada en Harmony Hub -->
<nav class="sidebar">
  <div class="sidebar-header">
    <div class="logo">
      <i class="icon-music"></i>
      <span class="logo-text">Harmony Hub</span>
    </div>
  </div>
  
  <div class="sidebar-menu">
    <a href="/dashboard" class="nav-item active">
      <i class="icon-dashboard"></i>
      <span class="nav-text">Dashboard</span>
    </a>
    <a href="/members" class="nav-item">
      <i class="icon-users"></i>
      <span class="nav-text">Miembros</span>
    </a>
    <a href="/subscriptions" class="nav-item">
      <i class="icon-credit-card"></i>
      <span class="nav-text">Suscripciones</span>
    </a>
    <a href="/payments" class="nav-item highlighted">
      <i class="icon-dollar-sign"></i>
      <span class="nav-text">Pagos</span>
    </a>
    <a href="/expenses" class="nav-item">
      <i class="icon-trending-up"></i>
      <span class="nav-text">Gastos</span>
    </a>
    <a href="/reports" class="nav-item">
      <i class="icon-bar-chart"></i>
      <span class="nav-text">Reportes</span>
    </a>
    <a href="/settings" class="nav-item">
      <i class="icon-settings"></i>
      <span class="nav-text">Configuración</span>
    </a>
  </div>
  
  <div class="sidebar-footer">
    <a href="/help" class="nav-item">
      <i class="icon-help-circle"></i>
      <span class="nav-text">Ayuda y Docs</span>
    </a>
    <a href="/support" class="nav-item">
      <i class="icon-headphones"></i>
      <span class="nav-text">Contactar Soporte</span>
    </a>
  </div>
</nav>
```

```scss
.sidebar {
  width: 250px;
  background: $primary-white;
  border-right: 1px solid $gray-200;
  display: flex;
  flex-direction: column;
  
  .sidebar-header {
    padding: $space-6;
    border-bottom: 1px solid $gray-200;
    
    .logo {
      display: flex;
      align-items: center;
      gap: $space-3;
      
      i {
        color: $gold-medium;
        font-size: 24px;
      }
      
      .logo-text {
        font-size: $font-size-lg;
        font-weight: $font-weight-bold;
        color: $gray-900;
      }
    }
  }
  
  .sidebar-menu {
    flex: 1;
    padding: $space-4 0;
  }
  
  .nav-item {
    display: flex;
    align-items: center;
    gap: $space-3;
    padding: $space-3 $space-6;
    color: $gray-600;
    text-decoration: none;
    transition: all 0.2s ease;
    
    i {
      width: 20px;
      height: 20px;
    }
    
    &:hover {
      background: $gray-100;
      color: $gray-900;
    }
    
    &.active {
      background: $gold-light;
      color: $gold-dark;
      border-right: 3px solid $gold-medium;
    }
    
    &.highlighted {
      background: $gold-medium;
      color: $primary-black;
      font-weight: $font-weight-medium;
    }
  }
  
  .sidebar-footer {
    padding: $space-4 0;
    border-top: 1px solid $gray-200;
  }
}
```

### 2. Top Navigation Bar
```html
<!-- Barra superior con usuario y notificaciones -->
<header class="top-nav">
  <div class="nav-left">
    <button class="sidebar-toggle">
      <i class="icon-menu"></i>
    </button>
    <div class="page-title">
      <h1>Dashboard</h1>
      <p class="page-subtitle">Gestiona todas las suscripciones del coro</p>
    </div>
  </div>
  
  <div class="nav-right">
    <button class="btn-icon notification-btn">
      <i class="icon-bell"></i>
      <span class="notification-badge">3</span>
    </button>
    
    <div class="user-menu">
      <div class="user-avatar">
        <img src="/avatars/user.jpg" alt="Usuario">
      </div>
      <div class="user-info">
        <span class="user-name">Admin User</span>
        <span class="user-role">Administrador</span>
      </div>
      <button class="user-dropdown">
        <i class="icon-chevron-down"></i>
      </button>
    </div>
  </div>
</header>
```

```scss
.top-nav {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: $space-4 $space-6;
  background: $primary-white;
  border-bottom: 1px solid $gray-200;
  
  .nav-left {
    display: flex;
    align-items: center;
    gap: $space-4;
  }
  
  .sidebar-toggle {
    display: none;
    
    @media (max-width: 768px) {
      display: flex;
    }
  }
  
  .page-title {
    h1 {
      margin: 0;
      font-size: $font-size-h2;
      font-weight: $font-weight-bold;
      color: $gray-900;
    }
    
    .page-subtitle {
      margin: 0;
      font-size: $font-size-sm;
      color: $gray-600;
    }
  }
  
  .nav-right {
    display: flex;
    align-items: center;
    gap: $space-4;
  }
  
  .notification-btn {
    position: relative;
    
    .notification-badge {
      position: absolute;
      top: -4px;
      right: -4px;
      background: $status-expired;
      color: $primary-white;
      border-radius: 50%;
      width: 18px;
      height: 18px;
      font-size: $font-size-xs;
      display: flex;
      align-items: center;
      justify-content: center;
    }
  }
  
  .user-menu {
    display: flex;
    align-items: center;
    gap: $space-3;
    cursor: pointer;
    
    .user-avatar {
      width: 32px;
      height: 32px;
      border-radius: 50%;
      overflow: hidden;
      
      img {
        width: 100%;
        height: 100%;
        object-fit: cover;
      }
    }
    
    .user-info {
      display: flex;
      flex-direction: column;
      
      .user-name {
        font-size: $font-size-sm;
        font-weight: $font-weight-medium;
        color: $gray-900;
      }
      
      .user-role {
        font-size: $font-size-xs;
        color: $gray-600;
      }
    }
  }
}
```

---

## Componentes de Datos

### 1. Data Table
```html
<!-- Tabla de datos reutilizable -->
<div class="data-table-container">
  <div class="table-header">
    <div class="table-title">
      <h3>Suscripciones</h3>
      <span class="table-count">4 miembros</span>
    </div>
    <div class="table-actions">
      <button class="btn-icon">
        <i class="icon-filter"></i>
      </button>
      <button class="btn-icon">
        <i class="icon-download"></i>
      </button>
      <button class="btn-secondary">
        <i class="icon-columns"></i>
        Columnas
      </button>
    </div>
  </div>
  
  <div class="table-wrapper">
    <table class="data-table">
      <thead>
        <tr>
          <th class="sortable">
            Miembro
            <i class="icon-arrow-up"></i>
          </th>
          <th>Plan</th>
          <th>Estado</th>
          <th>Método de Pago</th>
          <th>Próximo Pago</th>
          <th class="text-right">Monto</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
            <div class="member-cell">
              <div class="member-avatar bg-premium">SC</div>
              <div class="member-info">
                <span class="member-name">Sophia Carter</span>
                <span class="member-email">sophia@example.com</span>
              </div>
            </div>
          </td>
          <td>
            <span class="plan-badge premium">Premium</span>
          </td>
          <td>
            <span class="status-badge active">Activo</span>
          </td>
          <td>Tarjeta de Crédito</td>
          <td>2024-08-15</td>
          <td class="text-right">$25.00</td>
          <td>
            <div class="action-buttons">
              <button class="btn-action edit" title="Editar">
                <i class="icon-edit"></i>
              </button>
              <button class="btn-action delete" title="Eliminar">
                <i class="icon-trash"></i>
              </button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</div>
```

```scss
.data-table-container {
  background: $primary-white;
  border-radius: 12px;
  border: 1px solid $gray-200;
  overflow: hidden;
  
  .table-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: $space-6;
    border-bottom: 1px solid $gray-200;
    
    .table-title {
      h3 {
        margin: 0;
        font-size: $font-size-lg;
        font-weight: $font-weight-semibold;
        color: $gray-900;
      }
      
      .table-count {
        font-size: $font-size-sm;
        color: $gray-600;
        margin-left: $space-2;
      }
    }
    
    .table-actions {
      display: flex;
      gap: $space-2;
    }
  }
  
  .table-wrapper {
    overflow-x: auto;
  }
  
  .data-table {
    width: 100%;
    border-collapse: collapse;
    
    th {
      padding: $space-4 $space-6;
      text-align: left;
      font-size: $font-size-sm;
      font-weight: $font-weight-medium;
      color: $gray-700;
      background: $gray-50;
      border-bottom: 1px solid $gray-200;
      white-space: nowrap;
      
      &.sortable {
        cursor: pointer;
        user-select: none;
        
        &:hover {
          background: $gray-100;
        }
        
        i {
          margin-left: $space-1;
          opacity: 0.5;
        }
      }
      
      &.text-right {
        text-align: right;
      }
    }
    
    td {
      padding: $space-4 $space-6;
      border-bottom: 1px solid $gray-200;
      font-size: $font-size-sm;
      
      &.text-right {
        text-align: right;
      }
    }
    
    tr:hover {
      background: $gray-50;
    }
  }
  
  .member-cell {
    display: flex;
    align-items: center;
    gap: $space-3;
    
    .member-avatar {
      width: 32px;
      height: 32px;
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: $font-size-xs;
      font-weight: $font-weight-bold;
      color: $primary-white;
      
      &.bg-premium { background: $gold-medium; }
      &.bg-basic { background: $gray-600; }
      &.bg-family { background: $status-active; }
    }
    
    .member-info {
      display: flex;
      flex-direction: column;
      
      .member-name {
        font-weight: $font-weight-medium;
        color: $gray-900;
      }
      
      .member-email {
        font-size: $font-size-xs;
        color: $gray-600;
      }
    }
  }
  
  .plan-badge {
    padding: $space-1 $space-3;
    border-radius: 20px;
    font-size: $font-size-xs;
    font-weight: $font-weight-medium;
    
    &.premium {
      background: $gold-light;
      color: $gold-dark;
    }
    
    &.basic {
      background: $gray-200;
      color: $gray-700;
    }
    
    &.family {
      background: $status-active-bg;
      color: $status-active;
    }
  }
  
  .action-buttons {
    display: flex;
    gap: $space-1;
    
    .btn-action {
      width: 32px;
      height: 32px;
      border: none;
      border-radius: 6px;
      display: flex;
      align-items: center;
      justify-content: center;
      cursor: pointer;
      transition: all 0.2s ease;
      
      &.edit {
        background: $gold-light;
        color: $gold-dark;
        
        &:hover {
          background: $gold-medium;
        }
      }
      
      &.delete {
        background: $status-expired-bg;
        color: $status-expired;
        
        &:hover {
          background: $status-expired;
          color: $primary-white;
        }
      }
    }
  }
}
```

### 2. Metric Cards
```html
<!-- Card de métricas inspirada en Harmony Hub -->
<div class="metrics-grid">
  <div class="metric-card">
    <div class="metric-value">$12,500</div>
    <div class="metric-label">Total Recaudado</div>
    <div class="metric-change positive">
      <i class="icon-trending-up"></i>
      +10%
    </div>
  </div>
  
  <div class="metric-card">
    <div class="metric-value">$2,300</div>
    <div class="metric-label">Pagos Pendientes</div>
    <div class="metric-change negative">
      <i class="icon-trending-down"></i>
      -5%
    </div>
  </div>
  
  <div class="metric-card">
    <div class="metric-value">$125</div>
    <div class="metric-label">Pago Promedio</div>
    <div class="metric-change positive">
      <i class="icon-trending-up"></i>
      +2%
    </div>
  </div>
</div>
```

```scss
.metrics-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: $space-6;
  margin-bottom: $space-8;
}

.metric-card {
  background: $primary-white;
  padding: $space-6;
  border-radius: 12px;
  border: 1px solid $gray-200;
  text-align: center;
  transition: transform 0.2s ease, box-shadow 0.2s ease;
  
  &:hover {
    transform: translateY(-2px);
    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  }
  
  .metric-value {
    font-size: 2.5rem;
    font-weight: $font-weight-bold;
    color: $gray-900;
    margin-bottom: $space-2;
    line-height: 1;
  }
  
  .metric-label {
    font-size: $font-size-sm;
    color: $gray-600;
    font-weight: $font-weight-medium;
    margin-bottom: $space-3;
  }
  
  .metric-change {
    display: flex;
    align-items: center;
    justify-content: center;
    gap: $space-1;
    font-size: $font-size-xs;
    font-weight: $font-weight-medium;
    
    &.positive {
      color: $status-active;
    }
    
    &.negative {
      color: $status-expired;
    }
    
    i {
      width: 14px;
      height: 14px;
    }
  }
}
```

---

## Componentes de Formularios

### 1. Form Group
```html
<!-- Grupo de formulario estándar -->
<div class="form-group">
  <label class="form-label">Nombre del Miembro *</label>
  <input type="text" class="form-control" placeholder="Ingresa el nombre completo" required>
  <div class="form-help">Este nombre aparecerá en todas las comunicaciones</div>
  <div class="form-error">Este campo es obligatorio</div>
</div>

<!-- Select con búsqueda -->
<div class="form-group">
  <label class="form-label">Plan de Suscripción</label>
  <select class="form-control select-search">
    <option value="">Seleccionar plan</option>
    <option value="basic">Básico - $10/mes</option>
    <option value="premium">Premium - $25/mes</option>
    <option value="family">Familiar - $40/mes</option>
  </select>
</div>

<!-- Campo con ícono -->
<div class="form-group">
  <label class="form-label">Email</label>
  <div class="input-with-icon">
    <i class="input-icon icon-mail"></i>
    <input type="email" class="form-control" placeholder="usuario@ejemplo.com">
  </div>
</div>
```

```scss
.form-group {
  margin-bottom: $space-5;
  
  .form-label {
    display: block;
    font-size: $font-size-sm;
    font-weight: $font-weight-medium;
    color: $gray-800;
    margin-bottom: $space-2;
  }
  
  .form-control {
    width: 100%;
    padding: $space-3 $space-4;
    border: 1px solid $gray-300;
    border-radius: 8px;
    font-size: $font-size-base;
    transition: border-color 0.2s ease, box-shadow 0.2s ease;
    background: $primary-white;
    
    &:focus {
      outline: none;
      border-color: $gold-medium;
      box-shadow: 0 0 0 3px rgba(247, 197, 45, 0.1);
    }
    
    &.error {
      border-color: $status-expired;
      
      &:focus {
        box-shadow: 0 0 0 3px rgba(239, 68, 68, 0.1);
      }
    }
    
    &:disabled {
      background: $gray-100;
      color: $gray-500;
      cursor: not-allowed;
    }
  }
  
  .input-with-icon {
    position: relative;
    
    .input-icon {
      position: absolute;
      left: $space-3;
      top: 50%;
      transform: translateY(-50%);
      color: $gray-500;
      width: 16px;
      height: 16px;
    }
    
    .form-control {
      padding-left: $space-10;
    }
  }
  
  .form-help {
    font-size: $font-size-xs;
    color: $gray-600;
    margin-top: $space-1;
  }
  
  .form-error {
    font-size: $font-size-xs;
    color: $status-expired;
    margin-top: $space-1;
    display: none;
    
    .error & {
      display: block;
    }
  }
}
```

### 2. Search Bar
```html
<!-- Barra de búsqueda con filtros -->
<div class="search-filter-bar">
  <div class="search-input">
    <i class="search-icon icon-search"></i>
    <input type="text" placeholder="Buscar suscripciones (ej. Nombre, Plan, Estado)">
    <button class="clear-search">
      <i class="icon-x"></i>
    </button>
  </div>
  
  <div class="filter-controls">
    <select class="filter-select">
      <option value="">Estado</option>
      <option value="active">Activo</option>
      <option value="pending">Pendiente</option>
      <option value="expired">Expirado</option>
    </select>
    
    <select class="filter-select">
      <option value="">Plan</option>
      <option value="basic">Básico</option>
      <option value="premium">Premium</option>
      <option value="family">Familiar</option>
    </select>
    
    <select class="filter-select">
      <option value="">Método de Pago</option>
      <option value="credit-card">Tarjeta</option>
      <option value="paypal">PayPal</option>
      <option value="bank-transfer">Transferencia</option>
    </select>
    
    <button class="btn-icon filter-trigger">
      <i class="icon-filter"></i>
    </button>
    
    <button class="btn-icon">
      <i class="icon-download"></i>
    </button>
  </div>
</div>
```

```scss
.search-filter-bar {
  display: flex;
  gap: $space-4;
  margin-bottom: $space-6;
  
  @media (max-width: 768px) {
    flex-direction: column;
  }
  
  .search-input {
    flex: 1;
    position: relative;
    
    .search-icon {
      position: absolute;
      left: $space-3;
      top: 50%;
      transform: translateY(-50%);
      color: $gray-500;
      width: 16px;
      height: 16px;
    }
    
    input {
      width: 100%;
      padding: $space-3 $space-10 $space-3 $space-10;
      border: 1px solid $gray-300;
      border-radius: 8px;
      background: $gray-50;
      font-size: $font-size-sm;
      
      &:focus {
        outline: none;
        border-color: $gold-medium;
        background: $primary-white;
        box-shadow: 0 0 0 3px rgba(247, 197, 45, 0.1);
      }
    }
    
    .clear-search {
      position: absolute;
      right: $space-3;
      top: 50%;
      transform: translateY(-50%);
      background: none;
      border: none;
      color: $gray-500;
      cursor: pointer;
      display: none;
      
      &.visible {
        display: block;
      }
    }
  }
  
  .filter-controls {
    display: flex;
    gap: $space-2;
    
    .filter-select {
      padding: $space-3 $space-4;
      border: 1px solid $gray-300;
      border-radius: 8px;
      background: $primary-white;
      font-size: $font-size-sm;
      min-width: 120px;
      
      &:focus {
        outline: none;
        border-color: $gold-medium;
        box-shadow: 0 0 0 3px rgba(247, 197, 45, 0.1);
      }
    }
  }
}
```

---

## Componentes de Feedback

### 1. Status Badges
```html
<!-- Badges de estado reutilizables -->
<span class="status-badge active">Activo</span>
<span class="status-badge pending">Pendiente</span>
<span class="status-badge expired">Expirado</span>
<span class="status-badge inactive">Inactivo</span>
```

```scss
.status-badge {
  padding: $space-1 $space-3;
  border-radius: 20px;
  font-size: $font-size-xs;
  font-weight: $font-weight-medium;
  text-transform: uppercase;
  letter-spacing: 0.05em;
  
  &.active {
    background: $status-active-bg;
    color: $status-active;
  }
  
  &.pending {
    background: $status-pending-bg;
    color: $status-pending;
  }
  
  &.expired {
    background: $status-expired-bg;
    color: $status-expired;
  }
  
  &.inactive {
    background: $status-inactive-bg;
    color: $status-inactive;
  }
}
```

### 2. Toast Notifications
```html
<!-- Notificaciones toast -->
<div class="toast-container">
  <div class="toast success">
    <div class="toast-icon">
      <i class="icon-check-circle"></i>
    </div>
    <div class="toast-content">
      <div class="toast-title">¡Éxito!</div>
      <div class="toast-message">La suscripción ha sido creada correctamente</div>
    </div>
    <button class="toast-close">
      <i class="icon-x"></i>
    </button>
  </div>
</div>
```

```scss
.toast-container {
  position: fixed;
  top: $space-6;
  right: $space-6;
  z-index: 1000;
  display: flex;
  flex-direction: column;
  gap: $space-3;
}

.toast {
  display: flex;
  align-items: flex-start;
  gap: $space-3;
  padding: $space-4;
  background: $primary-white;
  border-radius: 8px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
  border-left: 4px solid;
  min-width: 320px;
  animation: slideIn 0.3s ease;
  
  &.success {
    border-left-color: $status-active;
    
    .toast-icon {
      color: $status-active;
    }
  }
  
  &.error {
    border-left-color: $status-expired;
    
    .toast-icon {
      color: $status-expired;
    }
  }
  
  &.warning {
    border-left-color: $status-pending;
    
    .toast-icon {
      color: $status-pending;
    }
  }
  
  .toast-icon {
    width: 20px;
    height: 20px;
    margin-top: 2px;
  }
  
  .toast-content {
    flex: 1;
    
    .toast-title {
      font-weight: $font-weight-semibold;
      font-size: $font-size-sm;
      color: $gray-900;
      margin-bottom: $space-1;
    }
    
    .toast-message {
      font-size: $font-size-sm;
      color: $gray-600;
    }
  }
  
  .toast-close {
    background: none;
    border: none;
    color: $gray-500;
    cursor: pointer;
    padding: 0;
    
    &:hover {
      color: $gray-700;
    }
  }
}

@keyframes slideIn {
  from {
    transform: translateX(100%);
    opacity: 0;
  }
  to {
    transform: translateX(0);
    opacity: 1;
  }
}
```

---

## Componentes de Dashboard

### 1. Chart Container
```html
<!-- Contenedor para gráficos -->
<div class="chart-container">
  <div class="chart-header">
    <div class="chart-title">
      <h3>Tendencias de Pago</h3>
      <p>Últimos 6 meses • ↑ +8%</p>
    </div>
    <div class="chart-controls">
      <select class="chart-period">
        <option value="6m">6 meses</option>
        <option value="1y">1 año</option>
        <option value="2y">2 años</option>
      </select>
    </div>
  </div>
  
  <div class="chart-content">
    <canvas id="paymentTrendsChart"></canvas>
  </div>
  
  <div class="chart-legend">
    <div class="legend-item">
      <div class="legend-color primary"></div>
      <span>Pagos Recibidos</span>
    </div>
    <div class="legend-item">
      <div class="legend-color secondary"></div>
      <span>Pagos Pendientes</span>
    </div>
  </div>
</div>
```

```scss
.chart-container {
  background: $primary-white;
  border-radius: 12px;
  border: 1px solid $gray-200;
  padding: $space-6;
  
  .chart-header {
    display: flex;
    justify-content: space-between;
    align-items: flex-start;
    margin-bottom: $space-6;
    
    .chart-title {
      h3 {
        margin: 0 0 $space-1 0;
        font-size: $font-size-lg;
        font-weight: $font-weight-semibold;
        color: $gray-900;
      }
      
      p {
        margin: 0;
        font-size: $font-size-sm;
        color: $gray-600;
      }
    }
    
    .chart-period {
      padding: $space-2 $space-3;
      border: 1px solid $gray-300;
      border-radius: 6px;
      background: $primary-white;
      font-size: $font-size-sm;
    }
  }
  
  .chart-content {
    height: 300px;
    margin-bottom: $space-4;
  }
  
  .chart-legend {
    display: flex;
    gap: $space-6;
    justify-content: center;
    
    .legend-item {
      display: flex;
      align-items: center;
      gap: $space-2;
      font-size: $font-size-sm;
      color: $gray-700;
      
      .legend-color {
        width: 12px;
        height: 12px;
        border-radius: 2px;
        
        &.primary { background: $gold-medium; }
        &.secondary { background: $gray-400; }
      }
    }
  }
}
```

### 2. Activity Feed
```html
<!-- Feed de actividad reciente -->
<div class="activity-feed">
  <div class="feed-header">
    <h3>Actividad Reciente</h3>
    <button class="btn-text">Ver todas</button>
  </div>
  
  <div class="feed-items">
    <div class="feed-item">
      <div class="feed-icon success">
        <i class="icon-check"></i>
      </div>
      <div class="feed-content">
        <div class="feed-title">Pago procesado</div>
        <div class="feed-description">Sophia Carter pagó $25.00 por suscripción Premium</div>
        <div class="feed-time">Hace 2 horas</div>
      </div>
    </div>
    
    <div class="feed-item">
      <div class="feed-icon warning">
        <i class="icon-clock"></i>
      </div>
      <div class="feed-content">
        <div class="feed-title">Recordatorio enviado</div>
        <div class="feed-description">Se envió recordatorio de pago a 5 miembros</div>
        <div class="feed-time">Hace 4 horas</div>
      </div>
    </div>
    
    <div class="feed-item">
      <div class="feed-icon info">
        <i class="icon-user-plus"></i>
      </div>
      <div class="feed-content">
        <div class="feed-title">Nuevo miembro</div>
        <div class="feed-description">John Doe se registró con plan Básico</div>
        <div class="feed-time">Ayer</div>
      </div>
    </div>
  </div>
</div>
```

```scss
.activity-feed {
  background: $primary-white;
  border-radius: 12px;
  border: 1px solid $gray-200;
  padding: $space-6;
  
  .feed-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: $space-6;
    
    h3 {
      margin: 0;
      font-size: $font-size-lg;
      font-weight: $font-weight-semibold;
      color: $gray-900;
    }
    
    .btn-text {
      background: none;
      border: none;
      color: $gold-medium;
      font-size: $font-size-sm;
      font-weight: $font-weight-medium;
      cursor: pointer;
      
      &:hover {
        color: $gold-dark;
      }
    }
  }
  
  .feed-items {
    display: flex;
    flex-direction: column;
    gap: $space-4;
  }
  
  .feed-item {
    display: flex;
    gap: $space-3;
    
    .feed-icon {
      width: 32px;
      height: 32px;
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      flex-shrink: 0;
      
      i {
        width: 16px;
        height: 16px;
      }
      
      &.success {
        background: $status-active-bg;
        color: $status-active;
      }
      
      &.warning {
        background: $status-pending-bg;
        color: $status-pending;
      }
      
      &.info {
        background: $gold-light;
        color: $gold-dark;
      }
    }
    
    .feed-content {
      flex: 1;
      
      .feed-title {
        font-size: $font-size-sm;
        font-weight: $font-weight-medium;
        color: $gray-900;
        margin-bottom: $space-1;
      }
      
      .feed-description {
        font-size: $font-size-sm;
        color: $gray-600;
        margin-bottom: $space-1;
      }
      
      .feed-time {
        font-size: $font-size-xs;
        color: $gray-500;
      }
    }
  }
}
```

---

## Patrones de Uso

### Inicialización de Componentes
```javascript
// Inicialización de componentes con jQuery
$(document).ready(function() {
  // Inicializar tooltips
  $('[data-tooltip]').tooltip();
  
  // Inicializar select con búsqueda
  $('.select-search').select2({
    theme: 'bootstrap-5'
  });
  
  // Inicializar tablas ordenables
  $('.data-table').DataTable({
    order: [[0, 'asc']],
    pageLength: 10,
    responsive: true
  });
  
  // Manejo de sidebar en móvil
  $('.sidebar-toggle').click(function() {
    $('.sidebar').toggleClass('open');
  });
});
```

### Manejo de Estados
```javascript
// Funciones para manejo de estados
function showToast(type, title, message) {
  const toast = `
    <div class="toast ${type}">
      <div class="toast-icon">
        <i class="icon-${type === 'success' ? 'check-circle' : 'alert-circle'}"></i>
      </div>
      <div class="toast-content">
        <div class="toast-title">${title}</div>
        <div class="toast-message">${message}</div>
      </div>
      <button class="toast-close">
        <i class="icon-x"></i>
      </button>
    </div>
  `;
  
  $('.toast-container').append(toast);
  
  // Auto-remove después de 5 segundos
  setTimeout(() => {
    $('.toast').last().fadeOut(() => {
      $(this).remove();
    });
  }, 5000);
}

// Actualizar métricas del dashboard
function updateMetric(selector, value, change) {
  $(selector).find('.metric-value').text(value);
  const changeEl = $(selector).find('.metric-change');
  changeEl.removeClass('positive negative');
  changeEl.addClass(change >= 0 ? 'positive' : 'negative');
  changeEl.html(`<i class="icon-trending-${change >= 0 ? 'up' : 'down'}"></i>${change >= 0 ? '+' : ''}${change}%`);
}
```

Esta biblioteca de componentes proporciona una base sólida y consistente para el desarrollo frontend, manteniendo el estilo visual de Harmony Hub mientras se adapta a las necesidades específicas del Coro Polyphonia y su sistema de gestión financiera.
