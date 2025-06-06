# Test Case - Historia de Usuario #19676
## Aplicar validación de fortaleza de password en la creación de usuario

---

### 📋 **INFORMACIÓN GENERAL**

| **Campo** | **Valor** |
|-----------|-----------|
| **Historia de Usuario** | #19676 - Aplicar validación de fortaleza de password en la creación de usuario |
| **Sprint** | Sprint 61 |
| **Estado** | Resolved |
| **Responsable** | Joel Olaya |
| **Fecha de Test** | _________________ |
| **Tester** | _________________ |
| **Ambiente** | 🧪 **ENTORNO DE TEST** |

---

### 🎯 **OBJETIVO DEL TEST**

Verificar que la validación de fortaleza de contraseñas funciona correctamente tanto en el backend como en el frontend, incluyendo:
- Validación de fortaleza en creación de usuarios
- Validación de fortaleza en cambio de contraseña
- Campo `require_change_password` en base de datos
- Advertencias y navegación en aplicaciones frontend

---

### 📝 **TAREAS IMPLEMENTADAS**

| **ID** | **Tarea** | **Estado** |
|--------|-----------|------------|
| #19828 | Agregar campo a la tabla users "require_change_password" | ✅ Closed |
| #19829 | Agregar al resource y entidad de user nuevo campo | ✅ Closed |
| #19830 | En cada user creado imaginario agregar este campo | ✅ Closed |
| #19831 | FRONT wmcloud - Agregar cartel de advertencia con botón a change-password | ✅ Closed |
| #19853 | FRONT tiendas - Agregar cartel de advertencia si devuelve en 1 nuevo campo | ✅ Closed |
| #19854 | FRONT fabricaciones - Agregar cartel de advertencia si devuelve en 1 nuevo campo | ✅ Closed |
| #19865 | FRONT combustibles - Agregar cartel de advertencia si devuelve en 1 nuevo campo | ✅ Closed |

---

## 🧪 **CASOS DE PRUEBA**

### **TEST CASE 1: Validación Backend - Creación de Usuario**

#### **Prerrequisitos:**
- [ ] Acceso a la aplicación con permisos de administrador
- [ ] Base de datos actualizada con el campo `require_change_password`
- [ ] Backend con validaciones implementadas

#### **Pasos de Ejecución:**

**Paso 1:** Crear usuario con contraseña DÉBIL
- [ ] 1.1. Acceder al módulo de creación de usuarios
- [ ] 1.2. Ingresar datos del usuario (nombre, email, etc.)
- [ ] 1.3. Ingresar contraseña débil (ej: "123456")
- [ ] 1.4. Intentar guardar el usuario

**Resultado Esperado:** ❌ El sistema debe rechazar la creación y mostrar mensaje de error indicando los requisitos de contraseña

**Paso 2:** Crear usuario con contraseña FUERTE
- [ ] 2.1. Mantener los mismos datos del usuario
- [ ] 2.2. Ingresar contraseña fuerte (ej: "MiContraseña123!@")
- [ ] 2.3. Guardar el usuario

**Resultado Esperado:** ✅ El usuario se crea exitosamente y se guarda en base de datos

---

### **TEST CASE 2: Verificación Base de Datos**

#### **Pasos de Ejecución:**

**Paso 3:** Verificar campo en base de datos
- [ ] 3.1. Consultar la tabla `users` en base de datos
- [ ] 3.2. Verificar que existe el campo `require_change_password`
- [ ] 3.3. Verificar que el usuario creado tiene un valor en este campo

**Resultado Esperado:** ✅ El campo existe y tiene un valor apropiado (0 o 1)

**Paso 4:** Verificar usuarios existentes
- [ ] 4.1. Verificar que usuarios imaginarios tienen el campo agregado
- [ ] 4.2. Consultar varios registros de usuarios de prueba

**Resultado Esperado:** ✅ Todos los usuarios existentes tienen el nuevo campo poblado

---

### **TEST CASE 3: Validación Frontend - WMCloud**

#### **Pasos de Ejecución:**

**Paso 5:** Login con usuario que requiere cambio de contraseña
- [ ] 5.1. Acceder a la aplicación **WMCloud**
- [ ] 5.2. Hacer login con un usuario que tenga `require_change_password = 1`
- [ ] 5.3. Observar la interfaz después del login

