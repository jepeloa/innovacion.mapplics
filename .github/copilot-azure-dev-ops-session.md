# Sesión de Trabajo con Azure DevOps usando MCP Server

Este documento proporciona instrucciones estructuradas para trabajar con Azure DevOps a través del servidor MCP, permitiendo consultas eficientes sobre historias de usuario, tareas y métricas de proyecto.

## Configuración del MCP Server
> **Prerequisito:** Este documento requiere el servidor MCP de Azure DevOps configurado y activo.  
> **Documentación:** https://github.com/Tiberriver256/mcp-server-azure-devops

## Estructura Organizacional de Azure DevOps

### Jerarquía de Elementos
```
Organización
├── Proyecto
    ├── Área (AreaPath)
    │   ├── Área Principal
    │   └── Sub-áreas
    └── Iteración (IterationPath)
        ├── Sprint 1
        ├── Sprint 2
        └── Sprint N
```

### Configuración por Defecto
- **Organización por defecto:** `mapplicsdevs`
- **Proyecto por defecto:** `MEN0009-Shell.SCM_1`

> **Importante:** Estos valores pueden modificarse según tu configuración específica.


## Conceptos Fundamentales

### Separación de Áreas y Sprints
> **Crítico:** AreaPath e IterationPath son conceptos independientes:
> - **AreaPath:** Define categorías funcionales (Frontend, Backend, QA, etc.)
> - **IterationPath:** Define períodos temporales (Sprint 1, Sprint 2, etc.)
> 
> Las consultas por área y sprint son independientes y pueden combinarse.

### Directiva de Gestión de Contexto
> **Protocolo obligatorio:**
> 1. **Confirmar sprint:** Siempre preguntar "¿Qué sprint utilizamos?"
> 2. **Mantener contexto:** Conservar el sprint activo durante toda la sesión
> 3. **Indicar contexto:** Mostrar "Trabajando con Sprint [X]" en cada respuesta
> 4. **Cambio explícito:** Solo cambiar sprint cuando el usuario lo solicite
>
> **Nota técnica:** Variables como `@CurrentSprint` no funcionan en API. Usar nombres/números explícitos.

## Funciones MCP Disponibles

### Consulta y Búsqueda
- **`search_work_items`** - Búsqueda avanzada con filtros
- **`search_code`** - Búsqueda en código fuente  
- **`search_wiki`** - Búsqueda en documentación wiki
- **`list_work_items`** - Listar elementos con WIQL
- **`get_work_item`** - Obtener detalles completos de un elemento

### Gestión de Proyectos
- **`list_organizations`** - Listar organizaciones disponibles
- **`list_projects`** - Listar proyectos en organización
- **`get_project`** - Obtener detalles de proyecto específico
- **`get_project_details`** - Información completa del proyecto

### Repositorios y Código
- **`list_repositories`** - Listar repositorios del proyecto
- **`get_repository`** - Detalles de repositorio específico
- **`get_file_content`** - Contenido de archivos
- **`get_all_repositories_tree`** - Estructura de archivos múltiples repos

### Pull Requests
- **`list_pull_requests`** - Listar PRs con filtros
- **`create_pull_request`** - Crear nueva PR
- **`update_pull_request`** - Actualizar PR existente
- **`get_pull_request_comments`** - Obtener comentarios
- **`add_pull_request_comment`** - Agregar comentarios

### Pipelines y Automatización
- **`list_pipelines`** - Listar pipelines disponibles
- **`get_pipeline`** - Detalles de pipeline específico
- **`trigger_pipeline`** - Ejecutar pipeline

### Work Items y Gestión
- **`create_work_item`** - Crear nuevo elemento
- **`update_work_item`** - Actualizar elemento existente
- **`manage_work_item_link`** - Gestionar relaciones entre elementos

### Wiki y Documentación
- **`get_wikis`** - Listar wikis disponibles
- **`create_wiki`** - Crear nueva wiki
- **`get_wiki_page`** - Obtener contenido de página
- **`update_wiki_page`** - Actualizar página wiki

### Usuario y Autenticación
- **`get_me`** - Información del usuario autenticado

