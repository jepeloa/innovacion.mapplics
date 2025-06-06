# Proyecto Innovación Mapplics

## Introducción

Este proyecto está diseñado para facilitar la implementación y ejecución de casos de ejemplo organizados en subdirectorios. La estructura modular permite desarrollar, probar y demostrar soluciones en entornos aislados de manera sencilla.

## Estructura del Proyecto

La siguiente estructura de directorios facilita la organización de los casos de ejemplo:

```
/home/javier/Proyectos/MAPPLICS/innovacion.mapplics/
│
├── README.md
├── docs/                # Documentación general del proyecto
│   └── cuestionario-contexto-proyecto.md
├── examples/            # Casos de ejemplo y documentación técnica
│   └── generacion de test case/
│       ├── consideraciones-tecnicas-test-cases-azure-devops.md
│       ├── correccion-relaciones-test-cases-us-19676.md
│       ├── ejemplos-practicos-mcp-azure-devops-test-cases.md
│       ├── guia-completa-test-cases-azure-devops.md
│       ├── promt_utilizado.md
│       └── test-case-us-19676-validacion-fortaleza-password.md
├── .github/             # Configuración de GitHub Copilot
│   ├── copilot-azure-dev-ops-session.md
│   ├── copilot-documentation-session.md
│   ├── copilot-instructions.md
│   └── copilot-vibe-session.md
└── .vscode/             # Configuración del workspace
    └── mcp.json
```

## Uso

### Navegando la Documentación

Para acceder a la documentación técnica del caso de ejemplo de generación de test cases:

1. **Navegue al directorio del caso:**
   ```bash
   cd examples/"generacion de test case"
   ```

2. **Revise la guía principal:**
   - Comience con `guia-completa-test-cases-azure-devops.md` para una visión general completa
   - Consulte `ejemplos-practicos-mcp-azure-devops-test-cases.md` para implementaciones específicas

3. **Explore el caso de estudio:**
   - Revise `test-case-us-19676-validacion-fortaleza-password.md` para ver la definición de test cases
   - Consulte `correccion-relaciones-test-cases-us-19676.md` para el proceso de implementación

### Trabajando con GitHub Copilot

Para activar las sesiones especializadas de GitHub Copilot, utilice los comandos definidos en los archivos de configuración:

```
Iniciar sesión de trabajo con Azure DevOps
```

```
Iniciar sesión de documentación
```

```
Iniciar sesión de Vibe Coding
```

## Cómo Agregar Nuevos Casos de Ejemplo

1. **Crear un nuevo subdirectorio** dentro de `examples/` con un nombre descriptivo del caso.

2. **Incluir documentación completa** siguiendo el patrón establecido:
   - Guía principal del caso
   - Ejemplos prácticos con código
   - Consideraciones técnicas específicas
   - Documentación del proceso o prompt utilizado

3. **Seguir las mejores prácticas**:
   - Usar formato Markdown consistente
   - Incluir índices y referencias cruzadas
   - Documentar tanto el qué como el cómo y el por qué
   - Agregar ejemplos de código funcional cuando sea aplicable

4. **Actualizar este README** para incluir referencias al nuevo caso en la sección de documentación técnica.

## Contribuciones

Si deseas mejorar o agregar nuevos casos de ejemplo, por favor sigue las directrices de contribución y asegúrate de mantener la coherencia en la estructura y documentación.

## Documentación Técnica

### Caso de Ejemplo: Generación de Test Cases

Dentro del directorio `examples/generacion de test case/` se encuentra toda la documentación técnica relacionada con la creación y gestión de test cases en Azure DevOps:

#### **Guías Principales**
- **[Guía Completa para Test Cases](examples/generacion%20de%20test%20case/guia-completa-test-cases-azure-devops.md)**: Documentación exhaustiva sobre creación y gestión de test cases en Azure DevOps
- **[Ejemplos Prácticos con MCP Server](examples/generacion%20de%20test%20case/ejemplos-practicos-mcp-azure-devops-test-cases.md)**: Casos de uso prácticos utilizando el MCP Server de Azure DevOps
- **[Consideraciones Técnicas](examples/generacion%20de%20test%20case/consideraciones-tecnicas-test-cases-azure-devops.md)**: Mejores prácticas y configuraciones técnicas

#### **Documentación del Caso de Estudio**
- **[Corrección de Relaciones US #19676](examples/generacion%20de%20test%20case/correccion-relaciones-test-cases-us-19676.md)**: Proceso detallado de corrección de relaciones entre test cases y user stories
- **[Test Cases Validación de Password](examples/generacion%20de%20test%20case/test-case-us-19676-validacion-fortaleza-password.md)**: Definición completa de test cases para validación de fortaleza de contraseñas
- **[Prompt Utilizado](examples/generacion%20de%20test%20case/promt_utilizado.md)**: Documentación del prompt y proceso de generación

### Configuración de GitHub Copilot

En el directorio `.github/` se encuentran las configuraciones para sesiones especializadas:

- **[Sesión Azure DevOps](.github/copilot-azure-dev-ops-session.md)**: Configuración para trabajar con Azure DevOps usando GitHub Copilot
- **[Sesión de Documentación](.github/copilot-documentation-session.md)**: Flujo para generar documentación técnica
- **[Sesión Vibe Coding](.github/copilot-vibe-session.md)**: Metodología de desarrollo colaborativo con IA
- **[Instrucciones Generales](.github/copilot-instructions.md)**: Instrucciones base para el comportamiento de GitHub Copilot

### Documentación General

En el directorio `docs/` se encuentra documentación general del proyecto:

- **[Cuestionario Contexto Proyecto](docs/cuestionario-contexto-proyecto.md)**: Plantilla para definir el contexto de proyectos






