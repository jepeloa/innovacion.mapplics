using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChoirSubscriptionManager.Data.Repositories.Interfaces;
using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Web.Controllers
{
    /// <summary>
    /// Controlador para manejar las operaciones CRUD de suscripciones
    /// Como un encargado de una biblioteca que gestiona los carnets de los miembros
    /// </summary>
    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMemberRepository _memberRepository;

        /// <summary>
        /// Constructor del controlador
        /// Recibe los repositorios necesarios por inyección de dependencias
        /// </summary>
        public SubscriptionsController(
            ISubscriptionRepository subscriptionRepository,
            IMemberRepository memberRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _memberRepository = memberRepository;
        }

        /// <summary>
        /// Muestra la lista de todas las suscripciones
        /// Como ver todos los carnets de biblioteca emitidos
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            return View(subscriptions);
        }

        /// <summary>
        /// Muestra los detalles de una suscripción específica
        /// Como ver los detalles de un carnet específico
        /// </summary>
        public async Task<IActionResult> Details(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return View(subscription);
        }

        /// <summary>
        /// Muestra el formulario para crear una nueva suscripción
        /// Como preparar un formulario para emitir un nuevo carnet
        /// </summary>
        public async Task<IActionResult> Create()
        {
            await PrepareViewBagForForm();
            return View();
        }

        /// <summary>
        /// Procesa la creación de una nueva suscripción
        /// Como procesar el formulario de nuevo carnet y guardarlo
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                // Establecer valores por defecto
                subscription.CreatedAt = DateTime.Now;
                
                // Si no se especifica fecha de inicio, usar la fecha actual
                if (subscription.StartDate == default)
                {
                    subscription.StartDate = DateTime.Now;
                }

                // Calcular fecha de fin basada en el tipo de suscripción
                subscription.EndDate = CalculateEndDate(subscription.StartDate, subscription.Type);

                await _subscriptionRepository.AddAsync(subscription);
                
                TempData["SuccessMessage"] = "Suscripción creada exitosamente.";
                return RedirectToAction(nameof(Index));
            }

            await PrepareViewBagForForm();
            return View(subscription);
        }

        /// <summary>
        /// Muestra el formulario para editar una suscripción existente
        /// Como preparar el formulario para modificar un carnet existente
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            await PrepareViewBagForForm();
            return View(subscription);
        }

        /// <summary>
        /// Procesa la edición de una suscripción existente
        /// Como procesar los cambios en un carnet y guardarlos
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                // Obtener la suscripción original para preservar algunos campos
                var originalSubscription = await _subscriptionRepository.GetByIdAsync(id);
                if (originalSubscription == null)
                {
                    return NotFound();
                }

                // Preservar fecha de creación
                subscription.CreatedAt = originalSubscription.CreatedAt;
                
                // Recalcular fecha de fin si cambió el tipo o fecha de inicio
                if (subscription.Type != originalSubscription.Type || 
                    subscription.StartDate != originalSubscription.StartDate)
                {
                    subscription.EndDate = CalculateEndDate(subscription.StartDate, subscription.Type);
                }

                _subscriptionRepository.Update(subscription);
                
                TempData["SuccessMessage"] = "Suscripción actualizada exitosamente.";
                return RedirectToAction(nameof(Index));
            }

            await PrepareViewBagForForm();
            return View(subscription);
        }

        /// <summary>
        /// Muestra la confirmación para eliminar una suscripción
        /// Como mostrar los detalles antes de cancelar un carnet
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return View(subscription);
        }

        /// <summary>
        /// Procesa la eliminación de una suscripción
        /// Como cancelar definitivamente un carnet
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            if (subscription != null)
            {
                await _subscriptionRepository.RemoveByIdAsync(id);
                TempData["SuccessMessage"] = "Suscripción eliminada exitosamente.";
            }
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Muestra las suscripciones de un miembro específico
        /// Como ver todos los carnets de una persona específica
        /// </summary>
        public async Task<IActionResult> ByMember(int memberId)
        {
            var member = await _memberRepository.GetByIdAsync(memberId);
            if (member == null)
            {
                return NotFound();
            }

            var subscriptions = await _subscriptionRepository.GetByMemberIdAsync(memberId);
            ViewBag.MemberName = member.FullName;
            ViewBag.MemberId = memberId;
            
            return View(subscriptions);
        }

        /// <summary>
        /// Muestra las suscripciones que están por expirar
        /// Como ver los carnets que están por vencer
        /// </summary>
        public async Task<IActionResult> Expiring()
        {
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(30); // Próximos 30 días
            
            var subscriptions = await _subscriptionRepository.GetExpiringSubscriptionsAsync(startDate, endDate);
            ViewBag.DateRange = $"Próximos 30 días (hasta {endDate:dd/MM/yyyy})";
            
            return View(subscriptions);
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

            // Lista de tipos de suscripción
            ViewBag.SubscriptionTypes = new SelectList(Enum.GetValues<SubscriptionType>());

            // Lista de estados de suscripción
            ViewBag.SubscriptionStatuses = new SelectList(Enum.GetValues<SubscriptionStatus>());
        }

        /// <summary>
        /// Calcula la fecha de fin basada en el tipo de suscripción
        /// Como calcular cuándo expira un carnet según su tipo
        /// </summary>
        private DateTime CalculateEndDate(DateTime startDate, SubscriptionType type)
        {
            return type switch
            {
                SubscriptionType.Monthly => startDate.AddMonths(1),
                SubscriptionType.Quarterly => startDate.AddMonths(3),
                SubscriptionType.Yearly => startDate.AddYears(1),
                _ => startDate.AddMonths(1) // Por defecto mensual
            };
        }
    }
}
