using OrchardCore.Events;
using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Events",
    Author = "LefeWare Solutions",
    Website = "",
    Version = "1.0.0",
    Description = "Create events",
    Category = "LefeWare Solution Modules",
    Dependencies = new string [] {}
)]

[assembly: Feature(
    Id = EventsConstants.Features.EventManager,
    Name = "Event Manager",
    Description = "Create & Manage events",
    Category = "LefeWare Solutions",
    Dependencies = new string[] { }
)]

[assembly: Feature(
    Id = EventsConstants.Features.EventCalendar,
    Name = "Event Calendar",
    Category = "LefeWare Solutions",
    Description = "A calendar for viewing and creating OrchardCore Events",
    Dependencies = new string[] { EventsConstants.Features.EventManager }
)]
