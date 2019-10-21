using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class EventItem
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string OrganizerName { get; set; }
        public string VenueName { get; set; }
        public string Date { get; set; }
        public decimal TicketPrice { get; set; }
        public string PictureUrl { get; set; }
        public string Time { get; set; }

        public int EventCategoryId { get; set; }
        public string EventCategory { get; set; }

        public int EventTypeId { get; set; }
        public string EventType { get; set; }
        public int EventLocationId { get; set; }
        public string City { get; set; }
    }
}
