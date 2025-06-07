// JavaScript personalizado para el Sistema de Gestión del Coro

// Función para cerrar alertas automáticamente después de 5 segundos
document.addEventListener('DOMContentLoaded', function() {
    // Auto-cerrar alertas de notificaciones
    const alerts = document.querySelectorAll('.alert');
    alerts.forEach(function(alert) {
        setTimeout(function() {
            const bsAlert = new bootstrap.Alert(alert);
            if (bsAlert) {
                bsAlert.close();
            }
        }, 5000); // 5 segundos
    });
});

// Validación adicional para formularios
function validateForm(formId) {
    const form = document.getElementById(formId);
    if (form) {
        form.addEventListener('submit', function(event) {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        });
    }
}

// Función para confirmar eliminaciones
function confirmDelete(message) {
    return confirm(message || '¿Está seguro de que desea eliminar este elemento?');
}
