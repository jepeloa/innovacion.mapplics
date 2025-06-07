# Presentación: Vibe Coding Estructurado con GitHub Copilot

## 1. Introducción: El Futuro del Desarrollo con IA

### ¿Qué es el Vibe Coding Estructurado?

Es el arte de construir una narrativa a través de la colaboración con una inteligencia artificial.

**Implica:**

- **Metodología:** Seguir un plan claro y guiar a la IA, comunicando el "porqué" de cada paso en la generación de código.
- **Claridad:** Dirigir a la IA para producir código simple, legible y bien explicado.
- **Interacción:** Involucrar activamente a la IA, ajustando las instrucciones y adaptándose a las sugerencias que ofrece.
- **Objetivo:** El fin no es solo el código funcional generado por la IA, sino la transferencia de conocimiento y el aprendizaje colaborativo.

### ¿Por qué usar GitHub Copilot?

GitHub Copilot es más que un autocompletado; es un compañero de programación basado en IA. En un entorno de vibe coding, su principal valor es:

- **Reducir el "Tiempo Muerto":** Genera código repetitivo (boilerplate), funciones complejas y pruebas en segundos, permitiéndote enfocarte en la lógica y la explicación.
- **Aumentar la Fluidez:** Evita que te quedes atascado en problemas de sintaxis o buscando en la documentación.
- **Inspirar Soluciones:** Puede sugerir enfoques o algoritmos que no habías considerado.
- **Integración y Continuidad:** Al funcionar dentro del mismo IDE (como VS Code), no hay necesidad de cambiar de entorno. Esto permite una transición gradual desde la programación "a mano" hacia un flujo de trabajo asistido por IA, reduciendo la curva de aprendizaje.
- **Modelo de Precios Predecible:** Su suscripción fija evita sorpresas en la facturación, a diferencia de los modelos de pago por token, lo que lo hace rentable para un uso intensivo y facilita la presupuestación.
- **Acceso a Múltiples LLMs:** Integra modelos de vanguardia de diferentes proveedores (como OpenAI, Anthropic, etc.) en una sola herramienta, permitiendo elegir el más adecuado para cada tarea sin cambiar de aplicación.
## 2. El Flujo de Trabajo: De la Idea al Código con "Sesiones de IA"

En lugar de pensar en prompts aislados, el enfoque más efectivo es un flujo de trabajo dividido en sesiones de trabajo contextualizadas. Cada sesión tiene un objetivo claro y configura al asistente de IA con un rol específico.

### El "Prompt Cero" Estructurado: La Plantilla de Inicio

Para maximizar la eficiencia, se evoluciona del "Prompt Cero" conversacional a una plantilla estructurada. Este enfoque obliga al desarrollador a clarificar sus propios pensamientos y provee a la IA un contexto completo y sin ambigüedades desde el inicio. A continuación se describe una plantilla de referencia altamente efectiva:

1. **Rol del Agente IA:** Define la 'personalidad' y el área de especialización que debe adoptar la IA.
   - **Ejemplo:** "Eres un Ingeniero de Software Full Stack altamente capacitado, con experiencia en diseño de APIs RESTful y desarrollo de interfaces de usuario escalables. Tu objetivo es ayudarme a desarrollar código de manera eficiente y siguiendo las mejores prácticas."

2. **Contexto del Proyecto:** Describe el panorama general del proyecto.
   - **Ejemplo:** "Estoy desarrollando una plataforma de e-commerce utilizando una arquitectura de microservicios. Actualmente, trabajo en el servicio de gestión de productos."

3. **Objetivo de la Sesión de Vibe Coding:** Define la tarea específica o el problema a resolver.
   - **Ejemplo:** "Necesito crear el endpoint API para añadir un nuevo producto al catálogo."

4. **Requisitos Funcionales y Técnicos:** Enumera de forma explícita la lógica, validaciones e interacciones.
   - **Ejemplo:**
     - "El endpoint debe ser POST /products."
     - "Requiere autenticación de administrador."
     - "Validar datos del producto (nombre, precio, stock deben ser positivos)."
     - "Guardar el producto en la tabla products en PostgreSQL."
     - "Retornar un objeto con el producto creado y status 201."

5. **Stack Tecnológico Específico para Esta Tarea:** Detalla las herramientas a utilizar.
   - **Ejemplo:** Lenguaje: Python 3.10, Framework: FastAPI, Base de Datos: PostgreSQL.

