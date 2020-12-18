using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.Events.Models;
using OrchardCore.Title.Models;
using Org.BouncyCastle.Utilities.Collections;

namespace OrchardCore.EventManager.Services
{
    public class EventManagerService : IEventManagerService
    {
        private readonly IContentManager _contentManager;
        public EventManagerService(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public async Task CreateEvent(string eventName, string description, DateTime startDate, DateTime endDate)
        {
            //Create contentitem
            var newEvent = await _contentManager.NewAsync("Event");

            //Title
            newEvent.As<TitlePart>().Title = eventName;

            //Event info
            var newEventPart = newEvent.As<EventPart>();
            newEventPart.Description = new TextField() { Text = description };
            newEventPart.StartDate = new DateTimeField() { Value = startDate };
            newEventPart.EndDate = new DateTimeField() { Value = endDate };

            //Publish
            await _contentManager.CreateAsync(newEvent);
            newEventPart.Apply();
        }

        public Task<IEnumerable<ContentItem>> GetAllEvents()
        {
            return Task.FromResult<IEnumerable<ContentItem>>(Enumerable.Empty<ContentItem>());
        }
    }
}
