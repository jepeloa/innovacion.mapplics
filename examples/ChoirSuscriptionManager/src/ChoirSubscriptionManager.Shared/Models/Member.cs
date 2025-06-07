using ChoirSubscriptionManager.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChoirSubscriptionManager.Shared.Models;

/// <summary>
/// Representa a un miembro del coro
/// Esta clase contiene toda la información de una persona que participa en el coro
/// </summary>
public class Member
{
    /// <summary>
    /// ID único del miembro (lo genera automáticamente la base de datos)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre completo del miembro
    /// </summary>
    [Required(ErrorMessage = "El nombre completo es obligatorio")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
    [Display(Name = "Nombre Completo")]
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Email del miembro (debe ser único)
    /// </summary>
    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido")]
    [StringLength(150, ErrorMessage = "El email no puede exceder 150 caracteres")]
    [Display(Name = "Correo Electrónico")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Teléfono del miembro
    /// </summary>
    [Phone(ErrorMessage = "El formato del teléfono no es válido")]
    [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
    [Display(Name = "Teléfono")]
    public string? Phone { get; set; }

    /// <summary>
    /// Fecha de nacimiento
    /// </summary>
    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Nacimiento")]
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Rol/Voz del miembro en el coro (Soprano, Alto, Tenor, Bass)
    /// </summary>
    [Required(ErrorMessage = "El rol en el coro es obligatorio")]
    [Display(Name = "Rol en el Coro")]
    public MemberRole Role { get; set; }

    /// <summary>
    /// Fecha en que se unió al coro
    /// </summary>
    [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Ingreso")]
    public DateTime JoinDate { get; set; }

    /// <summary>
    /// Si el miembro está activo o no
    /// </summary>
    [Display(Name = "Activo")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Fecha en que se creó el registro
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Fecha de la última actualización del registro
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Lista de todas las suscripciones de este miembro
    /// (Un miembro puede tener múltiples suscripciones a lo largo del tiempo)
    /// </summary>
    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
