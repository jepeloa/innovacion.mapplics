using Microsoft.AspNetCore.Mvc;
using ChoirSubscriptionManager.Data.Repositories.Interfaces;
using ChoirSubscriptionManager.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ChoirSubscriptionManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ChoirDbContext _context;

        public HomeController(
            IMemberRepository memberRepository, 
            ISubscriptionRepository subscriptionRepository,
            IPaymentRepository paymentRepository,
            ChoirDbContext context)
        {
            _memberRepository = memberRepository;
            _subscriptionRepository = subscriptionRepository;
            _paymentRepository = paymentRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Estadísticas básicas
            var totalMembers = await _context.Members.CountAsync();
            var activeMembers = await _context.Members.CountAsync(m => m.IsActive);
            var totalSubscriptions = await _context.Subscriptions.CountAsync();
            var totalPayments = await _context.Payments.CountAsync();

            // Estadísticas de suscripciones por estado
            var subscriptionsByStatus = await _subscriptionRepository.GetSubscriptionCountByStatusAsync();
            var activeSubscriptions = subscriptionsByStatus.GetValueOrDefault(ChoirSubscriptionManager.Shared.Enums.SubscriptionStatus.Active, 0);
            var expiredSubscriptions = subscriptionsByStatus.GetValueOrDefault(ChoirSubscriptionManager.Shared.Enums.SubscriptionStatus.Expired, 0);

            // Estadísticas de pagos
            var paymentsByStatus = await _paymentRepository.GetPaymentCountByStatusAsync();
            var pendingPayments = paymentsByStatus.GetValueOrDefault(ChoirSubscriptionManager.Shared.Enums.PaymentStatus.Pending, 0);
            var completedPayments = paymentsByStatus.GetValueOrDefault(ChoirSubscriptionManager.Shared.Enums.PaymentStatus.Completed, 0);

            // Ingresos del mes actual
            var monthlyRevenue = await _paymentRepository.GetTotalIncomeByMonthAsync(DateTime.Now.Year, DateTime.Now.Month);

            // Suscripciones que expiran pronto (próximos 7 días)
            var soonExpiring = await _subscriptionRepository.GetExpiringSubscriptionsAsync(
                DateTime.Now, 
                DateTime.Now.AddDays(7));

            ViewBag.TotalMembers = totalMembers;
            ViewBag.ActiveMembers = activeMembers;
            ViewBag.TotalSubscriptions = totalSubscriptions;
            ViewBag.TotalPayments = totalPayments;
            ViewBag.ActiveSubscriptions = activeSubscriptions;
            ViewBag.ExpiredSubscriptions = expiredSubscriptions;
            ViewBag.PendingPayments = pendingPayments;
            ViewBag.CompletedPayments = completedPayments;
            ViewBag.MonthlyRevenue = monthlyRevenue;
            ViewBag.SoonExpiringCount = soonExpiring.Count();
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
