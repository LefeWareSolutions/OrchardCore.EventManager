using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace LefeWareLearning.Events
{
    public class EventsMigrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public EventsMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
              _contentDefinitionManager.AlterPartDefinition("EventPart", part => part
                .Attachable()
                .WithDescription("Fields for events")
                .WithField("Thumbnail", field => field
                    .OfType("MediaField")
                    .WithDisplayName("Event Thumbnail")
                )
                .WithField("Description", field => field
                    .OfType("TextField")
                    .WithSettings(new ContentPartFieldSettings(){Editor = "Wysiwyg" })
                    .WithDisplayName("Description of event")
                )
                .WithField("StartDate", field => field
                    .OfType("DateTimeField")
                    .WithSettings(new DateTimeFieldSettings(){Required = true})
                    .WithDisplayName("Event Start Date")
                )
                .WithField("EndDate", field => field
                    .OfType("DateTimeField")
                    .WithSettings(new DateTimeFieldSettings() { Required = true })
                    .WithDisplayName("Event End Date")
                )
            );

            _contentDefinitionManager.AlterTypeDefinition("Event", builder => builder
                .Creatable()
                .Listable()
                .WithPart("TitlePart", part => part.WithPosition("1"))
                .WithPart("EventPart", part => part.WithPosition("2"))
            );

            return 1;
        }

    }
}
