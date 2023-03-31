using event_platform_classLibrary.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_platform_classLibrary
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public string EventType { get; set; }
        public int Capacity { get; set; }
        public List<Booking> Bookings { get; set; }

        public Event(int id, string name, DateTime date, int price, string eventType, int capacity)
        {
            Id = id;
            Name = name;
            Date = date;
            Price = price;
            EventType = eventType;
            Capacity = capacity;
        }
    }
}