6. **Formato de Salida Deseado:** Indica cómo debe presentar la solución la IA.
   - **Ejemplo:** "Provee el código completo del endpoint en un solo archivo. Añade comentarios breves para explicar las partes clave y sugiere la forma más eficiente de hacerlo para producción."

7. **Consideraciones Adicionales:** Cualquier otra indicación importante (rendimiento, estándares de codificación, etc.).
   - **Ejemplo:** "Asegura que las operaciones de base de datos sean seguras contra inyección SQL."
### Fase 1: Sesión de Producto y Diseño (Visión e Ideación)

- **Rol del Asistente:** Experto en Producto y Diseñador UX/UI.
- **Objetivo:** Definir el QUÉ. Se describen las necesidades del negocio y las acciones del usuario, sin mencionar tecnología.
- **Proceso:**
  - Se proporciona el contexto inicial del producto usando la plantilla.
  - El asistente sugiere mejoras al flujo, identifica necesidades no cubiertas y refina el alcance.
  - Se le puede dar inspiración visual (capturas de pantalla) para que defina un sistema de diseño (colores, tipografías).
- **Entregable:** Documentación funcional completa, flujos de usuario (con diagramas Mermaid para validación visual) y las bases de la UI.

### Fase 2: Sesión de Arquitectura Técnica

- **Rol del Asistente:** Arquitecto de Software y Experto en Seguridad.
- **Objetivo:** Definir el CÓMO. Se toma el entregable de la Fase 1 como base.
- **Proceso:**
  - Se inicia una nueva sesión con el rol de arquitecto y la plantilla.
  - El asistente define la arquitectura, las tecnologías necesarias y las políticas de seguridad adecuadas al contexto del proyecto.
  - No se genera código de implementación, como mucho pseudocódigo para algoritmos complejos.
- **Entregable:** Documentación técnica, diagramas de arquitectura (C4, etc.) y políticas de seguridad.

### Fase 3: Sesión de Implementación

- **Rol del Asistente:** Desarrollador Experto en las tecnologías definidas.
- **Objetivo:** Escribir el código.
- **Proceso:**
  - Se inicia la sesión configurando al asistente como un programador senior.
  - Se le instruye para que implemente la aplicación siguiendo estrictamente la documentación generada en las Fases 1 y 2.
- **Entregable:** El código fuente completo de la aplicación.

### Principios Fundamentales del Flujo

- **Puntos de Control Humanos:** Entre cada sesión, el desarrollador debe revisar, validar y corregir los entregables. La IA es un asistente, no un sustituto. Esto garantiza que el proyecto se mantenga alineado con los objetivos.
- **Retroalimentación y Aprendizaje Continuo:** Si durante una sesión se requieren muchas correcciones por un contexto inicial pobre, al final se le puede pedir al asistente: "Basado en nuestras correcciones, genera una 'Plantilla de Inicio' mejorada para que nuestra próxima sesión sobre este tema sea más eficiente". Esto nos permite registrar el aprendizaje y mejorar procesos futuros.
## 3. Configurando tu Entorno de Vibe Coding en VS Code

Tu `settings.json` no es solo un archivo de configuración; es la declaración de cómo trabajas y la personalización de tu compañero de IA. Una configuración avanzada te da superpoderes, pero requiere conocer sus implicaciones.

### 3.1: Configuración Esencial de Copilot

Estas opciones afinan el comportamiento básico de Copilot para máxima relevancia.

#### `github.copilot.enable` para plaintext y markdown

- **¿Qué hace?** Activa Copilot en archivos de texto y documentación.
- **Ventaja Estratégica:** Permite usar IA para escribir READMEs, documentación de arquitectura, y hasta el guion de tu sesión de Vibe Coding. Mantiene la consistencia entre el código y su explicación.
- **Riesgo/Consideración:** Puede generar sugerencias no deseadas si solo quieres tomar notas rápidas. Se gestiona fácilmente activando/desactivando Copilot según la tarea.

#### `github.copilot.chat.localeOverride: "es"`

- **¿Qué hace?** Fuerza a que Copilot Chat se comunique exclusivamente en español.
- **Ventaja Estratégica:** Esencial para desarrolladores hispanohablantes. Garantiza claridad, evita el "Spanglish" y permite pensar y recibir ayuda en tu idioma nativo, aumentando la velocidad de comprensión.
- **Riesgo/Consideración:** Para equipos internacionales o al trabajar con librerías muy específicas, la documentación y los términos técnicos pueden ser más precisos en inglés. El modelo subyacente puede tener un rendimiento marginalmente superior en inglés para consultas de alta complejidad técnica.

### 3.2: Integración Avanzada (MCP)

