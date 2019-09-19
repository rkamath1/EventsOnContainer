using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly EventCatalogContext _context;//our database
        private readonly IConfiguration _config;
        public CatalogController(EventCatalogContext context,
            IConfiguration config)
        {
            _context = context;//dependancy injection
            _config = config;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var itemsCount = await
                _context.EventItems.LongCountAsync();

            var items = await _context.EventItems
                .OrderBy(c => c.EventName)//Linq queries & lambda statements
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);

            return Ok(items);
        }

        [HttpGet]
        [Route("[action]/type/{eventTypeId}/category/{eventCategoryId}")]
        public async Task<IActionResult> Items(
            int? eventTypeId,
            int? eventCategoryId,
        [FromQuery] int pageIndex = 0,
        [FromQuery] int pageSize = 6)
        {
            var root = (IQueryable<EventItem>)_context.EventItems;
            if (eventTypeId.HasValue)
            {
                root =
                    root.Where(c => c.EventTypeId == eventTypeId);
            }
            if (eventCategoryId.HasValue)
            {
                root =
                    root.Where(c => c.EventCategoryId == eventCategoryId);
            }


            var itemsCount = await
                root.LongCountAsync();

            var items = await root
                .OrderBy(c => c.EventName)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);

            return Ok(items);
        }


        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(//Linq query
                c => c.PictureUrl = c.PictureUrl
                        .Replace("http://externalEventbaseurltobereplaced",
                        _config["ExternalCatalogBaseUrl"]));
            return items;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var items = await _context.EventTypes.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var items = await _context.EventCategories.ToListAsync();
            return Ok(items);
        }
    }
}