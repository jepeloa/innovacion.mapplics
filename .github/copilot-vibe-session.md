# Guía para Sesiones de Vibe Coding con IA

## Utiliza el siguiente formato para estructurar la solicitud:

**Rol del Agente IA:** Eres un [Tipo de experto, e.g., Ingeniero de Software Full Stack, Especialista en Backend con Python, Desarrollador Frontend con React, Experto en DevOps] altamente capacitado, con experiencia en [Tecnologías relevantes para el rol: e.g., diseño de APIs RESTful, desarrollo de interfaces de usuario escalables, gestión de bases de datos NoSQL, configuración de pipelines CI/CD]. Tu objetivo es ayudarme a desarrollar código de manera eficiente y siguiendo las mejores prácticas para [Contexto del proyecto: e.g., una aplicación web, un script de automatización, un microservicio].

**Contexto del Proyecto:**
[Proporciona una descripción concisa del proyecto en el que estás trabajando. ¿Cuál es su propósito principal? ¿Cuál es su estado actual (nuevo, en desarrollo, mantenimiento)?
Describe la arquitectura general si es relevante (e.g., monolítica, microservicios).
Si estás trabajando en una parte específica, menciona cómo se relaciona con el todo.]
*Ejemplo: "Estoy desarrollando una plataforma de e-commerce utilizando una arquitectura de microservicios. Actualmente, trabajo en el servicio de gestión de productos."*

**Objetivo de la Sesión de Vibe Coding:**
[Define claramente la tarea específica o el problema que quieres abordar en esta sesión. ¿Qué funcionalidad buscas? ¿Qué error necesitas corregir? ¿Qué refactorización quieres realizar?]
*Ejemplo: "Necesito crear el endpoint API para añadir un nuevo producto al catálogo."*

**Requisitos Funcionales y Técnicos:**
[Enumera los requisitos de forma detallada. Sé lo más explícito posible sobre la lógica, las validaciones, las interacciones con otros sistemas (como una base de datos o servicios externos).]
- [Requisito 1]
- [Requisito 2]
- [Requisito N]
*Ejemplo:
- "El endpoint debe ser POST /products."
- "Requiere autenticación de administrador (verificar token en el header)."
- "Validar los datos del producto (nombre, descripción, precio, stock) – el precio y stock deben ser números positivos."
- "Guardar el producto en la tabla `products` en la base de datos PostgreSQL."
- "Si es exitoso, retornar un objeto con el producto creado y status 201."
- "Manejar errores de validación y de base de datos con respuestas adecuadas (e.g., status 400, 500)."*

**Stack Tecnológico Específico para Esta Tarea:**
- **Lenguaje/Versión:** [e.g., Python 3.10, TypeScript 5.x]
- **Framework/Librerías:** [e.g., FastAPI, Express.js, Spring Boot, Next.js, TypeORM, Mongoose]
- **Base de Datos (si aplica):** [e.g., PostgreSQL, MongoDB]
- **Entorno/Otros:** [e.g., Docker, Kubernetes, AWS Lambda, etc.]

**Formato de Salida Deseado:**
[Indica cómo esperas que la IA presente la solución. ¿Solo el fragmento de código? ¿El archivo completo? ¿Una explicación del código? ¿Pruebas unitarias?]
- [Formato 1]
- [Formato 2]
*Ejemplo:
- "Provee el código completo del endpoint en Python usando FastAPI."
- "Incluye ejemplos de cómo usar los modelos de Pydantic para validación y TypeORM para la interacción con la DB."
- "Añade comentarios breves para explicar las partes clave."
- "Si hay múltiples formas de hacerlo, sugiere la más eficiente para producción y explica por qué."*

**Consideraciones Adicionales:**
[Cualquier otra indicación importante: rendimiento esperado, estándares de codificación (PEP 8, Airbnb, etc.), seguridad (aunque la IA necesita supervisión humana en esto ), etc.]
*Ejemplo: "Asegura que el código sea idempotente si aplica."*