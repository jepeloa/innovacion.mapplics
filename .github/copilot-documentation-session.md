# Prompt para Sesión de Documentación con Copilot

Este documento define el formato y estructura para las sesiones de documentación técnica asistidas por Copilot. El objetivo es proporcionar un marco consistente para generar documentación de alta calidad en diferentes ámbitos del desarrollo de software.

## Directrices Generales

### Formato y Exportación
- Toda la documentación se genera primariamente en **Markdown**.
- Los diagramas se crean con **Mermaid**, ya sea integrados en el markdown o como archivos `.mmd` separados.
- Se puede solicitar la exportación a **HTML** con estilos predefinidos.
- Se puede solicitar la exportación a **CSV** para datos tabulares compatibles con Excel.

### Disclaimer de Asistencia IA

> Es muy importante no saltar este paso. La inclusión del disclaimer es obligatoria para cumplir con las políticas de transparencia y ética en el uso de inteligencia artificial.

- Incluir siempre en cada documento generado un disclaimer que indique que fue escrito con asistencia de modelos de inteligencia artificial.
- Mencionar que el contenido fue revisado por un líder técnico o profesional con idoneidad afín al documento.
- Advertir que pueden existir detalles que deban considerarse como sugerencias y requieren una lectura crítica.
- Al exportar documentos, preguntar si el disclaimer debe ser incluido o no en el documento final.

### Estimaciones Temporales
- Nunca utilizar fechas absolutas (ej. "15 de junio de 2025")
- Siempre expresar duraciones como rangos (ej. "2-3 semanas", "1-2 meses")
- Considerar complejidad y dependencias en las estimaciones

### Estructura de Documentos
- Incluir siempre encabezados claramente jerarquizados (H1, H2, H3)
- Utilizar listas y tablas para mejorar la legibilidad
- Incluir secciones de "Resumen Ejecutivo" al inicio de documentos extensos

### Proceso de Creación de Historias de Usuario

Para la creación de historias de usuario, se debe seguir un proceso estructurado que garantice la calidad, claridad y validación de las mismas:

#### Directrices para la Elaboración de Historias de Usuario
1. **Proceso de Revisión Gradual**:
   - Todas las historias de usuario serán presentadas primero en un archivo borrador (ejemplo: `Sprint_XX_draft.md`).
   - El archivo borrador debe incorporar cualquier historia de usuario existente en Azure DevOps y sus tareas asociadas.
   - Solo después de la revisión y confirmación se podrán crear o actualizar historias en Azure DevOps.

2. **Sistema de Aprobación**:
   - Las historias en el borrador deben marcarse con una de estas acciones: `Aprobada`, `Backlog`, `Rechazada`, o `Refactorizar`.
   - El proceso de aprobación debe realizarlo el interlocutor humano, no el asistente de IA.
   - El archivo borrador incluirá un sistema de etiquetas (labels) donde seleccionar la opción correspondiente.
   - Las historias marcadas para refactorización tendrán un campo adicional donde se pueden indicar los criterios para la refactorización.

3. **Lenguaje y Redacción**:
   - El lenguaje de las historias debe ser técnico relajado, evitando jerga excesivamente técnica.
   - La redacción debe ser comprensible tanto para desarrolladores como para personas sin conocimiento técnico profundo del proceso.
   - Incluir ejemplos claros y concretos cuando sea posible.

4. **Formato de Historia de Usuario**:
   ```markdown
   ### [ID] - [Título de la Historia]
   
   - **Como**: [rol del usuario]
   - **Quiero**: [acción o característica]
   - **Para**: [beneficio o valor]
   
   #### Criterios de Aceptación
   1. **Dado** [contexto inicial]
      **Cuando** [acción]
      **Entonces** [resultado esperado]
   
   #### Notas Técnicas
   - [Consideraciones técnicas relevantes]
   - [Dependencias]
   
   #### Estimación: [X-Y puntos]
   
   #### Estado:
   - [ ] Aprobada
   - [ ] Backlog
   - [ ] Rechazada
   - [ ] Refactorizar
   
   #### Comentarios para Refactorización:
   > [A completar si se selecciona "Refactorizar"]
   ```

