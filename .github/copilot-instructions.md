# Instrucciones para GitHub Copilot

Este documento contiene instrucciones específicas para trabajar con GitHub Copilot en el proyecto.

---

## Activación de Sesiones Especiales

Las sesiones especiales de GitHub Copilot permiten a los desarrolladores interactuar con la IA de manera más estructurada y enfocada. Estas sesiones se inician con comandos específicos que guían a la IA en la generación de código o documentación.
Es posible utilizar instrucciones para solicitar sesiones hibridas por ejemplo generar documentacion utilziando vibe coding o generar codigo utilizando la documentacion existente.

### Sesión de Vibe Coding

Para iniciar una sesión de Vibe Coding, utiliza la siguiente instrucción:

```Iniciar sesión de Vibe Coding
```
Al iniciar una sesion de Vibe Coding, guiar al desarrollador para que propocione un contexto claro y detallado.Trata de en lo posible utilizar preguntas con opciones numeradas para facilitar la respuesta.
Esto permite a la IA entender mejor el contexto y los objetivos del proyecto, facilitando la generación de código relevante y útil.

Esta sesion inicia un flujo de trabajo para crear código de manera eficiente y siguiendo las mejores prácticas. Durante esta sesión, se te guiará a través de preguntas sobre:

1. El rol del agente IA (tipo de experto)
2. El contexto del proyecto
3. El objetivo de la sesión de Vibe Coding
4. Los requisitos funcionales y técnicos
5. El stack tecnológico específico para la tarea
6. El formato de salida deseado
7. Consideraciones adicionales

Las instrucciones completas para esta sesión se encuentran en el archivo `.github/copilot-vibe-session.md`.


### Sesión de Documentación

Para activar una sesión específica de generación de documentación, utiliza la siguiente instrucción:

```
Iniciar sesión de documentación
```

Esta instrucción inicia un flujo de trabajo para crear diversos tipos de documentación técnica:
- Documentación de procesos
- Diseño de aplicación/sistema
- Historias de usuario y requerimientos
- Plan de trabajo y estimaciones

Al iniciar esta sesión, se te guiará a través de preguntas sobre:
1. El tipo de documentación que necesitas
2. La audiencia objetivo
3. El nivel de detalle requerido
4. Los elementos visuales necesarios
5. El nivel de formalidad del lenguaje
6. El contexto del proyecto
7. Las preferencias para archivos y directorios

Las instrucciones completas para esta sesión se encuentran en el archivo `.github/copilot-documentation-session.md`.

### Sesión de Azure DevOps

Para activar una sesión específica de trabajo con Azure DevOps, utiliza la siguiente instrucción:

```
Iniciar sesión de trabajo con Azure DevOps
```

Esta instrucción activa las funcionalidades y consultas específicas para trabajar con Azure DevOps, permitiéndote:
- Consultar historias de usuario
- Obtener tareas por sprint
- Generar reportes de trabajo
- Analizar tiempos de trabajo

Las instrucciones completas para esta sesión se encuentran en el archivo `.github/copilot-azure-dev-ops-session.md`.

---

## Servicios MCP dispobibles

- **MCP de Documentación**: Utilizar Context 7 para obtener la ultima documentacion disponibles de frameworks, apis, lengueges, tectnologias, etc. No buscar documentcion en internet. Si el servicion no esta disponible sugerir al desarrollador que lo configure en su entorno local.
- **MCP de MySql**: Utilizar un servicion mcp para mysql para realizar consultas a la base de datos si el codigo que se esta desarrollando implica la interaccion con la base de datos, Es posible utilizar un servicio MCP para que la ia realice las queries necesarias para comprender la estrucutra de datos y analizar si el origen de un problema es la informacion en la base de datos en lugar del codigo. 
