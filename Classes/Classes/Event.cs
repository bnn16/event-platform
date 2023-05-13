using event_platform_classLibrary.EventHandlers.Classes;
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
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public string EventType { get; set; }
        public int Capacity { get; set; }

        public List<string> tags = new List<string>();


        public Event(int id, string name, string desc,DateTime date, int price, string eventType, int capacity)
        {
            Id = id;
            Name = name;
            Description = desc;
            Date = date;
            Price = price;
            EventType = eventType;
            Capacity = capacity;
        }
    }
}

