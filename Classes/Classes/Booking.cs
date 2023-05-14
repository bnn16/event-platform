namespace event_platform_classLibrary.EventHandlers.Classes
{
    public class Booking
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int NumAttendees { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
