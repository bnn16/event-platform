using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_platform_classLibrary.EventHandlers
{
    public class ConcertEvent : Event
    {
        public string Artist { get; set; }
        public string Venue { get; set; }

        public ConcertEvent(int id, string name, DateTime date, int price, string eventType, int capacity, string artist, string venue) : base(id, name, date, price, eventType, capacity)
        {
            Artist = artist;
            Venue = venue;
        }
    }
}
