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
        //DIP high level module doesn't depend on the low level module (in this case IEventStrategy)
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
            //update the Interfaces to folow liskovs substitution principle checks if the strategy implements IConcertEventStrategy
            if (_eventStrategy is IConcertEventStrategy concertEventStrategy)
            {
                return concertEventStrategy.CreateConcertEvent(id, name, description, date, price, eventType, capacity, artist, venue);
            }

            throw new NotSupportedException("Concert event strategy not implemented");
        }

        //the class now follows the OCP of SOLID and is flexible and you can easily add more without risk of bugs
    }
}
