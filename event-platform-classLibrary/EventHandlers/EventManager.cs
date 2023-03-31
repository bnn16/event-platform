using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_platform_classLibrary.EventHandlers
{
    public class EventManager
    {
        private readonly IEventStrategy _eventStrategy;
        public EventManager(IEventStrategy eventStrategy)
        {
            _eventStrategy = eventStrategy;
        }
        public Event CreateEvent(int id, string name, DateTime date, int price, string eventType, int capacity)
        {
            return _eventStrategy.CreateEvent(id, name, date, price, eventType, capacity);
        }


    }
}
