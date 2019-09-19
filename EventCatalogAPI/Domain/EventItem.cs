using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string OrganizerName { get; set; }
        public string EventDescription { get; set; }
        public string VenueName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }//navigational property

        public int EventCategoryId { get; set; }
        public virtual EventCategory EventCategory { get; set; }
    }
}
