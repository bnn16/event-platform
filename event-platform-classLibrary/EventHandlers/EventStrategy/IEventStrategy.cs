using System.Data;

namespace event_platform_classLibrary.EventHandlers.EventStrategy
{
    public interface IEventStrategy
    {
        Event CreateEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity);
        Task<bool> UpdateEventAsync(Event @event, int id);
        Task<bool> DeleteEvent(int id);
        DataTable GetAllElements();
        DataSet GetEventById(int id);
        DataTable GetEventByFilter(string filter);
        Task<bool> AddEventAsync(Event eventObj);
    }
}
