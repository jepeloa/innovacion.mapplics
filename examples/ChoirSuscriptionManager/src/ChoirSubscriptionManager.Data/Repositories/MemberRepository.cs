using Microsoft.EntityFrameworkCore;
using ChoirSubscriptionManager.Data.Context;
using ChoirSubscriptionManager.Data.Repositories.Interfaces;
using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Data.Repositories;

/// <summary>
/// Implementación del repositorio específico para Members
/// Hereda de Repository<Member> y agrega funcionalidades específicas
/// </summary>
public class MemberRepository : Repository<Member>, IMemberRepository
{
    public MemberRepository(ChoirDbContext context) : base(context)
    {
    }

    public async Task<Member?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(m => m.Email == email);
    }

    public async Task<IEnumerable<Member>> GetActiveMembersAsync()
    {
        return await _dbSet.Where(m => m.IsActive).ToListAsync();
    }

    public async Task<IEnumerable<Member>> GetMembersByRoleAsync(MemberRole role)
    {
        return await _dbSet.Where(m => m.Role == role && m.IsActive).ToListAsync();
    }

    public async Task<IEnumerable<Member>> GetMembersWithSubscriptionsAsync()
    {
        return await _dbSet
            .Include(m => m.Subscriptions) // Incluir las suscripciones
            .Where(m => m.IsActive)
            .ToListAsync();
    }

    public async Task<Member?> GetMemberWithFullDetailsAsync(int memberId)
    {
        return await _dbSet
            .Include(m => m.Subscriptions) // Incluir suscripciones
                .ThenInclude(s => s.Payments) // Y también los pagos de cada suscripción
            .FirstOrDefaultAsync(m => m.Id == memberId);
    }

    public async Task<IEnumerable<Member>> GetMembersByJoinDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Where(m => m.JoinDate >= startDate && m.JoinDate <= endDate)
            .OrderBy(m => m.JoinDate)
            .ToListAsync();
    }

    /// <summary>
    /// Override del método GetByIdAsync para incluir las suscripciones automáticamente
    /// </summary>
    public override async Task<Member?> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(m => m.Subscriptions)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}
