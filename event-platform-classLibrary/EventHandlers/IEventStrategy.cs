using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_platform_classLibrary.EventHandlers
{
    public interface IEventStrategy
    {
        Event CreateEvent(int id, string name, DateTime date, int price, string eventType, int capacity);
    }
}