5. **Seguimiento de Cambios**:
   - Mantener un registro de cambios en cada iteración del borrador.
   - Documentar las decisiones tomadas durante el proceso de revisión.

Este proceso asegura que las historias de usuario sean validadas adecuadamente antes de su implementación, mejorando la comunicación entre stakeholders y equipo de desarrollo.

## Flujo de Trabajo para Sesiones de Documentación

Cuando el usuario indique "Iniciar sesión de documentación", seguir este flujo de preguntas:

1. **Tipo de documentación**
   - Documentación de procesos
   - Diseño de aplicación/sistema
   - Historias de usuario y requerimientos
   - Plan de trabajo y estimaciones
   - Otro (especificar)

2. **Audiencia objetivo**
   - Equipo técnico (desarrolladores, arquitectos)
   - Gestores de proyecto
   - Stakeholders de negocio
   - Usuarios finales
   - Mixta (especificar)

3. **Nivel de detalle requerido**
   - Visión general (alto nivel)
   - Estándar (balance entre visión general y detalles)
   - Detallado (incluye elementos técnicos específicos)

4. **Elementos visuales necesarios**
   - Diagramas de flujo
   - Diagramas de arquitectura
   - Diagramas de secuencia
   - Diagramas de clases/entidades
   - Otros (especificar)
   - Ninguno

5. **Nivel de formalidad del lenguaje**
   - **Formal y técnico**: Lenguaje académico-profesional, terminología específica, sin coloquialismos ni emojis, tono neutro y objetivo.
   - **Relajado y técnico**: Terminología técnica con explicaciones accesibles, ocasionales analogías, uso moderado de emojis en secciones introductorias.
   - **Conversacional**: Lenguaje sencillo, abundantes ejemplos y analogías, emojis frecuentes, segunda persona, tono amigable.
   - **Simplificado**: Explicaciones muy básicas sin tecnicismos, múltiples ejemplos cotidianos, emojis abundantes, lenguaje visual y narrativo.

6. **Contexto del proyecto**
   - Nombre del proyecto/producto
   - Objetivos principales
   - Restricciones importantes
   - Sistemas relacionados/integrados
   - Documentación existente relevante

7. **Archivos y directorios a utilizar**
    - Preguntar en que directorio se guardará la documentación generada.
    - Preguntar si se generarán archivos separados para cada sección o un único archivo.
    - En caso de que se generen varios archivos, preguntar si se desea un índice o tabla de contenido.
    - Ofrecer la opcion de responder un cuestionario para definir el contexto de la documentacion para poder generar una estructura inicial.
    - El cuestionario debe generarse en un archivo markdown separado y guardarse en el directorio definido por el usuario.
    - El usuario debe responder las preguntas del cuestionario una vez finalizado indicar que se ha completado para poder incorporarlo al contexto de la sesion.

### Formato de Preguntas

 - Las preguntas se deben realizar de a una por vez y el usuario debe responderlas antes de continuar con la siguiente pregunta. 
 - Ofrecer opciones numeradas que permian al usuario ingresar una respuesta rapida. Si la opcion requiere especificar el usuario debe acompañar el numero de respuesta por la especificacion requerida.
 - Las respuestas se deben guardar en un contexto temporal para poder utilizarlas en la generación de la documentación.

## Plantillas por Tipo de Documentación

### Documentación de Procesos

```markdown
# Documentación del Proceso: [Nombre del Proceso]

## Resumen Ejecutivo
[Breve descripción del proceso, su propósito y valor para el negocio]

## Alcance
[Límites del proceso: dónde comienza y termina]

## Actores Involucrados
- [Actor 1]: [Responsabilidades]
- [Actor 2]: [Responsabilidades]

## Flujo del Proceso
[Diagrama de flujo en Mermaid]

## Pasos Detallados
1. **[Paso 1]**
   - Descripción: [Explicación detallada]
   - Entradas: [Documentos/datos necesarios]
   - Salidas: [Resultados del paso]
   - Responsable: [Rol/persona encargada]

2. **[Paso 2]**
   - ...

## Excepciones y Manejo de Errores
- **[Excepción 1]**: [Cómo manejarla]
- **[Excepción 2]**: [Cómo manejarla]

## Métricas e Indicadores
- [Métrica 1]: [Cómo se mide, valor objetivo]
- [Métrica 2]: [Cómo se mide, valor objetivo]

## Integración con Otros Procesos
- [Proceso relacionado 1]: [Descripción de la relación]
- [Proceso relacionado 2]: [Descripción de la relación]
```

