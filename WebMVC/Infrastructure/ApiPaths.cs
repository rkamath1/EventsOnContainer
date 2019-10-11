using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }
            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}eventcategories";
            }
            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}eventlocations";
            }

            public static string GetAllCatalogItems(string baseUri,
                int page, int take, int? category, int? type, int? location)
            {
                var filterQs = string.Empty;

                if (category.HasValue || type.HasValue || location.HasValue)
                {
                    var categoryQs = (category.HasValue) ? category.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    var locationQs = (location.HasValue) ? location.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}/category/{categoryQs}/location/{locationQs}";
                }

                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";

            }
        }
    }
}
