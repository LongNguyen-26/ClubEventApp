// ClubEventApp/Controllers/EventController.cs
using ClubEventApp.BLL.IServices;
using ClubEventApp.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClubEventApp.Controllers
{
    [Authorize(Roles = "Admin")]   // Chỉ Ban điều hành mới vào được
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService) => _eventService = eventService;

        [HttpGet]
        public IActionResult Create() => View(new CreateEventViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var (success, error) = await _eventService.CreateEventAsync(model, creatorId);

            if (!success)
            {
                ModelState.AddModelError("", error);
                return View(model);
            }

            TempData["SuccessMessage"] = "Sự kiện đã được tạo và công bố thành công!";
            return RedirectToAction("Index", "Home");
        }
    }
}