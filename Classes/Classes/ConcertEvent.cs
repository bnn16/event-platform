namespace event_platform_classLibrary.EventHandlers.Classes
{
    public class ConcertEvent : Event
    {
        public string Artist { get; set; }
        public string Venue { get; set; }

        public ConcertEvent(int id, string name, string desc, DateTime date, int price, string eventType, int capacity, string artist, string venue) : base(id, name, desc, date, price, eventType, capacity)
        {
            Artist = artist;
            Venue = venue;
        }
    }
}
