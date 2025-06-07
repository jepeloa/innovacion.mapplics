using Microsoft.EntityFrameworkCore;
using ChoirSubscriptionManager.Data.Context;
using ChoirSubscriptionManager.Data.Repositories.Interfaces;
using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Data.Repositories
{
    /// <summary>
    /// Implementación del repositorio de pagos
    /// Hereda de Repository para funcionalidades básicas y añade operaciones específicas
    /// </summary>
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ChoirDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtiene los pagos de un miembro específico
        /// </summary>
        public async Task<IEnumerable<Payment>> GetByMemberIdAsync(int memberId)
        {
            return await _dbSet
                .Include(p => p.Subscription)
                    .ThenInclude(s => s.Member)
                .Where(p => p.MemberId == memberId)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene los pagos de una suscripción específica
        /// </summary>
        public async Task<IEnumerable<Payment>> GetBySubscriptionIdAsync(int subscriptionId)
        {
            return await _dbSet
                .Include(p => p.Subscription)
                    .ThenInclude(s => s.Member)
                .Where(p => p.SubscriptionId == subscriptionId)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene pagos por estado
        /// </summary>
        public async Task<IEnumerable<Payment>> GetByStatusAsync(PaymentStatus status)
        {
            return await _dbSet
                .Include(p => p.Subscription)
                    .ThenInclude(s => s.Member)
                .Where(p => p.Status == status)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene pagos en un rango de fechas
        /// </summary>
        public async Task<IEnumerable<Payment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(p => p.Subscription)
                    .ThenInclude(s => s.Member)
                .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene el total de ingresos por mes
        /// </summary>
        public async Task<decimal> GetTotalIncomeByMonthAsync(int year, int month)
        {
            return await _dbSet
                .Where(p => p.PaymentDate.Year == year && 
                           p.PaymentDate.Month == month && 
                           p.Status == PaymentStatus.Completed)
                .SumAsync(p => p.Amount);
        }

        /// <summary>
        /// Obtiene el total de pagos por estado
        /// </summary>
        public async Task<Dictionary<PaymentStatus, int>> GetPaymentCountByStatusAsync()
        {
            return await _dbSet
                .GroupBy(p => p.Status)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Obtiene el total de ingresos por estado
        /// </summary>
        public async Task<Dictionary<PaymentStatus, decimal>> GetIncomeByStatusAsync()
        {
            return await _dbSet
                .GroupBy(p => p.Status)
                .ToDictionaryAsync(g => g.Key, g => g.Sum(p => p.Amount));
        }

        /// <summary>
        /// Override del método GetAllAsync para incluir entidades relacionadas
        /// </summary>
        public override async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Subscription)
                    .ThenInclude(s => s.Member)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        /// <summary>
        /// Override del método GetByIdAsync para incluir entidades relacionadas
        /// </summary>
        public override async Task<Payment?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Subscription)
                    .ThenInclude(s => s.Member)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
