using System;
using System.ComponentModel.DataAnnotations;

namespace CCOGWebsite.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide details of event")]

        public string Details { get; set; }

        [Required(ErrorMessage = "Please provide a date and time for event")]
        public DateTime Date { get; set; }

        public Event()
        {
        }
    }
}

