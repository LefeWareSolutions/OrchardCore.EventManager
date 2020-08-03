using OrchardCore.ContentManagement;
using OrchardCore.ContentFields.Fields;
using OrchardCore.Media.Fields;

namespace OrchardCore.Events.Models
{
    public class EventPart : ContentPart
    {
        public MediaField Thumbnail { get; set; }

        public TextField Description { get; set; }

        public DateTimeField StartDate { get; set; }

        public DateTimeField EndDate { get; set; }

        public string EventStatus { get; set; }

        public void SetEventStatus(EventStatus status)
        {
            EventStatus = status.ToString();
        }
    }

    public enum EventStatus
    {
        Upcomming,
        StartingSoon,
        Started,
        Ended
    }
}