### Diseño de Aplicación/Sistema

```markdown
# Diseño de [Nombre de la Aplicación/Sistema]

## Resumen Ejecutivo
[Visión general del sistema y su propósito]

## Requerimientos Principales
- [Requerimiento 1]
- [Requerimiento 2]
- ...

## Arquitectura del Sistema
[Diagrama de arquitectura en Mermaid]

### Componentes Principales
1. **[Componente 1]**
   - Propósito: [Descripción]
   - Responsabilidades: [Lista de funciones]
   - Interfaces: [APIs/interfaces expuestas]
   
2. **[Componente 2]**
   - ...

## Modelo de Datos
[Diagrama de entidades en Mermaid]

### Entidades Principales
1. **[Entidad 1]**
   - Atributos: [Lista de campos y tipos]
   - Relaciones: [Conexiones con otras entidades]
   
2. **[Entidad 2]**
   - ...

## Flujos Principales
### [Flujo 1]
[Diagrama de secuencia en Mermaid]
[Descripción del flujo]

### [Flujo 2]
...

## Consideraciones Técnicas
- **Seguridad**: [Aspectos de seguridad relevantes]
- **Escalabilidad**: [Consideraciones de escalabilidad]
- **Rendimiento**: [Requisitos de rendimiento]
- **Mantenibilidad**: [Aspectos de mantenimiento]

## Dependencias Externas
- [Dependencia 1]: [Descripción y propósito]
- [Dependencia 2]: [Descripción y propósito]

## Decisiones de Diseño
| Decisión | Alternativas Consideradas | Justificación |
|----------|---------------------------|---------------|
| [Decisión 1] | [Alternativas] | [Justificación] |
| [Decisión 2] | [Alternativas] | [Justificación] |
```

### Historias de Usuario

```markdown
# Historias de Usuario: [Nombre del Módulo/Característica]

## Visión General
[Descripción general de esta funcionalidad y su valor para el usuario]

## Épica: [Nombre de la Épica]
[Descripción de la épica]

### Historia de Usuario 1
- **Como** [tipo de usuario]
- **Quiero** [acción/objetivo]
- **Para** [beneficio/valor]

#### Criterios de Aceptación
1. **Dado** [contexto inicial]
   **Cuando** [acción]
   **Entonces** [resultado esperado]
2. **Dado**...

#### Notas Técnicas
- [Consideraciones de implementación]
- [Dependencias]
- [Restricciones]

#### Estimación: [Rango de tiempo o puntos]

### Historia de Usuario 2
...

## Mockups y Diseños
[Referencias o inclusión de mockups]

## Impacto en Otros Componentes
- [Componente 1]: [Descripción del impacto]
- [Componente 2]: [Descripción del impacto]

## Métricas de Éxito
- [Métrica 1]: [Descripción y valor objetivo]
- [Métrica 2]: [Descripción y valor objetivo]
```

### Plan de Trabajo y Estimaciones

