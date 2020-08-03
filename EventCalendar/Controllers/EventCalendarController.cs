using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Admin;
using OrchardCore.Events;
using OrchardCore.ManageEvents;
using OrchardCore.Modules;

namespace OrchardCore.EventManager.Controllers
{
    [Admin]
    [Feature(EventsConstants.Features.EventCalendar)]
    public class EventCalendarController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public EventCalendarController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public Task<IActionResult> Admin()
        {
            // Used to provide a different url such that the Admin Templates menu entry doesn't collide with the Templates ones
            return Index();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!await _authorizationService.AuthorizeAsync(User, EventManagerPermissions.ManageEvents))
            {
                return Forbid();
            }

            return View();
        }
    }
}
