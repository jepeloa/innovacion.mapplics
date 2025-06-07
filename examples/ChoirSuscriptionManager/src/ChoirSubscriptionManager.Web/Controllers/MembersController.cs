using Microsoft.AspNetCore.Mvc;
using ChoirS        // GET: Members/CreatetionManager.Data.Repositories.Interfaces;
using ChoirSubscriptionManager.Data.Context;
using ChoirSubscriptionManager.Shared.Models;
using ChoirSubscriptionManager.Shared.Enums;

namespace ChoirSubscriptionManager.Web.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ChoirDbContext _dbContext;

        public MembersController(IMemberRepository memberRepository, ChoirDbContext dbContext)
        {
            _memberRepository = memberRepository;
            _dbContext = dbContext;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            var members = await _memberRepository.GetAllAsync();
            return View(members);
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            ViewBag.Roles = Enum.GetValues<MemberRole>();
            return View();
        }

        // GET: Members/CreateTest - Método de prueba
        public IActionResult CreateTest()
        {
            return View();
        }

        // GET: Members/CreateSimple - Vista de prueba sin layout
        public IActionResult CreateSimple()
        {
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _memberRepository.AddAsync(member);
                    TempData["SuccessMessage"] = "Miembro agregado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al guardar el miembro: " + ex.Message);
                }
            }
            ViewBag.Roles = Enum.GetValues<MemberRole>();
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            ViewBag.Roles = Enum.GetValues<MemberRole>();
            return View(member);
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    member.UpdatedAt = DateTime.UtcNow;
                    _memberRepository.Update(member);
                    await _dbContext.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Miembro actualizado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al actualizar el miembro: " + ex.Message);
                }
            }
            ViewBag.Roles = Enum.GetValues<MemberRole>();
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _memberRepository.RemoveByIdAsync(id);
                await _dbContext.SaveChangesAsync();
                TempData["SuccessMessage"] = "Miembro eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al eliminar el miembro: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Members/Activate/5
        public async Task<IActionResult> Activate(int id)
        {
            try
            {
                var member = await _memberRepository.GetByIdAsync(id);
                if (member != null)
                {
                    member.IsActive = true;
                    member.UpdatedAt = DateTime.UtcNow;
                    _memberRepository.Update(member);
                    await _dbContext.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Miembro activado exitosamente.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al activar el miembro: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Members/Deactivate/5
        public async Task<IActionResult> Deactivate(int id)
        {
            try
            {
                var member = await _memberRepository.GetByIdAsync(id);
                if (member != null)
                {
                    member.IsActive = false;
                    member.UpdatedAt = DateTime.UtcNow;
                    _memberRepository.Update(member);
                    await _dbContext.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Miembro desactivado exitosamente.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al desactivar el miembro: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
