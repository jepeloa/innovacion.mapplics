using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChoirSubscriptionManager.Shared.Models;

namespace ChoirSubscriptionManager.Data.Configurations;

/// <summary>
/// Configuración para la tabla Subscriptions
/// </summary>
public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        // Configuración de la tabla
        builder.ToTable("Subscriptions");

        // Clave primaria
        builder.HasKey(s => s.Id);

        // Configuración de columnas
        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.MemberId)
            .IsRequired();

        builder.Property(s => s.Type)
            .IsRequired()
            .HasConversion<int>(); // Convertir enum a número

        builder.Property(s => s.StartDate)
            .IsRequired();

        builder.Property(s => s.EndDate)
            .IsRequired();

        builder.Property(s => s.Amount)
            .IsRequired()
            .HasColumnType("decimal(10,2)") // Precisión para dinero: 10 dígitos, 2 decimales
            .HasDefaultValue(0);

        builder.Property(s => s.Status)
            .IsRequired()
            .HasConversion<int>(); // Convertir enum a número

        builder.Property(s => s.CreatedAt)
            .IsRequired();

        builder.Property(s => s.UpdatedAt)
            .IsRequired();

        // Índices únicos
        // No puede haber dos suscripciones activas del mismo miembro con fechas superpuestas
        builder.HasIndex(s => new { s.MemberId, s.StartDate, s.EndDate })
            .IsUnique();

        // Relación con Member
        builder.HasOne(s => s.Member)
            .WithMany(m => m.Subscriptions)
            .HasForeignKey(s => s.MemberId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación con Payments
        builder.HasMany(s => s.Payments)
            .WithOne(p => p.Subscription)
            .HasForeignKey(p => p.SubscriptionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Restricciones de validación usando ToTable
        builder.ToTable(t => 
        {
            t.HasCheckConstraint("CK_Subscription_Amount", "Amount >= 0");
            t.HasCheckConstraint("CK_Subscription_Dates", "EndDate > StartDate");
        });
    }
}
