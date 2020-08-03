using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrchardCore.ContentManagement;

namespace OrchardCore.EventManager.Services
{
    public interface IEventManagerService
    {
        Task CreateEvent(string eventName, string description, DateTime startDate, DateTime endDate);
        Task<IEnumerable<ContentItem>> GetAllEvents();
    }
}