## Patrones de Consulta WIQL

### Estructura Base de Consultas
```sql
SELECT [Campo1], [Campo2], [Campo3]
FROM WorkItems 
WHERE [Condicion1] 
AND [Condicion2]
ORDER BY [CampoOrden]
```

### Campos Principales
- **Identificación:** `[System.Id]`, `[System.Title]`, `[System.WorkItemType]`
- **Estado:** `[System.State]`, `[System.Reason]`
- **Asignación:** `[System.AssignedTo]`, `[System.CreatedBy]`
- **Organización:** `[System.AreaPath]`, `[System.IterationPath]`
- **Tiempo:** `[Microsoft.VSTS.Scheduling.CompletedWork]`, `[Microsoft.VSTS.Scheduling.OriginalEstimate]`
- **Jerarquía:** `[System.Parent]`, `[System.Children]`
- **Fechas:** `[System.CreatedDate]`, `[System.ChangedDate]`

### Ejemplos de Filtros Comunes

#### Por Área Funcional
```sql
WHERE [System.AreaPath] = 'Proyecto\\Area\\Subarea'
```

#### Por Sprint
```sql
WHERE [System.IterationPath] = 'Proyecto\\Sprint XX'
```

#### Por Estado
```sql
WHERE [System.State] IN ('Active', 'Closed', 'Resolved')
```

#### Por Usuario
```sql
WHERE [System.AssignedTo] CONTAINS 'nombre.usuario'
```

#### Por Tipo de Elemento
```sql
WHERE [System.WorkItemType] IN ('Task', 'User Story', 'Bug')
```

## Consultas Frecuentes

### Elementos Completados por Sprint
```sql
SELECT [System.Id], [System.Title], [System.State], [System.AssignedTo]
FROM WorkItems 
WHERE [System.IterationPath] = 'Proyecto\\Sprint XX' 
AND [System.State] = 'Closed'
ORDER BY [System.ChangedDate] DESC
```

### Trabajo por Usuario y Sprint
```sql
SELECT [System.Id], [System.Title], [System.State], [Microsoft.VSTS.Scheduling.CompletedWork]
FROM WorkItems 
WHERE [System.IterationPath] = 'Proyecto\\Sprint XX' 
AND [System.AssignedTo] CONTAINS 'nombre.usuario'
AND [System.State] = 'Closed'
```

### Métricas de Tiempo por Sprint
```sql
SELECT [System.Id], [System.Title], [System.State], 
       [Microsoft.VSTS.Scheduling.CompletedWork], 
       [Microsoft.VSTS.Scheduling.OriginalEstimate],
       [Microsoft.VSTS.Scheduling.RemainingWork]
FROM WorkItems 
WHERE [System.IterationPath] = 'Proyecto\\Sprint XX'
ORDER BY [System.State], [Microsoft.VSTS.Scheduling.CompletedWork] DESC
```

### Elementos con Jerarquía
```sql
SELECT [System.Id], [System.Title], [System.Parent], [System.WorkItemType], [System.State]
FROM WorkItems 
WHERE [System.IterationPath] = 'Proyecto\\Sprint XX'
ORDER BY [System.Parent], [System.Id]
```

### Elementos por Área y Período
```sql
SELECT [System.Id], [System.Title], [System.State], [System.AreaPath]
FROM WorkItems 
WHERE [System.AreaPath] UNDER 'Proyecto\\Area'
AND [System.ChangedDate] >= 'YYYY-MM-DD'
AND [System.State] IN ('Closed', 'Resolved')
```

## Metodología y Configuración

### Tipos de Elementos de Trabajo

#### User Stories
- **Campo requerido:** `Microsoft.VSTS.Scheduling.StoryPoints`
- **Propósito:** Funcionalidades desde perspectiva del usuario
- **Prioridad:** Media (después de bugs)

#### Bugs  
- **Campo requerido:** `Microsoft.VSTS.Common.Severity`
- **Valores:** 1-Critical, 2-High, 3-Medium, 4-Low
- **Prioridad:** Alta (antes que user stories)

