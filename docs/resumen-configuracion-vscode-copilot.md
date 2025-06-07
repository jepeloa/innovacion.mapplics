# Resumen de Configuración VS Code - GitHub Copilot y Chat

## 📋 Resumen Ejecutivo de Configuración Actual

### **✅ Configuraciones Clave de GitHub Copilot:**
- **Habilitado para archivos adicionales** (`github.copilot.enable`) - texto plano y Markdown
- **Sugerencias de edición siguiente** (`github.copilot.nextEditSuggestions.enabled`) - activadas
- **Modelo de completado** (`github.copilot.selectedCompletionModel`) - automático

### **✅ Configuraciones Destacadas de Copilot Chat:**
- **Idioma en español** (`github.copilot.chat.localeOverride`) - configurado como "es"
- **Preferencias de usuario** (`github.copilot.chat.enableUserPreferences`) - habilitadas
- **Herramienta de pensamiento** (`github.copilot.chat.agent.thinkingTool`) - activada
- **Búsqueda de código** (`github.copilot.chat.codesearch.enabled`) - habilitada
- **Seguimiento de notebooks** (`github.copilot.chat.notebook.followCellExecution.enabled`) - activado

### **🔥 Integración MCP Avanzada:**
- **Servidor Azure DevOps MCP** (`mcp.servers.azureDevOpsSHELL`) - completamente configurado
- **Servidor Context7** (`mcp.servers.context7`) - para documentación técnica actualizada
- **Múltiples modelos de IA** (`chat.mcp.serverSampling`) - GPT-4, Claude, Gemini, o1/o3/o4
- **Descubrimiento automático** (`chat.mcp.discovery.enabled`) - habilitado

### **🎯 Características Especiales:**
- **Auto-aprobación de herramientas** (`chat.tools.autoApprove`) - flujo ágil
- **Síntesis de voz** (`accessibility.voice.*`) - en español mexicano
- **Extensiones remotas** (`remote.defaultExtensionsIfInstalledLocally`) - sincronizadas

---

## 📋 Configuración Actual (Exportada desde VS Code Insiders)

A continuación se presenta un análisis detallado de tu configuración actual de VS Code, enfocándose en las configuraciones que modifican el comportamiento de GitHub Copilot y GitHub Copilot Chat.

---

## 📝 Índice de Configuraciones por Parámetro

Para referencia rápida, aquí tienes un índice alfabético de todos los parámetros de configuración relacionados con GitHub Copilot y Chat:

