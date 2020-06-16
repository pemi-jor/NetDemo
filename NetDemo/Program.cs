using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NetDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()//;
            .UseKestrel(options =>
            {
                // configure the HTTP port number
                const int PortNumber = 5000;

                // configure HTTP bindings
                options.Listen(IPAddress.Loopback, PortNumber);
                //Set site IPAdress

                options.Listen(new IPAddress(ipAddress), PortNumber);
            });
            /*
            */
    }
}