```markdown
# Plan de Trabajo: [Nombre del Proyecto/Característica]

## Resumen Ejecutivo
[Visión general del trabajo a realizar y objetivos]

## Objetivos y Entregables
- [Objetivo 1]: [Entregables asociados]
- [Objetivo 2]: [Entregables asociados]

## Fases del Proyecto
### Fase 1: [Nombre de la Fase]
- **Duración estimada**: [Rango de tiempo]
- **Actividades principales**:
  - [Actividad 1]: [Descripción] - [Estimación]
  - [Actividad 2]: [Descripción] - [Estimación]
- **Dependencias**: [Dependencias para iniciar/completar esta fase]
- **Riesgos**: [Riesgos específicos de esta fase]
- **Entregables**: [Lista de entregables al finalizar]

### Fase 2: [Nombre de la Fase]
...

## Dependencias Externas
- [Dependencia 1]: [Descripción e impacto]
- [Dependencia 2]: [Descripción e impacto]

## Recursos Necesarios
- **Roles**:
  - [Rol 1]: [Cantidad] - [Responsabilidades principales]
  - [Rol 2]: [Cantidad] - [Responsabilidades principales]
- **Infraestructura**:
  - [Recurso 1]: [Especificaciones]
  - [Recurso 2]: [Especificaciones]

## Cronograma de Alto Nivel
[Diagrama de Gantt en Mermaid]

## Riesgos y Mitigaciones
| Riesgo | Probabilidad | Impacto | Estrategia de Mitigación |
|--------|-------------|---------|--------------------------|
| [Riesgo 1] | Alta/Media/Baja | Alto/Medio/Bajo | [Estrategia] |
| [Riesgo 2] | Alta/Media/Baja | Alto/Medio/Bajo | [Estrategia] |

## Criterios de Éxito
- [Criterio 1]: [Métrica y valor objetivo]
- [Criterio 2]: [Métrica y valor objetivo]
```

## Especificaciones para Exportación HTML

### Estilos Básicos
```css
body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    line-height: 1.6;
    color: #253236;
    max-width: 1200px;
    margin: 0 auto;
    padding: 20px;
    background-color: #ffffff;
}

h1 {
    color: #131393; /* Color principal azul oscuro */
    border-bottom: 2px solid #131393;
    padding-bottom: 10px;
}

h2 {
    color: #c42376; /* Color secundario magenta */
    margin-top: 30px;
}

h3 {
    color: #4e8acd; /* Color principal azul claro */
}

h4 {
    color: #d16f1c; /* Color secundario naranja */
}

h5, h6 {
    color: #2a406e; /* Color principal azul medio */
}

code {
    background-color: #acacac; /* Color secundario gris claro */
    padding: 2px 4px;
    border-radius: 3px;
    color: #253236;
}

pre {
    background-color: #acacac; /* Color secundario gris claro */
    padding: 15px;
    border-radius: 5px;
    overflow-x: auto;
    color: #253236;
}

table {
    border-collapse: collapse;
    width: 100%;
    margin: 20px 0;
}

th, td {
    border: 1px solid #4e8acd; /* Color principal azul claro */
    padding: 8px 12px;
    text-align: left;
}

th {
    background-color: #2a406e; /* Color principal azul medio */
    color: #ffffff;
}

header {
    display: flex;
    align-items: center;
    margin-bottom: 40px;
    background-color: #ffffff;
    padding: 10px;
    border-bottom: 3px solid #131393; /* Color principal azul oscuro */
}

.logo {
    height: 60px;
    margin-right: 20px;
}

.disclaimer {
    background-color: #f0cf50; /* Color secundario amarillo */
    border-left: 4px solid #131393; /* Color principal azul oscuro */
    padding: 15px;
    margin: 20px 0;
    font-size: 0.9em;
    color: #253236;
}
```

### Estilos HTML para Niveles de Formalidad

Para cada nivel de formalidad, se aplicarán diferentes estilos visuales en la exportación HTML:

#### Estilos para "Formal y técnico"
```css
/* Añadir a los estilos base */
body.formal-tecnico {
    font-family: 'Georgia', serif;
    line-height: 1.6;
    color: #253236;
}

body.formal-tecnico h1, 
body.formal-tecnico h2, 
body.formal-tecnico h3 {
    font-weight: normal;
}

body.formal-tecnico blockquote {
    border-left: 3px solid #2a406e;
    color: #444;
    font-style: italic;
    padding-left: 20px;
}

body.formal-tecnico .nota-tecnica {
    background-color: #f5f5f5;
    border: 1px solid #ddd;
    padding: 15px;
    border-radius: 0;
    font-size: 0.9em;
}
```

