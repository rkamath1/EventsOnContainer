using System;
using System.Collections.Generic;
using IOFile = System.IO.File;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : ControllerBase
    {
        private readonly IHostingEnvironment _env;
        public PicController(IHostingEnvironment env)
        {
            _env = env;//maps to the top folder in the hosting environment
                        //EventVatalogAPI in this case
        }

        [HttpGet("{id}")] //Get request
        public IActionResult GetImage(int id)//IActionResult converts data to json
        {
            var webRoot = _env.WebRootPath;//navigating to wwwroot folder
            var path = Path.Combine($"{webRoot}/Pics/", $"Event{id}.jpg");//navigating to the picture
            var buffer = IOFile.ReadAllBytes(path);
            return File(buffer, "image/jpeg");
        }
    }
}