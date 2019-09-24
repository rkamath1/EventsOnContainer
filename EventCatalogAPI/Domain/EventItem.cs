using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string PictureUrl { get; set; }
        public decimal TicketPrice { get; set; }
        public string Time { get; set; }
        public int EventCategoryId { get; set; }
        public virtual EventCategory EventCategory { get; set; }
        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }
        public int EventLocationId { get; set; }
        public virtual EventLocation EventLocation { get; set; }
    }
}