**Resultado Esperado:** ⚠️ Debe aparecer un cartel de advertencia indicando que se debe cambiar la contraseña

**Paso 6:** Navegar al cambio de contraseña
- [ ] 6.1. Hacer clic en el botón del cartel de advertencia
- [ ] 6.2. Verificar que redirecciona a la vista "change-password"
- [ ] 6.3. Verificar que la vista se carga correctamente

**Resultado Esperado:** ✅ Navegación exitosa a la pantalla de cambio de contraseña

---

### **TEST CASE 4: Validación Frontend - Tiendas**

#### **Pasos de Ejecución:**

**Paso 7:** Verificar advertencia en aplicación Tiendas
- [ ] 7.1. Acceder a la aplicación **Tiendas**
- [ ] 7.2. Hacer login con usuario que requiere cambio de contraseña
- [ ] 7.3. Verificar aparición del cartel de advertencia

**Resultado Esperado:** ⚠️ Cartel de advertencia visible y funcional

**Paso 8:** Funcionalidad del cartel en Tiendas
- [ ] 8.1. Interactuar con el cartel de advertencia
- [ ] 8.2. Verificar que permite navegar al cambio de contraseña
- [ ] 8.3. Verificar que no interfiere con otras funcionalidades

**Resultado Esperado:** ✅ Funcionalidad completa y sin interferencias

---

### **TEST CASE 5: Validación Frontend - Fabricaciones**

#### **Pasos de Ejecución:**

**Paso 9:** Verificar advertencia en aplicación Fabricaciones
- [ ] 9.1. Acceder a la aplicación **Fabricaciones**
- [ ] 9.2. Hacer login con usuario que requiere cambio de contraseña
- [ ] 9.3. Verificar aparición del cartel de advertencia

**Resultado Esperado:** ⚠️ Cartel de advertencia visible según el nuevo campo

**Paso 10:** Consistencia visual en Fabricaciones
- [ ] 10.1. Verificar que el cartel sigue el mismo diseño que otras apps
- [ ] 10.2. Verificar que el comportamiento es consistente
- [ ] 10.3. Probar la funcionalidad del botón

**Resultado Esperado:** ✅ Diseño y comportamiento consistente

---

### **TEST CASE 6: Validación Frontend - Combustibles**

#### **Pasos de Ejecución:**

**Paso 11:** Verificar advertencia en aplicación Combustibles
- [ ] 11.1. Acceder a la aplicación **Combustibles**
- [ ] 11.2. Hacer login con usuario que requiere cambio de contraseña
- [ ] 11.3. Verificar aparición del cartel de advertencia

**Resultado Esperado:** ⚠️ Cartel de advertencia visible y funcional

**Paso 12:** Integración completa en Combustibles
- [ ] 12.1. Verificar que no afecta otras funcionalidades
- [ ] 12.2. Probar flujo completo de cambio de contraseña
- [ ] 12.3. Verificar que el cartel desaparece después del cambio

**Resultado Esperado:** ✅ Integración sin problemas y flujo completo

---

### **TEST CASE 7: Validación Cambio de Contraseña**

#### **Pasos de Ejecución:**

**Paso 13:** Cambiar contraseña con validación
- [ ] 13.1. Acceder a la vista de cambio de contraseña desde cualquier app
- [ ] 13.2. Intentar cambiar a una contraseña débil
- [ ] 13.3. Verificar que el sistema rechaza la contraseña débil

**Resultado Esperado:** ❌ Sistema rechaza contraseña débil con mensaje claro

**Paso 14:** Cambio exitoso de contraseña
- [ ] 14.1. Cambiar a una contraseña que cumpla los requisitos
- [ ] 14.2. Confirmar el cambio
- [ ] 14.3. Verificar que el campo `require_change_password` se actualiza a 0

**Resultado Esperado:** ✅ Cambio exitoso y actualización en base de datos

---

### **TEST CASE 8: Casos Extremos y Validaciones**

#### **Pasos de Ejecución:**

