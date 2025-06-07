# Descripción de la interfaz de usuario para el gestor financiero del Coro Polyphonia

Este documento describe las funcionalidades esenciales para la gestión financiera y administrativa del Coro Polyphonia, una agrupación coral de 58 integrantes activos que opera de manera colaborativa e independiente desde 2013.

## Contexto del Coro Polyphonia

- **58 integrantes activos** que participan colaborativamente en todas las actividades
- **Ensayos semanales** los martes de 20:00 a 22:30 hs en salón alquilado
- **4-6 conciertos anuales** con gestión de ingresos por entradas y donaciones
- **Financiamiento** a través de cuotas mensuales y patrocinadores
- **Gestión independiente** con necesidad de transparencia financiera

## Roles de usuario simplificados

- **Tesorero/Administrador**: Gestiona finanzas, cuotas, gastos y reportes (1-2 personas)
- **Miembro Activo**: Consulta su estado de cuenta, realiza pagos y accede a información general (58 personas)

## Funcionalidades principales (Enfoque simplificado)

### 1. Autenticación Básica
**Para todos los usuarios:**
- **Login simple**: Email/usuario y contraseña
- **Recuperación de contraseña**: Via email
- **Logout seguro**: Con confirmación
- **Cambio de contraseña**: Desde perfil personal

### 2. Dashboard Principal
**Para Tesorero/Administrador:**
- **Resumen financiero mensual**: Total ingresos vs gastos del mes actual
- **Estado de cuotas**: Cuántos miembros están al día, atrasados o adelantados
- **Próximos vencimientos**: Lista de cuotas que vencen en los próximos días
- **Balance general**: Fondos disponibles del coro
- **Accesos rápidos**: Botones para registrar ingresos, gastos y generar reportes

**Para Miembro Activo:**
- **Mi estado de cuenta**: Cuotas pagadas, pendientes y próximos vencimientos
- **Balance personal**: Cuánto debo o si estoy adelantado
- **Últimos movimientos**: Historial de mis pagos recientes
- **Información general**: Estado financiero general del coro (opcional, configurable)

### 3. Gestión de Cuotas Mensuales
**Para Tesorero/Administrador:**
- **Registro de pagos**: Marcar cuotas como pagadas (efectivo, transferencia, etc.)
- **Generación de recibos**: PDF simple con logo del coro y detalles del pago
- **Estados de cuota**: Al día, atrasado (1-2 meses), muy atrasado (+3 meses)
- **Recordatorios**: Email automático 3 días antes del vencimiento
- **Listado de morosos**: Vista rápida de miembros con cuotas atrasadas
- **Configuración de cuotas**: Monto mensual, fechas de vencimiento

**Para Miembro Activo:**
- **Mi historial de cuotas**: Últimos 12 meses con estado de cada pago
- **Descargar recibo**: PDF de pagos realizados
- **Métodos de pago**: Ver opciones disponibles (efectivo en ensayo, transferencia)
- **Alertas personales**: Recordatorio configurable antes del vencimiento

### 4. Gestión de Gastos del Coro
**Para Tesorero/Administrador:**
- **Categorías principales específicas del coro**:
  - 🏢 **Alquiler de salón** (iglesia - ensayos semanales)
  - 👨‍🎓 **Honorarios** (director, preparador vocal, pianista)
  - 🎵 **Partituras y materiales** (repertorio, licencias)
  - 🎪 **Producción de conciertos** (4-6 anuales)
  - 👔 **Vestuario y utilería** (presentaciones)
  - 💼 **Gastos administrativos** (seguros, contabilidad)

- **Registro de gastos simple**:
  - Formulario básico: fecha, monto, categoría, descripción, comprobante
  - Upload de foto del recibo/factura desde celular
  - Aprobación automática para gastos menores, manual para mayores

- **Control presupuestario básico**:
  - Presupuesto anual simple por categoría
  - Alerta cuando se gasta más del 80% del presupuesto mensual
  - Comparación mes actual vs mismo mes año anterior

**Para Miembro Activo:**
- **Transparencia básica**: Ver resumen mensual de gastos principales
- **Sugerencias**: Proponer gastos o mejoras necesarias para el coro

### 5. Ingresos Adicionales (Conciertos y Patrocinios)
**Para Tesorero/Administrador:**
- **Registro de ingresos por conciertos**:
  - Entradas vendidas (cuando aplique)
  - Donaciones recibidas del público
  - Patrocinios específicos para eventos

- **Gestión de patrocinadores**:
  - Registro de patrocinador actual y contactos
  - Historial de aportes y fechas
  - Seguimiento de renovaciones anuales

- **Proyección de ingresos**:
  - Estimación para próximos conciertos
  - Análisis de ingresos vs gastos por evento

