using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChoirSubscriptionManager.Shared.Models;

namespace ChoirSubscriptionManager.Data.Configurations;

/// <summary>
/// Configuración para la tabla Payments
/// </summary>
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        // Configuración de la tabla
        builder.ToTable("Payments");

        // Clave primaria
        builder.HasKey(p => p.Id);

        // Configuración de columnas
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.SubscriptionId)
            .IsRequired();

        builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnType("decimal(10,2)")
            .HasDefaultValue(0);

        builder.Property(p => p.PaymentDate)
            .IsRequired();

        builder.Property(p => p.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(p => p.Method)
            .IsRequired()
            .HasConversion<int>(); // Convertir enum a número

        builder.Property(p => p.ReferenceNumber)
            .HasMaxLength(100);

        builder.Property(p => p.Notes)
            .HasMaxLength(500);

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .IsRequired();

        // Relación con Subscription
        builder.HasOne(p => p.Subscription)
            .WithMany(s => s.Payments)
            .HasForeignKey(p => p.SubscriptionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Restricciones usando ToTable
        builder.ToTable(t => 
        {
            t.HasCheckConstraint("CK_Payment_Amount", "Amount > 0");
        });
    }
}
