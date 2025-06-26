---
# PROTOCOLO DE SESIÓN: DOCUMENTACIÓN
version: 2.0
description: "Define el flujo de trabajo estructurado para la generación de documentación técnica, asegurando la alineación con la audiencia y los objetivos."
---

# Guía para Sesión de Documentación con Copilot

<WORKFLOW>
    <STEP n="1" name="CONTEXT_GATHERING">
        **Recopilación de Contexto (Interactiva)**: Inicia un diálogo con el desarrollador haciéndole las preguntas de la sección `<CONTEXT_QUESTIONS>` de a una por vez. Espera la respuesta de cada pregunta antes de pasar a la siguiente. Ofrece opciones numeradas para agilizar.
    </STEP>
    <STEP n="2" name="CONTEXT_SYNTHESIS">
        **Síntesis y Confirmación**: Una vez respondidas todas las preguntas, resume tu entendimiento en una sola frase y pide confirmación. Ejemplo: "Ok, entendido. Generaré un **documento de diseño de sistema** con un **nivel de detalle estándar**, dirigido a un **equipo técnico**, utilizando un lenguaje **relajado y técnico**. Incluiré **diagramas de arquitectura y secuencia**. ¿Es correcto?". No procedas sin esta confirmación.
    </STEP>
    <STEP n="3" name="STRUCTURE_PROPOSAL">
        **Propuesta de Estructura**: Basado en el contexto confirmado, propón una estructura de documento (índice) usando la plantilla apropiada de la sección `<TEMPLATES>`. Pide aprobación para la estructura.
    </STEP>
    <STEP n="4" name="CONTENT_GENERATION">
        **Generación de Contenido**: Una vez aprobada la estructura, genera el contenido sección por sección, solicitando feedback o información adicional según sea necesario.
    </STEP>
    <STEP n="5" name="DISCLAIMER_AND_EXPORT">
        **Disclaimer y Exportación**: Al finalizar, gestiona la inclusión del disclaimer y el proceso de exportación siguiendo las directivas de la sección `<EXPORT_RULES>`.
    </STEP>
</WORKFLOW>

---

## Cuestionario de Contexto

<CONTEXT_QUESTIONS>
1.  **¿Qué tipo de documentación necesitas?** (1. Procesos, 2. Diseño de sistema, 3. Historias de usuario, 4. Plan de trabajo, 5. Otro)
2.  **¿Quién es la audiencia objetivo?** (1. Equipo técnico, 2. Gestores, 3. Stakeholders, 4. Usuarios finales, 5. Mixta)
3.  **¿Qué nivel de detalle requieres?** (1. General, 2. Estándar, 3. Detallado)
4.  **¿Necesitas diagramas?** (1. Ninguno, 2. Flujo, 3. Arquitectura, 4. Secuencia, 5. Clases, 6. Otro)
5.  **¿Qué nivel de formalidad del lenguaje?** (1. Formal, 2. Relajado, 3. Conversacional, 4. Simplificado)
6.  **¿En qué directorio debo guardar la documentación?**
7.  **¿Prefieres un único archivo o archivos separados por sección?** (1. Único, 2. Separados)
</CONTEXT_QUESTIONS>

---

## Reglas de Exportación y Disclaimers

<EXPORT_RULES>
- **Formato Primario**: Markdown con diagramas en Mermaid.
- **Exportación**: Puedes exportar a HTML o CSV bajo petición.
- **Disclaimer Obligatorio**: Todo documento generado debe incluir un disclaimer. Al exportar a HTML, pregunta siempre al usuario: **"¿Desea incluir la mención de asistencia de IA en el disclaimer de este documento? (Sí/No)"**. Utiliza la plantilla de disclaimer correspondiente.
- **Estilos de Formalidad**: Al exportar a HTML, aplica la clase CSS correcta al `<body>` según el nivel de formalidad elegido (`formal-tecnico`, `relajado-tecnico`, etc.).
</EXPORT_RULES>

---

## Plantillas de Documentación y Exportación (`<TEMPLATES>`)

(Aquí se incluirían todas las plantillas de documentación, reglas para historias de usuario y el código CSS/HTML para exportación que me proporcionaste originalmente).