#### Estilos para "Relajado y técnico"
```css
/* Añadir a los estilos base */
body.relajado-tecnico {
    font-family: 'Segoe UI', Tahoma, sans-serif;
    line-height: 1.7;
}

body.relajado-tecnico h1, 
body.relajado-tecnico h2 {
    border-bottom: 2px solid #4e8acd;
    padding-bottom: 8px;
}

body.relajado-tecnico .nota-tecnica {
    background-color: #eef5fc;
    border-left: 4px solid #4e8acd;
    padding: 15px;
    border-radius: 5px;
}

body.relajado-tecnico blockquote {
    background-color: #fafafa;
    border-left: 4px solid #d16f1c;
    padding: 10px 15px;
}
```

#### Estilos para "Conversacional"
```css
/* Añadir a los estilos base */
body.conversacional {
    font-family: 'Calibri', 'Trebuchet MS', sans-serif;
    line-height: 1.8;
    font-size: 1.05em;
}

body.conversacional h1, 
body.conversacional h2, 
body.conversacional h3 {
    color: #c42376;
    font-weight: 600;
}

body.conversacional blockquote {
    background-color: #fff8e1;
    border-left: 5px solid #f0cf50;
    padding: 15px;
    border-radius: 8px;
    box-shadow: 0 2px 5px rgba(0,0,0,0.05);
}

body.conversacional .nota-idea {
    background-color: #e1f5fe;
    border: 2px solid #4e8acd;
    border-radius: 10px;
    padding: 15px;
    margin: 20px 0;
    box-shadow: 0 3px 8px rgba(0,0,0,0.08);
}

body.conversacional .emoji-punto {
    font-size: 1.2em;
    margin-right: 5px;
}
```

#### Estilos para "Simplificado"
```css
/* Añadir a los estilos base */
body.simplificado {
    font-family: 'Comic Sans MS', 'Marker Felt', cursive;
    line-height: 2;
    font-size: 1.1em;
}

body.simplificado h1 {
    color: #d16f1c;
    text-align: center;
    font-size: 2.2em;
    margin-top: 40px;
    text-shadow: 1px 1px 3px rgba(0,0,0,0.2);
}

body.simplificado h2 {
    color: #c42376;
    font-size: 1.8em;
    border-bottom: 3px dotted #f0cf50;
    padding-bottom: 10px;
}

body.simplificado h3 {
    color: #4e8acd;
    font-size: 1.5em;
}

body.simplificado blockquote {
    background-color: #fff8e1;
    border: 3px dashed #f0cf50;
    border-radius: 20px;
    padding: 20px;
    font-size: 1.05em;
    margin: 30px 15px;
}

body.simplificado .nota-importante {
    background-color: #ffebee;
    border: 3px solid #c42376;
    border-radius: 15px;
    padding: 15px;
    margin: 25px 0;
    font-weight: bold;
    box-shadow: 0 4px 10px rgba(0,0,0,0.1);
}

body.simplificado .emoji {
    font-size: 1.5em;
    vertical-align: middle;
    margin: 0 3px;
}

body.simplificado table {
    border: 3px solid #4e8acd;
    border-radius: 10px;
    box-shadow: 0 4px 12px rgba(0,0,0,0.15);
    overflow: hidden;
}

body.simplificado th {
    background-color: #c42376;
    color: white;
    text-align: center;
    font-size: 1.1em;
}
```

Al exportar a HTML, se debe incluir la clase correspondiente en el elemento body según el nivel de formalidad seleccionado.

### Logo y Encabezado
- Logo de Mapplics: https://mapplics.com/wp-content/uploads/2023/07/logo-1.png
- Incluir en el encabezado de cada documento HTML exportado

### Disclaimer
```html
<div class="disclaimer">
    <p><strong>Confidencial:</strong> Este documento es confidencial y contiene información propietaria de Mapplics. 
    No debe ser compartido o distribuido sin autorización explícita.</p>
    <p>Generado automáticamente el [FECHA_GENERACION]. La información puede estar sujeta a cambios.</p>
    <p><strong>Nota sobre asistencia IA:</strong> Este documento fue redactado con asistencia de modelos de inteligencia artificial y revisado por un líder técnico o profesional con idoneidad afín a la temática. Algunos detalles pueden considerarse como sugerencias y requieren una lectura crítica por parte del intérprete.</p>
</div>
```

