using Microsoft.EntityFrameworkCore;
using ChoirSubscriptionManager.Data.Context;
using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Web.Services
{
    public class DataSeederService
    {
        private readonly ChoirDbContext _context;

        public DataSeederService(ChoirDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Verificar si ya hay datos
            if (await _context.Members.AnyAsync())
                return;

            // Crear miembros de ejemplo
            var members = new List<Member>
            {
                new Member
                {
                    FullName = "María González",
                    Email = "maria.gonzalez@email.com",
                    Phone = "+34 600 123 456",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    Role = MemberRole.Soprano,
                    JoinDate = new DateTime(2023, 1, 15),
                    IsActive = true
                },
                new Member
                {
                    FullName = "Carlos Rodríguez",
                    Email = "carlos.rodriguez@email.com",
                    Phone = "+34 600 234 567",
                    DateOfBirth = new DateTime(1980, 8, 22),
                    Role = MemberRole.Tenor,
                    JoinDate = new DateTime(2023, 2, 10),
                    IsActive = true
                },
                new Member
                {
                    FullName = "Ana Martínez",
                    Email = "ana.martinez@email.com",
                    Phone = "+34 600 345 678",
                    DateOfBirth = new DateTime(1990, 12, 3),
                    Role = MemberRole.Alto,
                    JoinDate = new DateTime(2023, 3, 5),
                    IsActive = true
                },
                new Member
                {
                    FullName = "David López",
                    Email = "david.lopez@email.com",
                    Phone = "+34 600 456 789",
                    DateOfBirth = new DateTime(1975, 4, 18),
                    Role = MemberRole.Bass,
                    JoinDate = new DateTime(2023, 1, 20),
                    IsActive = true
                },
                new Member
                {
                    FullName = "Elena Fernández",
                    Email = "elena.fernandez@email.com",
                    Phone = "+34 600 567 890",
                    DateOfBirth = new DateTime(1988, 9, 12),
                    Role = MemberRole.Soprano,
                    JoinDate = new DateTime(2023, 4, 1),
                    IsActive = true
                }
            };

            _context.Members.AddRange(members);
            await _context.SaveChangesAsync();

            // Crear suscripciones de ejemplo
            var subscriptions = new List<Subscription>();
            var random = new Random();
            
            foreach (var member in members)
            {
                // Crear 1-2 suscripciones por miembro
                var subscriptionCount = random.Next(1, 3);
                
                for (int i = 0; i < subscriptionCount; i++)
                {
                    var startDate = DateTime.Now.AddMonths(-(subscriptionCount - i));
                    var type = (SubscriptionType)random.Next(0, 3); // Monthly, Quarterly, Yearly
                    var amount = type switch
                    {
                        SubscriptionType.Monthly => 25.00m,
                        SubscriptionType.Quarterly => 70.00m,
                        SubscriptionType.Yearly => 250.00m,
                        _ => 25.00m
                    };

                    var endDate = type switch
                    {
                        SubscriptionType.Monthly => startDate.AddMonths(1),
                        SubscriptionType.Quarterly => startDate.AddMonths(3),
                        SubscriptionType.Yearly => startDate.AddYears(1),
                        _ => startDate.AddMonths(1)
                    };

                    var status = endDate > DateTime.Now ? SubscriptionStatus.Active : SubscriptionStatus.Expired;

                    subscriptions.Add(new Subscription
                    {
                        MemberId = member.Id,
                        Type = type,
                        StartDate = startDate,
                        EndDate = endDate,
                        Amount = amount,
                        Status = status,
                        Notes = $"Suscripción {type} para {member.FullName}",
                        CreatedAt = startDate.AddDays(-7)
                    });
                }
            }

            _context.Subscriptions.AddRange(subscriptions);
            await _context.SaveChangesAsync();

            // Crear algunos pagos
            var payments = new List<Payment>();
            
            foreach (var subscription in subscriptions)
            {
                // 80% de probabilidad de tener al menos un pago
                if (random.Next(1, 101) <= 80)
                {
                    var paymentDate = subscription.StartDate.AddDays(random.Next(1, 10));
                    var status = random.Next(1, 101) <= 90 ? PaymentStatus.Completed : PaymentStatus.Pending;
                    var method = (PaymentMethod)random.Next(0, 4); // Cash, Card, Transfer, Check

                    payments.Add(new Payment
                    {
                        SubscriptionId = subscription.Id,
                        MemberId = subscription.MemberId,
                        Amount = subscription.Amount,
                        PaymentDate = paymentDate,
                        Status = status,
                        Method = method,
                        ReferenceNumber = $"PAY{subscription.Id:D4}{paymentDate:MMdd}",
                        Notes = $"Pago {method} por suscripción {subscription.Type}",
                        CreatedAt = paymentDate
                    });
                }
            }

            _context.Payments.AddRange(payments);
            await _context.SaveChangesAsync();
        }
    }
}
