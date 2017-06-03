using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Angular_ASPNETCore_CustomersService.Repository;
using Swashbuckle.Swagger.Model;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace Angular_ASPNETCore_CustomersService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add PostgreSQL support
            //services.AddDbContext<CustomersDbContext>(options => {
            //    options.UseNpgsql(Configuration.GetConnectionString("CustomersPostgresConnectionString"));
            //});

            //Add SQL Server support
            //services.AddDbContext<CustomersDbContext>(options => {
            //    options.UseSqlServer(Configuration.GetConnectionString("CustomersSqlServerConnectionString"));
            //});

            //Add SqLite support
            services.AddDbContext<CustomersDbContext>(options => {
                options.UseSqlite(Configuration.GetConnectionString("CustomersSqliteConnectionString"));
            });

            services.AddMvc();

            //Handle XSRF Name for Header
            //services.AddAntiforgery(options => {
            //    options.HeaderName = "X-XSRF-TOKEN";
            //});

            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IStatesRepository, StatesRepository>();
            services.AddTransient<CustomersDbSeeder>();

            //https://docs.asp.net/en/latest/tutorials/web-api-help-pages-using-swagger.html
            //View the docs by going to http://localhost:5000/swagger
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "ASP.NET Core Customers API",
                    Description = "ASP.NET Core Customers Web API documentation",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Dan Wahlin", Url = "http://twitter.com/danwahlin" },
                    License = new License { Name = "MIT", Url = "https://en.wikipedia.org/wiki/MIT_License" }
                });

                //Enable following for XML comment support 
                //Useful when you want to add more details into the Swagger docs that are generated

                //Base app path 
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                //Set the comments path for the swagger json and ui.
                //options.IncludeXmlComments(basePath + "\\yourAPI.xml");

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory, 
            CustomersDbSeeder customersDbSeeder,
            IAntiforgery antiforgery)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //Manually handle setting XSRF cookie. Needed because HttpOnly has to be set to false so that
            //Angular is able to read/access the cookie.
            // app.Use((context, next) =>
            // {
            //     if (context.Request.Method == HttpMethods.Get &&
            //         (string.Equals(context.Request.Path.Value, "/", StringComparison.OrdinalIgnoreCase) ||
            //          string.Equals(context.Request.Path.Value, "/home/index", StringComparison.OrdinalIgnoreCase)))
            //     {
            //         var tokens = antiforgery.GetAndStoreTokens(context);
            //         context.Response.Cookies.Append("XSRF-TOKEN", 
            //             tokens.RequestToken,
            //             new CookieOptions() { HttpOnly = false });
            //     }

            //     return next();
            // });

            // Serve wwwroot as root
            app.UseFileServer();

            // Serve /node_modules as a separate root (for packages that use other npm modules client side)
            // Added for convenience for those who don't want to worry about running 'gulp copy:libs'
            // Only use in development mode!!
            app.UseFileServer(new FileServerOptions()
            {
                // Set root of file server
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });

            //This would need to be locked down as needed (very open right now)
            app.UseCors((corsPolicyBuilder) => 
            {
                corsPolicyBuilder.AllowAnyOrigin();
                corsPolicyBuilder.AllowAnyMethod();
                corsPolicyBuilder.AllowAnyHeader();
            });

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //https://github.com/aspnet/JavaScriptServices/blob/dev/samples/angular/MusicStore/Startup.cs
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });

            });

            customersDbSeeder.SeedAsync(app.ApplicationServices).Wait();
        }
    }
}
