using event_platform_classLibrary.EventHandlers.Classes;
using System.Data;

namespace event_platform_classLibrary
{
    public class EventManager
    {
        private readonly IDBController _dbController;

        public EventManager(IDBController dbController)
        {
            _dbController = dbController;
        }

        public Event CreateEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity)
        {
            return new Event(id, name, description, date, price, eventType, capacity);
        }

        public ConcertEvent CreateConcertEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity, string artist, string venue)
        {
            return new ConcertEvent(id, name, description, date, price, eventType, capacity, artist, venue);
        }

        public async Task<bool> UpdateEventAsync(Event eventToUpdate, int updateId)
        {
            return await _dbController.UpdateEventAsync(eventToUpdate, updateId);
        }

        public async Task<bool> UpdateConcertEventAsync(ConcertEvent concertEvent, int id)
        {
            return await _dbController.UpdateEventAsync(concertEvent, id, concertEvent.Artist, concertEvent.Venue);
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            return await _dbController.DeleteEvent(eventId);
        }

        public async Task<bool> DeleteConcertEvent(int id)
        {
            return await _dbController.DeleteEvent(id);
        }

        public DataTable GetAllEvents()
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

        public async Task<bool> AddConcertAsync(ConcertEvent concertEvent)
        {
            return await _dbController.AddConcertAsync(concertEvent);
        }

        public async Task<bool> AddEventAsync(Event eventObj)
        {
            return await _dbController.AddEventAsync(eventObj);
        }

        public Event GetEventObj(int id)
        {
            return _dbController.GetEventByIdObjObj(id);
        }

        public string GenerateRandomCode()
        {
            Random random = new Random();
            string randomCode = GenerateRandomString(5); // Generate a random string of length 5
            bool exists = CheckBooking(randomCode);
            while (exists)
            {
                randomCode = GenerateRandomString(5);
                if (!CheckBooking(randomCode))
                {
                    break;
                }
            }

            return "#" + randomCode;
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] codeArray = new char[length];

            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                codeArray[i] = chars[random.Next(chars.Length)];
            }

            return new string(codeArray);
        }

        public async Task AddEventTagAsync(int eventId, string tag)
        {
            await _dbController.AddEventTags(eventId, tag);
        }


        public List<(int userId, string tag)> GetAllEventTags()
        {
            return _dbController.GetAllEventTags();
        }

        public List<string> GetAllUserTags(int userId)
        {
            return _dbController.GetAllUserTags(userId);
        }

        public bool CheckBooking(string code)
        {
            return _dbController.CheckBooking(code);
        }

        public void DeleteBooking(string code)
        {
            _dbController.DeleteBooking(code);
        }

    }
}
