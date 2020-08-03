using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.EventManager.Services;
using OrchardCore.ManageEvents;

namespace OrchardCore.Calender.Controllers
{
    [Route("api/events")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Api"), IgnoreAntiforgeryToken]
    public class EventApiController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IEventManagerService _eventManagerService;

        public EventApiController(IEventManagerService eventManagerService, IAuthorizationService authorizationService)
        {
            _eventManagerService = eventManagerService;
            _authorizationService = authorizationService;
        }

        public async Task<IEnumerable<ContentItem>> GetEvents()
        {
            if (!await _authorizationService.AuthorizeAsync(User, EventManagerPermissions.ManageEvents))
            {
                //return Forbid();
            }

            var events = await _eventManagerService.GetAllEvents();
            return events;
        }

        public async Task<IActionResult> CreateEvent(string eventName, string description, DateTime startTime, DateTime endDate)
        {
            if (!await _authorizationService.AuthorizeAsync(User, EventManagerPermissions.ManageEvents))
            {
                return Forbid();
            }

            await _eventManagerService.CreateEvent(eventName, description, startTime, endDate);
            return Ok();
        }
    }
}
