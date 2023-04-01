using event_platform_classLibrary.EventHandlers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_platform_classLibrary.EventHandlers
{
    public class ConcertEventStrategy : IEventStrategy
    {
        public ConcertEvent CreateConcertEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity, string artist, string venue)
        {
            return new ConcertEvent(id, name, description, date, price, eventType, capacity, artist, venue);
        }

        // Throw NotImplementedException for CreateEvent method since this strategy only creates concert events
        public Event CreateEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity)
        {
            throw new NotImplementedException("CreateEvent method is not implemented");
        }
    }
}
