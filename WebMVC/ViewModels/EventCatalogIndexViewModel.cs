using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.ViewModel
{
    public class EventCatalogIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<EventItem> EventItems { get; set; }
        public int? eventCategoryFilterApplied { get; set; }
        public int? eventTypeFilterApplied { get; set; }
        public int? eventLocationFilterApplied { get; set; }

    }
}
