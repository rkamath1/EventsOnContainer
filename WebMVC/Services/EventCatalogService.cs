using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly IHttpClient _client;
        private readonly string _baseUri;

        public EventCatalogService(IConfiguration config, IHttpClient client)
        {
            _baseUri = $"{config["CatalogUrl"]}/api/catalog/";
            _client = client;
        }

        public async Task<EventCatalog> GetEventCatalogItemsAsync(int page, int size, int? eventType, int? eventCategory, int? eventLocation)
        {
            var catalogItemsUri = ApiPaths.Catalog.GetAllEventCatalogItems(_baseUri, page, size, eventType, eventCategory, eventLocation);
            var dataString = await _client.GetStringAsync(catalogItemsUri);
            var response = JsonConvert.DeserializeObject<EventCatalog>(dataString);
            return response;
        }
        public async Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync()
        {
            var categoryUri = ApiPaths.Catalog.GetAllEventCategories(_baseUri);
            var dataString = await _client.GetStringAsync(categoryUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "0",
                    Text =  "All",
                    Selected = true
                }
            };
            var categories = JArray.Parse(dataString);
            foreach (var category in categories)
            {
                items.Add(new SelectListItem
                {
                    Value = category.Value<string>("id"),
                    Text = category.Value<string>("category")
                }
                ) ;
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetEventLocationsAsync()
        {
            var locationUri = ApiPaths.Catalog.GetAllEventLocations(_baseUri);
            var dataString = await _client.GetStringAsync(locationUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "0",
                    Text =  "All",
                    Selected = true
                }
            };
            var locations = JArray.Parse(dataString);
            foreach (var location in locations)
            {
                items.Add(new SelectListItem
                {
                    Value = location.Value<string>("id"),
                    Text = location.Value<string>("city")
                    //Text1 = location.Value<string>("state")                    
                }
                );
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetEventTypesAsync()
        {
            var typeUri = ApiPaths.Catalog.GetAllEventTypes(_baseUri);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "0",
                    Text =  "All",
                    Selected = true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(new SelectListItem
                {
                    Value = type.Value<string>("id"),
                    Text = type.Value<string>("type")
                }
                );
            }
            return items;
        }

    }
}