#### Tasks
- **Campos requeridos:**
  - `Microsoft.VSTS.Scheduling.OriginalEstimate` (tareas nuevas/activas)
  - `Microsoft.VSTS.Scheduling.RemainingWork` (tareas activas)
  - `Microsoft.VSTS.Scheduling.CompletedWork` (tareas completadas)

### Estados de Elementos
- **New:** Creado, sin iniciar
- **Active:** En desarrollo activo  
- **Resolved:** Completado, pendiente verificación
- **Closed:** Completado y verificado

### Ciclo de Sprint
1. **Planificación:** Selección y estimación
2. **Ejecución:** Desarrollo (2 semanas típico)
3. **Revisión:** Evaluación y retrospectiva

### Directivas de Priorización
1. **Bugs críticos/altos** (Severity 1-2)
2. **Bugs medios/bajos** (Severity 3-4)  
3. **User Stories** (por Story Points)
4. **Tareas de mantenimiento**

## Formatos de Salida

### Agrupación por User Story
```markdown
## US: [Título] (ID: [ID])
- [Tarea 1] ([X]h)
- [Tarea 2] ([Y]h)
**Total: [X+Y] horas**

## US: [Siguiente título] (ID: [ID])
- [Tarea 1] ([Z]h)
**Total: [Z] horas**
```

### Métricas de Sprint
```markdown
# Sprint [X] - Resumen
**Período:** [Fecha inicio] - [Fecha fin]
**Completados:** [N] elementos
**Tiempo total:** [X] horas

## Por Área
- **Frontend:** [N] elementos ([X]h)
- **Backend:** [N] elementos ([Y]h)
- **QA:** [N] elementos ([Z]h)

## Por Usuario  
- **[Usuario 1]:** [N] elementos ([X]h)
- **[Usuario 2]:** [N] elementos ([Y]h)
```

## Estándares de Documentación

### Formato HTML para Descripciones
> **Obligatorio:** Usar HTML estructurado en campos de descripción.

#### Template User Story
```html
<div>
  <h3>Como: <strong>[rol del usuario]</strong></h3>
  <p>Quiero: <strong>[funcionalidad deseada]</strong></p>
  <p>Para: <strong>[beneficio esperado]</strong></p>
  
  <h4>Criterios de Aceptación</h4>
  <ol>
    <li><strong>Dado</strong> [contexto], <strong>Cuando</strong> [acción], <strong>Entonces</strong> [resultado]</li>
    <li>[Criterio adicional...]</li>
  </ol>
  
  <h4>Notas Técnicas</h4>
  <ul>
    <li>Consideración técnica 1</li>
    <li>Dependencia relevante</li>
  </ul>
  
  <hr>
  <blockquote>Validar criterios con QA antes de cerrar</blockquote>
</div>
```

#### Template Task
```html
<div>
  <h4>Objetivo</h4>
  <p><strong>[Descripción clara de la acción a realizar]</strong></p>
  
  <h5>Pasos</h5>
  <ol>
    <li>Paso específico 1</li>
    <li>Paso específico 2</li>
  </ol>
  
  <h5>Criterios de Finalización</h5>
  <ul>
    <li>Resultado verificable 1</li>
    <li>Resultado verificable 2</li>
  </ul>
  
  <hr>
  <p><em>Notas o referencias adicionales</em></p>
</div>
```

### Etiquetas HTML Recomendadas
| Propósito | Etiqueta | Uso |
|-----------|----------|-----|
| Estructura | `<div>`, `<p>` | Organización general |
| Títulos | `<h1>` a `<h6>` | Jerarquía de información |
| Listas | `<ul>`, `<ol>`, `<li>` | Criterios, pasos, notas |
| Énfasis | `<strong>`, `<em>` | Destacar elementos clave |
| Separación | `<hr>` | Dividir secciones |
| Destacado | `<blockquote>` | Notas importantes |
| Código | `<code>` | Referencias técnicas |

## Notas Importantes

### Limitaciones Técnicas
- Variables como `@CurrentSprint` no funcionan vía API
- Usar nombres/números explícitos en consultas
- Campos de tiempo pueden estar vacíos en elementos sin estimación

