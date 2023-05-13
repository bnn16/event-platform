using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform_classLibrary.EventHandlers.EventStrategy
{
    public interface IConcertEventStrategy : IEventStrategy
    {
        ConcertEvent CreateConcertEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity, string artist, string venue);
        Task<bool> UpdateConcertEventAsync(ConcertEvent concertEvent, int id);
        Task<bool> AddConcertAsync(ConcertEvent concertEvent);
    }
}
