using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class EventCatalogController : Controller
    {
        //IEventCatalogService will be in the service folder
        private readonly IEventCatalogService _service;
        public EventCatalogController(IEventCatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(
            int? eventCategoryFilterApplied,
            int? eventTypeFilterApplied,
            int? eventLocationFilterApplied,
            int? page)
        {
            var itemsOnPage = 10;
            var catalog = await _service.GetCatalogItemsAsync
                (page ?? 0, itemsOnPage, eventCategoryFilterApplied, 
                eventTypeFilterApplied, eventLocationFilterApplied);
            return View();
        }
    }
}