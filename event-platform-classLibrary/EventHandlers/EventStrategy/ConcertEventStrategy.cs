using event_platform_classLibrary.EventHandlers.Classes;
using System.Data;

namespace event_platform_classLibrary.EventHandlers.EventStrategy.EventStrategy
{
    public class ConcertEventStrategy : IConcertEventStrategy
    {
        private readonly DBController _dbController;

        public ConcertEventStrategy(DBController dbController)
        {
            _dbController = dbController;
        }

        public ConcertEvent CreateConcertEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity, string artist, string venue)
        {
            return new ConcertEvent(id, name, description, date, price, eventType, capacity, artist, venue);
        }

        public async Task<bool> UpdateConcertEventAsync(ConcertEvent concertEvent, int id)
        {
            return await _dbController.UpdateEventAsync(concertEvent, id, concertEvent.Artist, concertEvent.Venue);
        }

        public async Task<bool> DeleteConcertEvent(int id)
        {
            return await _dbController.DeleteEvent(id);
        }

        public Event CreateEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEventAsync(Event @event, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEvent(int id)
        {
            throw new NotImplementedException();
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


        public async Task<bool> AddConcertAsync(ConcertEvent concert)
        {
            return await _dbController.AddConcertAsync(concert);
        }

        public Task<bool> AddEventAsync(Event eventObj)
        {
            throw new NotImplementedException();
        }
    }
}
