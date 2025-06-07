# Inspiración Visual: Harmony Hub
## Adaptación para la Gestión Financiera del Coro Polyphonia

> **Nota Importante**: Las capturas de Harmony Hub proporcionadas sirven únicamente como inspiración visual para elementos de diseño, layout y componentes. NO definen la funcionalidad ni los flujos de usuario del sistema de gestión financiera del Coro Polyphonia, que mantiene su propia lógica específica para:
> - Gestión de cuotas mensuales de 58 integrantes
> - Control de gastos operativos del coro
> - Reportes de transparencia financiera
> - Gestión colaborativa e independiente

---

## Contexto del Coro Polyphonia
- **58 integrantes activos** con funcionamiento colaborativo
- **Gestión financiera independiente** desde 2013
- **Transparencia total** en manejo de fondos
- **Simplicidad de uso** para usuarios de todas las edades
- **Optimización móvil** para uso durante ensayos

---

## Análisis Visual de las Capturas

### Captura 1: Dashboard Principal
**Elementos Visuales Inspiradores:**
- Layout limpio con navegación lateral (sidebar)
- Cards de métricas con íconos prominentes
- Uso de espacios blancos generosos
- Tipografía clara y jerarquizada
- Colores suaves y profesionales

**Aplicación en Polyphonia Hub:**
```html
<!-- Dashboard Principal inspirado en Harmony Hub -->
<div class="dashboard-layout">
    <aside class="sidebar-choir">
        <nav class="nav-choir">
            <a href="#dashboard" class="nav-item-choir active">
                <i class="icon-dashboard"></i>
                <span>Dashboard</span>
            </a>
            <a href="#subscriptions" class="nav-item-choir">
                <i class="icon-subscriptions"></i>
                <span>Suscripciones</span>
            </a>
            <a href="#members" class="nav-item-choir">
                <i class="icon-members"></i>
                <span>Miembros</span>
            </a>
            <a href="#payments" class="nav-item-choir">
                <i class="icon-payments"></i>
                <span>Pagos</span>
            </a>
        </nav>
    </aside>
    
    <main class="main-content-choir">
        <header class="page-header-choir">
            <h1 class="page-title-choir">Dashboard de Suscripciones</h1>
            <p class="page-subtitle-choir">Resumen general del estado del coro</p>
        </header>
        
        <div class="metrics-grid-choir">
            <div class="metric-card-choir">
                <div class="metric-icon-choir gold">
                    <i class="icon-users"></i>
                </div>
                <div class="metric-content-choir">
                    <h3 class="metric-title-choir">Miembros Activos</h3>
                    <p class="metric-value-choir">45</p>
                    <p class="metric-trend-choir positive">+5 este mes</p>
                </div>
            </div>
            
            <div class="metric-card-choir">
                <div class="metric-icon-choir gold">
                    <i class="icon-dollar"></i>
                </div>
                <div class="metric-content-choir">
                    <h3 class="metric-title-choir">Ingresos Mensuales</h3>
                    <p class="metric-value-choir">$2,250</p>
                    <p class="metric-trend-choir positive">+12% vs mes anterior</p>
                </div>
            </div>
        </div>
    </main>
</div>
```

### Captura 2: Lista/Tabla de Datos
**Elementos Visuales Inspiradores:**
- Tablas limpias con alternancia de filas
- Headers destacados
- Acciones en contexto (botones de acción por fila)
- Badges de estado coloridos
- Filtros y búsqueda integrados

**Aplicación en Polyphonia Hub:**
```html
<!-- Lista de Suscripciones inspirada en Harmony Hub -->
<div class="data-table-container-choir">
    <div class="table-header-choir">
        <h2 class="table-title-choir">Suscripciones Activas</h2>
        <div class="table-actions-choir">
            <div class="search-box-choir">
                <input type="text" placeholder="Buscar miembro..." class="search-input-choir">
                <i class="icon-search"></i>
            </div>
            <button class="btn-primary-choir">
                <i class="icon-plus"></i>
                Nueva Suscripción
            </button>
        </div>
    </div>
    
    <div class="table-wrapper-choir">
        <table class="table-choir">
            <thead class="table-head-choir">
                <tr>
                    <th>Miembro</th>
                    <th>Plan</th>
                    <th>Estado</th>
                    <th>Próximo Pago</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody class="table-body-choir">
                <tr class="table-row-choir">
                    <td class="table-cell-choir">
                        <div class="member-info-choir">
                            <div class="member-avatar-choir">JD</div>
                            <div class="member-details-choir">
                                <p class="member-name-choir">Juan Pérez</p>
                                <p class="member-email-choir">juan@email.com</p>
                            </div>
                        </div>
                    </td>
                    <td class="table-cell-choir">
                        <span class="plan-badge-choir gold">Premium</span>
                    </td>
                    <td class="table-cell-choir">
                        <span class="status-badge-choir active">Activa</span>
                    </td>
                    <td class="table-cell-choir">15 Feb 2024</td>
                    <td class="table-cell-choir">
                        <div class="action-buttons-choir">
                            <button class="btn-sm-choir btn-outline-choir">Ver</button>
                            <button class="btn-sm-choir btn-outline-choir">Editar</button>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
```

