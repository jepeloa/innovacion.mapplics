using Microsoft.AspNetCore.Mvc;
using ChoirSubscriptionManager.Data.Repositories.Interfaces;
using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPaymentRepository _paymentRepository;

        public SearchController(
            IMemberRepository memberRepository,
            ISubscriptionRepository subscriptionRepository,
            IPaymentRepository paymentRepository)
        {
            _memberRepository = memberRepository;
            _subscriptionRepository = subscriptionRepository;
            _paymentRepository = paymentRepository;
        }

        // GET: Search
        public IActionResult Index()
        {
            return View();
        }

        // POST: Search/Members
        [HttpPost]
        public async Task<IActionResult> Members(string? searchTerm, MemberRole? role, bool? isActive)
        {
            var members = await _memberRepository.GetAllAsync();

            // Filtrar por término de búsqueda
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                members = members.Where(m => 
                    m.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    m.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    (m.Phone != null && m.Phone.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                );
            }

            // Filtrar por rol
            if (role.HasValue)
            {
                members = members.Where(m => m.Role == role.Value);
            }

            // Filtrar por estado activo
            if (isActive.HasValue)
            {
                members = members.Where(m => m.IsActive == isActive.Value);
            }

            ViewBag.SearchTerm = searchTerm;
            ViewBag.SelectedRole = role;
            ViewBag.SelectedIsActive = isActive;
            ViewBag.Roles = Enum.GetValues<MemberRole>();

            return View(members.OrderBy(m => m.FullName));
        }

        // POST: Search/Subscriptions
        [HttpPost]
        public async Task<IActionResult> Subscriptions(string? memberName, SubscriptionType? type, SubscriptionStatus? status, DateTime? startDate, DateTime? endDate)
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            var members = await _memberRepository.GetAllAsync();

            // Combinar datos para búsqueda
            var subscriptionResults = subscriptions.Select(s => new
            {
                Subscription = s,
                Member = members.FirstOrDefault(m => m.Id == s.MemberId)
            });

            // Filtrar por nombre del miembro
            if (!string.IsNullOrWhiteSpace(memberName))
            {
                subscriptionResults = subscriptionResults.Where(sr => 
                    sr.Member != null && sr.Member.FullName.Contains(memberName, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Filtrar por tipo
            if (type.HasValue)
            {
                subscriptionResults = subscriptionResults.Where(sr => sr.Subscription.Type == type.Value);
            }

            // Filtrar por estado
            if (status.HasValue)
            {
                subscriptionResults = subscriptionResults.Where(sr => sr.Subscription.Status == status.Value);
            }

            // Filtrar por rango de fechas
            if (startDate.HasValue)
            {
                subscriptionResults = subscriptionResults.Where(sr => sr.Subscription.StartDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                subscriptionResults = subscriptionResults.Where(sr => sr.Subscription.EndDate <= endDate.Value);
            }

            ViewBag.MemberName = memberName;
            ViewBag.SelectedType = type;
            ViewBag.SelectedStatus = status;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
            ViewBag.SubscriptionTypes = Enum.GetValues<SubscriptionType>();
            ViewBag.SubscriptionStatuses = Enum.GetValues<SubscriptionStatus>();

            return View(subscriptionResults.OrderByDescending(sr => sr.Subscription.StartDate));
        }

        // POST: Search/Payments
        [HttpPost]
        public async Task<IActionResult> Payments(string? memberName, PaymentStatus? status, PaymentMethod? method, DateTime? fromDate, DateTime? toDate, decimal? minAmount, decimal? maxAmount)
        {
            var payments = await _paymentRepository.GetAllAsync();
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            var members = await _memberRepository.GetAllAsync();

            // Combinar datos para búsqueda
            var paymentResults = payments.Select(p => new
            {
                Payment = p,
                Subscription = subscriptions.FirstOrDefault(s => s.Id == p.SubscriptionId),
                Member = members.FirstOrDefault(m => m.Id == p.MemberId)
            });

            // Filtrar por nombre del miembro
            if (!string.IsNullOrWhiteSpace(memberName))
            {
                paymentResults = paymentResults.Where(pr => 
                    pr.Member != null && pr.Member.FullName.Contains(memberName, StringComparison.OrdinalIgnoreCase)
                );
            }

            // Filtrar por estado
            if (status.HasValue)
            {
                paymentResults = paymentResults.Where(pr => pr.Payment.Status == status.Value);
            }

            // Filtrar por método
            if (method.HasValue)
            {
                paymentResults = paymentResults.Where(pr => pr.Payment.Method == method.Value);
            }

            // Filtrar por rango de fechas
            if (fromDate.HasValue)
            {
                paymentResults = paymentResults.Where(pr => pr.Payment.PaymentDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                paymentResults = paymentResults.Where(pr => pr.Payment.PaymentDate <= toDate.Value);
            }

            // Filtrar por rango de montos
            if (minAmount.HasValue)
            {
                paymentResults = paymentResults.Where(pr => pr.Payment.Amount >= minAmount.Value);
            }

            if (maxAmount.HasValue)
            {
                paymentResults = paymentResults.Where(pr => pr.Payment.Amount <= maxAmount.Value);
            }

            ViewBag.MemberName = memberName;
            ViewBag.SelectedStatus = status;
            ViewBag.SelectedMethod = method;
            ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
            ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");
            ViewBag.MinAmount = minAmount;
            ViewBag.MaxAmount = maxAmount;
            ViewBag.PaymentStatuses = Enum.GetValues<PaymentStatus>();
            ViewBag.PaymentMethods = Enum.GetValues<PaymentMethod>();

            return View(paymentResults.OrderByDescending(pr => pr.Payment.PaymentDate));
        }
    }
}
