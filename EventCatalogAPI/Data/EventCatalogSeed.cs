using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class EventCatalogSeed
    {
        public static void Seed(EventCatalogContext context)
        {
            context.Database.Migrate();
            if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetPreconfiguredEventCategories());
                context.SaveChanges();
            }
            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetPreconfiguredEventTypes());
                context.SaveChanges();
            }
            if (!context.EventLocations.Any())
            {
                context.EventLocations.AddRange(GetPreConfiguredEventLocations());
                context.SaveChanges();
            }            
            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetPreconfiguredEventItems());
                context.SaveChanges();
            }
        }

        private static IEnumerable<EventItem> GetPreconfiguredEventItems()
        {
            return new List<EventItem>()
            {
                new EventItem() {EventTypeId = 1, EventCategoryId =2, EventLocationId = 1, EventName = "Kirkland Oktoberest", OrganizerName = "Kirkland Community", VenueName = "Performance center", Date = "10/29/2019", Time = "7:00PM", TicketPrice = 10, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/1"},
                new EventItem() {EventTypeId = 2, EventCategoryId =2, EventLocationId = 1, EventName = "Gobble Up Seattle 2019", OrganizerName = "Urban Craft", VenueName = "Maguson Park", Date = "9/27/2019", Time = "10:00AM", TicketPrice = 15, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/2"},
                new EventItem() {EventTypeId = 1, EventCategoryId =3, EventLocationId = 1, EventName = "Seattle Education & Community Fair", OrganizerName = "Seattle College", VenueName = "Seattle Center", Date = "11/10/2019", Time = "8:00AM", TicketPrice = 5, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/3"},
                new EventItem() {EventTypeId = 1, EventCategoryId =2, EventLocationId = 2, EventName = "Chicago Fest", OrganizerName = "Mount Prospect Public Library", VenueName = "Cantigny Park", Date = "12/1/2019", Time = "5:00PM", TicketPrice = 10, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/4"},
                new EventItem() {EventTypeId = 3, EventCategoryId =3, EventLocationId = 2, EventName = "Chicago Gourmet 2019", OrganizerName = "Bon Appetit", VenueName = "Millennium Park", Date = "12/25/2019", Time = "6:00PM", TicketPrice = 5, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/5"},
                new EventItem() {EventTypeId = 1, EventCategoryId =1, EventLocationId = 2, EventName = "3rd Annual Gather Gala", OrganizerName = "I grow Chicago", VenueName = "Salvage One", Date = "11/25/2019", Time = "5:00PM", TicketPrice = 20, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/6"},
                new EventItem() {EventTypeId = 2, EventCategoryId =3, EventLocationId = 3, EventName = "Hip Hop Fridays", OrganizerName = "Brittany Trade", VenueName = "Lincoln Ave",Date = "11/10/2019", Time = "4:30PM", TicketPrice = 10, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/7"},
                new EventItem() {EventTypeId = 3, EventCategoryId =2, EventLocationId = 3, EventName = "Friday Night Bites", OrganizerName = "The Potter's house", VenueName = "Malden",Date = "10/15/2019", Time = "11:00AM", TicketPrice = 15, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/8"},
                new EventItem() {EventTypeId = 1, EventCategoryId =2, EventLocationId = 3, EventName = "RAISE 2019", OrganizerName = "Join Alyssa Blask", VenueName = "Gloucester",Date = "9/21/2019", Time = "7:00PM", TicketPrice = 20, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/9"},
                new EventItem() {EventTypeId = 1, EventCategoryId =3, EventLocationId = 3, EventName = "Family Night", OrganizerName = "Family Reach", VenueName = "Boston Museum", Date = "9/30/2019", Time = "1:00PM", TicketPrice = 10, PictureUrl = "http://externaleventbaseurltobereplaced/api/pic/10"},

            };
        }

        private static IEnumerable<EventType> GetPreconfiguredEventTypes()
        {
            return new List<EventType>()
            {
                new EventType() {Type = "Appearance or Singing"},
                new EventType() {Type = "Dinner or Gala"},
                new EventType() {Type = "Festival or Fair"}
            };
        }

        private static IEnumerable<EventCategory> GetPreconfiguredEventCategories()
        {
            return new List<EventCategory>()
            {
                new EventCategory() {Category = "Music"},
                new EventCategory() {Category = "Food & Drink"},
                new EventCategory() {Category = "Charity & Causes"}
            };
        }

        private static IEnumerable<EventLocation> GetPreConfiguredEventLocations()
        {
            return new List<EventLocation>()
            {
                new EventLocation() {City = "Seattle", State = "WA"},
                new EventLocation() {City = "Chicago", State = "IL"},
                new EventLocation() {City = "Boston", State = "MA"}
            };
        }
    }
} 