### 6. Reportes Financieros Básicos
**Para Tesorero/Administrador:**
- **Estado financiero mensual**: Ingresos (cuotas + otros) vs Gastos por categoría
- **Flujo de caja trimestral**: Evolución de fondos disponibles
- **Reporte anual simplificado**: Para presentar en asamblea de miembros
- **Exportación a Excel**: Para contabilidad externa si es necesaria

**Para Miembro Activo:**
- **Transparencia financiera**: Estado general del coro (fondos, gastos principales)
- **Mi aporte al coro**: Cuotas pagadas en el año vs gastos promedio por miembro

### 7. Comunicación Básica
**Para Tesorero/Administrador:**
- **Recordatorios de cuotas**: Email automático a morosos
- **Anuncios financieros**: Comunicar estado del coro, gastos importantes
- **Notificaciones de vencimiento**: 3 días antes del vencimiento de cuota

**Para Miembro Activo:**
- **Notificaciones personales**: Estado de mi cuenta, vencimientos próximos
- **Información general**: Anuncios importantes sobre finanzas del coro

### 8. Gestión de Miembros (Información Básica)
**Para Tesorero/Administrador:**
- **Lista de miembros activos**: 58 integrantes con datos de contacto
- **Estado de membresía**: Activo, inactivo, licencia temporal
- **Información de contacto**: Email, teléfono, para comunicaciones
- **Historial de participación**: Cuándo se unió, tiempo en el coro

**Para Miembro Activo:**
- **Mi perfil básico**: Nombre, email, teléfono, fecha de ingreso al coro
- **Actualización de datos**: Cambiar información de contacto
- **Configuración de notificaciones**: Cómo y cuándo recibir recordatorios

## Funcionalidades Simplificadas (Eliminadas o Reducidas)

### Lo que NO incluiremos en la versión básica:
- ❌ **Gestión compleja de repertorio musical** (se maneja externamente por el director)
- ❌ **Calendario avanzado de eventos** (se usa Google Calendar compartido)
- ❌ **Chat interno y mensajería** (WhatsApp del coro cumple esta función)
- ❌ **Sistema de evaluación musical** (no aplica para coro colaborativo)
- ❌ **Integración con redes sociales** (no es prioritario financieramente)
- ❌ **App móvil nativa** (versión web responsive es suficiente para 58 usuarios)
- ❌ **Búsquedas avanzadas complejas** (filtros básicos son suficientes para el tamaño)
- ❌ **Configuraciones avanzadas de personalización** (opciones básicas)
- ❌ **Sistema de reservas de instrumentos** (se maneja presencialmente)
- ❌ **Control de asistencia automatizado** (lista manual en ensayos)

### Funcionalidades futuras (opcional, según necesidad real):
- 📱 **Mejora de interfaz móvil**: Optimización para pagos durante ensayos
- 💳 **Integración con banca electrónica**: Importar movimientos de cuenta del coro
- 📊 **Reportes más avanzados**: Proyecciones financieras para planificación anual
- 🔗 **Integración con WhatsApp Business**: Envío de recordatorios por WhatsApp
- 📅 **Sincronización básica con calendario**: Mostrar próximos conciertos para contexto financiero
- 💰 **Cálculo automático de presupuestos**: Basado en históricos del coro

## Consideraciones técnicas específicas

### Tamaño del grupo (58 miembros activos):
- Base de datos liviana, sin necesidad de optimizaciones complejas de rendimiento
- Interfaz responsive prioritaria (muchos accederán desde el teléfono durante ensayos)
- Backup automático semanal (datos críticos financieros del coro)
- Estructura simple que permita crecimiento gradual si es necesario

### Uso real esperado:
- **Tesorero**: Uso intensivo 2-3 veces por semana (registros, seguimiento)
- **Miembros**: Consulta ocasional, principalmente para verificar estado de cuenta
- **Pico de uso**: Días de vencimiento de cuotas (1-3 días del mes)
- **Acceso móvil**: 70% del uso esperado desde celulares

### Tecnología recomendada:
- **Web responsive** que funcione excelente en celulares y tablets
- **Notificaciones por email** (no push notifications complejas)
- **Backup automático** de datos financieros críticos
- **Interfaz simple** inspirada en aplicaciones bancarias móviles
- **Carga rápida** para uso durante ensayos con conectividad variable
- **Funcionalidad offline básica** para consultas de estado personal

### Contexto específico del Coro Polyphonia:
- **Funcionamiento colaborativo**: Todos los miembros participan en decisiones importantes
- **Transparencia total**: Los miembros deben poder ver el estado general de las finanzas
- **Informalidad controlada**: Balance entre simplicidad de uso y control financiero profesional
- **Estacionalidad**: Actividad financiera mayor en meses de conciertos (mayo, diciembre)
- **Diversidad etaria**: Interfaz debe ser usable para miembros de todas las edades
- **Tradición vs tecnología**: Herramienta debe complementar, no reemplazar, la calidez humana del coro