### Captura 3: Formularios y Detalles
**Elementos Visuales Inspiradores:**
- Layout de dos columnas para formularios
- Campos de entrada con labels claros
- Secciones bien definidas
- Botones de acción prominentes
- Uso de cards para agrupar información relacionada

**Aplicación en Polyphonia Hub:**
```html
<!-- Formulario de Suscripción inspirado en Harmony Hub -->
<div class="form-layout-choir">
    <div class="form-header-choir">
        <h1 class="form-title-choir">Nueva Suscripción</h1>
        <p class="form-subtitle-choir">Registra una nueva suscripción para un miembro del coro</p>
    </div>
    
    <div class="form-content-choir">
        <div class="form-section-choir">
            <div class="section-header-choir">
                <h3 class="section-title-choir">Información del Miembro</h3>
            </div>
            <div class="form-grid-choir">
                <div class="form-group-choir">
                    <label class="form-label-choir" for="member-name">Nombre Completo</label>
                    <input type="text" id="member-name" class="form-input-choir" placeholder="Ingresa el nombre completo">
                </div>
                <div class="form-group-choir">
                    <label class="form-label-choir" for="member-email">Email</label>
                    <input type="email" id="member-email" class="form-input-choir" placeholder="email@ejemplo.com">
                </div>
            </div>
        </div>
        
        <div class="form-section-choir">
            <div class="section-header-choir">
                <h3 class="section-title-choir">Detalles de Suscripción</h3>
            </div>
            <div class="form-grid-choir">
                <div class="form-group-choir">
                    <label class="form-label-choir" for="subscription-plan">Plan de Suscripción</label>
                    <select id="subscription-plan" class="form-select-choir">
                        <option value="">Selecciona un plan</option>
                        <option value="basic">Básico - $25/mes</option>
                        <option value="premium">Premium - $50/mes</option>
                    </select>
                </div>
                <div class="form-group-choir">
                    <label class="form-label-choir" for="start-date">Fecha de Inicio</label>
                    <input type="date" id="start-date" class="form-input-choir">
                </div>
            </div>
        </div>
    </div>
    
    <div class="form-actions-choir">
        <button class="btn-secondary-choir">Cancelar</button>
        <button class="btn-primary-choir">
            <i class="icon-save"></i>
            Crear Suscripción
        </button>
    </div>
</div>
```

---

## Componentes CSS Inspirados en Harmony Hub

### Paleta de Colores Harmony Hub adaptada
```scss
// Inspirado en el estilo visual de Harmony Hub pero con nuestra identidad
$harmony-inspired-palette: (
    // Blanco como base (limpieza y respiración)
    'surface-primary': #FFFFFF,
    'surface-secondary': #FAFAFA,
    'surface-tertiary': #F5F5F5,
    
    // Dorado como acento principal (elegancia y calidez)
    'accent-primary': #F7C52D,      // Dorado principal
    'accent-light': #FFF4CC,        // Dorado claro para fondos
    'accent-dark': #E6B800,         // Dorado oscuro para hover
    
    // Negro para contraste y definición
    'text-primary': #1A1A1A,        // Negro principal
    'text-secondary': #4A4A4A,      // Gris oscuro
    'text-tertiary': #757575,       // Gris medio
    
    // Colores funcionales manteniendo la armonía
    'success': #10B981,             // Verde para estados activos
    'warning': #F59E0B,             // Amarillo para advertencias
    'error': #EF4444,               // Rojo para errores
    'info': #3B82F6                 // Azul para información
);
```

