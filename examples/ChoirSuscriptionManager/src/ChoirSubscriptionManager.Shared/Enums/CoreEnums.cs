namespace ChoirSubscriptionManager.Shared.Enums;

/// <summary>
/// Tipo de suscripción
/// </summary>
public enum SubscriptionType
{
    Monthly = 1,     // Mensual
    Quarterly = 2,   // Trimestral
    Yearly = 3       // Anual
}

/// <summary>
/// Estado de la suscripción de un miembro
/// </summary>
public enum SubscriptionStatus
{
    Active = 1,      // Activa - vigente
    Expired = 2,     // Expirada - venció
    Suspended = 3,   // Suspendida - pausada temporalmente
    Cancelled = 4    // Cancelada - anulada definitivamente
}

/// <summary>
/// Estado del pago
/// </summary>
public enum PaymentStatus
{
    Pending = 1,     // Pendiente de pago
    Completed = 2,   // Completado/Pagado
    Failed = 3,      // Falló
    Refunded = 4     // Reembolsado
}

/// <summary>
/// Método de pago
/// </summary>
public enum PaymentMethod
{
    Cash = 1,        // Efectivo
    CreditCard = 2,  // Tarjeta de crédito
    BankTransfer = 3,// Transferencia bancaria
    Check = 4        // Cheque
}

/// <summary>
/// Rol del miembro en el coro
/// </summary>
public enum MemberRole
{
    Soprano = 1,     // Voz aguda femenina
    Alto = 2,        // Voz grave femenina  
    Tenor = 3,       // Voz aguda masculina
    Bass = 4         // Voz grave masculina
}
