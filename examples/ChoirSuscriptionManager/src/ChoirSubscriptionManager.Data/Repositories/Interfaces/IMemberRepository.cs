using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Data.Repositories.Interfaces;

/// <summary>
/// Interfaz específica para el repositorio de Members
/// Además de las operaciones básicas, incluye métodos específicos para miembros
/// </summary>
public interface IMemberRepository : IRepository<Member>
{
    /// <summary>
    /// Obtener un miembro por su email
    /// </summary>
    Task<Member?> GetByEmailAsync(string email);

    /// <summary>
    /// Obtener miembros activos
    /// </summary>
    Task<IEnumerable<Member>> GetActiveMembersAsync();

    /// <summary>
    /// Obtener miembros por rol de voz
    /// </summary>
    Task<IEnumerable<Member>> GetMembersByRoleAsync(MemberRole role);

    /// <summary>
    /// Obtener miembros con sus suscripciones
    /// </summary>
    Task<IEnumerable<Member>> GetMembersWithSubscriptionsAsync();

    /// <summary>
    /// Obtener un miembro con todas sus suscripciones y pagos
    /// </summary>
    Task<Member?> GetMemberWithFullDetailsAsync(int memberId);

    /// <summary>
    /// Obtener miembros que se unieron en un rango de fechas
    /// </summary>
    Task<IEnumerable<Member>> GetMembersByJoinDateRangeAsync(DateTime startDate, DateTime endDate);
}
