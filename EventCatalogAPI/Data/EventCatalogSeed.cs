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
            //Use Add-Migration in powershell everytime changes were made to database tables
            context.Database.Migrate();//equivalent to PowerShell Command Update-Database
            if(!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetPreconfiguredEventCategories());
                context.SaveChanges();
            }
            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetPreconfiguredEventTypes());
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
                new EventItem() { EventTypeId=3,EventCategoryId=2, EventName = "Nourishment Festival", OrganizerName = "Health Conscious", EventDescription = "Sample and purchase hundreds of products, meet with brands, receive coupons and attend educational classes with industry experts", VenueName = "Seattle Center", AddressLine1 = "301 Mercer St", City = "Seattle", State = "WA", Zip = "98109", Date = "09/21/2019", Time = "1:00PM", Price = 9.99M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventTypeId=4,EventCategoryId=4, EventName = "Taylor Swift", OrganizerName = "TS Company", EventDescription = "Come see Taylor Swift rock the venue with her latest hits!", VenueName = "Tacoma Dome", AddressLine1 = "2727 E D St", City = "Tacoma", State = "WA", Zip = "98421", Date = "10/11/2019", Time = "4:00PM", Price = 29.99M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/2" },
                new EventItem() { EventTypeId=2,EventCategoryId=2, EventName = "Advanced Physiotherapy", OrganizerName = "Dr. John Doe", EventDescription = "Medical Concepts Presents a Masterclass on Advanced Physiotherapy by industry leader, Dr. John Doe", VenueName = "Boston Center", AddressLine1 = "109 Croton Ave", City = "Ossining", State = "NY", Zip = "10562", Date = "10/21/2019", Time = "1:00PM", Price = 105.00M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/3" },
                new EventItem() { EventTypeId=1,EventCategoryId=1, EventName = "Hello Beauty", OrganizerName = "Cosmic Fashions", EventDescription = "The best and brightest show NYC has to offer", VenueName = "Broadway Club", AddressLine1 = "318 W 53rd St", City = "New York", State = "NY", Zip = "10019", Date = "10/11/2019", Time = "1:30PM", Price = 17.50M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/4" },
                new EventItem() { EventTypeId=2,EventCategoryId=3, EventName = "Excel Training", OrganizerName = "Information Technology", EventDescription = "Learn to use Microsoft Excel like a pro", VenueName = "County Education Office", AddressLine1 = "1111 Las Gallinas Ave", City = "San Rafael", State = "CA", Zip = "94903", Date = "09/30/2019", Time = "3:00PM", Price = 1.00M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/5" },
                new EventItem() { EventTypeId=2,EventCategoryId=3, EventName = "Succession Planning & Career Advancement", OrganizerName = "Jane Doe", EventDescription = "Provides employees with programing, training and development resources, coaching and mentoring resources, and professional organization resources", VenueName = "Municipal Services Building - Room #3", AddressLine1 = "33 Arroyo Drive", City = "San Francisco", State = "CA", Zip = "94080", Date = "09/24/2019", Time = "9:00AM", Price = 5.00M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/6" },
                new EventItem() { EventTypeId=1,EventCategoryId=3, EventName = "Managing Risks", OrganizerName = "Science Movies", EventDescription = "How AI helps", VenueName = "The Conference Center", AddressLine1 = "1 N. Upper Wacker Drive", City = "Chicago", State = "IL", Zip = "60606", Date = "09/25/2019", Time = "6:30PM", Price = 15.99M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/7" },
                new EventItem() { EventTypeId=2,EventCategoryId=4, EventName = "Vocal Technique Training", OrganizerName = "Fivers", EventDescription = "Ever played a show and get hoarse halfway through? Want to learn a few techniques and beef up your vocals?", VenueName = "SPACE", AddressLine1 = "1245 Chicago Avenue", City = "Evanston", State = "IL", Zip = "60202", Date = "12/21/2019", Time = "7:00PM", Price = 49.99M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/8" },
                new EventItem() { EventTypeId=4,EventCategoryId=4, EventName = "House of Blues Concerts", OrganizerName = "House of Blues Chicago", EventDescription = "Experience the ultimate night out", VenueName = "North Park", AddressLine1 = "5137 N Spaulding Ave", City = "Chicago", State = "IL", Zip = "60625", Date = "09/21/2019", Time = "11:00PM", Price = 1.00M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/9" },
                new EventItem() { EventTypeId=2,EventCategoryId=1, EventName = "Personal Stylist Training", OrganizerName = "Fashion Institute", EventDescription = "This program will teach you the basics of personal styling and how to put together creative outfits for yourself and potential clients", VenueName = "Brickell City Center", AddressLine1 = "301 Mercer St", City = "Miami", State = "FL", Zip = "33131", Date = "10/23/2019", Time = "10:00AM", Price = 700.00M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/10" },
                new EventItem() { EventTypeId=3,EventCategoryId=3, EventName = "FinTech Festival", OrganizerName = "Bank Of America", EventDescription = "Blockchain Innovation projects showcase 2019", VenueName = "Anne Kolb Center", AddressLine1 = "751 Sheridan Street", City = "Hollywood", State = "FL", Zip = "33019", Date = "11/14/2019", Time = "4:00PM", Price = 1.00M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/11" },
                new EventItem() { EventTypeId=3,EventCategoryId=2, EventName = "Yoga Festival", OrganizerName = "Yoga Collective", EventDescription = "Bringing together the very best yoga instructors, wellness experts, and leaders in healthy living for a transformational experience of practice, connection, and community", VenueName = "The Asbury Hotel", AddressLine1 = "210 5th Avenue", City = "Asbury Park", State = "NJ", Zip = "07712", Date = "10/27/2019", Time = "8:00AM", Price = 35.00M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/12" },
                new EventItem() { EventTypeId=2,EventCategoryId=2, EventName = "Botox Training", OrganizerName = "MedTrain", EventDescription = "Learn to perform Botox injections and other aesthetic procedures", VenueName = "Marriott Downtown", AddressLine1 = "1201 Market Street", City = "Philadelphia", State = "PA", Zip = "19107", Date = "11/21/2019", Time = "8:00AM", Price = 799.99M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/13" },
                new EventItem() { EventTypeId=1,EventCategoryId=4, EventName = "Live Sound", OrganizerName = "Music Project", EventDescription = "Halloween band show featuring 21+ tribute bands", VenueName = "Highline", AddressLine1 = "1201 Market Street", City = "Seattle", State = "WA", Zip = "98102", Date = "10/31/2019", Time = "11:00PM", Price = 19.99M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/14" },
                new EventItem() { EventTypeId=2,EventCategoryId=3, EventName = "Automation Anywhere", OrganizerName = "Automaton", EventDescription = "Live instructor led training on automation", VenueName = "Seattle Center", AddressLine1 = "301 Mercer St", City = "Seattle", State = "WA", Zip = "98109", Date = "11/21/2019", Time = "10:00AM", Price = 49.99M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/15" },
                new EventItem() { EventTypeId=2,EventCategoryId=3, EventName = "ScrumMaster Training", OrganizerName = "Scrum Company", EventDescription = "Our Certified ScrumMaster training is a highly interactive blend of theory and practice offered by worldclass instructors", VenueName = "Seattle Center", AddressLine1 = "301 Mercer St", City = "Seattle", State = "WA", Zip = "98109", Date = "10/01/2019", Time = "1:00PM", Price = 200.00M, PictureUrl = "http://externalEventbaseurltobereplaced/api/pic/16" }

            };
        }

        private static IEnumerable<EventType> GetPreconfiguredEventTypes()
        {
            return new List<EventType>()
            {
                new EventType() {Type = "Show"},
                new EventType() {Type = "Training"},
                new EventType() {Type = "Festival"},
                new EventType() {Type = "Concert"}
            };
        }

        private static IEnumerable<EventCategory> GetPreconfiguredEventCategories()
        {
            return new List<EventCategory>()
            {
                new EventCategory() {Category = "Fashion"},
                new EventCategory() {Category = "Health"},
                new EventCategory() {Category = "Science & Technology"},
                new EventCategory() {Category = "Music"}
            };
        }
    }
}
