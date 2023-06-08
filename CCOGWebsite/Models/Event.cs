using System;
namespace CCOGWebsite.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }

        public Event()
        {
        }
    }
}

