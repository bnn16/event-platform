using System.Data;

namespace event_platform_classLibrary.EventHandlers.EventStrategy.EventStrategy
{
    public class EventStrategy : IEventStrategy
    {
        private readonly IDBController _dbController;

        public EventStrategy(IDBController dbController)
        {
            _dbController = dbController;
        }

        public Event CreateEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity)
        {
            return new Event(id, name, description, date, price, eventType, capacity);
        }

        public async Task<bool> UpdateEventAsync(Event @event, int id)
        {
            return await _dbController.UpdateEventAsync(@event, id);
        }

        public async Task<bool> DeleteEvent(int id)
        {
            return await _dbController.DeleteEvent(id);
        }

        public DataTable GetAllElements()
        {
            return _dbController.GetAllEvents();
        }

        public DataSet GetEventById(int id)
        {
            return _dbController.GetEventById(id);
        }

        public DataTable GetEventByFilter(string filter)
        {
            return _dbController.GetEventByFilter(filter);
        }

        public async Task<bool> AddEventAsync(Event eventObj)
        {
            return await _dbController.AddEventAsync(eventObj);
        }
    }
}
