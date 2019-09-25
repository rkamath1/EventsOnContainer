using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventCatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();//build the host
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider; //Find all services (Startup,cs)
                var context = services.GetRequiredService<EventCatalogContext>();//Check if catalogcontext service is running
                EventCatalogSeed.Seed(context);//If yes, then seed the database
            }
            host.Run();//run the host 
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