### Sidebar Navigation (Inspirado en Harmony Hub)
```scss
.sidebar-choir {
    width: 280px;
    background: $harmony-inspired-palette('surface-primary');
    border-right: 1px solid #E5E7EB;
    height: 100vh;
    position: fixed;
    left: 0;
    top: 0;
    z-index: 100;
    
    .nav-choir {
        padding: 2rem 0;
        
        .nav-item-choir {
            display: flex;
            align-items: center;
            padding: 0.75rem 2rem;
            color: $harmony-inspired-palette('text-secondary');
            text-decoration: none;
            font-weight: 500;
            transition: all 0.2s ease;
            border-left: 3px solid transparent;
            
            &:hover {
                background: $harmony-inspired-palette('accent-light');
                color: $harmony-inspired-palette('text-primary');
                border-left-color: $harmony-inspired-palette('accent-primary');
            }
            
            &.active {
                background: $harmony-inspired-palette('accent-light');
                color: $harmony-inspired-palette('text-primary');
                border-left-color: $harmony-inspired-palette('accent-primary');
                font-weight: 600;
            }
            
            i {
                margin-right: 0.75rem;
                font-size: 1.25rem;
                color: $harmony-inspired-palette('accent-primary');
            }
        }
    }
}
```

### Metric Cards (Inspirado en Harmony Hub)
```scss
.metric-card-choir {
    background: $harmony-inspired-palette('surface-primary');
    border: 1px solid #E5E7EB;
    border-radius: 12px;
    padding: 2rem;
    box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
    transition: all 0.2s ease;
    
    &:hover {
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
        transform: translateY(-2px);
    }
    
    .metric-icon-choir {
        width: 60px;
        height: 60px;
        border-radius: 12px;
        display: flex;
        align-items: center;
        justify-content: center;
        margin-bottom: 1.5rem;
        
        &.gold {
            background: $harmony-inspired-palette('accent-light');
            color: $harmony-inspired-palette('accent-dark');
        }
        
        i {
            font-size: 1.75rem;
        }
    }
    
    .metric-title-choir {
        font-size: 0.875rem;
        font-weight: 500;
        color: $harmony-inspired-palette('text-secondary');
        margin-bottom: 0.5rem;
        text-transform: uppercase;
        letter-spacing: 0.05em;
    }
    
    .metric-value-choir {
        font-size: 2.25rem;
        font-weight: 700;
        color: $harmony-inspired-palette('text-primary');
        margin-bottom: 0.5rem;
        line-height: 1;
    }
    
    .metric-trend-choir {
        font-size: 0.75rem;
        font-weight: 500;
        
        &.positive {
            color: $harmony-inspired-palette('success');
        }
        
        &.negative {
            color: $harmony-inspired-palette('error');
        }
    }
}
```

### Data Table (Inspirado en Harmony Hub)
```scss
.table-choir {
    width: 100%;
    background: $harmony-inspired-palette('surface-primary');
    border-radius: 12px;
    overflow: hidden;
    box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
    
    .table-head-choir {
        background: $harmony-inspired-palette('surface-secondary');
        
        th {
            padding: 1rem 1.5rem;
            font-weight: 600;
            font-size: 0.875rem;
            color: $harmony-inspired-palette('text-secondary');
            text-transform: uppercase;
            letter-spacing: 0.05em;
            border-bottom: 1px solid #E5E7EB;
        }
    }
    
    .table-body-choir {
        .table-row-choir {
            border-bottom: 1px solid #F3F4F6;
            transition: background-color 0.2s ease;
            
            &:hover {
                background: $harmony-inspired-palette('surface-secondary');
            }
            
            .table-cell-choir {
                padding: 1.25rem 1.5rem;
                vertical-align: middle;
            }
        }
    }
}

.member-info-choir {
    display: flex;
    align-items: center;
    
    .member-avatar-choir {
        width: 40px;
        height: 40px;
        border-radius: 50%;
        background: $harmony-inspired-palette('accent-primary');
        color: $harmony-inspired-palette('text-primary');
        display: flex;
        align-items: center;
        justify-content: center;
        font-weight: 600;
        font-size: 0.875rem;
        margin-right: 0.75rem;
    }
    
    .member-name-choir {
        font-weight: 500;
        color: $harmony-inspired-palette('text-primary');
        margin-bottom: 0.25rem;
    }
    
    .member-email-choir {
        font-size: 0.75rem;
        color: $harmony-inspired-palette('text-tertiary');
        margin: 0;
    }
}
```

