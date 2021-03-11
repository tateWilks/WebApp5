using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp5.Models;

namespace WebApp5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // allows us to create our own endpoints by using the controller

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:WebApp5Connection"]); //this is going to connect us to a database
            });

            services.AddScoped<IBookRepository, EFBookRepository>(); //give people their own scope for what's happening When we register a type as Scoped, one instance is available throughout the application per request. When a new request comes in, the new instance is created. Add scoped specifies that a single object is available per request.

            services.AddRazorPages(); //need to add razor pages

            services.AddDistributedMemoryCache(); //need these two services to make the information stick
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession(); //sets up the session for us on startup

            //these next two app settings will protect against xss and enable certificate pinning
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                await next();
            });

            app.UseHsts();

            app.Use(async (ctx, next) =>
            {
                ctx.Response.Headers.Add("Content-Security-Policy",
                "default-src 'self'");
                await next();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { //change this a bit to make things nicer
                endpoints.MapControllerRoute( //for if they enter a category AND a page
                    "categorypage",
                    "{category}/P{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute( //for when they just want a page
                    "page",
                    "{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute( //for when they want to enter just a category - for spaces do "%20"
                    "category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1});

                endpoints.MapControllerRoute( //for when they want to do book categories
                    "pagination",
                    "Books/P{page}", //change this so you can enter this in the URL to request a page and its number
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages(); //need to route to razor pages
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