### Variante de Disclaimer sin mención de IA
```html
<div class="disclaimer">
    <p><strong>Confidencial:</strong> Este documento es confidencial y contiene información propietaria de Mapplics. 
    No debe ser compartido o distribuido sin autorización explícita.</p>
    <p>Generado automáticamente el [FECHA_GENERACION]. La información puede estar sujeta a cambios.</p>
</div>
```

### Plantilla HTML Completa
```html
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>[TITULO_DOCUMENTO]</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            line-height: 1.6;
            color: #253236;
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
            background-color: #ffffff;
        }
        
        h1 {
            color: #131393;
            border-bottom: 2px solid #131393;
            padding-bottom: 10px;
        }
        
        h2 {
            color: #c42376;
            margin-top: 30px;
        }
        
        h3 {
            color: #4e8acd;
        }
        
        h4 {
            color: #d16f1c;
        }
        
        h5, h6 {
            color: #2a406e;
        }
        
        code {
            background-color: #acacac;
            padding: 2px 4px;
            border-radius: 3px;
            color: #253236;
        }
        
        pre {
            background-color: #acacac;
            padding: 15px;
            border-radius: 5px;
            overflow-x: auto;
            color: #253236;
        }
        
        table {
            border-collapse: collapse;
            width: 100%;
            margin: 20px 0;
        }
        
        th, td {
            border: 1px solid #4e8acd;
            padding: 8px 12px;
            text-align: left;
        }
        
        th {
            background-color: #2a406e;
            color: #ffffff;
        }
        
        header {
            display: flex;
            align-items: center;
            margin-bottom: 40px;
            background-color: #ffffff;
            padding: 10px;
            border-bottom: 3px solid #131393;
        }
        
        .logo {
            height: 60px;
            margin-right: 20px;
        }
        
        .disclaimer {
            background-color: #f0cf50;
            border-left: 4px solid #131393;
            padding: 15px;
            margin: 20px 0;
            font-size: 0.9em;
            color: #253236;
        }
        
        /* Añadir a los estilos base */
body.formal-tecnico {
    font-family: 'Georgia', serif;
    line-height: 1.6;
    color: #253236;
}

body.formal-tecnico h1, 
body.formal-tecnico h2, 
body.formal-tecnico h3 {
    font-weight: normal;
}

body.formal-tecnico blockquote {
    border-left: 3px solid #2a406e;
    color: #444;
    font-style: italic;
    padding-left: 20px;
}

body.formal-tecnico .nota-tecnica {
    background-color: #f5f5f5;
    border: 1px solid #ddd;
    padding: 15px;
    border-radius: 0;
    font-size: 0.9em;
}

/* Añadir a los estilos base */
body.relajado-tecnico {
    font-family: 'Segoe UI', Tahoma, sans-serif;
    line-height: 1.7;
}

body.relajado-tecnico h1, 
body.relajado-tecnico h2 {
    border-bottom: 2px solid #4e8acd;
    padding-bottom: 8px;
}

body.relajado-tecnico .nota-tecnica {
    background-color: #eef5fc;
    border-left: 4px solid #4e8acd;
    padding: 15px;
    border-radius: 5px;
}

body.relajado-tecnico blockquote {
    background-color: #fafafa;
    border-left: 4px solid #d16f1c;
    padding: 10px 15px;
}

/* Añadir a los estilos base */
body.conversacional {
    font-family: 'Calibri', 'Trebuchet MS', sans-serif;
    line-height: 1.8;
    font-size: 1.05em;
}

body.conversacional h1, 
body.conversacional h2, 
body.conversacional h3 {
    color: #c42376;
    font-weight: 600;
}

body.conversacional blockquote {
    background-color: #fff8e1;
    border-left: 5px solid #f0cf50;
    padding: 15px;
    border-radius: 8px;
    box-shadow: 0 2px 5px rgba(0,0,0,0.05);
}

body.conversacional .nota-idea {
    background-color: #e1f5fe;
    border: 2px solid #4e8acd;
    border-radius: 10px;
    padding: 15px;
    margin: 20px 0;
    box-shadow: 0 3px 8px rgba(0,0,0,0.08);
}

body.conversacional .emoji-punto {
    font-size: 1.2em;
    margin-right: 5px;
}

/* Añadir a los estilos base */
body.simplificado {
    font-family: 'Comic Sans MS', 'Marker Felt', cursive;
    line-height: 2;
    font-size: 1.1em;
}

body.simplificado h1 {
    color: #d16f1c;
    text-align: center;
    font-size: 2.2em;
    margin-top: 40px;
    text-shadow: 1px 1px 3px rgba(0,0,0,0.2);
}

body.simplificado h2 {
    color: #c42376;
    font-size: 1.8em;
    border-bottom: 3px dotted #f0cf50;
    padding-bottom: 10px;
}

body.simplificado h3 {
    color: #4e8acd;
    font-size: 1.5em;
}

body.simplificado blockquote {
    background-color: #fff8e1;
    border: 3px dashed #f0cf50;
    border-radius: 20px;
    padding: 20px;
    font-size: 1.05em;
    margin: 30px 15px;
}

body.simplificado .nota-importante {
    background-color: #ffebee;
    border: 3px solid #c42376;
    border-radius: 15px;
    padding: 15px;
    margin: 25px 0;
    font-weight: bold;
    box-shadow: 0 4px 10px rgba(0,0,0,0.1);
}

body.simplificado .emoji {
    font-size: 1.5em;
    vertical-align: middle;
    margin: 0 3px;
}

body.simplificado table {
    border: 3px solid #4e8acd;
    border-radius: 10px;
    box-shadow: 0 4px 12px rgba(0,0,0,0.15);
    overflow: hidden;
}

body.simplificado th {
    background-color: #c42376;
    color: white;
    text-align: center;
    font-size: 1.1em;
}
    </style>
    <script src="https://cdn.jsdelivr.net/npm/mermaid/dist/mermaid.min.js"></script>
    <script>
        mermaid.initialize({
            startOnLoad: true,
            theme: 'default',
            flowchart: {
                useMaxWidth: true,
                htmlLabels: true
            }
        });
    </script>
</head>
<body class="[NIVEL_FORMALIDAD]">
    <header>
        <img src="https://mapplics.com/wp-content/uploads/2023/07/logo-1.png" alt="Mapplics Logo" class="logo">
        <h1>[TITULO_DOCUMENTO]</h1>
    </header>
    
    [CONTENIDO_DOCUMENTO]
    
    [BLOQUE_DISCLAIMER]
</body>
</html>
```

