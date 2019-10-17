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
                return $"{baseUri}eventcategories";
            }
            public static string GetAllEventTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }
            public static string GetAllEventLocations(string baseUri)
            {
                return $"{baseUri}eventlocations";
            }
            public static string GetAllEventCatalogItems(string baseUri,
                int page, int take, int? category, int? type, int? location)
            {
                var filterQs = string.Empty;

                if (type.HasValue || category.HasValue || location.HasValue)
                {
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    var categoryQs = (category.HasValue) ? category.Value.ToString() : "null";                    
                    var locationQs = (location.HasValue) ? location.Value.ToString() : "null"; 
                    filterQs = $"/category/{categoryQs}/type/{typeQs}/location/{locationQs}";
                }

                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";

            }
        }       
    }
}

