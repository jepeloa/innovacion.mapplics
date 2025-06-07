# Guía de Pruebas - Sistema de Gestión de Suscripciones del Coro

Esta guía te ayudará a probar todas las funcionalidades implementadas en la aplicación de gestión de suscripciones del coro.

## 🚀 Inicio Rápido

1. **Compilar y ejecutar la aplicación:**
   ```bash
   cd examples/ChoirSuscriptionManager
   dotnet build
   dotnet run --project src/ChoirSubscriptionManager.Web --urls "http://localhost:5007"
   ```

2. **Abrir el navegador en:** http://localhost:5007

## 📋 Funcionalidades Implementadas

### 🏠 Dashboard Principal (`/`)
- **Qué probar:** 
  - Estadísticas en tiempo real de miembros, suscripciones y pagos
  - Tarjetas informativas con datos actualizados
  - Navegación a diferentes secciones
- **Cómo probarlo:** Navegar a la página principal y verificar que las estadísticas se muestren correctamente

### 👥 Gestión de Miembros (`/Members`)

#### Listar Miembros (`/Members`)
- **Qué probar:** Ver todos los miembros registrados
- **Funcionalidades:** Tabla con información completa, acciones de editar/ver/eliminar
- **Datos de prueba:** La aplicación incluye datos de ejemplo automáticamente

#### Crear Miembro (`/Members/Create`)
- **Qué probar:** Formulario de creación con validaciones
- **Campos obligatorios:**
  - Nombre completo
  - Email (formato válido)
  - Rol en el coro (Soprano, Alto, Tenor, Bajo)
  - Fecha de nacimiento
- **Campos opcionales:**
  - Teléfono
  - Estado activo/inactivo
- **Validaciones:** 
  - Email único
  - Formato de email válido
  - Campos requeridos
  - Edad mínima (calculada automáticamente)

#### Editar Miembro (`/Members/Edit/{id}`)
- **Qué probar:** Modificación de datos existentes
- **Funcionalidades:** Formulario pre-populado, validaciones, actualización de fecha de modificación

#### Ver Detalles (`/Members/Details/{id}`)
- **Qué probar:** Vista detallada de un miembro específico
- **Información mostrada:** Todos los datos del miembro, fecha de creación y última actualización

#### Eliminar Miembro (`/Members/Delete/{id}`)
- **Qué probar:** Eliminación con confirmación
- **Funcionalidades:** Página de confirmación antes de eliminar

#### Activar/Desactivar (`/Members/Activate/{id}` y `/Members/Deactivate/{id}`)
- **Qué probar:** Cambio de estado del miembro desde la lista
- **Funcionalidades:** Enlaces directos para activar/desactivar miembros

### 📝 Gestión de Suscripciones (`/Subscriptions`)

#### Listar Suscripciones (`/Subscriptions`)
- **Qué probar:** Ver todas las suscripciones con información del miembro asociado
- **Información mostrada:** Miembro, tipo, fechas de inicio y fin, estado, costo

#### Crear Suscripción (`/Subscriptions/Create`)
- **Qué probar:** Formulario con selección de miembro y validaciones
- **Campos requeridos:**
  - Miembro (lista desplegable)
  - Tipo de suscripción (Mensual, Trimestral, Semestral, Anual)
  - Fecha de inicio
  - Costo
- **Validaciones:**
  - Un miembro no puede tener suscripciones superpuestas activas
  - Costo debe ser mayor a 0
  - Fecha de inicio no puede ser en el pasado

#### Editar Suscripción (`/Subscriptions/Edit/{id}`)
- **Qué probar:** Modificación de suscripciones existentes
- **Validaciones:** Las mismas que al crear + verificación de conflictos de fechas

#### Ver/Eliminar Suscripciones
- **Funcionalidades:** Similares a las de miembros con confirmaciones apropiadas

### 💰 Gestión de Pagos (`/Payments`)

#### Listar Pagos (`/Payments`)
- **Qué probar:** Ver todos los pagos registrados
- **Información:** Suscripción asociada, monto, fecha, método de pago, estado

#### Crear Pago (`/Payments/Create`)
- **Qué probar:** Formulario de registro de pagos
- **Campos requeridos:**
  - Suscripción (lista desplegable con suscripciones activas)
  - Monto
  - Fecha de pago
  - Método de pago (Efectivo, Transferencia, Tarjeta)
- **Validaciones:**
  - Monto debe ser mayor a 0
  - Fecha no puede ser futura
  - Solo suscripciones activas disponibles