### Form Styling (Inspirado en Harmony Hub)
```scss
.form-layout-choir {
    max-width: 800px;
    margin: 0 auto;
    
    .form-header-choir {
        text-align: center;
        margin-bottom: 3rem;
        
        .form-title-choir {
            font-size: 2rem;
            font-weight: 700;
            color: $harmony-inspired-palette('text-primary');
            margin-bottom: 0.5rem;
        }
        
        .form-subtitle-choir {
            color: $harmony-inspired-palette('text-secondary');
            font-size: 1.125rem;
        }
    }
    
    .form-section-choir {
        background: $harmony-inspired-palette('surface-primary');
        border: 1px solid #E5E7EB;
        border-radius: 12px;
        padding: 2rem;
        margin-bottom: 2rem;
        
        .section-title-choir {
            font-size: 1.25rem;
            font-weight: 600;
            color: $harmony-inspired-palette('text-primary');
            margin-bottom: 1.5rem;
            padding-bottom: 0.75rem;
            border-bottom: 2px solid $harmony-inspired-palette('accent-light');
        }
    }
    
    .form-group-choir {
        margin-bottom: 1.5rem;
        
        .form-label-choir {
            display: block;
            font-weight: 500;
            color: $harmony-inspired-palette('text-primary');
            margin-bottom: 0.5rem;
            font-size: 0.875rem;
        }
        
        .form-input-choir,
        .form-select-choir {
            width: 100%;
            padding: 0.75rem 1rem;
            border: 1px solid #D1D5DB;
            border-radius: 8px;
            font-size: 1rem;
            transition: all 0.2s ease;
            
            &:focus {
                outline: none;
                border-color: $harmony-inspired-palette('accent-primary');
                box-shadow: 0 0 0 3px rgba(247, 197, 45, 0.1);
            }
        }
    }
    
    .form-actions-choir {
        display: flex;
        justify-content: flex-end;
        gap: 1rem;
        padding-top: 2rem;
        border-top: 1px solid #E5E7EB;
    }
}
```

---

## Patrones de Interacción Inspirados

### Hover Effects
```scss
// Efectos hover sutiles inspirados en Harmony Hub
.hover-lift {
    transition: all 0.2s ease;
    
    &:hover {
        transform: translateY(-2px);
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
    }
}

.hover-glow {
    transition: all 0.2s ease;
    
    &:hover {
        box-shadow: 0 0 0 3px rgba(247, 197, 45, 0.2);
    }
}
```

### Loading States
```scss
// Estados de carga inspirados en interfaces modernas
.loading-shimmer {
    background: linear-gradient(90deg, #f0f0f0 25%, #e0e0e0 50%, #f0f0f0 75%);
    background-size: 200% 100%;
    animation: shimmer 1.5s infinite;
}

@keyframes shimmer {
    0% { background-position: -200% 0; }
    100% { background-position: 200% 0; }
}
```

### Microinteracciones
```scss
// Botones con feedback visual inspirado en Harmony Hub
.btn-primary-choir {
    position: relative;
    overflow: hidden;
    
    &::after {
        content: '';
        position: absolute;
        top: 50%;
        left: 50%;
        width: 0;
        height: 0;
        border-radius: 50%;
        background: rgba(255, 255, 255, 0.3);
        transform: translate(-50%, -50%);
        transition: all 0.3s ease;
    }
    
    &:active::after {
        width: 300px;
        height: 300px;
    }
}
```

---

## Implementación Responsive

### Breakpoints inspirados en diseños modernos
```scss
$breakpoints: (
    'mobile': 320px,
    'tablet': 768px,
    'desktop': 1024px,
    'wide': 1280px
);

// Sidebar responsive
.sidebar-choir {
    @media (max-width: 768px) {
        transform: translateX(-100%);
        transition: transform 0.3s ease;
        
        &.open {
            transform: translateX(0);
        }
    }
}

// Metric grid responsive
.metrics-grid-choir {
    display: grid;
    gap: 1.5rem;
    
    @media (min-width: 768px) {
        grid-template-columns: repeat(2, 1fr);
    }
    
    @media (min-width: 1024px) {
        grid-template-columns: repeat(4, 1fr);
    }
}
```

---

## Conclusión

Esta guía de inspiración visual basada en Harmony Hub proporciona:

1. **Componentes Base**: Cards, tablas, formularios y navegación con el estilo visual moderno
2. **Paleta Harmonizada**: Blanco, dorado y negro como colores predominantes
3. **Patrones de Interacción**: Hover effects, loading states y microinteracciones
4. **Responsive Design**: Adaptación a diferentes dispositivos manteniendo la elegancia

**Recuerda**: Harmony Hub es solo la inspiración visual. Toda la funcionalidad, flujos de usuario y lógica de negocio son específicas del Coro Polyphonia y están definidas en los otros documentos de diseño del proyecto.