**Paso 15:** Validar requisitos específicos de contraseña
- [ ] 15.1. Probar contraseña muy corta (menos de 8 caracteres)
- [ ] 15.2. Probar contraseña sin números
- [ ] 15.3. Probar contraseña sin mayúsculas
- [ ] 15.4. Probar contraseña sin caracteres especiales
- [ ] 15.5. Probar contraseña solo con espacios

**Resultado Esperado:** ❌ Todas las contraseñas débiles deben ser rechazadas con mensajes específicos

**Paso 16:** Consistency check entre frontend y backend
- [ ] 16.1. Verificar que las validaciones del frontend coinciden con las del backend
- [ ] 16.2. Intentar bypasear validaciones frontend (si es técnicamente posible)
- [ ] 16.3. Confirmar que el backend siempre valida independientemente

**Resultado Esperado:** ✅ Validaciones consistentes y backend siempre protegido

---

## 📊 **CRITERIOS DE ACEPTACIÓN**

### ✅ **Funcionalidad Básica**
- [ ] **FB1:** Backend valida fortaleza de contraseña en creación de usuarios
- [ ] **FB2:** Backend valida fortaleza de contraseña en cambio de contraseña
- [ ] **FB3:** Campo `require_change_password` existe y funciona correctamente
- [ ] **FB4:** Usuarios existentes tienen el nuevo campo poblado

### ✅ **Frontend Applications**
- [ ] **FA1:** WMCloud muestra advertencia y permite navegación a change-password
- [ ] **FA2:** Tiendas muestra advertencia cuando corresponde
- [ ] **FA3:** Fabricaciones muestra advertencia cuando corresponde
- [ ] **FA4:** Combustibles muestra advertencia cuando corresponde

### ✅ **Integración y Consistencia**
- [ ] **IC1:** Validaciones consistentes entre frontend y backend
- [ ] **IC2:** Mensajes de error claros y útiles
- [ ] **IC3:** Flujo de cambio de contraseña funciona end-to-end
- [ ] **IC4:** Performance no se ve afectada negativamente

### ✅ **Edge Cases**
- [ ] **EC1:** Manejo correcto de todos los tipos de contraseñas débiles
- [ ] **EC2:** No se puede bypasear validación a través del frontend
- [ ] **EC3:** Usuarios sin el campo funcionan sin errores
- [ ] **EC4:** Campo se actualiza correctamente después del cambio

---

## 🚨 **ISSUES ENCONTRADOS**

| **#** | **Descripción** | **Severidad** | **Estado** |
|-------|-----------------|---------------|------------|
| 1     | _________________ | ⚠️ Medium     | 🔴 Open    |
| 2     | _________________ | 🔥 High       | 🔴 Open    |
| 3     | _________________ | ℹ️ Low        | 🔴 Open    |

---

## ✅ **RESUMEN DE RESULTADOS**

### **Estadísticas del Test:**
- **Total de pasos:** 16 casos principales + validaciones
- **Pasos ejecutados:** _____ / _____
- **Pasos exitosos:** _____ / _____
- **Issues encontrados:** _____
- **Issues críticos:** _____

### **Veredicto Final:**
- [ ] ✅ **APROBADO** - Funcionalidad lista para producción
- [ ] ⚠️ **APROBADO CON OBSERVACIONES** - Issues menores encontrados
- [ ] ❌ **RECHAZADO** - Issues críticos que impiden el paso a producción

### **Observaciones Generales:**
```
_________________________________________________________________
_________________________________________________________________
_________________________________________________________________
_________________________________________________________________
```

---

### **Firmas:**

**Tester:** ___________________________ **Fecha:** ___________

**Tech Lead:** ________________________ **Fecha:** ___________

**Product Owner:** ____________________ **Fecha:** ___________

---

### 📎 **Referencias:**
- **Historia de Usuario:** [#19676](https://dev.azure.com/mapplicsdevs/9cd1784f-cb3f-4ae3-9e02-cace32a443e1/_workitems/edit/19676)
- **Pull Requests relacionados:** #3549, #3550, #3551, #3552, #3553, #3554, #3555
- **Sprint:** Sprint 61
- **Fecha de implementación:** 27/05/2025

---
*Test Case generado automaticamente basado en Azure DevOps - Historia #19676*
