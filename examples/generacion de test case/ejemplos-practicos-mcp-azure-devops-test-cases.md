# Ejemplos Prácticos - MCP Server Azure DevOps para Test Cases

## Índice
1. [Configuración Inicial](#configuración-inicial)
2. [Creación de Test Cases](#creación-de-test-cases)
3. [Gestión de Relaciones](#gestión-de-relaciones)
4. [Consultas y Búsquedas](#consultas-y-búsquedas)
5. [Actualizaciones y Mantenimiento](#actualizaciones-y-mantenimiento)
6. [Casos de Uso Avanzados](#casos-de-uso-avanzados)

---

## Configuración Inicial

### Verificar Conexión y Permisos

```javascript
// Obtener información del usuario autenticado
const userInfo = await mcp_azuredevopssh2_get_me();
console.log(`Usuario conectado: ${userInfo.displayName} (${userInfo.email})`);

// Verificar acceso al proyecto
const projectInfo = await mcp_azuredevopssh2_get_project({
  projectId: "MEN0009-Shell.SCM_1"
});
console.log(`Proyecto: ${projectInfo.name} - Estado: ${projectInfo.state}`);
```

### Listar Work Item Types Disponibles

```javascript
const projectDetails = await mcp_azuredevopssh2_get_project_details({
  projectId: "MEN0009-Shell.SCM_1",
  includeWorkItemTypes: true,
  includeFields: true
});

// Filtrar tipos relacionados con testing
const testWorkItemTypes = projectDetails.workItemTypes?.filter(wit => 
  ['Test Case', 'Test Suite', 'Test Plan'].includes(wit.name)
);
```

---

## Creación de Test Cases

### Ejemplo 1: Test Case Básico

```javascript
const testCase = await mcp_azuredevopssh2_create_work_item({
  workItemType: "Test Case",
  title: "TC001 - Validación Password Mínimo 8 Caracteres",
  description: `
    <div>
      <p><strong>Objetivo:</strong> Verificar que el sistema valide correctamente que las contraseñas tengan un mínimo de 8 caracteres.</p>
      <p><strong>Criterios de Aceptación:</strong></p>
      <ul>
        <li><strong>Dado</strong> que el usuario accede al formulario de registro</li>
        <li><strong>Cuando</strong> ingresa una contraseña con menos de 8 caracteres</li>
        <li><strong>Entonces</strong> el sistema debe mostrar un mensaje de error</li>
      </ul>
    </div>
  `,
  areaPath: "MEN0009-Shell.SCM_1\\Features\\Authentication",
  iterationPath: "MEN0009-Shell.SCM_1\\Sprint 2024-Q1",
  priority: 1,
  additionalFields: {
    "Microsoft.VSTS.TCM.Steps": `
      <steps id="0">
        <step id="1" type="ValidateStep">
          <parameterizedString isformatted="true">
            <div><p>1. Acceder al formulario de registro</p></div>
          </parameterizedString>
          <expectedResult isformatted="true">
            <div><p>El formulario se muestra correctamente</p></div>
          </expectedResult>
        </step>
        <step id="2" type="ValidateStep">
          <parameterizedString isformatted="true">
            <div><p>2. Ingresar contraseña con 7 caracteres: "abc123d"</p></div>
          </parameterizedString>
          <expectedResult isformatted="true">
            <div><p>Sistema muestra error de validación</p></div>
          </expectedResult>
        </step>
      </steps>
    `
  }
});

console.log(`Test Case creado con ID: ${testCase.id}`);
```

### Ejemplo 2: Test Case con Datos Parametrizados

```javascript
const parametrizedTestCase = await mcp_azuredevopssh2_create_work_item({
  workItemType: "Test Case",
  title: "TC002 - Validación Password Caracteres Especiales",
  description: `
    <div>
      <p><strong>Objetivo:</strong> Verificar validación de caracteres especiales en passwords.</p>
      <p><strong>Datos de Prueba:</strong></p>
      <table>
        <tr><th>Password</th><th>Resultado Esperado</th></tr>
        <tr><td>@abc123</td><td>Válido</td></tr>
        <tr><td>abc123!</td><td>Válido</td></tr>
        <tr><td>abc123</td><td>Inválido - Sin carácter especial</td></tr>
      </table>
    </div>
  `,
  priority: 2,
  additionalFields: {
    "Microsoft.VSTS.TCM.Steps": `
      <steps id="0">
        <step id="1" type="ValidateStep">
          <parameterizedString isformatted="true">
            <div><p>1. Ingresar password: @paramPassword</p></div>
          </parameterizedString>
          <expectedResult isformatted="true">
            <div><p>Sistema valida según @expectedResult</p></div>
          </expectedResult>
        </step>
      </steps>
    `,
    "System.Tags": "password-validation; security; parametrized"
  }
});
```

---

## Gestión de Relaciones

### Establecer Relación "Tests" con User Story

```javascript
// Crear la relación Tests entre Test Case y User Story
const relation = await mcp_azuredevopssh2_manage_work_item_link({
  sourceWorkItemId: testCase.id, // ID del test case
  targetWorkItemId: 19676,       // ID de la user story
  operation: "add",
  relationType: "Microsoft.VSTS.Common.TestedBy-Reverse",
  comment: "Test case que valida los requisitos de la user story"
});

console.log(`Relación establecida: Test Case ${testCase.id} TESTS User Story 19676`);
```

### Eliminar Relación Parent/Child No Deseada

```javascript
// Intentar eliminar relación jerárquica incorrecta
try {
  await mcp_azuredevopssh2_manage_work_item_link({
    sourceWorkItemId: testCase.id,
    targetWorkItemId: 19676,
    operation: "remove",
    relationType: "System.LinkTypes.Hierarchy-Forward"
  });
  console.log("Relación Parent eliminada exitosamente");
} catch (error) {
  console.warn("No se pudo eliminar la relación Parent automáticamente:", error.message);
  console.log("Será necesario eliminar manualmente desde la UI de Azure DevOps");
}
```

### Crear Relaciones Entre Test Cases

```javascript
// Relacionar test cases que prueban la misma funcionalidad
await mcp_azuredevopssh2_manage_work_item_link({
  sourceWorkItemId: testCase1.id,
  targetWorkItemId: testCase2.id,
  operation: "add",
  relationType: "System.LinkTypes.Related",
  comment: "Test cases relacionados para validación de passwords"
});
```

---

## Consultas y Búsquedas

### Buscar Test Cases por User Story

```javascript
// Buscar todos los test cases relacionados con una user story
const testCases = await mcp_azuredevopssh2_search_work_items({
  searchText: "password validation",
  filters: {
    "System.WorkItemType": ["Test Case"],
    "System.State": ["New", "Active"]
  },
  top: 50
});

console.log(`Encontrados ${testCases.results?.length} test cases`);
```

### Obtener Detalles Completos de un Test Case

```javascript
const testCaseDetails = await mcp_azuredevopssh2_get_work_item({
  workItemId: testCase.id,
  expand: 4 // Nivel máximo de detalle
});

// Mostrar relaciones
console.log("Relaciones del test case:");
testCaseDetails.relations?.forEach(rel => {
  console.log(`- ${rel.rel}: ${rel.url}`);
});

// Mostrar campos específicos de testing
console.log("Pasos de ejecución:", testCaseDetails.fields["Microsoft.VSTS.TCM.Steps"]);
```

### Buscar Test Cases por Área y Sprint

```javascript
const sprintTestCases = await mcp_azuredevopssh2_list_work_items({
  wiql: `
    SELECT [System.Id], [System.Title], [System.State], [Microsoft.VSTS.Common.Priority]
    FROM WorkItems 
    WHERE [System.WorkItemType] = 'Test Case'
    AND [System.AreaPath] UNDER 'MEN0009-Shell.SCM_1\\Features\\Authentication'
    AND [System.IterationPath] = 'MEN0009-Shell.SCM_1\\Sprint 2024-Q1'
    ORDER BY [Microsoft.VSTS.Common.Priority] ASC, [System.Title] ASC
  `
});
```

---

## Actualizaciones y Mantenimiento

### Actualizar Contenido de Test Case

```javascript
const updatedTestCase = await mcp_azuredevopssh2_update_work_item({
  workItemId: testCase.id,
  title: "TC001 - Validación Password Mínimo 8 Caracteres - ACTUALIZADO",
  description: `
    <div>
      <p><strong>Objetivo:</strong> Verificar validación de longitud mínima de password (ACTUALIZADO).</p>
      <p><strong>Última actualización:</strong> ${new Date().toISOString()}</p>
    </div>
  `,
  state: "Active",
  additionalFields: {
    "Microsoft.VSTS.TCM.Steps": `
      <steps id="0">
        <step id="1" type="ValidateStep">
          <parameterizedString isformatted="true">
            <div><p>1. [NUEVO] Abrir navegador y navegar a la página de registro</p></div>
          </parameterizedString>
          <expectedResult isformatted="true">
            <div><p>La página se carga correctamente mostrando el formulario</p></div>
          </expectedResult>
        </step>
        <step id="2" type="ValidateStep">
          <parameterizedString isformatted="true">
            <div><p>2. [ACTUALIZADO] Ingresar password con exactamente 7 caracteres en el campo correspondiente</p></div>
          </parameterizedString>
          <expectedResult isformatted="true">
            <div><p>El sistema acepta la entrada pero prepara validación</p></div>
          </expectedResult>
        </step>
      </steps>
    `,
    "System.History": "Actualizado con nuevos pasos de ejecución y criterios mejorados"
  }
});
```

### Bulk Update para Múltiples Test Cases

```javascript
// Actualizar múltiples test cases con información común
const testCaseIds = [20087, 20088, 20089, 20090, 20091];

const updatePromises = testCaseIds.map(async (id) => {
  return await mcp_azuredevopssh2_update_work_item({
    workItemId: id,
    iterationPath: "MEN0009-Shell.SCM_1\\Sprint 2024-Q2", // Mover a nuevo sprint
    additionalFields: {
      "System.Tags": "automated-testing; password-validation; security",
      "System.History": "Migrado al Sprint Q2 y agregadas tags de categorización"
    }
  });
});

const results = await Promise.allSettled(updatePromises);
console.log(`Actualizados ${results.filter(r => r.status === 'fulfilled').length} de ${testCaseIds.length} test cases`);
```

---

## Casos de Uso Avanzados

### 1. Crear Suite de Test Cases para una Feature

```javascript
async function createTestSuiteForFeature(featureId, testCaseDefinitions) {
  const createdTestCases = [];
  
  for (const testDef of testCaseDefinitions) {
    // Crear test case
    const testCase = await mcp_azuredevopssh2_create_work_item({
      workItemType: "Test Case",
      title: testDef.title,
      description: testDef.description,
      priority: testDef.priority || 2,
      additionalFields: testDef.additionalFields || {}
    });
    
    // Establecer relación con la feature
    await mcp_azuredevopssh2_manage_work_item_link({
      sourceWorkItemId: testCase.id,
      targetWorkItemId: featureId,
      operation: "add",
      relationType: "Microsoft.VSTS.Common.TestedBy-Reverse"
    });
    
    createdTestCases.push(testCase);
    console.log(`Created test case: ${testCase.id} - ${testCase.fields["System.Title"]}`);
  }
  
  return createdTestCases;
}

// Uso
const passwordValidationTests = [
  {
    title: "TC001 - Password Mínimo 8 Caracteres",
    description: "...",
    priority: 1
  },
  {
    title: "TC002 - Password Máximo 50 Caracteres", 
    description: "...",
    priority: 1
  }
  // ... más definiciones
];

const testCases = await createTestSuiteForFeature(19676, passwordValidationTests);
```

### 2. Generar Reporte de Cobertura de Testing

```javascript
async function generateTestCoverageReport(userStoryId) {
  // Obtener la user story
  const userStory = await mcp_azuredevopssh2_get_work_item({
    workItemId: userStoryId,
    expand: 4
  });
  
  // Encontrar test cases relacionados
  const testRelations = userStory.relations?.filter(rel => 
    rel.rel === "Microsoft.VSTS.Common.TestedBy"
  ) || [];
  
  console.log(`\n📊 REPORTE DE COBERTURA - US #${userStoryId}`);
  console.log(`📋 User Story: ${userStory.fields["System.Title"]}`);
  console.log(`🧪 Test Cases Asociados: ${testRelations.length}`);
  
  if (testRelations.length === 0) {
    console.log("❌ Sin cobertura de testing");
    return;
  }
  
  // Analizar cada test case
  for (const relation of testRelations) {
    const testCaseId = relation.url.split('/').pop();
    const testCase = await mcp_azuredevopssh2_get_work_item({
      workItemId: parseInt(testCaseId)
    });
    
    const priority = testCase.fields["Microsoft.VSTS.Common.Priority"] || "No definida";
    const state = testCase.fields["System.State"];
    
    console.log(`  ✅ ${testCase.fields["System.Title"]}`);
    console.log(`     Estado: ${state} | Prioridad: ${priority}`);
  }
  
  return {
    userStoryId,
    testCaseCount: testRelations.length,
    testCases: testRelations
  };
}

// Uso
const coverage = await generateTestCoverageReport(19676);
```

### 3. Migración de Test Cases Entre Proyectos

```javascript
async function migrateTestCases(sourceProjectId, targetProjectId, testCaseIds) {
  const migrationResults = [];
  
  for (const testCaseId of testCaseIds) {
    try {
      // Obtener test case original
      const originalTestCase = await mcp_azuredevopssh2_get_work_item({
        workItemId: testCaseId
      });
      
      // Crear copia en proyecto destino
      const migratedTestCase = await mcp_azuredevopssh2_create_work_item({
        organizationId: "mapplicsdevs",
        projectId: targetProjectId,
        workItemType: "Test Case",
        title: `[MIGRADO] ${originalTestCase.fields["System.Title"]}`,
        description: originalTestCase.fields["System.Description"],
        additionalFields: {
          "Microsoft.VSTS.TCM.Steps": originalTestCase.fields["Microsoft.VSTS.TCM.Steps"],
          "Microsoft.VSTS.Common.Priority": originalTestCase.fields["Microsoft.VSTS.Common.Priority"],
          "System.Tags": "migrated; " + (originalTestCase.fields["System.Tags"] || "")
        }
      });
      
      migrationResults.push({
        original: testCaseId,
        migrated: migratedTestCase.id,
        status: 'success'
      });
      
      console.log(`✅ Migrado TC ${testCaseId} → ${migratedTestCase.id}`);
      
    } catch (error) {
      migrationResults.push({
        original: testCaseId,
        status: 'error',
        error: error.message
      });
      console.error(`❌ Error migrando TC ${testCaseId}:`, error.message);
    }
  }
  
  return migrationResults;
}
```

### 4. Automatización de Validaciones

```javascript
async function validateTestCaseStructure(testCaseId) {
  const testCase = await mcp_azuredevopssh2_get_work_item({
    workItemId: testCaseId,
    expand: 4
  });
  
  const validations = [];
  
  // Validar campos obligatorios
  if (!testCase.fields["System.Title"]) {
    validations.push("❌ Título faltante");
  }
  
  if (!testCase.fields["System.Description"]) {
    validations.push("⚠️ Descripción faltante");
  }
  
  if (!testCase.fields["Microsoft.VSTS.TCM.Steps"]) {
    validations.push("❌ Pasos de ejecución faltantes");
  }
  
  // Validar relaciones
  const hasTestRelation = testCase.relations?.some(rel => 
    rel.rel === "Microsoft.VSTS.Common.TestedBy-Reverse"
  );
  
  if (!hasTestRelation) {
    validations.push("⚠️ No está asociado a ninguna User Story");
  }
  
  // Validar prioridad
  const priority = testCase.fields["Microsoft.VSTS.Common.Priority"];
  if (!priority || priority < 1 || priority > 4) {
    validations.push("⚠️ Prioridad no definida o inválida");
  }
  
  if (validations.length === 0) {
    console.log(`✅ Test Case ${testCaseId} - Estructura válida`);
  } else {
    console.log(`📋 Test Case ${testCaseId} - Validaciones:`);
    validations.forEach(v => console.log(`  ${v}`));
  }
  
  return {
    testCaseId,
    valid: validations.length === 0,
    issues: validations
  };
}

// Validar múltiples test cases
async function validateTestSuite(testCaseIds) {
  const results = await Promise.all(
    testCaseIds.map(id => validateTestCaseStructure(id))
  );
  
  const valid = results.filter(r => r.valid).length;
  const total = results.length;
  
  console.log(`\n📊 Resumen de Validación: ${valid}/${total} test cases válidos`);
  
  return results;
}
```

---

## Configuración del MCP Server

### Archivo `.vscode/mcp.json` Recomendado

```json
{
  "mcpServers": {
    "azuredevops": {
      "command": "npx",
      "args": ["-y", "azure-devops-mcp-server"],
      "env": {
        "AZURE_DEVOPS_ORG": "mapplicsdevs",
        "AZURE_DEVOPS_PROJECT": "MEN0009-Shell.SCM_1",
        "AZURE_DEVOPS_PAT": "${AZURE_DEVOPS_PAT}"
      }
    }
  }
}
```

### Variables de Entorno Necesarias

```bash
# Configurar en .bashrc o .zshrc
export AZURE_DEVOPS_PAT="tu_personal_access_token_aqui"
export AZURE_DEVOPS_ORG="mapplicsdevs"
export AZURE_DEVOPS_PROJECT="MEN0009-Shell.SCM_1"
```

---

## Conclusiones

Este documento proporciona ejemplos prácticos y reutilizables para trabajar con test cases en Azure DevOps usando el MCP Server. Los patrones aquí mostrados pueden adaptarse a diferentes necesidades y proyectos.

### Puntos Clave:
1. **Estructuración Consistente**: Usar templates y patrones consistentes
2. **Relaciones Correctas**: Priorizar "Tests" sobre "Parent/Child"
3. **Validación Continua**: Implementar validaciones automáticas
4. **Documentación Rica**: Incluir HTML bien formado en descripciones
5. **Automatización**: Usar scripts para operaciones repetitivas

---

*Documento generado como complemento de la guía completa de test cases, basado en la experiencia práctica del proyecto US #19676.*
