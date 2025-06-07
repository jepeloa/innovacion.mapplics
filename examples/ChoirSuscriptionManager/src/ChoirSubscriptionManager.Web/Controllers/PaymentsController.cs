using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChoirSubscriptionManager.Data.Repositories.Interfaces;
using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Web.Controllers
{
    /// <summary>
    /// Controlador para manejar las operaciones CRUD de pagos
    /// Como un cajero que registra y gestiona los pagos del coro
    /// </summary>
    public class PaymentsController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;

        /// <summary>
        /// Constructor del controlador
        /// Recibe los repositorios necesarios por inyección de dependencias
        /// </summary>
        public PaymentsController(
            IPaymentRepository paymentRepository,
            IMemberRepository memberRepository,
            ISubscriptionRepository subscriptionRepository)
        {
            _paymentRepository = paymentRepository;
            _memberRepository = memberRepository;
            _subscriptionRepository = subscriptionRepository;
        }

        /// <summary>
        /// Muestra la lista de todos los pagos
        /// Como ver el registro de caja con todos los pagos
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var payments = await _paymentRepository.GetAllAsync();
            
            // Preparar estadísticas para la vista
            await PreparePaymentStatistics();
            
            return View(payments);
        }

        /// <summary>
        /// Muestra los detalles de un pago específico
        /// Como ver el recibo detallado de un pago
        /// </summary>
        public async Task<IActionResult> Details(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        /// <summary>
        /// Muestra el formulario para registrar un nuevo pago
        /// Como preparar un formulario de registro de pago
        /// </summary>
        public async Task<IActionResult> Create(int? subscriptionId)
        {
            await PrepareViewBagForForm();
            
            var payment = new Payment();
            
            // Si se especifica una suscripción, precargar los datos
            if (subscriptionId.HasValue)
            {
                var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId.Value);
                if (subscription != null)
                {
                    payment.SubscriptionId = subscription.Id;
                    payment.MemberId = subscription.MemberId;
                    payment.Amount = subscription.Amount;
                }
            }
            
            return View(payment);
        }

        /// <summary>
        /// Procesa el registro de un nuevo pago
        /// Como procesar y guardar un nuevo pago en la caja
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                // Establecer valores por defecto
                payment.CreatedAt = DateTime.Now;
                
                // Si no se especifica fecha de pago, usar la fecha actual
                if (payment.PaymentDate == default)
                {
                    payment.PaymentDate = DateTime.Now;
                }

                await _paymentRepository.AddAsync(payment);
                
                TempData["SuccessMessage"] = "Pago registrado exitosamente.";
                return RedirectToAction(nameof(Index));
            }

            await PrepareViewBagForForm();
            return View(payment);
        }

        /// <summary>
        /// Muestra el formulario para editar un pago existente
        /// Como preparar el formulario para corregir un pago
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            await PrepareViewBagForForm();
            return View(payment);
        }

        /// <summary>
        /// Procesa la edición de un pago existente
        /// Como procesar las correcciones de un pago
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // Obtener el pago original para preservar algunos campos
                var originalPayment = await _paymentRepository.GetByIdAsync(id);
                if (originalPayment == null)
                {
                    return NotFound();
                }

                // Preservar fecha de creación
                payment.CreatedAt = originalPayment.CreatedAt;

                _paymentRepository.Update(payment);
                
                TempData["SuccessMessage"] = "Pago actualizado exitosamente.";
                return RedirectToAction(nameof(Index));
            }

            await PrepareViewBagForForm();
            return View(payment);
        }

        /// <summary>
        /// Muestra la confirmación para eliminar un pago
        /// Como mostrar los detalles antes de anular un pago
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        /// <summary>
        /// Procesa la eliminación de un pago
        /// Como anular definitivamente un pago
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment != null)
            {
                await _paymentRepository.RemoveByIdAsync(id);
                TempData["SuccessMessage"] = "Pago eliminado exitosamente.";
            }
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Muestra los pagos de un miembro específico
        /// Como ver el historial de pagos de una persona
        /// </summary>
        public async Task<IActionResult> ByMember(int memberId)
        {
            var member = await _memberRepository.GetByIdAsync(memberId);
            if (member == null)
            {
                return NotFound();
            }

            var payments = await _paymentRepository.GetByMemberIdAsync(memberId);
            ViewBag.MemberName = member.FullName;
            ViewBag.MemberId = memberId;
            
            return View(payments);
        }

        /// <summary>
        /// Muestra los pagos de una suscripción específica
        /// Como ver todos los pagos relacionados a una suscripción
        /// </summary>
        public async Task<IActionResult> BySubscription(int subscriptionId)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId);
            if (subscription == null)
            {
                return NotFound();
            }

            var payments = await _paymentRepository.GetBySubscriptionIdAsync(subscriptionId);
            ViewBag.SubscriptionInfo = $"Suscripción #{subscription.Id} - {subscription.Member?.FullName}";
            ViewBag.SubscriptionId = subscriptionId;
            
            return View(payments);
        }

        /// <summary>
        /// Muestra el reporte de pagos por fecha
        /// Como ver los ingresos en un período específico
        /// </summary>
        public async Task<IActionResult> Report(DateTime? startDate, DateTime? endDate)
        {
            // Valores por defecto: mes actual
            var start = startDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var end = endDate ?? start.AddMonths(1).AddDays(-1);

            var payments = await _paymentRepository.GetByDateRangeAsync(start, end);
            var paymentCountByStatus = await _paymentRepository.GetPaymentCountByStatusAsync();
            var incomeByStatus = await _paymentRepository.GetIncomeByStatusAsync();

            ViewBag.StartDate = start;
            ViewBag.EndDate = end;
            ViewBag.PaymentCountByStatus = paymentCountByStatus;
            ViewBag.IncomeByStatus = incomeByStatus;
            ViewBag.TotalIncome = incomeByStatus.Values.Sum();
            ViewBag.TotalPayments = payments.Count();

            return View(payments);
        }

        /// <summary>
        /// Prepara los datos necesarios para los formularios (ViewBag)
        /// Como preparar las listas desplegables con opciones
        /// </summary>
        private async Task PrepareViewBagForForm()
        {
            // Lista de miembros para el dropdown
            var members = await _memberRepository.GetAllAsync();
            ViewBag.MemberList = new SelectList(members, "Id", "FullName");

            // Lista de suscripciones para el dropdown
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            ViewBag.SubscriptionList = new SelectList(
                subscriptions.Select(s => new { 
                    Id = s.Id, 
                    Text = $"#{s.Id} - {s.Member?.FullName} ({s.Type})" 
                }), 
                "Id", 
                "Text");

            // Lista de métodos de pago
            ViewBag.PaymentMethods = new SelectList(Enum.GetValues<PaymentMethod>());

            // Lista de estados de pago
            ViewBag.PaymentStatuses = new SelectList(Enum.GetValues<PaymentStatus>());
        }

        /// <summary>
        /// Prepara las estadísticas de pagos para mostrar en la vista
        /// Como preparar un resumen financiero del coro
        /// </summary>
        private async Task PreparePaymentStatistics()
        {
            var allPayments = await _paymentRepository.GetAllAsync();
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            // Ingresos del mes actual
            var monthlyIncome = await _paymentRepository.GetTotalIncomeByMonthAsync(currentYear, currentMonth);
            ViewBag.MonthlyIncome = monthlyIncome;

            // Total de pagos
            ViewBag.TotalPayments = allPayments.Count();

            // Pagos pendientes
            var pendingPayments = allPayments.Count(p => p.Status == PaymentStatus.Pending);
            ViewBag.PendingPayments = pendingPayments;

            // Promedio por pago (solo pagos completados)
            var completedPayments = allPayments.Where(p => p.Status == PaymentStatus.Completed);
            ViewBag.AveragePayment = completedPayments.Any() ? completedPayments.Average(p => p.Amount) : 0;
        }
    }
}
