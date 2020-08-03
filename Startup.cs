using System;
using LefeWareLearning.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.Calendar;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.EventManager.Controllers;
using OrchardCore.EventManager.Services;
using OrchardCore.Events;
using OrchardCore.Events.Models;
using OrchardCore.ManageEvents;
using OrchardCore.Modules;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;

namespace OrchardCore.EventManager
{
    public class Startup : StartupBase
    { 
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataMigration, EventsMigrations>();
            services.AddScoped<IPermissionProvider, EventManagerPermissions>();

            //ContentParts
            services.AddContentPart<EventPart>();
            //.AddHandler<EventPartHandler>();
            //.UseDisplayDriver<EventDisplayDriver>()

            //Services
            services.AddTransient<IEventManagerService, EventManagerService>();

            //services.AddSingleton<IIndexProvider, EventPartIndexProvider>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }
    }

    [Feature(EventsConstants.Features.EventCalendar)]
    public class EventCalendarStartup : StartupBase
    {
        private readonly AdminOptions _adminOptions;

        public EventCalendarStartup(IOptions<AdminOptions> adminOptions)
        {
            _adminOptions = adminOptions.Value;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INavigationProvider, CalendarAdminMenu>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            var eventCalendarControllerName = typeof(EventCalendarController).ControllerName();

            routes.MapAreaControllerRoute(
                name: "EventCalendar.Index",
                    areaName: "OrchardCore.EventManager",
                    pattern: _adminOptions.AdminUrlPrefix + "/EventCalendar",
                    defaults: new { controller = eventCalendarControllerName, action = nameof(EventCalendarController.Index) }
                );
        }

    }


}
