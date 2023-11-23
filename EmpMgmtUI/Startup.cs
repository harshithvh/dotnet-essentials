using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMgmtDAL;
using EmpMgmtDAL.EntityLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmpMgmtUI
{
    public class Startup
    {
        // constructor that gets called as soon as this application launches
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // responsible for configuring the services required by the application.
        // if an application requires access to a database, the ConfigureServices method might add a database connection service using the AddDbContext method.
        // Similarly, if the application requires authentication add an authentication service using the AddAuthentication method.
        public void ConfigureServices(IServiceCollection services)
        {
            // AddControllersWithViews() registers the services required for controllers and views to work together
            // shortcut method that combines AddControllers() and AddRazorPages()
            services.AddControllersWithViews();

            // injecting the connectionstring"EmpConString" that connects the UI with database
            string constring = Configuration.GetConnectionString("EmpConString");
            services.AddDbContext<EmpMgmtDbContext>(dboptions =>
                                dboptions.UseSqlServer(constring));

            // By calling AddScoped, a new instance of EmployeeRepository will be created each time an IRepository<Employee> instance is requested during the processing of an HTTP request.
            // The created instance will be shared across all the components within that request.
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // checks if the application is running in the development environment
            if (env.IsDevelopment())
            {
                // provides detailed information about the exception, including the exception type, message, stack trace, and other 
                app.UseDeveloperExceptionPage();
            }

            // since wwwroot is a static folder which is being used
            app.UseStaticFiles();

            // middleware: analyzes incoming requests and determines which endpoint (controller action) should handle the request based on the request's URL and HTTP method.
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });

                // this is an endpoint that has default route set as controller=home, action=index(method) and id is optional
                // https://localhost:5001/home will call the HomeController.cs file whereas https://localhost:5001/second will call SecondController.cs file
                //  https://localhost:5001/home/method will call the 'method' under the specified file
                //endpoints.MapDefaultControllerRoute();

                // the first param in MapControllerRoute is the name given to the route/endpoint
                //endpoints.MapControllerRoute("third",
                //            "dayforce/abc/{id?}",
                //            new { controller = "thrid", action = "index" });

                // this is an endpoint that has default route set as controller=MyMath, action=index(method) on calling https://localhost:5001/
                endpoints.MapControllerRoute("second",
                            "{controller}/{action}/{id?}",
                            new { controller = "ManageEmployee", action = "index" });

                // required for attribute based routing
                //endpoints.MapControllers();

            });
        }
    }
}
