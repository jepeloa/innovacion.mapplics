# Documentación de Flujos de Usuario - Coro Polyphonia (Versión Simplificada)

> Flujos detallados de navegación para la gestión financiera del Coro Polyphonia (58 miembros)
> **Base**: Funcionalidades simplificadas + Inspiración visual Harmony Hub

## Índice
1. [Arquitectura de Navegación Simplificada](#arquitectura-de-navegación-simplificada)
2. [Flujos del Tesorero/Administrador](#flujos-del-tesorero-administrador)
3. [Flujos del Miembro Activo](#flujos-del-miembro-activo)
4. [Flujos Compartidos](#flujos-compartidos)
5. [Interacciones Específicas del Coro](#interacciones-específicas-del-coro)

---

## Arquitectura de Navegación Simplificada

### Estructura General
```
Coro Polyphonia Manager/
├── Autenticación
│   ├── Login
│   └── Recuperar contraseña
├── Dashboard (Rol-específico)
│   ├── Tesorero Dashboard
│   └── Miembro Dashboard  
├── Gestión Financiera (Solo Tesorero)
│   ├── Cuotas Mensuales
│   ├── Gastos del Coro
│   ├── Reportes Financieros
│   └── Lista de Miembros
├── Mi Cuenta (Ambos roles)
│   ├── Estado de cuenta
│   ├── Información personal
│   └── Configuración básica
└── Información
    ├── Transparencia financiera (opcional)
    └── Ayuda
```

### Navegación Principal Simplificada
```html
<!-- Para Tesorero/Administrador -->
<nav class="sidebar">
  <a href="/dashboard" class="nav-item active">
    <i class="icon-dashboard"></i>
    <span>Resumen</span>
  </a>
  <a href="/cuotas" class="nav-item">
    <i class="icon-money"></i>
    <span>Cuotas</span>
  </a>
  <a href="/gastos" class="nav-item">
    <i class="icon-expense"></i>
    <span>Gastos</span>
  </a>
  <a href="/reportes" class="nav-item">
    <i class="icon-report"></i>
    <span>Reportes</span>
  </a>
  <a href="/miembros" class="nav-item">
    <i class="icon-users"></i>
    <span>Miembros</span>
  </a>
</nav>

<!-- Para Miembro Activo -->
<nav class="sidebar">
  <a href="/dashboard" class="nav-item active">
    <i class="icon-dashboard"></i>
    <span>Mi Estado</span>
  </a>
  <a href="/cuenta" class="nav-item">
    <i class="icon-account"></i>
    <span>Mi Cuenta</span>
  </a>
  <a href="/transparencia" class="nav-item">
    <i class="icon-info"></i>
    <span>Finanzas del Coro</span>
  </a>
</nav>
```
    <span>Suscripciones</span>
  </a>
  <a href="/members" class="nav-item">
    <i class="icon-members"></i>
    <span>Miembros</span>
  </a>
  <a href="/payments" class="nav-item">
    <i class="icon-payments"></i>
    <span>Pagos</span>
  </a>
  <a href="/reports" class="nav-item">
    <i class="icon-reports"></i>
    <span>Reportes</span>
  </a>
  <a href="/settings" class="nav-item">
    <i class="icon-settings"></i>
    <span>Configuración</span>
  </a>
</nav>
```

---

## Flujos del Administrador

### 1. Dashboard Administrativo

#### Entrada al Sistema
```
1. Login → 2. Validación → 3. Redirect Dashboard Admin
```

#### Estructura del Dashboard
```html
<!-- Layout inspirado en Harmony Hub Payment Dashboard -->
<div class="admin-dashboard">
  <!-- Métricas principales -->
  <div class="metrics-row">
    <div class="metric-card">
      <div class="metric-value">150</div>
      <div class="metric-label">Suscripciones Activas</div>
      <div class="metric-change positive">+15%</div>
    </div>
    <div class="metric-card">
      <div class="metric-value">$12,500</div>
      <div class="metric-label">Ingresos Mensuales</div>
      <div class="metric-change positive">+8%</div>
    </div>
    <div class="metric-card">
      <div class="metric-value">5</div>
      <div class="metric-label">Pagos Pendientes</div>
      <div class="metric-change negative">-2</div>
    </div>
    <div class="metric-card">
      <div class="metric-value">12</div>
      <div class="metric-label">Nuevos Miembros</div>
      <div class="metric-change positive">+3</div>
    </div>
  </div>
  
  <!-- Gráfico de tendencias -->
  <div class="chart-section">
    <div class="chart-card">
      <h3>Crecimiento de Suscripciones</h3>
      <canvas id="subscriptionChart"></canvas>
    </div>
  </div>
  
  <!-- Acciones rápidas -->
  <div class="quick-actions">
    <button class="btn-primary">
      <i class="icon-plus"></i>
      Nueva Suscripción
    </button>
    <button class="btn-secondary">
      <i class="icon-send"></i>
      Enviar Recordatorios
    </button>
  </div>
  
  <!-- Transacciones recientes -->
  <div class="recent-activity">
    <h3>Actividad Reciente</h3>
    <div class="activity-list">
      <!-- Items de actividad -->
    </div>
  </div>
</div>
```

### 2. Gestión de Suscripciones

#### Flujo: Ver Lista de Suscripciones
```
Dashboard → Click "Suscripciones" → Lista con filtros y búsqueda
```

#### Estructura de la Lista
```html
<!-- Inspirado en Harmony Hub Subscriptions List -->
<div class="subscriptions-page">
  <!-- Header con acciones -->
  <div class="page-header">
    <h1>Suscripciones</h1>
    <button class="btn-primary">
      <i class="icon-plus"></i>
      Agregar Suscripción
    </button>
  </div>
  
  <!-- Barra de búsqueda y filtros -->
  <div class="search-filters">
    <div class="search-bar">
      <input type="text" placeholder="Buscar por nombre, email, estado...">
      <i class="search-icon"></i>
    </div>
    <div class="filter-group">
      <select name="status">
        <option value="">Estado</option>
        <option value="active">Activo</option>
        <option value="pending">Pendiente</option>
        <option value="expired">Expirado</option>
      </select>
      <select name="plan">
        <option value="">Plan</option>
        <option value="basic">Básico</option>
        <option value="premium">Premium</option>
        <option value="family">Familiar</option>
      </select>
      <button class="btn-secondary">
        <i class="icon-filter"></i>
        Filtrar
      </button>
    </div>
  </div>
  
  <!-- Tabla de suscripciones -->
  <div class="data-table">
    <table>
      <thead>
        <tr>
          <th>Miembro</th>
          <th>Plan</th>
          <th>Estado</th>
          <th>Método de Pago</th>
          <th>Próximo Pago</th>
          <th>Monto</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
            <div class="member-cell">
              <div class="member-avatar">SC</div>
              <div class="member-info">
                <div class="member-name">Sophia Carter</div>
                <div class="member-email">sophia@example.com</div>
              </div>
            </div>
          </td>
          <td><span class="plan-badge premium">Premium</span></td>
          <td><span class="status-badge active">Activo</span></td>
          <td>Tarjeta ****1234</td>
          <td>2024-08-15</td>
          <td>$25.00</td>
          <td>
            <div class="action-buttons">
              <button class="btn-action edit">Editar</button>
              <button class="btn-action delete">Eliminar</button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</div>
```

#### Flujo: Agregar Nueva Suscripción
```
Lista Suscripciones → Click "Agregar" → Modal/Página Formulario → Validación → Confirmación → Actualización Lista
```

#### Modal de Agregar Suscripción
```html
<div class="modal-overlay">
  <div class="modal-content">
    <div class="modal-header">
      <h2>Nueva Suscripción</h2>
      <button class="modal-close">&times;</button>
    </div>
    <form class="subscription-form">
      <div class="form-section">
        <h3>Información del Miembro</h3>
        <div class="form-group">
          <label>Nombre Completo *</label>
          <input type="text" required>
        </div>
        <div class="form-group">
          <label>Email *</label>
          <input type="email" required>
        </div>
        <div class="form-group">
          <label>Teléfono</label>
          <input type="tel">
        </div>
      </div>
      
      <div class="form-section">
        <h3>Detalles de Suscripción</h3>
        <div class="form-group">
          <label>Tipo de Plan *</label>
          <select required>
            <option value="">Seleccionar plan</option>
            <option value="basic">Básico - $10/mes</option>
            <option value="premium">Premium - $25/mes</option>
            <option value="family">Familiar - $40/mes</option>
          </select>
        </div>
        <div class="form-group">
          <label>Fecha de Inicio *</label>
          <input type="date" required>
        </div>
        <div class="form-group">
          <label>Método de Pago *</label>
          <select required>
            <option value="">Seleccionar método</option>
            <option value="credit-card">Tarjeta de Crédito</option>
            <option value="paypal">PayPal</option>
            <option value="bank-transfer">Transferencia Bancaria</option>
          </select>
        </div>
      </div>
      
      <div class="form-actions">
        <button type="button" class="btn-secondary">Cancelar</button>
        <button type="submit" class="btn-primary">Crear Suscripción</button>
      </div>
    </form>
  </div>
</div>
```

### 3. Gestión de Pagos

#### Dashboard de Pagos (Inspirado en Harmony Hub Payments)
```html
<div class="payments-dashboard">
  <!-- Pestañas de navegación -->
  <div class="tab-navigation">
    <button class="tab-btn active">Resumen</button>
    <button class="tab-btn">Transacciones</button>
    <button class="tab-btn">Recordatorios</button>
  </div>
  
  <!-- Resumen de pagos -->
  <div class="payment-summary">
    <div class="summary-card">
      <div class="summary-value">$12,500</div>
      <div class="summary-label">Total Recaudado</div>
      <div class="summary-change positive">↑ +10%</div>
    </div>
    <div class="summary-card">
      <div class="summary-value">$2,300</div>
      <div class="summary-label">Pagos Pendientes</div>
      <div class="summary-change negative">↓ -5%</div>
    </div>
    <div class="summary-card">
      <div class="summary-value">$125</div>
      <div class="summary-label">Pago Promedio</div>
      <div class="summary-change positive">↑ +2%</div>
    </div>
  </div>
  
  <!-- Gráfico de tendencias -->
  <div class="payment-trends">
    <h3>Tendencias de Pago</h3>
    <div class="trend-metric">
      <span>Pagos Mensuales</span>
      <span class="trend-value">$2,500</span>
      <span class="trend-period">Últimos 6 meses ↑ +8%</span>
    </div>
    <canvas id="paymentChart"></canvas>
  </div>
  
  <!-- Acciones de pago -->
  <div class="payment-actions">
    <button class="btn-primary">
      <i class="icon-record"></i>
      Registrar Pago
    </button>
    <button class="btn-secondary">
      <i class="icon-send"></i>
      Enviar Recordatorios
    </button>
  </div>
  
  <!-- Transacciones recientes -->
  <div class="recent-transactions">
    <h3>Transacciones Recientes</h3>
    <table class="transactions-table">
      <thead>
        <tr>
          <th>Miembro</th>
          <th>Monto</th>
          <th>Fecha</th>
          <th>Estado</th>
          <th>Método</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Sophia Clark</td>
          <td>$190</td>
          <td>2024-07-26</td>
          <td><span class="status-paid">Pagado</span></td>
          <td>Tarjeta</td>
        </tr>
        <!-- Más transacciones -->
      </tbody>
    </table>
  </div>
</div>
```

---

## Flujos del Miembro

### 1. Dashboard del Miembro

#### Vista Principal del Miembro
```html
<div class="member-dashboard">
  <!-- Estado de suscripción principal -->
  <div class="subscription-status-card">
    <div class="status-header">
      <h2>Mi Suscripción</h2>
      <span class="status-badge active">Activa</span>
    </div>
    <div class="subscription-details">
      <div class="detail-item">
        <span class="label">Plan</span>
        <span class="value">Premium</span>
      </div>
      <div class="detail-item">
        <span class="label">Próximo pago</span>
        <span class="value">15 de Julio, 2024</span>
      </div>
      <div class="detail-item">
        <span class="label">Método de pago</span>
        <span class="value">Tarjeta ****1234</span>
      </div>
    </div>
    <div class="subscription-actions">
      <button class="btn-secondary">
        <i class="icon-credit-card"></i>
        Actualizar Pago
      </button>
      <button class="btn-outline">
        <i class="icon-cancel"></i>
        Cancelar Suscripción
      </button>
    </div>
  </div>
  
  <!-- Información personal -->
  <div class="personal-info-card">
    <h3>Información Personal</h3>
    <div class="info-grid">
      <div class="info-item">
        <label>Nombre</label>
        <span>Jane Doe</span>
      </div>
      <div class="info-item">
        <label>Email</label>
        <span>jane.doe@example.com</span>
      </div>
      <div class="info-item">
        <label>Teléfono</label>
        <span>(555) 123-4567</span>
      </div>
      <div class="info-item">
        <label>Dirección</label>
        <span>123 Harmony Lane, Musicville, CA 90210</span>
      </div>
    </div>
    <button class="btn-primary">
      <i class="icon-edit"></i>
      Actualizar Información
    </button>
  </div>
  
  <!-- Notificaciones recientes -->
  <div class="notifications-card">
    <h3>Notificaciones</h3>
    <div class="notification-list">
      <div class="notification-item">
        <div class="notification-icon reminder"></div>
        <div class="notification-content">
          <div class="notification-title">Recordatorio de Renovación</div>
          <div class="notification-date">2023-11-15</div>
        </div>
      </div>
      <div class="notification-item">
        <div class="notification-icon welcome"></div>
        <div class="notification-content">
          <div class="notification-title">Bienvenida de Nuevo Miembro</div>
          <div class="notification-date">2023-11-10</div>
        </div>
      </div>
    </div>
  </div>
</div>
```

### 2. Actualización de Información Personal

#### Flujo: Editar Perfil
```
Dashboard → Click "Actualizar Información" → Formulario Editable → Validación → Confirmación → Actualización Vista
```

#### Formulario de Edición
```html
<div class="edit-profile-form">
  <div class="form-header">
    <h2>Actualizar Información Personal</h2>
    <p>Mantén tu información actualizada para una mejor experiencia</p>
  </div>
  
  <form class="profile-form">
    <div class="form-section">
      <h3>Información Básica</h3>
      <div class="form-row">
        <div class="form-group half">
          <label>Nombre *</label>
          <input type="text" value="Jane" required>
        </div>
        <div class="form-group half">
          <label>Apellido *</label>
          <input type="text" value="Doe" required>
        </div>
      </div>
      <div class="form-group">
        <label>Email *</label>
        <input type="email" value="jane.doe@example.com" required>
      </div>
      <div class="form-group">
        <label>Teléfono</label>
        <input type="tel" value="(555) 123-4567">
      </div>
    </div>
    
    <div class="form-section">
      <h3>Dirección</h3>
      <div class="form-group">
        <label>Dirección</label>
        <textarea>123 Harmony Lane, Musicville, CA 90210</textarea>
      </div>
    </div>
    
    <div class="form-actions">
      <button type="button" class="btn-secondary">Cancelar</button>
      <button type="submit" class="btn-primary">Guardar Cambios</button>
    </div>
  </form>
</div>
```

---

## Flujos Compartidos

### 1. Sistema de Notificaciones

#### Dropdown de Notificaciones
```html
<div class="notifications-dropdown">
  <div class="dropdown-header">
    <h3>Notificaciones</h3>
    <button class="mark-all-read">Marcar como leídas</button>
  </div>
  
  <div class="notifications-list">
    <div class="notification-item unread">
      <div class="notification-dot"></div>
      <div class="notification-content">
        <div class="notification-title">Pago procesado exitosamente</div>
        <div class="notification-text">Tu pago de $25 ha sido procesado</div>
        <div class="notification-time">Hace 2 horas</div>
      </div>
    </div>
    <!-- Más notificaciones -->
  </div>
  
  <div class="dropdown-footer">
    <a href="/notifications">Ver todas las notificaciones</a>
  </div>
</div>
```

### 2. Estados de Error y Éxito

#### Mensaje de Éxito
```html
<div class="toast success">
  <div class="toast-icon">✓</div>
  <div class="toast-content">
    <div class="toast-title">¡Éxito!</div>
    <div class="toast-message">La suscripción ha sido creada correctamente</div>
  </div>
  <button class="toast-close">&times;</button>
</div>
```

#### Mensaje de Error
```html
<div class="toast error">
  <div class="toast-icon">⚠</div>
  <div class="toast-content">
    <div class="toast-title">Error</div>
    <div class="toast-message">No se pudo procesar el pago. Por favor, intenta de nuevo.</div>
  </div>
  <button class="toast-close">&times;</button>
</div>
```

---

## Interacciones y Microanimaciones

### 1. Transiciones de Navegación
```css
/* Transición suave entre páginas */
.page-transition {
  opacity: 0;
  transform: translateY(20px);
  transition: all 0.3s ease;
}

.page-transition.loaded {
  opacity: 1;
  transform: translateY(0);
}

/* Hover en elementos de navegación */
.nav-item {
  transition: all 0.2s ease;
}

.nav-item:hover {
  background: var(--gold-light);
  transform: translateX(4px);
}
```

### 2. Estados de Botones
```css
/* Efectos de botones inspirados en Harmony Hub */
.btn-primary {
  transition: all 0.2s ease;
}

.btn-primary:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(247, 197, 45, 0.3);
}

.btn-primary:active {
  transform: translateY(0);
}
```

### 3. Loading States
```css
/* Skeleton loading para tablas */
.skeleton-row {
  background: linear-gradient(90deg, #f0f0f0 25%, #e0e0e0 50%, #f0f0f0 75%);
  background-size: 200% 100%;
  animation: loading 1.5s infinite;
}

@keyframes loading {
  0% { background-position: 200% 0; }
  100% { background-position: -200% 0; }
}
```

---

## Estados de Carga

### 1. Carga de Dashboard
```html
<!-- Estado inicial mientras cargan las métricas -->
<div class="dashboard-loading">
  <div class="metrics-skeleton">
    <div class="metric-skeleton"></div>
    <div class="metric-skeleton"></div>
    <div class="metric-skeleton"></div>
    <div class="metric-skeleton"></div>
  </div>
  <div class="chart-skeleton"></div>
</div>
```

### 2. Carga de Tablas
```html
<!-- Filas skeleton mientras cargan datos -->
<tbody class="table-loading">
  <tr class="skeleton-row">
    <td><div class="skeleton-text"></div></td>
    <td><div class="skeleton-text short"></div></td>
    <td><div class="skeleton-badge"></div></td>
    <td><div class="skeleton-text"></div></td>
    <td><div class="skeleton-text short"></div></td>
    <td><div class="skeleton-actions"></div></td>
  </tr>
  <!-- Repetir para más filas -->
</tbody>
```

### 3. Estados Vacíos
```html
<!-- Cuando no hay datos para mostrar -->
<div class="empty-state">
  <div class="empty-icon">
    <i class="icon-inbox"></i>
  </div>
  <h3>No hay suscripciones aún</h3>
  <p>Comienza agregando la primera suscripción del coro</p>
  <button class="btn-primary">
    <i class="icon-plus"></i>
    Agregar Primera Suscripción
  </button>
</div>
```

---

## Responsive Behavior

### 1. Adaptación Mobile
```css
/* Sidebar colapsable en móvil */
@media (max-width: 768px) {
  .sidebar {
    transform: translateX(-100%);
    transition: transform 0.3s ease;
  }
  
  .sidebar.open {
    transform: translateX(0);
  }
  
  /* Métricas en columna única */
  .metrics-row {
    grid-template-columns: 1fr;
    gap: 1rem;
  }
  
  /* Tabla horizontal scroll */
  .data-table {
    overflow-x: auto;
  }
}
```

### 2. Tablet Adaptation
```css
@media (max-width: 992px) {
  /* Métricas en 2 columnas */
  .metrics-row {
    grid-template-columns: repeat(2, 1fr);
  }
  
  /* Formularios de ancho completo */
  .form-row .form-group.half {
    width: 100%;
  }
}
```

Esta documentación proporciona a los desarrolladores frontend todo lo necesario para implementar los flujos de usuario de manera consistente, siguiendo los patrones visuales establecidos y manteniendo la funcionalidad definida en los requerimientos originales.
