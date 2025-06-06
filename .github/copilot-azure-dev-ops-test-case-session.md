# Sesión Azure DevOps - Prompt Optimizado

<config>
  <mcp_server>azure-devops</mcp_server>
  <org_default>mapplicsdevs</org_default>
  <project_default>MEN0009-Shell.SCM_1</project_default>
</config>

<session_protocol>
  <context_management>
    - Mantener contexto durante toda la sesión.
    - No reiniciar contexto a menos que se indique.
    - Verificar estar trabajando sobre la ultima version de los archivos al editarlos.
  </context_management>
</session_protocol>

## <funciones_mcp>

### <consultas>
- `search_work_items` - Búsqueda con filtros
- `list_work_items` - WIQL queries
- `get_work_item` - Detalles completos
- `get_project_details` - Info proyecto
</consultas>

### <gestion_work_items>
- `create_work_item` - Crear elementos
- `update_work_item` - Actualizar campos
- `manage_work_item_link` - **Gestionar relaciones**
</gestion_work_items>

### <repositorios_codigo>
- `list_repositories` - Listar repos
- `get_file_content` - Contenido archivos
- `search_code` - Búsqueda en código
</repositorios_codigo>

### <pull_requests>
- `list_pull_requests` - Listar PRs
- `create_pull_request` - Crear PR
- `add_pull_request_comment` - Comentarios
</pull_requests>

</funciones_mcp>

## <relaciones_work_items>

### <tipos_relaciones>
```xml
<relacion_tests>
  <nombre>Microsoft.VSTS.Common.TestedBy-Reverse</nombre>
  <uso>Test Case → User Story</uso>
  <vista_ui>Test Case "Tests" User Story</vista_ui>
  <criticidad>OBLIGATORIO para test cases</criticidad>
</relacion_tests>

<relacion_jerarquia>
  <nombre>System.LinkTypes.Hierarchy-Forward</nombre>
  <uso>Parent → Child (Test Suites)</uso>
  <warning>EVITAR para test cases individuales</warning>
</relacion_jerarquia>

<relacion_relacionado>
  <nombre>System.LinkTypes.Related</nombre>
  <uso>Elementos funcionalmente relacionados</uso>
</relacion_relacionado>
```
</tipos_relaciones>

### <comandos_relaciones>
```javascript
// Establecer relación Tests (CORRECTO)
{
  "operation": "add",
  "sourceWorkItemId": [TEST_CASE_ID],
  "targetWorkItemId": [USER_STORY_ID], 
  "relationType": "Microsoft.VSTS.Common.TestedBy-Reverse"
}

// Eliminar relación incorrecta
{
  "operation": "remove", 
  "sourceWorkItemId": [ID],
  "targetWorkItemId": [ID],
  "relationType": "System.LinkTypes.Hierarchy-Forward"
}
```
</comandos_relaciones>

</relaciones_work_items>

## <test_cases>

### <creacion_test_cases>
```xml
<campos_obligatorios>
  <campo>System.Title</campo>
  <campo>System.WorkItemType = "Test Case"</campo>
  <campo>System.Description (HTML)</campo>
</campos_obligatorios>

<campos_criticos>
  <campo>Microsoft.VSTS.TCM.Steps (HTML)</campo>
  <campo>Microsoft.VSTS.Common.AcceptanceCriteria (HTML)</campo>
  <campo>Microsoft.VSTS.Common.Priority (1-4)</campo>
</campos_criticos>

<nomenclatura>
  <formato>TC[NNN] - [Funcionalidad] - [Escenario]</formato>
  <ejemplo>TC001 - Validación Password - Longitud Mínima</ejemplo>
</nomenclatura>
```
</creacion_test_cases>

### <asociacion_user_stories>
```xml
<proceso>
  <paso1>Crear test case con contenido completo</paso1>
  <paso2>Establecer relación "Tests" usando manage_work_item_link</paso2>
  <paso3>Verificar relación en Azure DevOps UI</paso3>
  <paso4>Eliminar relaciones incorrectas si existen</paso4>
</proceso>

<validacion>
  <check>Título descriptivo y único</check>
  <check>Pasos de ejecución en HTML válido</check>
  <check>Criterios de aceptación completos</check>
  <check>Relación "Tests" establecida</check>
  <check>Sin relaciones Parent/Child incorrectas</check>
</validacion>
```
</asociacion_user_stories>

### <template_html>
```html
<!-- Para System.Description -->
<div>
  <h3>Objetivo</h3>
  <p><strong>[Propósito del test]</strong></p>
  
  <h4>Criterios de Aceptación</h4>
  <ol>
    <li><strong>Dado</strong> [contexto] <strong>Cuando</strong> [acción] <strong>Entonces</strong> [resultado]</li>
  </ol>
  
  <h4>Datos de Prueba</h4>
  <ul><li>[Datos específicos]</li></ul>
</div>

<!-- Para Microsoft.VSTS.TCM.Steps -->
<div>
  <h4>Pasos de Ejecución</h4>
  <ol>
    <li><strong>Acción:</strong> [Paso] <br><strong>Resultado:</strong> [Esperado]</li>
  </ol>
</div>
```
</template_html>

</test_cases>

## <api_azure_devops>

### <endpoints_principales>
```xml
<create_work_item>
  <url>/_apis/wit/workitems/$[TYPE]</url>
  <method>POST</method>
  <content_type>application/json-patch+json</content_type>
</create_work_item>

<update_work_item>
  <url>/_apis/wit/workitems/[ID]</url>
  <method>PATCH</method>
  <operations>add, replace, remove</operations>
</update_work_item>

<manage_relations>
  <url>/_apis/wit/workitems/[ID]</url>
  <method>PATCH</method>
  <path>/relations/-</path>
</manage_relations>
```
</endpoints_principales>