#### Otras operaciones
- **Editar/Ver/Eliminar:** Funcionalidades completas con validaciones apropiadas

### 📊 Reportes Avanzados (`/Reports`)

#### Índice de Reportes (`/Reports`)
- **Qué probar:** Dashboard de reportes con estadísticas detalladas
- **Métricas incluidas:**
  - Total de miembros por rol
  - Suscripciones por tipo y estado
  - Ingresos totales y promedio
  - Miembros activos vs inactivos

#### Reporte de Detalles de Miembros (`/Reports/MemberDetails`)
- **Qué probar:** Lista detallada de todos los miembros
- **Información:** Datos completos + estadísticas de suscripciones y pagos por miembro

#### Próximas Renovaciones (`/Reports/UpcomingRenewals`)
- **Qué probar:** Suscripciones que vencen próximamente
- **Utilidad:** Identificar miembros que necesitan renovar en los próximos 30 días

#### Suscripciones Vencidas (`/Reports/ExpiredSubscriptions`)
- **Qué probar:** Suscripciones que ya han vencido
- **Utilidad:** Seguimiento de suscripciones que requieren atención

#### Detalles de Pagos (`/Reports/PaymentDetails`)
- **Qué probar:** Análisis detallado de todos los pagos
- **Información:** Pagos agrupados por método, resúmenes financieros

### 🔍 Búsqueda Avanzada (`/Search`)
- **Qué probar:** Búsqueda por nombre de miembro
- **Funcionalidades:** 
  - Búsqueda en tiempo real
  - Resultados con información resumida
  - Enlaces directos a detalles del miembro

## 🧪 Escenarios de Prueba Recomendados

### Escenario 1: Nuevo Miembro Completo
1. Crear un nuevo miembro
2. Crear una suscripción para ese miembro
3. Registrar un pago para la suscripción
4. Verificar que aparezca en reportes y dashboard

### Escenario 2: Gestión de Vencimientos
1. Ir a "Próximas Renovaciones"
2. Identificar suscripciones próximas a vencer
3. Renovar suscripciones (crear nuevas suscripciones)
4. Verificar cambios en reportes

### Escenario 3: Análisis Financiero
1. Revisar "Detalles de Pagos"
2. Analizar métodos de pago más utilizados
3. Verificar totales y promedios
4. Comparar con dashboard principal

### Escenario 4: Gestión de Estados
1. Desactivar un miembro desde la lista
2. Verificar que no aparezca en estadísticas activas
3. Reactivar el miembro
4. Confirmar actualización en reportes

## 🔧 Características Técnicas Implementadas

### Validaciones
- **Frontend:** DataAnnotations en modelos
- **Backend:** Validaciones en controladores
- **Base de datos:** Restricciones de integridad

### Navegación
- **Consistente:** Menú de navegación en todas las páginas
- **Breadcrumbs:** Enlaces de retorno en formularios
- **Acciones rápidas:** Botones de acción en listas

### Datos de Ejemplo
- **Automáticos:** Se cargan al iniciar la aplicación
- **Diversos:** Incluyen todos los tipos y estados
- **Realistas:** Datos que simulan uso real

### Base de Datos
- **SQLite:** Base de datos local para desarrollo
- **Entity Framework:** ORM para gestión de datos
- **Migraciones:** Versionado del esquema de base de datos

## 🚨 Puntos de Atención

### Validaciones a Verificar
1. **Email único:** No se pueden crear dos miembros con el mismo email
2. **Suscripciones superpuestas:** Un miembro no puede tener dos suscripciones activas simultáneas
3. **Fechas lógicas:** Las fechas de fin deben ser posteriores a las de inicio
4. **Montos positivos:** Costos y pagos deben ser mayores a 0

### Mensajes de Usuario
- **Éxito:** Confirmaciones verdes para operaciones exitosas
- **Error:** Alertas rojas para problemas
- **Validación:** Mensajes específicos para cada campo

### Responsividad
- **Móvil:** La interfaz se adapta a pantallas pequeñas
- **Tablet:** Diseño optimizado para tablets
- **Desktop:** Aprovecha el espacio en pantallas grandes

---

## 📞 Próximos Pasos

Una vez completadas las pruebas básicas, se pueden implementar:

1. **Exportación de reportes** (PDF, Excel)
2. **Notificaciones automáticas** de vencimientos
3. **Gráficos interactivos** en reportes
4. **Integración con pasarelas de pago**
5. **Sistema de usuarios y roles**
6. **Backup automático de datos**

Esta aplicación está lista para uso en un entorno de desarrollo y puede ser adaptada fácilmente para producción.