### **Configuraciones de Accesibilidad**
- `accessibility.voice.autoSynthesize` → [#20](#20-síntesis-de-voz-automática)
- `accessibility.voice.ignoreCodeBlocks` → [#21](#21-ignorar-bloques-de-código-en-síntesis)
- `accessibility.voice.speechLanguage` → [#22](#22-idioma-de-síntesis-de-voz)

### **Configuraciones de Chat**
- `chat.agent.maxRequests` → [#12](#12-límite-de-solicitudes-del-agente)
- `chat.mcp.discovery.enabled` → [#18](#18-descubrimiento-mcp)
- `chat.mcp.serverSampling` → [#17](#17-configuración-de-modelos-mcp)
- `chat.renderRelatedFiles` → [#11](#11-renderizado-de-archivos-relacionados)
- `chat.setup.continueLaterIndicator` → [#14](#14-indicador-de-continuar-más-tarde)
- `chat.tools.autoApprove` → [#13](#13-auto-aprobación-de-herramientas)

### **Configuraciones de GitHub Copilot**
- `github.copilot.enable` → [#1](#1-habilitación-de-copilot-por-tipo-de-archivo)
- `github.copilot.nextEditSuggestions.enabled` → [#3](#3-sugerencias-de-edición-siguiente)
- `github.copilot.selectedCompletionModel` → [#2](#2-modelo-de-completado-seleccionado)

### **Configuraciones de GitHub Copilot Chat**
- `github.copilot.chat.agent.thinkingTool` → [#7](#7-herramienta-de-pensamiento-del-agente)
- `github.copilot.chat.codeGeneration.instructions` → [#8](#8-instrucciones-de-generación-de-código)
- `github.copilot.chat.codesearch.enabled` → [#9](#9-búsqueda-de-código-habilitada)
- `github.copilot.chat.enableUserPreferences` → [#4](#4-preferencias-de-usuario-habilitadas)
- `github.copilot.chat.localeOverride` → [#5](#5-configuración-de-idioma)
- `github.copilot.chat.newWorkspaceCreation.enabled` → [#6](#6-creación-de-nuevos-workspaces)
- `github.copilot.chat.notebook.followCellExecution.enabled` → [#10](#10-seguimiento-de-ejecución-de-celdas-en-notebooks)

### **Configuraciones MCP (Model Context Protocol)**
- `mcp.servers.azureDevOpsSHELL` → [#15](#15-servidor-azure-devops)
- `mcp.servers.context7` → [#16](#16-servidor-context7-documentación)

### **Configuraciones de Extensiones Remotas**
- `remote.defaultExtensionsIfInstalledLocally` → [#19](#19-extensiones-remotas-por-defecto)

---

## 🤖 Configuraciones de GitHub Copilot

### **1. Habilitación de Copilot por Tipo de Archivo**
**Parámetro:** `github.copilot.enable`
```json
"github.copilot.enable": {
  "plaintext": true,
  "markdown": true
}
```
**¿Qué hace?** Habilita GitHub Copilot específicamente para archivos de texto plano y Markdown. Por defecto, Copilot está habilitado para la mayoría de lenguajes de programación, pero esta configuración extiende su funcionalidad a tipos de archivo adicionales.

### **2. Modelo de Completado Seleccionado**
**Parámetro:** `github.copilot.selectedCompletionModel`
```json
"github.copilot.selectedCompletionModel": ""
```
**¿Qué hace?** Define el modelo específico de Copilot a usar para sugerencias de código. Al estar vacío, usa el modelo por defecto más reciente disponible.

### **3. Sugerencias de Edición Siguiente**
**Parámetro:** `github.copilot.nextEditSuggestions.enabled`
```json
"github.copilot.nextEditSuggestions.enabled": true
```
**¿Qué hace?** Habilita las sugerencias de edición inteligentes que predicen y sugieren la próxima modificación que podrías querer hacer en tu código, mejorando el flujo de trabajo de edición.

---

## 💬 Configuraciones de GitHub Copilot Chat

### **4. Preferencias de Usuario Habilitadas**
**Parámetro:** `github.copilot.chat.enableUserPreferences`
```json
"github.copilot.chat.enableUserPreferences": true
```
**¿Qué hace?** Permite que Copilot Chat recuerde y utilice tus preferencias personales de codificación y estilo, mejorando la personalización de las respuestas.

### **5. Configuración de Idioma**
**Parámetro:** `github.copilot.chat.localeOverride`
```json
"github.copilot.chat.localeOverride": "es"
```
**¿Qué hace?** Fuerza a Copilot Chat a responder en español, independientemente de la configuración regional del sistema.

### **6. Creación de Nuevos Workspaces**
**Parámetro:** `github.copilot.chat.newWorkspaceCreation.enabled`
```json
"github.copilot.chat.newWorkspaceCreation.enabled": true
```
**¿Qué hace?** Permite que Copilot Chat ayude en la creación y configuración de nuevos espacios de trabajo o proyectos.

### **7. Herramienta de Pensamiento del Agente**
**Parámetro:** `github.copilot.chat.agent.thinkingTool`
```json
"github.copilot.chat.agent.thinkingTool": true
```
**¿Qué hace?** Habilita la funcionalidad de "pensamiento" del agente, que permite a Copilot mostrar su proceso de razonamiento antes de proporcionar una respuesta.

### **8. Instrucciones de Generación de Código**
**Parámetro:** `github.copilot.chat.codeGeneration.instructions`
```json
"github.copilot.chat.codeGeneration.instructions": []
```
**¿Qué hace?** Define instrucciones personalizadas para la generación de código. Actualmente está vacío, pero puedes agregar reglas específicas de codificación.

### **9. Búsqueda de Código Habilitada**
**Parámetro:** `github.copilot.chat.codesearch.enabled`
```json
"github.copilot.chat.codesearch.enabled": true
```
**¿Qué hace?** Permite que Copilot Chat busque y analice código en tu proyecto para proporcionar respuestas más contextuales y precisas.

### **10. Seguimiento de Ejecución de Celdas en Notebooks**
**Parámetro:** `github.copilot.chat.notebook.followCellExecution.enabled`
```json
"github.copilot.chat.notebook.followCellExecution.enabled": true
```
**¿Qué hace?** En notebooks de Jupyter, permite que Copilot Chat siga la ejecución de las celdas para mantener el contexto y proporcionar asistencia más relevante.

---

## 🔧 Configuraciones de Chat Generales

### **11. Renderizado de Archivos Relacionados**
**Parámetro:** `chat.renderRelatedFiles`
```json
"chat.renderRelatedFiles": true
```
**¿Qué hace?** Muestra archivos relacionados en el contexto del chat, facilitando la comprensión del proyecto completo.

### **12. Límite de Solicitudes del Agente**
**Parámetro:** `chat.agent.maxRequests`
```json
"chat.agent.maxRequests": 50
```
**¿Qué hace?** Establece el número máximo de solicitudes que el agente de chat puede procesar, evitando el uso excesivo de recursos.

### **13. Auto-aprobación de Herramientas**
**Parámetro:** `chat.tools.autoApprove`
```json
"chat.tools.autoApprove": true
```
**¿Qué hace?** Permite que el chat use herramientas automáticamente sin pedir confirmación para cada acción, agilizando el flujo de trabajo.

### **14. Indicador de Continuar Más Tarde**
**Parámetro:** `chat.setup.continueLaterIndicator`
```json
"chat.setup.continueLaterIndicator": true
```
**¿Qué hace?** Muestra un indicador visual cuando una conversación puede continuarse más tarde, mejorando la experiencia de usuario.

---

## 🌐 Configuración MCP (Model Context Protocol)

### **15. Servidor Azure DevOps**
**Parámetro:** `mcp.servers.azureDevOpsSHELL`
```json
"mcp": {
  "servers": {
    "azureDevOpsSHELL": {
      "command": "bash",
      "args": ["-c", "source $HOME/.nvm/nvm.sh && nvm use --lts --silent && node ~/Proyectos/mcp-servers/mcp-server-azure-devops/dist/index.js"],
      "env": {
        "AZURE_DEVOPS_ORG_URL": "https://dev.azure.com/mapplicsdevs",
        "AZURE_DEVOPS_AUTH_METHOD": "azure-cli",
        "AZURE_TENANT_ID": "3909188d-2c34-40e3-b4d8-85023830b7d4",
        "AZURE_DEVOPS_DEFAULT_PROJECT": "MEN0009-Shell.SCM_1"
      }
    }
  }
}
```
**¿Qué hace?** Configura un servidor MCP personalizado para Azure DevOps que permite a Copilot Chat interactuar directamente con tu instancia de Azure DevOps para consultar work items, pull requests, pipelines, etc.

### **16. Servidor Context7 (Documentación)**
**Parámetro:** `mcp.servers.context7`
```json
"context7": {
  "command": "npx",
  "args": ["-y", "@upstash/context7-mcp"],
  "env": {
    "DEFAULT_MINIMUM_TOKENS": "6000"
  }
}
```
**¿Qué hace?** Configura el servidor MCP de Context7 que proporciona acceso a documentación actualizada de frameworks, APIs, lenguajes y tecnologías. Permite obtener documentación sin buscar en internet, con un mínimo de 6000 tokens por consulta.

### **17. Configuración de Modelos MCP**
**Parámetro:** `chat.mcp.serverSampling`
```json
"chat.mcp.serverSampling": {
  "Global in Code - Insiders: azureDevOpsSHELL": {
    "allowedModels": [
      "github.copilot-chat/gpt-4.1",
      "github.copilot-chat/claude-3.5-sonnet",
      "github.copilot-chat/claude-3.7-sonnet",
      "github.copilot-chat/claude-3.7-sonnet-thought",
      "github.copilot-chat/claude-sonnet-4",
      "github.copilot-chat/gemini-2.0-flash-001",
      "github.copilot-chat/gemini-2.5-pro",
      "github.copilot-chat/gpt-4o",
      "github.copilot-chat/o1",
      "github.copilot-chat/o3-mini",
      "github.copilot-chat/o4-mini"
    ]
  }
}
```
**¿Qué hace?** Define qué modelos de IA pueden usar el servidor MCP de Azure DevOps, incluyendo los modelos más avanzados como Claude, GPT-4, Gemini y la serie o1/o3/o4.

### **18. Descubrimiento MCP**
**Parámetro:** `chat.mcp.discovery.enabled`
```json
"chat.mcp.discovery.enabled": true
```
**¿Qué hace?** Habilita el descubrimiento automático de servidores MCP disponibles, facilitando la integración con servicios externos.

---

## 🎨 Configuraciones de Interfaz y Experiencia

### **19. Extensiones Remotas por Defecto**
**Parámetro:** `remote.defaultExtensionsIfInstalledLocally`
```json
"remote.defaultExtensionsIfInstalledLocally": [
  "GitHub.copilot",
  "GitHub.copilot-chat",
  "GitHub.vscode-pull-request-github"
]
```
**¿Qué hace?** Asegura que las extensiones de GitHub Copilot se instalen automáticamente en entornos remotos (como contenedores o SSH) si están instaladas localmente.

---

## 🔊 Configuraciones de Accesibilidad

### **20. Síntesis de Voz Automática**
**Parámetro:** `accessibility.voice.autoSynthesize`
```json
"accessibility.voice.autoSynthesize": "on"
```
**¿Qué hace?** Habilita la síntesis automática de voz para leer contenido en VS Code.

### **21. Ignorar Bloques de Código en Síntesis**
**Parámetro:** `accessibility.voice.ignoreCodeBlocks`
```json
"accessibility.voice.ignoreCodeBlocks": true
```
**¿Qué hace?** Configura la síntesis de voz para que ignore los bloques de código, proporcionando una mejor experiencia auditiva.

### **22. Idioma de Síntesis de Voz**
**Parámetro:** `accessibility.voice.speechLanguage`
```json
"accessibility.voice.speechLanguage": "es-MX"
```
**¿Qué hace?** Establece el idioma de la síntesis de voz en español mexicano para una mejor pronunciación.

---

## 📤 Cómo Exportar y Compartir esta Configuración

### Para Exportar:
1. Copia el contenido del archivo `settings.json` desde: `~/.config/Code - Insiders/User/settings.json`
2. O usa el comando: `Preferences: Open User Settings (JSON)` en VS Code

### Para Importar en Otra Instalación:
1. Abre VS Code en la nueva máquina
2. Ve a `Preferences: Open User Settings (JSON)`
3. Pega la configuración completa
4. Reinicia VS Code

### Exportación Completa del Perfil:
También puedes usar la función **Settings Sync** de VS Code para sincronizar toda tu configuración entre dispositivos:
- Ve a `File > Preferences > Settings Sync`
- Inicia sesión con tu cuenta de GitHub/Microsoft
- Selecciona qué elementos sincronizar

---

## 🚀 Recomendaciones Adicionales

Basándome en tu configuración actual, podrías considerar agregar:

1. **Instrucciones de generación de código personalizadas:**
   ```json
   "github.copilot.chat.codeGeneration.instructions": [
     "Siempre incluir comentarios en español",
     "Usar nombres de variables descriptivos",
     "Aplicar principios SOLID"
   ]
   ```

2. **Configuración específica por lenguaje:**
   ```json
   "[javascript]": {
     "github.copilot.enable": true
   },
   "[typescript]": {
     "github.copilot.enable": true
   }
   ```

---

**Fecha de exportación:** 7 de junio de 2025  
**Versión de VS Code:** Insiders  
**Ubicación del archivo:** `~/.config/Code - Insiders/User/settings.json`
