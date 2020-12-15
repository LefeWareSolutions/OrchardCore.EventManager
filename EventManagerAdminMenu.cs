using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCore.Calendar
{
    public class EventManagerAdminMenu : INavigationProvider
    {
        private readonly IStringLocalizer T;

        public EventManagerAdminMenu(IStringLocalizer<EventManagerAdminMenu> localizer)
        {
            T = localizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            var rvd = new RouteValueDictionary
            {
                { "Area", "OrchardCore.Contents" },
                { "Options.SelectedContentType", "Event" },
                { "Options.CanCreateSelectedContentType", true },
            };

            builder.Add(T["Events"], "16", settings => settings
                    .AddClass("events").Id("events")
                    .Add(T["Event List"], "1", client => client
                        .Action("List", "Admin", rvd)
                        .LocalNav()
                    )
                    .Add(T["Event Calendar"], "1", client => client
                        .Action("Index", "EventCalendar", "OrchardCore.EventManager")
                        .LocalNav()
                    )
            );

            return Task.CompletedTask;
        }
    }
}
