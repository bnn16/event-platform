using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform_classLibrary.EventHandlers
{
    public class EventManager
    {
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
            return _eventStrategy.CreateConcertEvent(id,name, description, date, price, eventType, capacity, artist, venue);
        }
    }
}
