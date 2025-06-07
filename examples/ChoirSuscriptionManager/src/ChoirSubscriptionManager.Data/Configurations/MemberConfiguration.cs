using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChoirSubscriptionManager.Shared.Models;

namespace ChoirSubscriptionManager.Data.Configurations;

/// <summary>
/// Configuración para la tabla Members
/// Aquí definimos exactamente cómo queremos que se vea la tabla en la base de datos
/// </summary>
public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        // Configuración de la tabla
        builder.ToTable("Members");

        // Clave primaria
        builder.HasKey(m => m.Id);

        // Configuración de columnas
        builder.Property(m => m.Id)
            .ValueGeneratedOnAdd(); // Auto-incremento

        builder.Property(m => m.FullName)
            .IsRequired() // No puede ser nulo
            .HasMaxLength(200); // Máximo 200 caracteres

        builder.Property(m => m.Email)
            .IsRequired()
            .HasMaxLength(100);

        // El email debe ser único
        builder.HasIndex(m => m.Email)
            .IsUnique();

        builder.Property(m => m.Phone)
            .HasMaxLength(20);

        builder.Property(m => m.DateOfBirth)
            .IsRequired();

        builder.Property(m => m.Role)
            .IsRequired()
            .HasConversion<int>(); // Convertir el enum a número en la BD

        builder.Property(m => m.JoinDate)
            .IsRequired();

        builder.Property(m => m.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(m => m.CreatedAt)
            .IsRequired();

        builder.Property(m => m.UpdatedAt)
            .IsRequired();

        // Relación con Subscriptions
        // Un Member puede tener muchas Subscriptions
        builder.HasMany(m => m.Subscriptions)
            .WithOne(s => s.Member)
            .HasForeignKey(s => s.MemberId)
            .OnDelete(DeleteBehavior.Cascade); // Si borras un Member, se borran sus Subscriptions
    }
}
