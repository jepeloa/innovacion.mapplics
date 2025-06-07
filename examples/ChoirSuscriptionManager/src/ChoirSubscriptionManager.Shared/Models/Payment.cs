using ChoirSubscriptionManager.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChoirSubscriptionManager.Shared.Models;

/// <summary>
/// Representa un pago realizado por un miembro para una suscripción específica
/// </summary>
public class Payment
{
    /// <summary>
    /// ID único del pago
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID del miembro que realizó el pago
    /// </summary>
    [Required(ErrorMessage = "Debe seleccionar un miembro")]
    [Display(Name = "Miembro")]
    public int MemberId { get; set; }

    /// <summary>
    /// ID de la suscripción a la que corresponde este pago
    /// </summary>
    [Required(ErrorMessage = "Debe seleccionar una suscripción")]
    [Display(Name = "Suscripción")]
    public int SubscriptionId { get; set; }

    /// <summary>
    /// Monto pagado
    /// </summary>
    [Required(ErrorMessage = "El monto es obligatorio")]
    [Range(0.01, 10000.00, ErrorMessage = "El monto debe estar entre 0.01 y 10,000")]
    [DataType(DataType.Currency)]
    [Display(Name = "Monto")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Fecha en que se realizó el pago
    /// </summary>
    [Required(ErrorMessage = "La fecha de pago es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Pago")]
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// Estado del pago
    /// </summary>
    [Required(ErrorMessage = "El estado del pago es obligatorio")]
    [Display(Name = "Estado")]
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

    /// <summary>
    /// Método de pago utilizado
    /// </summary>
    [Required(ErrorMessage = "El método de pago es obligatorio")]
    [Display(Name = "Método de Pago")]
    public PaymentMethod Method { get; set; } = PaymentMethod.Cash;

    /// <summary>
    /// Número de referencia del pago (número de transferencia, etc.)
    /// </summary>
    [StringLength(50, ErrorMessage = "El número de referencia no puede exceder 50 caracteres")]
    [Display(Name = "Número de Referencia")]
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Notas adicionales sobre el pago
    /// </summary>
    [StringLength(500, ErrorMessage = "Las notas no pueden exceder 500 caracteres")]
    [Display(Name = "Notas")]
    public string? Notes { get; set; }

    /// <summary>
    /// Fecha en que se registró el pago en el sistema
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Fecha de la última actualización del pago
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Referencia a la suscripción a la que pertenece este pago
    /// (Navigation Property)
    /// </summary>
    public virtual Subscription Subscription { get; set; } = null!;
}