### Flujo de Trabajo
1. **Confirmar contexto** (sprint, área, usuario)
2. **Ejecutar consulta** usando función MCP apropiada
3. **Procesar resultados** y agrupar según necesidad
4. **Formatear salida** usando templates establecidos
5. **Validar completitud** de la información

## Reportes y Análisis

### Reportes Semanales

#### Directiva para Generación
Cuando se solicite un "reporte semanal" o "informe de la semana":

1. **Confirmar contexto:**
   - Sprint actual de trabajo
   - Rango de fechas (lunes a lunes)
   - Áreas específicas (si aplica)

2. **Consultas base:**
   ```sql
   SELECT [System.Id], [System.WorkItemType], [System.Title], [System.State], 
          [System.AreaPath], [System.AssignedTo], [System.Parent],
          [Microsoft.VSTS.Scheduling.CompletedWork], [System.ChangedDate]
   FROM WorkItems 
   WHERE [System.IterationPath] = 'Proyecto\\Sprint XX' 
   AND ([System.State] = 'Closed' OR [System.State] = 'Resolved') 
   AND [System.ChangedDate] >= 'YYYY-MM-DD' 
   ORDER BY [System.AreaPath], [System.ChangedDate] DESC
   ```

3. **Métricas requeridas:**
   - Total elementos completados por estado
   - Distribución por área funcional
   - Distribución por miembro del equipo
   - Comparación con semanas anteriores

#### Template de Reporte Semanal
```markdown
# Reporte Semanal
**Período:** [Lunes anterior] - [Lunes actual]  
**Sprint:** [Número]  
**Proyecto:** [Nombre del proyecto]

## Resumen Ejecutivo
Esta semana se completaron **[X] elementos** distribuidos en:
1. **[Área 1]** ([N] elementos)
2. **[Área 2]** ([N] elementos)  
3. **[Área 3]** ([N] elementos)

## Desglose por Áreas

### [Área Funcional 1]
**Logros:** [Descripción breve]
* [Elemento 1] - [Asignado]
* [Elemento 2] - [Asignado]

### [Área Funcional 2]  
**Logros:** [Descripción breve]
* [Elemento 1] - [Asignado]
* [Elemento 2] - [Asignado]

## Distribución por Equipo
- **[Nombre 1]**: [N] elementos ([Áreas principales])
- **[Nombre 2]**: [N] elementos ([Áreas principales])

## Estado del Sprint [X]
**Progreso:** [Evaluación general]
**Destacados:**
1. [Logro importante 1]
2. [Logro importante 2]

## Próximos Pasos
- [Prioridad 1]
- [Prioridad 2]
- [Prioridad 3]
```

### Análisis de Tendencias
Para análisis histórico, combinar múltiples consultas:
- Comparar sprints consecutivos
- Identificar patrones por área/usuario
- Evaluar velocidad del equipo
- Detectar cuellos de botella

---

## Guía Rápida de Referencia

### Inicio de Sesión
1. Confirmar sprint de trabajo
2. Identificar objetivo de consulta
3. Seleccionar función MCP apropiada
4. Formatear resultados según template

### Consultas Más Comunes
| Objetivo | Función MCP | Parámetros Clave |
|----------|-------------|------------------|
| Buscar elementos | `search_work_items` | `searchText`, `filters` |
| Listar por sprint | `list_work_items` | `wiql` con IterationPath |
| Detalles específicos | `get_work_item` | `workItemId` |
| Crear elemento | `create_work_item` | `workItemType`, `title` |
| Actualizar | `update_work_item` | `workItemId`, campos |

### Errores Comunes
- Usar variables como `@CurrentSprint` en API
- Confundir AreaPath con IterationPath  
- Formatear descripción en Markdown en lugar de HTML
- No confirmar contexto de sprint al inicio

### Mejores Prácticas  
- Siempre confirmar sprint antes de consultas
- Usar HTML estructurado en descripciones
- Incluir campos de tiempo en consultas de métricas
- Agrupar resultados por jerarquía cuando sea relevante
- Validar datos antes de crear reportes

