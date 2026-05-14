// ClubEventApp.DTO/EventSummaryViewModel.cs
namespace ClubEventApp.DTO
{
    public class EventSummaryViewModel
    {
        public string EventID { get; set; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AvailableSlots { get; set; }
    }
}
