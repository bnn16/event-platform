using event_platform_classLibrary.EventHandlers.Classes;
using System.Data;

namespace event_platform_classLibrary.EventHandlers
{
    public class EventManager
    {
        // DIP: high level module doesn't depend on the low level module (in this case IEventStrategy)
        private readonly IEventStrategy _eventStrategy;

        public EventManager(IEventStrategy eventStrategy)
        {
            _eventStrategy = eventStrategy;
        }

        public Event CreateEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity)
        {
            return _eventStrategy.CreateEvent(id, name, description, date, price, eventType, capacity);
        }

        public ConcertEvent CreateConcertEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity, string artist, string venue)
        {
            // Liskov's Substitution Principle: update the Interfaces to follow Liskov's substitution principle checks if the strategy implements IConcertEventStrategy
            if (_eventStrategy is IConcertEventStrategy concertEventStrategy)
            {
                return concertEventStrategy.CreateConcertEvent(id, name, description, date, price, eventType, capacity, artist, venue);
            }

            throw new NotSupportedException("Concert event strategy not implemented");
        }

        // Open-Closed Principle: the class now follows the OCP of SOLID and is flexible and you can easily add more without risk of bugs

        // Update the event
        public async Task<bool> UpdateEventAsync(Event eventToUpdate, int updateId)
        {
            return await _eventStrategy.UpdateEventAsync(eventToUpdate, updateId);
        }

        public async Task<bool> UpdateConcertEventAsync(ConcertEvent concertEvent, int id)
        {
            if (_eventStrategy is IConcertEventStrategy concertEventStrategy)
            {
                return await concertEventStrategy.UpdateConcertEventAsync(concertEvent, id);
            }

            throw new NotSupportedException("Concert event strategy not implemented");
        }

        // Delete the event
        public async
        // Delete the event
        Task
DeleteEvent(int eventId)
        {
            await _eventStrategy.DeleteEvent(eventId);
        }

        public DataTable GetAllEvents()
        {
            return _eventStrategy.GetAllElements();
        }

        public DataSet GetEventById(int id)
        {
            return _eventStrategy.GetEventById(id);
        }

        public DataTable GetEventByFilter(string filter) 
        {
            return _eventStrategy.GetEventByFilter(filter);
        }

        public async Task<bool> AddConcertAsync(ConcertEvent concertEvent)
        {
            if (_eventStrategy is IConcertEventStrategy concertEventStrategy)
            {
                return await concertEventStrategy.AddConcertAsync(concertEvent);
            }
            else
            {
                throw new NotSupportedException("Concert event strategy not implemented");
            }
        }

        public async Task<bool> AddEventAsync(Event eventObj)
        {
            return await _eventStrategy.AddEventAsync(eventObj);
        }
    }

}
