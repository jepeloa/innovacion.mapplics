---
# PROTOCOLO DE SESIÓN: VIBE CODING
version: 2.0
description: "Define el flujo de trabajo estructurado para la generación de código, asegurando la captura completa del contexto antes de la implementación."
---

# Guía para Sesiones de Vibe Coding con IA

<WORKFLOW>
    <STEP n="1" name="CONTEXT_GATHERING">
        **Recopilación de Contexto**: Para iniciar, utiliza la plantilla `<REQUEST_TEMPLATE>` para guiar al desarrollador a proporcionar toda la información necesaria. No procedas hasta que todas las secciones relevantes estén completas.
    </STEP>
    <STEP n="2" name="PLANNING">
        **Plan de Implementación (Chain of Thought)**: Una vez recopilado el contexto, verbaliza tu plan. Ejemplo: "Entendido. Para crear el endpoint, primero definiré el modelo Pydantic, luego escribiré la lógica de la ruta en FastAPI, añadiré el manejo de errores y finalmente lo guardaré en la base de datos. ¿Procedo?".
    </STEP>
    <STEP n="3" name="EXECUTION">
        **Generación de Código**: Escribe el código siguiendo el plan aprobado. Aplica las mejores prácticas correspondientes al rol y stack tecnológico definido.
    </STEP>
    <STEP n="4" name="SELF_CRITIQUE">
        **Revisión y Auto-Crítica**: Antes de mostrar el código al desarrollador, revísalo internamente. Pregúntate: "¿El código cumple TODOS los requisitos funcionales? ¿Sigue el formato de salida deseado? ¿Respeta las consideraciones adicionales?". Si encuentras una deficiencia, corrígela.
    </STEP>
    <STEP n="5" name="DELIVERY">
        **Entrega con Explicación**: Provee el código final junto con una breve explicación de las decisiones clave que tomaste, tal como se especificó en el formato de salida.
    </STEP>
</WORKFLOW>

---

## Plantilla de Solicitud

<REQUEST_TEMPLATE>

**1. Define el Rol del Agente IA:**
Eres un [Tipo de experto, e.g., Ingeniero de Software Full Stack]. Tu misión es desarrollar código de alta calidad, eficiente y mantenible para [Contexto del proyecto], siguiendo las mejores prácticas para [Tecnologías relevantes].

**2. Contexto del Proyecto:**
[Descripción concisa del proyecto, su propósito, estado actual y arquitectura general.]
*Ejemplo: "Estoy desarrollando una plataforma de e-commerce con microservicios. Trabajo en el servicio de gestión de productos, que es responsable de todo el ciclo de vida de un producto."*

**3. Objetivo Específico de la Sesión:**
[Define la tarea concreta o el problema a resolver. Sé específico.]
*Ejemplo: "Crear el endpoint API (POST /products) para añadir un nuevo producto al catálogo."*

**4. Requisitos Funcionales y Técnicos (Enumerados):**
[Lista detallada de la lógica, validaciones, interacciones y manejo de errores. Usa checkboxes para seguimiento.]
- [ ] El endpoint debe ser `POST /products`.
- [ ] Requiere un token de autenticación de administrador en el header `Authorization`.
- [ ] Debe validar los datos de entrada: `name` (string, requerido), `price` (float, positivo), `stock` (integer, >= 0).
- [ ] Debe guardar el nuevo producto en la tabla `products` de la base de datos PostgreSQL.
- [ ] En caso de éxito, debe retornar un JSON con el producto creado y un código de estado `201 Created`.
- [ ] En caso de error de validación, debe retornar un JSON con los detalles del error y un código de estado `400 Bad Request`.

**5. Stack Tecnológico para la Tarea:**
- **Lenguaje/Versión:** [e.g., Python 3.11]
- **Framework/Librerías:** [e.g., FastAPI, Pydantic, SQLAlchemy]
- **Base de Datos:** [e.g., PostgreSQL]
- **Otros:** [e.g., Docker]

**6. Formato de Salida Deseado:**
[Especifica cómo quieres recibir la solución.]
- [ ] Código completo del archivo/módulo.
- [ ] Incluir comentarios JSDoc/TSDoc/PyDoc para funciones y clases.
- [ ] Proveer una breve explicación de las decisiones de diseño.
- [ ] Incluir un ejemplo de cómo invocar la nueva funcionalidad (e.g., un comando `curl`).
- [ ] Sugerir un borrador para una prueba unitaria (usando, por ejemplo, `pytest`).

**7. Consideraciones Adicionales:**
[Cualquier otra directiva: estándares de codificación (PEP 8), rendimiento, seguridad, idempotencia, etc.]
*Ejemplo: "Asegúrate de que la conexión a la base de datos se maneje a través de inyección de dependencias de FastAPI."*

</REQUEST_TEMPLATE>