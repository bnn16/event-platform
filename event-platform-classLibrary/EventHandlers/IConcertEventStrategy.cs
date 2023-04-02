using event_platform_classLibrary.EventHandlers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_platform_classLibrary.EventHandlers
{
    public interface IConcertEventStrategy : IEventStrategy
    {
        ConcertEvent CreateConcertEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity, string artist, string venue);
    }

}
