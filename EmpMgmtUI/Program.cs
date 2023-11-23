using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmpMgmtUI
{
    public class Program
    {
        // start point -> Main
        public static void Main(string[] args)
        {
            // build() method: prepares the host to start accepting requests by configuring services, middleware, and other components required for the application to run
            // run(): starts the host and begin accepting incoming requests
            CreateHostBuilder(args).Build().Run();
            // first CreateHostBuilder(args) is called followed by build() and run() 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        // sets up a default host builder(in this case ASP.net core)
            Host.CreateDefaultBuilder(args)
            // configures the middleware (through the startup class) requird by the application to run 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
