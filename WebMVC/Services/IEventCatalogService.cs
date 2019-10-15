using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface IEventCatalogService
    {
        Task<EventCatalog> GetEventCatalogItemsAsync(int page, int size, int? eventCategory, int? eventType, int? eventLocation);
        Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetEventTypesAsync();
        Task<IEnumerable<SelectListItem>> GetEventLocationsAsync();
    }
}
