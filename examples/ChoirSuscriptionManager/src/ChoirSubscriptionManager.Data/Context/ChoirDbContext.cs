using Microsoft.EntityFrameworkCore;
using ChoirSubscriptionManager.Shared.Models;

namespace ChoirSubscriptionManager.Data.Context;

/// <summary>
/// DbContext es como el "gerente" de la base de datos
/// Se encarga de conectar tu código C# con la base de datos
/// </summary>
public class ChoirDbContext : DbContext
{
    /// <summary>
    /// Constructor que recibe las opciones de configuración
    /// </summary>
    public ChoirDbContext(DbContextOptions<ChoirDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// DbSet representa una tabla en la base de datos
    /// Members = tabla de miembros
    /// </summary>
    public DbSet<Member> Members { get; set; }

    /// <summary>
    /// Subscriptions = tabla de suscripciones
    /// </summary>
    public DbSet<Subscription> Subscriptions { get; set; }

    /// <summary>
    /// Payments = tabla de pagos
    /// </summary>
    public DbSet<Payment> Payments { get; set; }

    /// <summary>
    /// OnModelCreating es donde configuramos las reglas de la base de datos
    /// (como las relaciones entre tablas, restricciones, etc.)
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplicar las configuraciones que vamos a crear
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChoirDbContext).Assembly);
    }
}
