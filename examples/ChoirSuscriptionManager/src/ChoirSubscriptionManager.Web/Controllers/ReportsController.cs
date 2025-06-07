using Microsoft.AspNetCore.Mvc;
using ChoirSubscriptionManager.Data.Repositories.Interfaces;
using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;
using ChoirSubscriptionManager.Web.Models.ViewModels;

namespace ChoirSubscriptionManager.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPaymentRepository _paymentRepository;

        public ReportsController(
            IMemberRepository memberRepository,
            ISubscriptionRepository subscriptionRepository,
            IPaymentRepository paymentRepository)
        {
            _memberRepository = memberRepository;
            _subscriptionRepository = subscriptionRepository;
            _paymentRepository = paymentRepository;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            var viewModel = new ReportsIndexViewModel
            {
                GeneratedAt = DateTime.Now
            };

            // Obtener datos básicos
            var members = await _memberRepository.GetAllAsync();
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            var payments = await _paymentRepository.GetAllAsync();

            // Estadísticas de miembros
            viewModel.TotalMembers = members.Count();
            viewModel.ActiveMembers = members.Count(m => m.IsActive);
            viewModel.InactiveMembers = members.Count(m => !m.IsActive);

            // Distribución por roles
            viewModel.MembersByRole = Enum.GetValues<MemberRole>()
                .ToDictionary(
                    role => role.ToString(),
                    role => members.Count(m => m.Role == role && m.IsActive)
                );

            // Estadísticas de suscripciones
            viewModel.TotalSubscriptions = subscriptions.Count();
            viewModel.ActiveSubscriptions = subscriptions.Count(s => s.Status == SubscriptionStatus.Active);
            viewModel.ExpiredSubscriptions = subscriptions.Count(s => s.Status == SubscriptionStatus.Expired);

            // Suscripciones por tipo
            viewModel.SubscriptionsByType = Enum.GetValues<SubscriptionType>()
                .ToDictionary(
                    type => type.ToString(),
                    type => subscriptions.Count(s => s.Type == type && s.Status == SubscriptionStatus.Active)
                );

            // Estadísticas de pagos
            viewModel.TotalPayments = payments.Count();
            viewModel.CompletedPayments = payments.Count(p => p.Status == PaymentStatus.Completed);
            viewModel.PendingPayments = payments.Count(p => p.Status == PaymentStatus.Pending);
            viewModel.FailedPayments = payments.Count(p => p.Status == PaymentStatus.Failed);

            // Ingresos totales
            viewModel.TotalRevenue = payments
                .Where(p => p.Status == PaymentStatus.Completed)
                .Sum(p => p.Amount);

            // Ingresos del mes actual
            var currentMonth = DateTime.Now;
            var startOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1);

            viewModel.MonthlyRevenue = payments
                .Where(p => p.Status == PaymentStatus.Completed 
                           && p.PaymentDate >= startOfMonth 
                           && p.PaymentDate < endOfMonth)
                .Sum(p => p.Amount);

            // Últimos 6 meses de ingresos
            viewModel.MonthlyRevenueData = new Dictionary<string, decimal>();
            for (int i = 5; i >= 0; i--)
            {
                var monthStart = startOfMonth.AddMonths(-i);
                var monthEnd = monthStart.AddMonths(1);
                var monthName = monthStart.ToString("MMM yyyy");
                
                var monthRevenue = payments
                    .Where(p => p.Status == PaymentStatus.Completed
                               && p.PaymentDate >= monthStart
                               && p.PaymentDate < monthEnd)
                    .Sum(p => p.Amount);
                
                viewModel.MonthlyRevenueData[monthName] = monthRevenue;
            }

            return View(viewModel);
        }

        // GET: Reports/MemberDetails
        public async Task<IActionResult> MemberDetails()
        {
            var members = await _memberRepository.GetAllAsync();
            var subscriptions = await _subscriptionRepository.GetAllAsync();

            var viewModel = members.Select(m => new MemberReportViewModel
            {
                Member = m,
                TotalSubscriptions = subscriptions.Count(s => s.MemberId == m.Id),
                ActiveSubscriptions = subscriptions.Count(s => s.MemberId == m.Id && s.Status == SubscriptionStatus.Active),
                ExpiredSubscriptions = subscriptions.Count(s => s.MemberId == m.Id && s.Status == SubscriptionStatus.Expired),
                LastSubscriptionDate = subscriptions
                    .Where(s => s.MemberId == m.Id)
                    .OrderByDescending(s => s.StartDate)
                    .FirstOrDefault()?.StartDate
            }).OrderBy(vm => vm.Member.FullName);

            return View(viewModel);
        }

        // GET: Reports/PaymentDetails
        public async Task<IActionResult> PaymentDetails()
        {
            var payments = await _paymentRepository.GetAllAsync();
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            var members = await _memberRepository.GetAllAsync();

            var viewModel = payments
                .OrderByDescending(p => p.PaymentDate)
                .Select(p => 
                {
                    var subscription = subscriptions.FirstOrDefault(s => s.Id == p.SubscriptionId);
                    var member = subscription != null ? members.FirstOrDefault(m => m.Id == subscription.MemberId) : null;
                    
                    return new PaymentReportViewModel
                    {
                        Payment = p,
                        Subscription = subscription,
                        Member = member
                    };
                });

            return View(viewModel);
        }

        // GET: Reports/ExpiredSubscriptions
        public async Task<IActionResult> ExpiredSubscriptions()
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            var members = await _memberRepository.GetAllAsync();

            var expiredSubscriptions = subscriptions
                .Where(s => s.EndDate < DateTime.Now)
                .OrderBy(s => s.EndDate)
                .Select(s => new SubscriptionReportViewModel
                {
                    Subscription = s,
                    Member = members.FirstOrDefault(m => m.Id == s.MemberId)
                });

            return View(expiredSubscriptions);
        }

        // GET: Reports/UpcomingRenewals
        public async Task<IActionResult> UpcomingRenewals()
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            var members = await _memberRepository.GetAllAsync();

            var nextMonth = DateTime.Now.AddMonths(1);
            var upcomingRenewals = subscriptions
                .Where(s => s.Status == SubscriptionStatus.Active && s.EndDate <= nextMonth && s.EndDate > DateTime.Now)
                .OrderBy(s => s.EndDate)
                .Select(s => new SubscriptionReportViewModel
                {
                    Subscription = s,
                    Member = members.FirstOrDefault(m => m.Id == s.MemberId)
                });

            return View(upcomingRenewals);
        }
    }
}
