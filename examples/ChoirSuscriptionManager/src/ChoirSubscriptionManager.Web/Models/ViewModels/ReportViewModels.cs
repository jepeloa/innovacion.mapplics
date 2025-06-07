using ChoirSubscriptionManager.Shared.Models;

namespace ChoirSubscriptionManager.Web.Models.ViewModels
{
    /// <summary>
    /// ViewModel para la página principal de reportes
    /// </summary>
    public class ReportsIndexViewModel
    {
        public DateTime GeneratedAt { get; set; }

        // Estadísticas de miembros
        public int TotalMembers { get; set; }
        public int ActiveMembers { get; set; }
        public int InactiveMembers { get; set; }
        public Dictionary<string, int> MembersByRole { get; set; } = new();

        // Estadísticas de suscripciones
        public int TotalSubscriptions { get; set; }
        public int ActiveSubscriptions { get; set; }
        public int ExpiredSubscriptions { get; set; }
        public Dictionary<string, int> SubscriptionsByType { get; set; } = new();

        // Estadísticas de pagos
        public int TotalPayments { get; set; }
        public int CompletedPayments { get; set; }
        public int PendingPayments { get; set; }
        public int FailedPayments { get; set; }

        // Estadísticas financieras
        public decimal TotalRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public Dictionary<string, decimal> MonthlyRevenueData { get; set; } = new();
    }

    /// <summary>
    /// ViewModel para reportes detallados de miembros
    /// </summary>
    public class MemberReportViewModel
    {
        public Member Member { get; set; } = null!;
        public int TotalSubscriptions { get; set; }
        public int ActiveSubscriptions { get; set; }
        public int ExpiredSubscriptions { get; set; }
        public DateTime? LastSubscriptionDate { get; set; }
    }

    /// <summary>
    /// ViewModel para reportes de pagos
    /// </summary>
    public class PaymentReportViewModel
    {
        public Payment Payment { get; set; } = null!;
        public Subscription? Subscription { get; set; }
        public Member? Member { get; set; }
    }

    /// <summary>
    /// ViewModel para reportes de suscripciones
    /// </summary>
    public class SubscriptionReportViewModel
    {
        public Subscription Subscription { get; set; } = null!;
        public Member? Member { get; set; }
    }
}
