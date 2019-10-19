using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;
using WebMVC.ViewModels;

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
        public async Task<IActionResult> About()
        {
            return View();
        }

        public async Task<IActionResult> Index(int? eventTypeFilterApplied, int? eventCategoryFilterApplied, int? eventLocationFilterApplied, int? page)
        {
            var itemsOnPage = 10;
            var catalog = await _service.GetEventCatalogItemsAsync (page ?? 0, itemsOnPage, eventTypeFilterApplied, eventCategoryFilterApplied, eventLocationFilterApplied);
            var vm = new EventCatalogIndexViewModel
            {
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                EventItems = catalog.Data,
                Categories = await _service.GetEventCategoriesAsync(),
                Types = await _service.GetEventTypesAsync(),
                Locations = await _service.GetEventLocationsAsync(),
                TypeFilterApplied = eventTypeFilterApplied ?? 0,
                CategoryFilterApplied = eventCategoryFilterApplied ?? 0,
                LocationFilterApplied = eventLocationFilterApplied ?? 0

            };
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";
            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            return View(vm);
        }
    }
}