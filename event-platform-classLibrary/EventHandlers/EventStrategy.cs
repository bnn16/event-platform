using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform_classLibrary.EventHandlers
{
    public class EventStrategy : IEventStrategy
    {
        public Event CreateEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity)
        {
            return new Event(id, name, description, date, price, eventType, capacity);
        }

        // Throw NotImplementedException for CreateConcertEvent method since this strategy only creates events
        public ConcertEvent CreateConcertEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity, string artist, string venue)
        {
            throw new NotImplementedException("CreateConcertEvent method is not implemented");
        }
    }
}