### <mcp_usage>
```xml
<best_practices>
  <practice>Usar funciones MCP en lugar de llamadas REST directas</practice>
  <practice>Validar conexión con get_me() antes de operaciones</practice>
  <practice>Usar search_work_items para localizar elementos existentes</practice>
  <practice>Verificar permisos antes de crear/actualizar</practice>
</best_practices>

<error_handling>
  <common>Campo obligatorio faltante → Verificar System.Title</common>
  <common>HTML inválido → Validar estructura antes de envío</common>
  <common>Relación no se elimina → Usar Azure DevOps UI manualmente</common>
  <common>Permisos insuficientes → Contactar admin proyecto</common>
</error_handling>
```
</mcp_usage>

</api_azure_devops>

## <consultas_wiql>

### <sintaxis_base>
```sql
SELECT [campos] FROM WorkItems 
WHERE [condiciones]
ORDER BY [orden]
```
</sintaxis_base>

### <campos_frecuentes>
```xml
<identificacion>
  <campo>[System.Id]</campo>
  <campo>[System.Title]</campo>
  <campo>[System.WorkItemType]</campo>
</identificacion>

<organizacion>
  <campo>[System.AreaPath]</campo>
  <campo>[System.IterationPath]</campo>
  <campo>[System.State]</campo>
</organizacion>

<relaciones>
  <campo>[System.Parent]</campo>
  <campo>[System.Children]</campo>
</relaciones>

<tiempo>
  <campo>[Microsoft.VSTS.Scheduling.CompletedWork]</campo>
  <campo>[Microsoft.VSTS.Scheduling.OriginalEstimate]</campo>
</tiempo>
```
</campos_frecuentes>

### <consultas_test_cases>
```sql
-- Test cases por User Story
SELECT [System.Id], [System.Title], [System.State]
FROM WorkItems 
WHERE [System.WorkItemType] = 'Test Case'
AND [System.Parent] = [USER_STORY_ID]

-- Test cases sin relación correcta
SELECT [System.Id], [System.Title] 
FROM WorkItems
WHERE [System.WorkItemType] = 'Test Case'
AND [System.Id] NOT IN (
  SELECT [Source].[System.Id] FROM WorkItemLinks
  WHERE [System.Links.LinkType] = 'Microsoft.VSTS.Common.TestedBy-Reverse'
)
```
</consultas_test_cases>

</consultas_wiql>

## <directivas_especiales>

### <test_case_workflow>
```xml
<cuando_crear_test_cases>
  <condicion>Usuario solicita "crear test cases para US #[ID]"</condicion>
  <condicion>Se menciona "validar funcionalidad" o "casos de prueba"</condicion>
  <condicion>Se requiere "cobertura de testing"</condicion>
</cuando_crear_test_cases>

<proceso_automatico>
  <paso1>Obtener detalles de User Story usando get_work_item</paso1>
  <paso2>Analizar criterios de aceptación</paso2>
  <paso3>Generar escenarios de test (positivos y negativos)</paso3>
  <paso4>Crear test cases con nomenclatura TC[NNN]</paso4>
  <paso5>Establecer relaciones "Tests" correctas</paso5>
  <paso6>Validar creación y reportar IDs generados</paso6>
</proceso_automatico>
</test_case_workflow>

### <correccion_relaciones>
```xml
<cuando_corregir>
  <condicion>Test cases con relación Parent/Child incorrecta</condicion>
  <condicion>Test cases sin relación "Tests"</condicion>
  <condicion>Usuario reporta "relaciones incorrectas"</condicion>
</cuando_corregir>

<proceso_correccion>
  <paso1>Identificar test cases afectados</paso1>
  <paso2>Establecer relación "Tests" si no existe</paso2>
  <paso3>Intentar eliminar relación "Parent" incorrecta</paso3>
  <paso4>Si falla eliminación, informar proceso manual</paso4>
  <paso5>Validar resultado final</paso5>
</proceso_correccion>
</correccion_relaciones>

</directivas_especiales>

## <formatos_salida>

### <reporte_test_coverage>
```markdown
# 📊 Cobertura de Testing - US #[ID]

## User Story
**Título:** [Título]
**Estado:** [Estado]

## Test Cases Asociados
✅ **TC001** - [Título] (ID: [ID]) - Estado: [Estado]
✅ **TC002** - [Título] (ID: [ID]) - Estado: [Estado]

## Relaciones
- **Tests correctas:** [N] test cases
- **Relaciones incorrectas:** [N] casos (si aplica)

## Acciones Realizadas
- [Acción 1]
- [Acción 2]

**Estado final:** ✅ COMPLETO / ⚠️ CON OBSERVACIONES
```
</reporte_test_coverage>

### <resumen_sprint>
```markdown
# Sprint [X] - Trabajando con Sprint [X]

## Elementos Completados ([N] total)
### Por Área
- **Frontend:** [N] elementos
- **Backend:** [N] elementos  
- **QA/Testing:** [N] elementos

### Test Cases
- **Creados:** [N] test cases
- **Actualizados:** [N] relaciones corregidas
```
</resumen_sprint>

</formatos_salida>

---

<notas_importantes>
- Variables como @CurrentSprint NO funcionan en API
- AreaPath ≠ IterationPath (conceptos independientes)  
- HTML obligatorio en campos de descripción
- Validar permisos antes de operaciones masivas
- Test cases requieren relación "Tests", no "Parent/Child"
</notas_importantes>
