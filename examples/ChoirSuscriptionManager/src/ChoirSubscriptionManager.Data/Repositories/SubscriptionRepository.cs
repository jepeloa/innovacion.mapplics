using Microsoft.EntityFrameworkCore;
using ChoirSubscriptionManager.Data.Context;
using ChoirSubscriptionManager.Data.Repositories.Interfaces;
using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Data.Repositories
{
    /// <summary>
    /// Implementación del repositorio de suscripciones
    /// Hereda de Repository para funcionalidades básicas y añade operaciones específicas
    /// </summary>
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(ChoirDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtiene las suscripciones de un miembro específico
        /// </summary>
        public async Task<IEnumerable<Subscription>> GetByMemberIdAsync(int memberId)
        {
            return await _dbSet
                .Include(s => s.Member)
                .Include(s => s.Payments)
                .Where(s => s.MemberId == memberId)
                .OrderByDescending(s => s.StartDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene suscripciones por estado
        /// </summary>
        public async Task<IEnumerable<Subscription>> GetByStatusAsync(SubscriptionStatus status)
        {
            return await _dbSet
                .Include(s => s.Member)
                .Include(s => s.Payments)
                .Where(s => s.Status == status)
                .OrderByDescending(s => s.StartDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene suscripciones activas
        /// </summary>
        public async Task<IEnumerable<Subscription>> GetActiveSubscriptionsAsync()
        {
            return await _dbSet
                .Include(s => s.Member)
                .Include(s => s.Payments)
                .Where(s => s.Status == SubscriptionStatus.Active)
                .OrderByDescending(s => s.StartDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene suscripciones que expiran en un rango de fechas
        /// </summary>
        public async Task<IEnumerable<Subscription>> GetExpiringSubscriptionsAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(s => s.Member)
                .Include(s => s.Payments)
                .Where(s => s.EndDate >= startDate && s.EndDate <= endDate && s.Status == SubscriptionStatus.Active)
                .OrderBy(s => s.EndDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene el total de suscripciones por estado
        /// </summary>
        public async Task<Dictionary<SubscriptionStatus, int>> GetSubscriptionCountByStatusAsync()
        {
            return await _dbSet
                .GroupBy(s => s.Status)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Override del método GetAllAsync para incluir entidades relacionadas
        /// </summary>
        public override async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _dbSet
                .Include(s => s.Member)
                .Include(s => s.Payments)
                .OrderByDescending(s => s.StartDate)
                .ToListAsync();
        }

        /// <summary>
        /// Override del método GetByIdAsync para incluir entidades relacionadas
        /// </summary>
        public override async Task<Subscription?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(s => s.Member)
                .Include(s => s.Payments)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
