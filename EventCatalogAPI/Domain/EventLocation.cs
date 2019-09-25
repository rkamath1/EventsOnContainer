using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventLocation
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