## Soporte para Mermaid en HTML
Incluir las dependencias para Mermaid ya está previsto en la plantilla HTML completa.

## Formato CSV para Exportación
- Delimitar campos con comas (,)
- Encerrar texto con comillas dobles (") cuando sea necesario
- Incluir encabezados en la primera fila
- Codificar en UTF-8

## Niveles de Formalidad del Lenguaje

La documentación puede adaptarse a diferentes tonos y estilos según el propósito y la audiencia. A continuación se definen los distintos niveles de formalidad disponibles:

### Formal y técnico
- **Características**: Lenguaje académico-profesional, terminología especializada sin simplificaciones, estructura rigurosa y jerárquica.
- **Uso de emojis**: Ninguno.
- **Estilo visual**: Sobrio, diagramas técnicos detallados, paleta de colores limitada y profesional.
- **Ejemplos de frases**:
  - "La implementación del patrón Observer facilita la notificación de cambios de estado a múltiples objetos dependientes sin acoplarlos explícitamente."
  - "La solución propuesta contempla una arquitectura de microservicios con comunicación asíncrona mediante mensajería."

### Relajado y técnico
- **Características**: Mantiene la precisión técnica pero con un tono más accesible, incluye analogías ocasionales, estructura flexible.
- **Uso de emojis**: Limitado a secciones introductorias o para resaltar puntos clave.
- **Estilo visual**: Profesional pero más dinámico, uso moderado de colores, diagramas con anotaciones explicativas.
- **Ejemplos de frases**:
  - "Usamos el patrón Observer para que todos los componentes 'escuchen' los cambios sin tener que estar constantemente preguntando. 🔄"
  - "La arquitectura de microservicios que elegimos nos permite escalar cada servicio independientemente, como si tuviéramos varios mini-aplicaciones trabajando juntas."

### Conversacional
- **Características**: Lenguaje cotidiano, abundantes ejemplos, uso de segunda persona, estructura menos formal, narrativa fluida.
- **Uso de emojis**: Frecuente, para enfatizar conceptos y mantener el interés visual.
- **Estilo visual**: Dinámico, infografías, uso de ilustraciones, paleta amplia de colores.
- **Ejemplos de frases**:
  - "¿Sabes cuándo tu teléfono te avisa de nuevos mensajes? 📱 Así es como funciona nuestro sistema: cada componente recibe una notificación cuando algo importante cambia."
  - "Imagina que tu aplicación es como una ciudad donde cada servicio es un edificio diferente. Pueden crecer o reducirse según sea necesario, sin afectar a los demás. 🏙️"

### Simplificado ("Para que lo entienda mi abuelita")
- **Características**: Lenguaje muy básico, sin tecnicismos, analogías con la vida cotidiana, estructura narrativa, paso a paso.
- **Uso de emojis**: Abundante, como elemento central de comunicación.
- **Estilo visual**: Muy ilustrativo, colores vivos, diagramas simplificados tipo historieta, imágenes explicativas.
- **Ejemplos de frases**:
  - "Piensa en nuestra aplicación como en una casa 🏠. Cada habitación hace algo diferente: la cocina prepara los datos 🍳, el salón los muestra bonitos 🖼️, y el buzón envía mensajes 📮."
  - "¡Es como tener un equipo de ayudantes! 👩‍🍳👨‍🔧 Cuando necesitas algo, cada ayudante hace su parte del trabajo sin molestar a los demás."

Al elegir un nivel de formalidad, todo el documento mantendrá ese tono coherentemente, adaptando tanto el contenido textual como los elementos visuales.

## Instrucciones de Activación

Para iniciar una sesión de documentación, el usuario debe indicar:

```
Iniciar sesión de documentación
```

El asistente responderá realizando las preguntas del flujo de trabajo definido y estableciendo el contexto apropiado para continuar la sesión de documentación.

## Instrucciones para Exportación

Para exportar documentación a formato HTML, el usuario debe indicar:

```
Exportar a HTML [nombre del documento]
```

El asistente debe entonces preguntar:

1. "¿Desea incluir el disclaimer que menciona la asistencia de IA en este documento?" (Sí/No)

2. "¿Qué nivel de formalidad desea aplicar al documento HTML?"
   - Formal y técnico
   - Relajado y técnico
   - Conversacional
   - Simplificado

Según las respuestas:
- Para el disclaimer: 
  - Si la respuesta es afirmativa: Utilizar la variante completa del disclaimer que incluye la mención de IA.
  - Si es negativa: Utilizar la variante reducida sin la mención de IA.

- Para el nivel de formalidad:
  - Formal y técnico: Usar la clase CSS "formal-tecnico" en el body
  - Relajado y técnico: Usar la clase CSS "relajado-tecnico" en el body
  - Conversacional: Usar la clase CSS "conversacional" en el body
  - Simplificado: Usar la clase CSS "simplificado" en el body

En la plantilla HTML:
- El bloque `[BLOQUE_DISCLAIMER]` debe ser reemplazado por el disclaimer apropiado según la elección del usuario.
- El marcador `[NIVEL_FORMALIDAD]` debe ser reemplazado por la clase CSS correspondiente al nivel de formalidad elegido.

Para exportar a CSV, el usuario debe indicar:

```
Exportar a CSV [nombre del documento] [datos a exportar]
```

