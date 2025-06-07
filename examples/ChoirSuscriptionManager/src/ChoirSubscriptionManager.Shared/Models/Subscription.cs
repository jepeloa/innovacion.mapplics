using ChoirSubscriptionManager.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChoirSubscriptionManager.Shared.Models;

/// <summary>
/// Representa una suscripción de un miembro
/// Una suscripción puede ser mensual, trimestral o anual
/// </summary>
public class Subscription
{
    /// <summary>
    /// ID único de la suscripción
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID del miembro al que pertenece esta suscripción
    /// </summary>
    [Required(ErrorMessage = "Debe seleccionar un miembro")]
    [Display(Name = "Miembro")]
    public int MemberId { get; set; }

    /// <summary>
    /// Tipo de suscripción (Mensual, Trimestral, Anual)
    /// </summary>
    [Required(ErrorMessage = "El tipo de suscripción es obligatorio")]
    [Display(Name = "Tipo de Suscripción")]
    public SubscriptionType Type { get; set; } = SubscriptionType.Monthly;

    /// <summary>
    /// Fecha de inicio de la suscripción
    /// </summary>
    [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Inicio")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Fecha de fin de la suscripción
    /// </summary>
    [Required(ErrorMessage = "La fecha de fin es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Fin")]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Monto que debe pagar por esta suscripción
    /// </summary>
    [Required(ErrorMessage = "El monto es obligatorio")]
    [Range(0.01, 10000.00, ErrorMessage = "El monto debe estar entre 0.01 y 10,000")]
    [DataType(DataType.Currency)]
    [Display(Name = "Monto")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Estado actual de la suscripción
    /// </summary>
    [Required(ErrorMessage = "El estado de la suscripción es obligatorio")]
    [Display(Name = "Estado")]
    public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Active;

    /// <summary>
    /// Notas adicionales sobre la suscripción
    /// </summary>
    [StringLength(500, ErrorMessage = "Las notas no pueden exceder 500 caracteres")]
    [Display(Name = "Notas")]
    public string? Notes { get; set; }

    /// <summary>
    /// Fecha en que se creó la suscripción
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Fecha de la última actualización
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Referencia al miembro dueño de esta suscripción
    /// (Navigation Property - permite acceder fácilmente al miembro)
    /// </summary>
    public virtual Member Member { get; set; } = null!;

    /// <summary>
    /// Lista de pagos realizados para esta suscripción
    /// (Normalmente debería ser uno, pero podrían ser pagos parciales)
    /// </summary>
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    /// <summary>
    /// Propiedad calculada que nos dice si la suscripción está completamente pagada
    /// </summary>
    public bool IsPaid => Payments.Where(p => p.Status == PaymentStatus.Completed).Sum(p => p.Amount) >= Amount;

    /// <summary>
    /// Propiedad calculada que nos dice cuánto se ha pagado hasta ahora
    /// </summary>
    public decimal PaidAmount => Payments.Where(p => p.Status == PaymentStatus.Completed).Sum(p => p.Amount);

    /// <summary>
    /// Propiedad calculada que nos dice cuánto falta por pagar
    /// </summary>
    public decimal RemainingAmount => Amount - PaidAmount;
}
