using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Data.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de suscripciones
    /// Define operaciones específicas para manejar suscripciones
    /// </summary>
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        /// <summary>
        /// Obtiene las suscripciones de un miembro específico
        /// </summary>
        Task<IEnumerable<Subscription>> GetByMemberIdAsync(int memberId);

        /// <summary>
        /// Obtiene suscripciones por estado
        /// </summary>
        Task<IEnumerable<Subscription>> GetByStatusAsync(SubscriptionStatus status);

        /// <summary>
        /// Obtiene suscripciones activas
        /// </summary>
        Task<IEnumerable<Subscription>> GetActiveSubscriptionsAsync();

        /// <summary>
        /// Obtiene suscripciones que expiran en un rango de fechas
        /// </summary>
        Task<IEnumerable<Subscription>> GetExpiringSubscriptionsAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Obtiene el total de suscripciones por estado
        /// </summary>
        Task<Dictionary<SubscriptionStatus, int>> GetSubscriptionCountByStatusAsync();
    }
}
