using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Data.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de pagos
    /// Define operaciones específicas para manejar pagos
    /// </summary>
    public interface IPaymentRepository : IRepository<Payment>
    {
        /// <summary>
        /// Obtiene los pagos de un miembro específico
        /// </summary>
        Task<IEnumerable<Payment>> GetByMemberIdAsync(int memberId);

        /// <summary>
        /// Obtiene los pagos de una suscripción específica
        /// </summary>
        Task<IEnumerable<Payment>> GetBySubscriptionIdAsync(int subscriptionId);

        /// <summary>
        /// Obtiene pagos por estado
        /// </summary>
        Task<IEnumerable<Payment>> GetByStatusAsync(PaymentStatus status);

        /// <summary>
        /// Obtiene pagos en un rango de fechas
        /// </summary>
        Task<IEnumerable<Payment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Obtiene el total de ingresos por mes
        /// </summary>
        Task<decimal> GetTotalIncomeByMonthAsync(int year, int month);

        /// <summary>
        /// Obtiene el total de pagos por estado
        /// </summary>
        Task<Dictionary<PaymentStatus, int>> GetPaymentCountByStatusAsync();

        /// <summary>
        /// Obtiene el total de ingresos por estado
        /// </summary>
        Task<Dictionary<PaymentStatus, decimal>> GetIncomeByStatusAsync();
    }
}
