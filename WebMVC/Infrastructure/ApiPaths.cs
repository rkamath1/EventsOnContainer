using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class ApiPaths
    {
        public static class EventCatalog
        {
            public static string GetAllEventCategories(string baseUri)
            {
                return $"{baseUri}eventcatalogcategories";
            }
            public static string GetAllEventTypes(string baseUri)
            {
                return $"{baseUri}eventcatalogtypes";
            }
            public static string GetAllEventLocations(string baseUri)
            {
                return $"{baseUri}eventcataloglocations";
            }
            public static string GetAllEventCatalogItems(string baseUri,
                int page, int take, int? eventcategory, int? eventtype, int? eventlocation)
            {
                var filterQs = string.Empty;
                if(eventcategory.HasValue || eventtype.HasValue || eventlocation.HasValue)
                {
                    var eventcategoriesQs = (eventcategory.HasValue) ? eventcategory.Value.ToString() : "0";
                    var eventtypeQs = (eventtype.HasValue) ? eventtype.Value.ToString() : "0";
                    var eventlocationQs = (eventlocation.HasValue) ? eventlocation.Value.ToString() : "0";
                    filterQs = $"/type/{eventtypeQs}/category/{eventcategoryQs}/location/{eventlocationQs}";
                }
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }
        }
    }
}
