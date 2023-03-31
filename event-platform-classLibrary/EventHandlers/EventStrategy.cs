using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_platform_classLibrary.EventHandlers
{
    public class EventStrategy : IEventStrategy
    {
        public EventStrategy()
        {
        }

        public Event CreateEvent(int id, string name, DateTime date, int price, string eventType, int capacity)
        {
            return new Event(id, name, date, price, eventType, capacity);
        }
    }
}