El Model Context Protocol (MCP) es lo que diferencia una configuración estándar de una profesional. Permite a Copilot conectarse a fuentes de datos externas para obtener un contexto hiper-específico.

#### `mcp.servers.azureDevOpsSHELL`

- **¿Qué hace?** Conecta Copilot a tu instancia de Azure DevOps.
- **Ventaja Estratégica:** Copilot puede responder preguntas sobre tus work items, builds, y PRs. Ejemplo: `@workspace #1234 ¿Cuáles son los criterios de aceptación para esta tarea?`. Acelera drásticamente la comprensión de requisitos.
- **Riesgo/Consideración:** Requiere configuración técnica (scripts, variables de entorno). Una mala configuración podría exponer datos sensibles. Depende de la disponibilidad del servicio de Azure DevOps.

#### `mcp.servers.context7`

- **¿Qué hace?** Provee a Copilot acceso a documentación técnica actualizada de frameworks y APIs.
- **Ventaja Estratégica:** Reduce las "alucinaciones" y las respuestas basadas en documentación obsoleta. Obtienes información precisa sin salir del editor, como si tuvieras un motor de búsqueda de documentación integrado y consciente de tu código.
- **Riesgo/Consideración:** Dependencia de un servicio de terceros. Asegúrate de entender su política de privacidad y manejo de datos.

### 3.3: Selección de Modelos y Flujo de Trabajo

Estas opciones te dan control granular sobre qué "cerebro" usa Copilot y cómo interactúa contigo.

#### `chat.mcp.serverSampling`

- **¿Qué hace?** Permite elegir entre diferentes LLMs (GPT-4o, Claude 3.5 Sonnet, Gemini 2.5 Pro, etc.) para tus consultas.
- **Ventaja Estratégica:** Flexibilidad máxima. Puedes usar el mejor modelo para cada tarea: Claude para procesar documentos largos, GPT-4 para lógica compleja, Gemini para creatividad. Es como tener un equipo de especialistas de IA.
- **Riesgo/Consideración:** Requiere un conocimiento profundo de las fortalezas y debilidades de cada modelo. Puede generar inconsistencias si se cambia de modelo a mitad de una tarea.

#### `chat.tools.autoApprove: true`

- **¿Qué hace?** Permite que Copilot ejecute herramientas (ej. comandos en terminal) sin pedir confirmación explícita cada vez.
- **Ventaja Estratégica:** Crea un flujo de trabajo extremadamente ágil y rápido. Reduce interrupciones y clics.
- **Riesgo/Consideración:** **RIESGO ALTO**. Una sugerencia errónea o malinterpretada podría ejecutar un comando destructivo (`rm -rf /`) de forma automática. Solo debe ser usado por desarrolladores experimentados que revisan cuidadosamente cada sugerencia del agente antes de aceptarla.
## 4. Automatizando el Ciclo de Vida del Software con MCP y Azure DevOps

Conectar Copilot a Azure DevOps a través de un servidor MCP transforma al asistente de un simple generador de código a un verdadero miembro del equipo de desarrollo. Le permite leer, entender y actuar sobre la fuente única de verdad de tu proyecto.

### Casos de Uso Estratégicos

#### 1. Creación de Historias de Usuario

- **Objetivo:** Transformar una idea o requisito de negocio en un backlog estructurado y accionable.
- **Proceso:** El desarrollador describe una necesidad en lenguaje natural. Copilot, utilizando la función `create_work_item` del MCP, genera las Historias de Usuario directamente en Azure DevOps, aplicando plantillas HTML estandarizadas para la descripción y los criterios de aceptación.
- **Ejemplo de Prompt:**
  ```
  @workspace #azureDevOps Crea las historias de usuario y tareas asociadas para un módulo de login con autenticación de dos factores. Usa la plantilla estándar de la organización.
  ```

#### 2. Generación de Pull Requests Detallados

- **Objetivo:** Eliminar la tarea manual de documentar los PRs, asegurando consistencia y calidad.
- **Proceso:** Una vez finalizado el código, se le pide a Copilot que cree un PR. El asistente obtiene el contexto de las Historias de Usuario y tareas relacionadas (usando `get_work_item`), analiza los cambios en las ramas y genera un PR con un resumen detallado del trabajo, vinculando los work items y asignando revisores.
- **Ejemplo de Prompt:**
  ```
  @workspace #azureDevOps Crea un Pull Request para la rama 'feature/login-2fa'. Enlaza la HU #5678, resume los cambios y asigna a @JuanPerez como revisor.
  ```

