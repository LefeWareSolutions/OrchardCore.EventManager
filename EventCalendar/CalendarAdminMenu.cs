using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace OrchardCore.Calendar
{
    public class CalendarAdminMenu : INavigationProvider
    {
        private readonly IStringLocalizer S;

        public CalendarAdminMenu(IStringLocalizer<CalendarAdminMenu> localizer)
        {
            S = localizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder.Add(S["Calendar"], "16", settings => settings
                    .AddClass("Calendar").Id("Calendar")
                        .Action("Index", "EventCalendar", "OrchardCore.EventManager")
                        .LocalNav()
            );

            return Task.CompletedTask;
        }
    }
}
