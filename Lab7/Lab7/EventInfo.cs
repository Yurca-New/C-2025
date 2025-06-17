using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class EventInfo
    {
        public SocialEvent EventType;
        public DateTime Date;
        public string Location;

        public EventInfo(SocialEvent eventType, DateTime date, string location)
        {
            EventType = eventType;
            Date = date;
            Location = location;
        }

        public string GetInfo()
        {
            return $"{EventType} - {Date:d} - {Location}";
        }

        public string HowLongUntilEvent()
        {
            TimeSpan timeUntilEvent = Date - DateTime.Now;
            return timeUntilEvent.TotalDays > 0 ? $"{timeUntilEvent.Days} d." : "Event has passed";
        }
    }
}