#### 3. Creación Inteligente de Casos de Test

- **Objetivo:** Acelerar el proceso de QA y aumentar la cobertura de las pruebas.
- **Proceso:** Se le indica a Copilot que genere casos de test para una HU específica. Copilot no solo traduce los criterios de aceptación a casos de prueba (usando `create_work_item` con el tipo "Test Case"), sino que también analiza el código modificado para sugerir pruebas adicionales (de regresión, de borde) que podrían ser necesarias.
- **Ejemplo de Prompt:**
  ```
  @workspace #azureDevOps Genera los casos de test para la HU #5678. Asegúrate de cubrir todos los criterios de aceptación y añade tests para validar el manejo de errores en el código modificado.
  ```

#### 4. Generación de Reportes Ejecutivos

- **Objetivo:** Proveer visibilidad del progreso del proyecto a stakeholders no técnicos y facilitar la planificación.
- **Proceso:** Copilot puede consultar el estado de múltiples work items para generar resúmenes. Esto puede ir desde un reporte de sprint que destaque el valor de negocio aportado por cada feature, hasta análisis de desviaciones basados en la cantidad de bugs o la planificación de un nuevo sprint extrayendo US del backlog.
- **Ejemplo de Prompt:**
  ```
  @workspace #azureDevOps Genera un reporte del Sprint 15 enfocado en el valor de negocio entregado. Luego, propón una planificación para el Sprint 16 con las 3 HU de mayor prioridad del backlog.
  ```
### Recomendaciones Clave para el Éxito

Interactuar con un sistema formal como Azure DevOps a través de una IA requiere una técnica de prompting muy especializada.

- **Inyección de Contexto Maestro:** La IA no conoce la API de Azure DevOps ni las funciones de tu MCP por defecto. Cada sesión debe comenzar proveyendo un contexto detallado, como los archivos de referencia que definen las funciones disponibles, la estructura de los work items y los tipos de relaciones. Esto es fundamental para evitar alucinaciones.

- **Trabajo Iterativo y Atómico:** No pidas a la IA que gestione todo el sprint en una sola instrucción. Es mucho más efectivo dar órdenes pequeñas y atómicas.
  - ❌ **Malo:** "Crea todas las tareas del sprint, haz los PR y genera los tests."
  - ✅ **Bueno:** "Crea la HU para el login." (Verificar) → "Ahora, crea las tareas para la HU #5678." (Verificar) → "Ahora, crea el PR para la tarea #5690."

- **Usa Directivas Fuertes y Explícitas:** Sé imperativo. Dile a la IA exactamente qué función del MCP debe usar y con qué parámetros.
  - ❌ **Débil:** "¿Puedes hacer un PR?"
  - ✅ **Fuerte:** "Usa la función `create_pull_request` con `sourceRefName: 'refs/heads/feature/login'`, `targetRefName: 'refs/heads/develop'`, y un título que contenga 'HU #5678'."

- **Utiliza Directivas Negativas:** A veces, es tan importante decir qué no hacer como qué hacer, especialmente para evitar que la IA pierda contexto o use funciones de forma incorrecta.
  - **Ejemplo:** "Genera los casos de prueba y relaciónalos usando `manage_work_item_link` con el tipo 'Microsoft.VSTS.Common.TestedBy-Reverse'. No uses una relación de tipo 'Parent'."
## 5. La Sesión de Documentación: Elevando la Calidad y Consistencia

Más allá del código y la gestión, existe un tipo de sesión especializada para tratar la documentación como un entregable crítico. La Sesión de Documentación utiliza un prompt de inicio detallado para establecer un marco de trabajo que garantice calidad, consistencia y adecuación al público.

### Flujo de Trabajo de la Sesión

Al invocar una "sesión de documentación", la IA inicia un cuestionario estructurado para definir el contexto:

1. **Tipo de Documentación:** ¿Es un manual técnico, un diseño de arquitectura, historias de usuario, un plan de trabajo?
2. **Audiencia Objetivo:** ¿Escribimos para desarrolladores, para gerentes de proyecto o para stakeholders de negocio? El tono y la profundidad cambiarán drásticamente.
3. **Nivel de Detalle:** ¿Visión general o una inmersión profunda y técnica?
4. **Elementos Visuales:** ¿Se necesitan diagramas de flujo, arquitectura o secuencia? Se darán directivas para generar código Mermaid que permita una documentación visual y fácil de mantener.
5. **Nivel de Formalidad:** ¿El lenguaje debe ser formal, técnico-relajado, conversacional o ultra-simplificado? Esto afectará al estilo de redacción, al uso de emojis e incluso a los estilos CSS si se exporta a HTML.
6. **Formato y Estructura:** ¿La salida será un único archivo Markdown, una estructura de directorios, o se exportará a HTML/CSV? Se definen reglas para mantener un formato coherente en todo el proyecto.

