using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform_classLibrary.EventHandlers
{
    public interface IEventStrategy
    {
        Event CreateEvent(int id, string name, string description, DateTime date, int price, string eventType, int capacity);
        Task<bool> UpdateEventAsync(Event @event, int id);
        Task<bool> DeleteEvent(int id);
        DataTable GetAllElements();
        DataSet GetEventById(int id);
        DataTable GetEventByFilter(string filter);
        Task<bool> AddEventAsync(Event eventObj);
    }
}
