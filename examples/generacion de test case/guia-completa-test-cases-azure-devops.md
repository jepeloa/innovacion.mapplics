# Guía Completa para la Creación de Test Cases en Azure DevOps

## Índice
1. [Introducción](#introducción)
2. [Estructura del Test Case](#estructura-del-test-case)
3. [Campos Obligatorios y Opcionales](#campos-obligatorios-y-opcionales)
4. [Relaciones entre Work Items](#relaciones-entre-work-items)
5. [API REST de Azure DevOps](#api-rest-de-azure-devops)
6. [Mejores Prácticas](#mejores-prácticas)
7. [Formato y Contenido](#formato-y-contenido)
8. [Ejemplo Práctico](#ejemplo-práctico)
9. [Troubleshooting](#troubleshooting)

---

## Introducción

Los Test Cases en Azure DevOps son work items especializados que forman parte del sistema de gestión de pruebas. Este documento proporciona una guía completa basada en la documentación oficial de Azure DevOps y la experiencia práctica del proyecto US #19676.

### Tipos de Work Items de Pruebas

| Work Item Type | Descripción |
|---|---|
| **Test Plan** | Contenedor principal que agrupa test suites |
| **Test Suite** | Agrupa test cases relacionados |
| **Test Case** | Define un escenario de prueba específico |
| **Shared Steps** | Pasos reutilizables entre múltiples test cases |
| **Shared Parameters** | Parámetros compartidos para data-driven testing |

---

## Estructura del Test Case

### Anatomía de un Test Case

```
Test Case: TC001 - Validación de Password Mínimo 8 Caracteres
├── Title (System.Title)
├── Description (System.Description)  
├── Steps (Microsoft.VSTS.TCM.Steps)
├── Acceptance Criteria
├── Priority (Microsoft.VSTS.Common.Priority)
├── Area Path (System.AreaPath)
├── Iteration Path (System.IterationPath)
└── Relationships
    ├── Tests → User Story
    ├── Parent → Test Suite (opcional)
    └── Related → Otros test cases
```

### Campos Específicos de Test Cases

#### Campos del Sistema (System.*)
- `System.Title`: Título descriptivo del test case
- `System.Description`: Descripción detallada del propósito
- `System.AreaPath`: Área funcional del proyecto
- `System.IterationPath`: Sprint o iteración asociada
- `System.State`: Estado (New, Active, Closed, etc.)
- `System.AssignedTo`: Responsable de la ejecución

#### Campos de Test Management (Microsoft.VSTS.TCM.*)
- `Microsoft.VSTS.TCM.Steps`: Pasos de ejecución en formato HTML
- `Microsoft.VSTS.TCM.ReproSteps`: Pasos de reproducción para bugs
- `Microsoft.VSTS.TCM.SystemInfo`: Información del sistema de pruebas

#### Campos Comunes (Microsoft.VSTS.Common.*)
- `Microsoft.VSTS.Common.Priority`: Prioridad (1-4, donde 1 es la más alta)
- `Microsoft.VSTS.Common.Severity`: Severidad para bugs relacionados

---

## Campos Obligatorios y Opcionales

### Campos Obligatorios
1. **System.Title**: Título único y descriptivo
2. **System.WorkItemType**: Debe ser "Test Case"
3. **System.AreaPath**: Área del proyecto (ej: "MEN0009-Shell.SCM_1")

### Campos Recomendados
1. **System.Description**: Contexto y objetivo del test
2. **Microsoft.VSTS.TCM.Steps**: Pasos detallados de ejecución
3. **Microsoft.VSTS.Common.Priority**: Prioridad de ejecución
4. **System.IterationPath**: Sprint asociado

### Campos Opcionales
1. **System.Tags**: Etiquetas para categorización
2. **Microsoft.VSTS.TCM.ReproSteps**: Pasos de reproducción
3. **Microsoft.VSTS.TCM.SystemInfo**: Información del entorno

---

## Relaciones entre Work Items

### Tipos de Relaciones para Test Cases

#### 1. Relación "Tests" / "Tested By"
```
User Story (19676) ←--[Tested By]--→ Test Case (TC001)
```
- **Reference Name**: `Microsoft.VSTS.Common.TestedBy`
- **Dirección**: User Story → Test Case (Tests)
- **Dirección Reversa**: Test Case → User Story (Tested By)

#### 2. Relación "Parent" / "Child" (Para Test Suites)
```
Test Suite ←--[Parent]--→ Test Case
```
- **Reference Name**: `System.LinkTypes.Hierarchy`
- **Uso**: Organización jerárquica de test suites

#### 3. Relación "Related"
```
Test Case A ←--[Related]--→ Test Case B
```
- **Reference Name**: `System.LinkTypes.Related`
- **Uso**: Test cases relacionados funcionalmente

### Establecimiento de Relaciones via API

#### Crear Relación "Tests"
```javascript
{
  "sourceWorkItemId": 20087, // Test Case ID
  "targetWorkItemId": 19676, // User Story ID
  "operation": "add",
  "relationType": "Microsoft.VSTS.Common.TestedBy-Reverse"
}
```

#### Eliminar Relación "Parent"
```javascript
{
  "sourceWorkItemId": 20087, // Test Case ID
  "targetWorkItemId": 19676, // User Story ID
  "operation": "remove",
  "relationType": "System.LinkTypes.Hierarchy-Forward"
}
```

---

## API REST de Azure DevOps

### Crear Test Case

#### Endpoint
```http
POST https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/$Test%20Case?api-version=7.0
```

#### Estructura del Request
```javascript
[
  {
    "op": "add",
    "path": "/fields/System.Title",
    "value": "TC001 - Validación de Password Mínimo 8 Caracteres"
  },
  {
    "op": "add",
    "path": "/fields/System.Description",
    "value": "Verificar que el sistema valide correctamente passwords con mínimo 8 caracteres"
  },
  {
    "op": "add",
    "path": "/fields/Microsoft.VSTS.TCM.Steps",
    "value": "<steps id=\"0\"><step id=\"1\" type=\"ValidateStep\"><parameterizedString isformatted=\"true\">...</parameterizedString><expectedResult isformatted=\"true\">...</expectedResult></step></steps>"
  },
  {
    "op": "add",
    "path": "/fields/Microsoft.VSTS.Common.Priority",
    "value": 1
  }
]
```

### Actualizar Test Case

#### Endpoint
```http
PATCH https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/{id}?api-version=7.0
```

### Gestionar Relaciones

#### Endpoint para Relaciones
```http
PATCH https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/{id}?api-version=7.0
```

#### Agregar Relación
```javascript
[
  {
    "op": "add",
    "path": "/relations/-",
    "value": {
      "rel": "Microsoft.VSTS.Common.TestedBy-Reverse",
      "url": "https://dev.azure.com/{org}/{project}/_apis/wit/workitems/{targetId}"
    }
  }
]
```

---

## Mejores Prácticas

### 1. Nomenclatura de Test Cases
```
Formato: TC{número} - {Funcionalidad} - {Escenario}
Ejemplos:
- TC001 - Validación Password - Mínimo 8 Caracteres
- TC002 - Validación Password - Máximo 50 Caracteres
- TC003 - Validación Password - Caracteres Especiales
```

### 2. Estructura de Pasos
```html
<steps id="0">
  <step id="1" type="ValidateStep">
    <parameterizedString isformatted="true">
      <DIV><P>1. Navegar al formulario de registro</P></DIV>
    </parameterizedString>
    <expectedResult isformatted="true">
      <DIV><P>El formulario se muestra correctamente</P></DIV>
    </expectedResult>
  </step>
  <step id="2" type="ValidateStep">
    <parameterizedString isformatted="true">
      <DIV><P>2. Ingresar password con 7 caracteres: "abc123d"</P></DIV>
    </parameterizedString>
    <expectedResult isformatted="true">
      <DIV><P>Sistema muestra error: "Password debe tener mínimo 8 caracteres"</P></DIV>
    </expectedResult>
  </step>
</steps>
```

### 3. Criterios de Aceptación
Incluir en la descripción:
- **Dado**: Condiciones previas
- **Cuando**: Acción realizada
- **Entonces**: Resultado esperado

### 4. Priorización
| Prioridad | Criterio |
|---|---|
| 1 (Crítica) | Funcionalidad core, casos felices principales |
| 2 (Alta) | Validaciones importantes, casos de error críticos |
| 3 (Media) | Casos edge, validaciones secundarias |
| 4 (Baja) | Casos excepcionales, mejoras de UX |

---

## Formato y Contenido

### Template de Test Case

```markdown
# TC{XXX} - {Título Descriptivo}

## Descripción
{Descripción detallada del propósito y contexto}

## Criterios de Aceptación
**Dado** que {condición previa}
**Cuando** {acción del usuario}
**Entonces** {resultado esperado}

## Pasos de Ejecución
1. **Paso 1**: {Acción detallada}
   - **Resultado Esperado**: {Qué debe ocurrir}

2. **Paso 2**: {Acción detallada}
   - **Resultado Esperado**: {Qué debe ocurrir}

## Datos de Prueba
- {Lista de datos específicos necesarios}

## Consideraciones Técnicas
- {Requisitos de entorno, configuración, etc.}
```

### Validación de Campos HTML

Para campos que aceptan HTML (como `Microsoft.VSTS.TCM.Steps`):
- Usar etiquetas válidas: `<DIV>`, `<P>`, `<STRONG>`, `<EM>`
- Evitar `<CDATA>` tags
- Escapar caracteres especiales: `&lt;`, `&gt;`, `&amp;`

---

## Ejemplo Práctico

### Caso de Estudio: US #19676 - Validación Fortaleza de Password

#### Test Case Completo
```json
{
  "fields": {
    "System.Title": "TC001 - Validación Password Mínimo 8 Caracteres",
    "System.Description": "<DIV><P><STRONG>Objetivo:</STRONG> Verificar que el sistema valide correctamente que las contraseñas tengan un mínimo de 8 caracteres.</P><P><STRONG>Criterios de Aceptación:</STRONG></P><UL><LI><STRONG>Dado</STRONG> que el usuario accede al formulario de registro/cambio de contraseña</LI><LI><STRONG>Cuando</STRONG> ingresa una contraseña con menos de 8 caracteres</LI><LI><STRONG>Entonces</STRONG> el sistema debe mostrar un mensaje de error indicando que la contraseña debe tener mínimo 8 caracteres</LI></UL></DIV>",
    "Microsoft.VSTS.TCM.Steps": "<steps id=\"0\"><step id=\"1\" type=\"ValidateStep\"><parameterizedString isformatted=\"true\"><DIV><P>1. Acceder al formulario de registro o cambio de contraseña</P></DIV></parameterizedString><expectedResult isformatted=\"true\"><DIV><P>El formulario se muestra correctamente con el campo de contraseña visible</P></DIV></expectedResult></step><step id=\"2\" type=\"ValidateStep\"><parameterizedString isformatted=\"true\"><DIV><P>2. Ingresar una contraseña con exactamente 7 caracteres: \"abc123d\"</P></DIV></parameterizedString><expectedResult isformatted=\"true\"><DIV><P>El campo acepta la entrada sin errores visuales inmediatos</P></DIV></expectedResult></step><step id=\"3\" type=\"ValidateStep\"><parameterizedString isformatted=\"true\"><DIV><P>3. Intentar enviar el formulario (hacer clic en botón Guardar/Registrar)</P></DIV></parameterizedString><expectedResult isformatted=\"true\"><DIV><P>Sistema muestra mensaje de error: \"La contraseña debe tener mínimo 8 caracteres\" y previene el envío del formulario</P></DIV></expectedResult></step><step id=\"4\" type=\"ValidateStep\"><parameterizedString isformatted=\"true\"><DIV><P>4. Corregir la contraseña ingresando exactamente 8 caracteres: \"abc123de\"</P></DIV></parameterizedString><expectedResult isformatted=\"true\"><DIV><P>El campo acepta la nueva contraseña</P></DIV></expectedResult></step><step id=\"5\" type=\"ValidateStep\"><parameterizedString isformatted=\"true\"><DIV><P>5. Intentar enviar el formulario nuevamente</P></DIV></parameterizedString><expectedResult isformatted=\"true\"><DIV><P>El formulario se envía exitosamente sin errores de validación de longitud</P></DIV></expectedResult></step></steps>",
    "Microsoft.VSTS.Common.Priority": 1,
    "System.AreaPath": "MEN0009-Shell.SCM_1\\Features\\Authentication",
    "System.IterationPath": "MEN0009-Shell.SCM_1\\Sprint 2024-Q1"
  },
  "relations": [
    {
      "rel": "Microsoft.VSTS.Common.TestedBy-Reverse",
      "url": "https://dev.azure.com/mapplicsdevs/MEN0009-Shell.SCM_1/_apis/wit/workitems/19676"
    }
  ]
}
```

---

## Troubleshooting

### Problemas Comunes

#### 1. Error: "Field does not exist"
**Causa**: Campo no válido para el tipo de work item
**Solución**: Verificar campos disponibles con:
```http
GET https://dev.azure.com/{org}/_apis/wit/fields
```

#### 2. Error: "Invalid HTML format"
**Causa**: HTML mal formado en campos como `Microsoft.VSTS.TCM.Steps`
**Solución**: 
- Validar HTML antes del envío
- Usar entidades HTML correctas
- Evitar tags CDATA

#### 3. Relaciones No Se Establecen
**Causa**: Tipo de relación incorrecto o URL malformada
**Solución**:
- Verificar reference name exacto
- Confirmar URLs de work items
- Usar API para listar tipos de relación disponibles

#### 4. Error: "Cannot remove relation"
**Causa**: Limitaciones de la API para ciertos tipos de relación
**Solución**:
- Intentar desde la UI de Azure DevOps
- Verificar permisos de usuario
- Contactar administrador del proyecto

### Herramientas de Debugging

#### 1. Validar Estructura de Work Item
```http
GET https://dev.azure.com/{org}/{project}/_apis/wit/workitems/{id}?$expand=all
```

#### 2. Listar Tipos de Relación
```http
GET https://dev.azure.com/{org}/_apis/wit/workitemrelationtypes
```

#### 3. Obtener Campos Disponibles
```http
GET https://dev.azure.com/{org}/_apis/wit/fields
```

---

## Referencias

### Documentación Oficial
- [Azure DevOps REST API Documentation](https://docs.microsoft.com/en-us/rest/api/azure/devops/)
- [Work Item Tracking API](https://docs.microsoft.com/en-us/rest/api/azure/devops/wit/)
- [Test Management in Azure DevOps](https://docs.microsoft.com/en-us/azure/devops/test/)

### APIs y Librerías
- [Azure DevOps Node.js API](https://github.com/microsoft/azure-devops-node-api)
- [Azure DevOps Python API](https://github.com/microsoft/azure-devops-python-api)

### MCP Server
- [Azure DevOps MCP Server Documentation](/.github/copilot-azure-dev-ops-session.md)

---

## Changelog

| Versión | Fecha | Cambios |
|---|---|---|
| 1.0 | 2024-01-XX | Versión inicial basada en experiencia US #19676 |
| 1.1 | 2024-01-XX | Agregadas mejores prácticas y troubleshooting |

---

*Este documento fue generado como parte del proyecto de automatización de test cases para la historia de usuario #19676, utilizando la documentación oficial de Azure DevOps y Context7.*