### El Poder de las Sesiones Híbridas

La verdadera potencia se desbloquea al combinar tipos de sesiones. No son mutuamente excluyentes; son módulos que se pueden fusionar para crear un flujo de trabajo integral.

#### Ejemplo de Sesión Híbrida: Vibe Coding + Documentación

Al iniciar un proyecto desde cero, se puede invocar una sesión combinada:

```
"Iniciar una sesión de documentación combinada con Vibe Code para el desarrollo de una nueva aplicación."
```

Este comando dispara ambos prompts de contexto. El resultado es un asistente que:

1. **Primero**, te guía a través del cuestionario de documentación para tomar decisiones clave sobre el producto, la audiencia y la arquitectura.
2. **Luego**, utiliza esa información para guiar la generación de código, asegurando que la implementación esté alineada con la documentación.
3. **Simultáneamente**, va generando la documentación del proyecto en tiempo real, con el formato, tono y estructura definidos al inicio.

Este enfoque asegura que al final no solo tengas una aplicación funcional, sino también una documentación de alta calidad, coherente y lista para ser entregada, eliminando la deuda técnica documental desde el primer día.
## 6. El Ecosistema y el Futuro: Más Allá de un Solo Modelo

Hemos hablado de Copilot, pero es crucial entender que esta metodología trasciende una única herramienta. La verdadera revolución está en el flujo de trabajo.

- **Copilot como Integrador:** Piensa en GitHub Copilot como el "cockpit" o la cabina de mandos. Es la interfaz que unifica todo. Proporciona el chat, las sugerencias inline y la conexión con tu IDE.

- **LLMs como Motores:** Los modelos como GPT-4, Claude y Gemini son los "motores". Tu configuración avanzada (`chat.mcp.serverSampling`) te permite cambiar de motor en pleno vuelo según la necesidad: uno para análisis de código, otro para creatividad, otro para procesar grandes documentos.

- **MCP como Conectores:** Los servidores MCP son los conectores que enchufan tus motores a fuentes de datos del mundo real como Azure DevOps o bases de datos de documentación.

El futuro no es depender de un único "mejor" modelo, sino tener un proceso robusto y agnóstico al modelo que te permita aprovechar la mejor herramienta para cada tarea específica, todo desde una única interfaz integrada.

## 7. Conclusión: Principios para un Nuevo Paradigma de Desarrollo

Si deben llevarse algo de esta presentación, que sean estos cuatro principios clave:

### 1. Cambio de Paradigma: De Programador a Director de Orquesta

El Vibe Coding Estructurado no se trata de escribir código más rápido. Se trata de pensar a un nivel más alto. Tu rol evoluciona de ser un simple ejecutor a ser un estratega que guía a un asistente de IA extremadamente capaz. La habilidad clave ya no es solo la sintaxis, sino la capacidad de definir, estructurar y comunicar una visión.

### 2. El Contexto es el Rey

Desde el "Prompt Cero" estructurado hasta la inyección de contexto de la API de Azure DevOps, el éxito depende de una sola cosa: la calidad de la información que proporcionas. Un contexto pobre o ambiguo lleva a resultados mediocres. Un contexto rico, preciso y bien estructurado produce soluciones de alta calidad. Invertir tiempo en definir el contexto es la optimización más importante que puedes hacer.

### 3. Modularidad y Sesiones Híbridas: Construye tu Flujo de Trabajo

No existe una única forma de trabajar. Piensa en las "Sesiones" (Vibe Code, Azure DevOps, Documentación) como bloques de Lego. Puedes usarlos por separado o combinarlos para crear flujos de trabajo híbridos y personalizados que se adapten perfectamente a las necesidades de tu proyecto. La verdadera maestría reside en saber qué bloques combinar y cuándo.

### 4. El Proceso sobre la Herramienta

El modelo de IA que uses hoy será superado por otro mañana. Las herramientas específicas cambiarán. Lo que perdurará es el proceso: la metodología de dividir problemas, definir contextos, validar resultados y automatizar tareas repetitivas. Al enfocarte en construir un flujo de trabajo sólido, te preparas para el futuro, sin importar qué nuevas tecnologías aparezcan.

## Discusión Abierta

¿Preguntas, ideas, experiencias? ¡Ahora les toca a ustedes!
