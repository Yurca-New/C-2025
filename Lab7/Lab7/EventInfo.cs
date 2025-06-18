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

        /// <summary>
        /// Initializes a new instance of the <see cref="EventInfo"/> class with the specified event type, date, and location.
        /// </summary>
        /// <param name="eventType">The type of the social event.</param>
        /// <param name="date">The date of the event.</param>
        /// <param name="location">The location where the event will take place.</param>
        public EventInfo(SocialEvent eventType, DateTime date, string location)
        {
            EventType = eventType;
            Date = date;
            Location = location;
        }

        /// <summary>
        /// Returns a string containing information about the event, including its type, date, and location.
        /// </summary>
        /// <returns>A formatted string with event details.</returns>
        public string GetInfo()
        {
            return $"{EventType} - {Date:d} - {Location}";
        }

        /// <summary>
        /// Calculates the number of days remaining until the event.
        /// </summary>
        /// <returns>
        /// A string representing the number of days until the event, or "Event has passed" if the event date is in the past.
        /// </returns>
        public string HowLongUntilEvent()
        {
            TimeSpan timeUntilEvent = Date - DateTime.Now;
            return timeUntilEvent.TotalDays > 0 ? $"{timeUntilEvent.Days} d." : "Event has passed";
        }
    }
}
