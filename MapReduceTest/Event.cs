using System;
using System.Collections.Generic;

namespace MapReduceTest
{
    [Serializable]
    public class Event
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public BusyStatus Status { get; set; }
        public string Details { get; set; }
        public List<string> Tags { get; private set; }

        public Event()
        {
            StartTime = DateTime.Now;
            EndTime = new DateTime(StartTime.Ticks + 36000000000000); // Should be +1 hour
            Title = "New Event";
            Status = BusyStatus.Busy;
            Details = string.Empty;
            Tags = new List<string>();
        }

        public Event(string title, DateTime start, DateTime end, BusyStatus status = BusyStatus.Busy)
        {
            StartTime = start;
            EndTime = end;
            Title = title;
            Status = status;
            Details = string.Empty;
            Tags = new List<string>();
        }

        public void AddTags(IEnumerable<string> tags) =>
            Tags.AddRange(tags);
    }
}
