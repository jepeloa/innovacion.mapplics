# Diagramas de Flujos de Usuario - Coro Polyphonia

Este documento contiene los diagramas Mermaid que representan los flujos principales de usuario para la aplicación de gestión financiera del Coro Polyphonia. Estos diagramas sirven como referencia visual para desarrolladores.

## Índice de Diagramas

1. [Flujo de Autenticación](#1-flujo-de-autenticación)
2. [Dashboard Principal - Roles](#2-dashboard-principal---roles)
3. [Gestión de Cuotas (Tesorero)](#3-gestión-de-cuotas-tesorero)
4. [Consulta de Estado Personal (Miembro)](#4-consulta-de-estado-personal-miembro)
5. [Registro de Gastos del Coro](#5-registro-de-gastos-del-coro)
6. [Generación de Reportes Financieros](#6-generación-de-reportes-financieros)
7. [Flujo de Ingresos Adicionales](#7-flujo-de-ingresos-adicionales)
8. [Gestión de Miembros](#8-gestión-de-miembros)

---

## 1. Flujo de Autenticación

```mermaid
flowchart TD
    A[Usuario accede a la aplicación] --> B{¿Está autenticado?}
    B -->|Sí| C[Redirect al Dashboard]
    B -->|No| D[Mostrar pantalla de Login]
    
    D --> E[Ingresa email/usuario y contraseña]
    E --> F{¿Credenciales válidas?}
    F -->|No| G[Mostrar error<br/>Permitir reintento]
    G --> E
    F -->|Sí| H{¿Qué rol tiene?}
    
    H -->|Tesorero/Admin| I[Dashboard Administrador]
    H -->|Miembro Activo| J[Dashboard Miembro]
    
    D --> K[¿Olvidó contraseña?]
    K --> L[Ingresa email]
    L --> M[Envía email de recuperación]
    M --> N[Sigue enlace en email]
    N --> O[Resetea contraseña]
    O --> E
    
    I --> P[Acceso a funciones<br/>administrativas]
    J --> Q[Acceso a funciones<br/>de consulta personal]
    
    style A fill:#e1f5fe
    style H fill:#fff3e0
    style I fill:#f3e5f5
    style J fill:#e8f5e8
```

---

## 2. Dashboard Principal - Roles

```mermaid
flowchart LR
    subgraph "TESORERO/ADMINISTRADOR"
        A1[Resumen Financiero Mensual]
        A2[Estado de Cuotas<br/>58 miembros]
        A3[Próximos Vencimientos]
        A4[Balance General del Coro]
        A5[Accesos Rápidos]
        
        A5 --> A6[Registrar Ingreso]
        A5 --> A7[Registrar Gasto]
        A5 --> A8[Generar Reporte]
        A5 --> A9[Gestionar Miembros]
    end
    
    subgraph "MIEMBRO ACTIVO"
        B1[Mi Estado de Cuenta]
        B2[Balance Personal]
        B3[Últimos Movimientos]
        B4[Información General del Coro]
        B5[Acciones Disponibles]
        
        B5 --> B6[Descargar Recibos]
        B5 --> B7[Actualizar Perfil]
        B5 --> B8[Ver Transparencia Financiera]
    end
    
    style A1 fill:#fff8e1
    style A2 fill:#f3e5f5
    style B1 fill:#e8f5e8
    style B2 fill:#e3f2fd
```

---

## 3. Gestión de Cuotas (Tesorero)

```mermaid
sequenceDiagram
    participant T as Tesorero
    participant S as Sistema
    participant M as Miembro
    participant E as Email
    
    T->>S: Accede a gestión de cuotas
    S-->>T: Lista de 58 miembros con estados
    
    Note over S: Estados: Al día, Atrasado (1-2 meses), Muy atrasado (+3 meses)
    
    T->>S: Busca miembro específico
    S-->>T: Muestra historial del miembro
    
    alt Registrar Pago
        T->>S: Marca cuota como pagada
        T->>S: Especifica método (efectivo/transferencia)
        S->>S: Genera recibo PDF
        S-->>T: Confirma registro exitoso
        S->>E: Notifica al miembro (opcional)
    end
    
    alt Recordatorios Automáticos
        S->>S: Verifica vencimientos próximos (3 días)
        S->>E: Envía recordatorio a miembros
        E->>M: Email: "Tu cuota vence en 3 días"
    end
    
    alt Configurar Cuotas
        T->>S: Accede a configuración
        T->>S: Modifica monto mensual
        T->>S: Ajusta fechas de vencimiento
        S-->>T: Guarda cambios
    end
    
    rect rgb(255, 248, 225)
    Note over T,S: Generación de reportes de morosos disponible
    end
```

---

## 4. Consulta de Estado Personal (Miembro)

```mermaid
flowchart TD
    A[Miembro accede a su dashboard] --> B[Ver estado de cuenta]
    
    B --> C{¿Cuotas al día?}
    C -->|Sí| D[✅ Estado: Al día<br/>Próximo vencimiento: XX/XX]
    C -->|No| E[⚠️ Estado: Atrasado<br/>Cuotas pendientes: X]
    
    D --> F[Mostrar últimos 12 meses]
    E --> F
    
    F --> G[Historial de pagos]
    G --> H[Opciones disponibles]
    
    H --> I[📄 Descargar recibos]
    H --> J[💳 Ver métodos de pago]
    H --> K[🔔 Configurar alertas]
    H --> L[📊 Mi aporte anual vs gastos]
    
    I --> M[Genera PDF con comprobantes]
    J --> N[Efectivo en ensayo<br/>Transferencia bancaria]
    K --> O[Email X días antes del vencimiento]
    L --> P[Transparencia: cuotas pagadas vs<br/>gastos promedio por miembro]
    
    style D fill:#c8e6c9
    style E fill:#ffcdd2
    style M fill:#e1f5fe
    style P fill:#f3e5f5
```

---

## 5. Registro de Gastos del Coro

```mermaid
flowchart TD
    A[Tesorero registra nuevo gasto] --> B[Selecciona categoría]
    
    B --> C{¿Qué tipo de gasto?}
    C -->|Alquiler| D[🏢 Alquiler de salón<br/>Iglesia - ensayos semanales]
    C -->|Honorarios| E[👨‍🎓 Director, preparador vocal, pianista]
    C -->|Partituras| F[🎵 Repertorio, licencias]
    C -->|Conciertos| G[🎪 Producción eventos]
    C -->|Vestuario| H[👔 Presentaciones]
    C -->|Administrativos| I[💼 Seguros, contabilidad]
    
    D --> J[Completa formulario básico]
    E --> J
    F --> J
    G --> J
    H --> J
    I --> J
    
    J --> K[Fecha, monto, descripción]
    K --> L[📷 Sube foto del recibo/factura]
    L --> M{¿Monto mayor a límite?}
    
    M -->|No| N[✅ Aprobación automática]
    M -->|Sí| O[⏳ Requiere aprobación manual]
    
    N --> P[Actualiza presupuesto]
    O --> Q[Notifica para aprobación]
    Q --> R{¿Aprobado?}
    R -->|Sí| P
    R -->|No| S[❌ Rechazado - motivo]
    
    P --> T{¿Gasto > 80% presupuesto mensual?}
    T -->|Sí| U[🚨 Alerta presupuestaria]
    T -->|No| V[Registro completado]
    
    style N fill:#c8e6c9
    style O fill:#fff3e0
    style S fill:#ffcdd2
    style U fill:#ff8a65
```

---

## 6. Generación de Reportes Financieros

```mermaid
sequenceDiagram
    participant T as Tesorero
    participant S as Sistema
    participant DB as Base de Datos
    participant PDF as Generador PDF
    participant Email as Sistema Email
    
    T->>S: Solicita generar reporte
    S-->>T: ¿Qué tipo de reporte?
    
    alt Estado Financiero Mensual
        T->>S: Selecciona mes y año
        S->>DB: Consulta ingresos del mes
        S->>DB: Consulta gastos por categoría
        DB-->>S: Datos financieros
        S->>PDF: Genera reporte mensual
        PDF-->>S: PDF con ingresos vs gastos
    end
    
    alt Flujo de Caja Trimestral
        T->>S: Selecciona trimestre
        S->>DB: Consulta evolución de fondos
        DB-->>S: Datos de 3 meses
        S->>PDF: Genera gráfico de flujo
        PDF-->>S: PDF con evolución trimestral
    end
    
    alt Reporte Anual (Asamblea)
        T->>S: Reporte completo del año
        S->>DB: Consulta datos anuales completos
        Note over DB: Cuotas, gastos, ingresos eventos, patrocinios
        DB-->>S: Dataset completo
        S->>PDF: Genera reporte ejecutivo
        PDF-->>S: PDF para presentar en asamblea
    end
    
    alt Exportación a Excel
        T->>S: Solicita exportar datos
        S->>DB: Extrae datos estructurados
        DB-->>S: Dataset para contabilidad
        S-->>T: Archivo Excel descargable
    end
    
    S-->>T: Reporte generado exitosamente
    T->>Email: Compartir con miembros (opcional)
    
    rect rgb(240, 248, 255)
    Note over T,PDF: Todos los reportes incluyen logo del coro y fecha de generación
    end
```

---

## 7. Flujo de Ingresos Adicionales

```mermaid
flowchart TD
    A[Tesorero registra ingreso adicional] --> B{¿Tipo de ingreso?}
    
    B -->|Concierto| C[Ingresos por concierto]
    B -->|Patrocinio| D[Gestión de patrocinadores]
    
    subgraph "Ingresos por Concierto"
        C --> E[Entradas vendidas]
        C --> F[Donaciones del público]
        C --> G[Patrocinio específico del evento]
        
        E --> H[Registra cantidad y precio]
        F --> I[Registra monto donado]
        G --> J[Vincula con patrocinador]
    end
    
    subgraph "Gestión de Patrocinadores"
        D --> K[¿Patrocinador existente?]
        K -->|Sí| L[Actualiza aporte]
        K -->|No| M[Registra nuevo patrocinador]
        
        M --> N[Datos de contacto]
        M --> O[Monto del patrocinio]
        M --> P[Fecha de renovación]
        
        L --> Q[Historial de aportes]
        N --> Q
        O --> Q
        P --> Q
    end
    
    H --> R[Proyección de ingresos]
    I --> R
    J --> R
    Q --> R
    
    R --> S[Análisis ingresos vs gastos por evento]
    S --> T[Actualiza balance general]
    
    style C fill:#e8f5e8
    style D fill:#fff3e0
    style R fill:#f3e5f5
    style T fill:#e1f5fe
```

---

## 8. Gestión de Miembros

```mermaid
flowchart TD
    A[Tesorero accede a gestión de miembros] --> B[Lista de 58 integrantes activos]
    
    B --> C{¿Qué acción realizar?}
    C -->|Ver/Editar| D[Selecciona miembro]
    C -->|Agregar| E[Nuevo miembro]
    C -->|Cambiar estado| F[Modificar membresía]
    
    D --> G[Información del miembro]
    G --> H[Datos de contacto]
    G --> I[Historial de cuotas]
    G --> J[Estado de membresía]
    G --> K[Fecha de ingreso al coro]
    
    H --> L[Email, teléfono]
    I --> M[Pagos realizados, pendientes]
    J --> N{¿Qué estado?}
    N -->|Activo| O[✅ Participa normalmente]
    N -->|Licencia| P[⏸️ Pausa temporal]
    N -->|Inactivo| Q[❌ No participa]
    
    E --> R[Formulario nuevo miembro]
    R --> S[Nombre, email, teléfono]
    R --> T[Fecha de ingreso]
    R --> U[Estado inicial: Activo]
    
    F --> V{¿Cambio de estado?}
    V -->|A licencia| W[Pausa pagos temporalmente]
    V -->|A inactivo| X[Suspende cuotas]
    V -->|Reactivar| Y[Reanuda cuotas]
    
    L --> Z[Actualiza información]
    S --> AA[Guarda nuevo miembro]
    T --> AA
    U --> AA
    
    W --> BB[Notifica cambio de estado]
    X --> BB
    Y --> BB
    Z --> BB
    AA --> BB
    
    style O fill:#c8e6c9
    style P fill:#fff3e0
    style Q fill:#ffcdd2
    style BB fill:#e1f5fe
```

---

## Flujo de Usuario Miembro - Navegación Completa

```mermaid
sequenceDiagram
    participant M as Miembro
    participant Auth as Autenticación
    participant Dashboard as Dashboard
    participant Profile as Perfil
    participant Reports as Transparencia
    
    M->>Auth: Inicia sesión
    Auth-->>M: Credenciales válidas
    Auth->>Dashboard: Redirect a dashboard miembro
    
    Dashboard-->>M: Mi estado de cuenta
    Note over Dashboard: Cuotas pagadas, pendientes, balance personal
    
    M->>Dashboard: Ver últimos movimientos
    Dashboard-->>M: Historial de pagos últimos 12 meses
    
    M->>Dashboard: Descargar recibo
    Dashboard->>Dashboard: Genera PDF
    Dashboard-->>M: Recibo descargado
    
    M->>Profile: Actualizar perfil
    Profile-->>M: Formulario de datos personales
    M->>Profile: Cambia teléfono/email
    Profile-->>M: Datos actualizados
    
    M->>Reports: Ver transparencia financiera
    Reports-->>M: Estado general del coro
    Note over Reports: Fondos disponibles, gastos principales, mi aporte vs promedio
    
    M->>Dashboard: Configurar notificaciones
    Dashboard-->>M: Preferencias de recordatorios
    Note over M: 3 días antes, 1 día antes, al vencimiento
    
    Dashboard-->>M: Sesión activa - navegación disponible
```

---

## Consideraciones Técnicas para Desarrolladores

### Estados de la Aplicación
- **Cuotas**: `al_dia`, `atrasado_1_mes`, `atrasado_2_meses`, `muy_atrasado`
- **Membresía**: `activo`, `licencia_temporal`, `inactivo`
- **Gastos**: `pendiente_aprobacion`, `aprobado`, `rechazado`
- **Notificaciones**: `programada`, `enviada`, `fallida`

### Flujos Críticos
1. **Respaldo automático**: Datos financieros cada semana
2. **Recordatorios**: 3 días antes del vencimiento de cuotas
3. **Validaciones**: Gastos > presupuesto mensual
4. **Generación PDF**: Recibos y reportes con logo del coro

### Optimizaciones para 58 Usuarios
- Base de datos liviana sin necesidad de escalabilidad compleja
- Interfaz responsive prioritaria (uso en celulares)
- Funcionalidades simplificadas enfocadas en gestión financiera
- Notificaciones por email (no push notifications)

---

*Documentación generada para el proyecto Coro Polyphonia - Sistema de Gestión Financiera*
*Fecha: Diciembre 2024*
