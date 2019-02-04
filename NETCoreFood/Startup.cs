using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NETCoreFood.Data;
using NETCoreFood.Services;
using NETCoreFood.ViewModels;

namespace NETCoreFood
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

            // this method is used to register custom services , so that ASP.NET can use those services 
            //and pass them around not only to itsself but to other parts of the application 
        public void ConfigureServices(IServiceCollection services)
        {

          

            // services.AddTransient(); //telling asp.net core that if some needs IGreeter, a new instance
            // of Greeter is created . There is no saving or re-using of the old instance .
            //of this service for the entire application.


            // services.AddSingleton();// telling asp.net core that we only will ever need a single instance 
            //of this service for the entire application.

            // services.AddScoped(); // this will allow me to create a sevrice that asp.net core 
            //will create (use) once per every http request .So the service is scoped to that specifc request 
            //and the service is reused through out the request cycle and then thrown away.

            services.AddSingleton<IGreeter, Greeter>();
            // this will make a new instance per http request. With in the same http request, the same instance 
            // will be used (re-used).
            services.AddDbContext<NETCoreFoodDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("NETCoreFood")));
            services.AddScoped<IResturantData, SQLResturantData>();
            services.AddScoped<IHomeIndexViewModel, HomeIndexViewModel>();
            services.AddMvc().AddRazorPagesOptions(options => options.AllowAreas = true);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = OpenIdConnectDefaults.AuthenticationScheme;

            })
            .AddGoogle(options =>
            {
                options.ClientId = "287678902462-f48b97fos1kqrr4tssc6pcihobvh8q31.apps.googleusercontent.com";
                options.ClientSecret = "5hvT_UU2WItZGn_jdfPABWcn";
              
             
            })
            .AddCookie();
        }

        // This method configures the HTTP Processing pipeline for my ASP.NET application.
        //For every HTTP message that arrives it is this code inside of this method that is invoked
        // and will define which component will process the request. This method will have access to the header info
        // and also the URL requsted from .

       // This method gets called by the runtime.Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());

            // app.UseFileServer();
            //app.UseDefaultFiles();// this is used to set the default page .. this is usually Index.html if not we need to define the file 
            app.UseStaticFiles(); // this is used to serve static files from wwwroot. 
                                  //(wwwroot is place to keep the static files.
            app.UseAuthentication();
          
            app.UseMvc(ConfigureRoutes);

            //app.UseMvc(rb =>
            //{
            //    rb.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "Home", action = "Index" });
            //});


            var greeting = greeter.GetMessageOfDay();
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/xml";
                await context.Response.WriteAsync(greeting);
            });



        }

        private void ConfigureRoutes(IRouteBuilder obj)
        {
            // this type of routing is conventional routing 
            // if we define the routing on a method , that is called as Attribute Routing 
            //obj.MapRoute(
            //   name: "default",
            //   template: "{controller}/{action}/{id?}",
            //   defaults: new { controller = "Home", action = "Index" });

            obj.MapRoute(
           "Default", // Route name
           "{controller}/{action}/{id}", // URL with parameters
           new
           {
               controller = "Home",
               action = "Index",
               id = ""
           }  // Parameter defaults
       );

        }

        //public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        //{
        //    app.Use((context, next) =>
        //    {
        //        var cultureQuery = context.Request.Query["culture"];
        //        if (!string.IsNullOrWhiteSpace(cultureQuery))
        //        {
        //            var culture = new CultureInfo(cultureQuery);

        //            CultureInfo.CurrentCulture = culture;
        //            CultureInfo.CurrentUICulture = culture;
        //        }

        //        // Call the next delegate/middleware in the pipeline
        //        return next();
        //    });


        //    app.Use(next =>
        //     {
        //         return async context =>
        //         {
        //             logger.LogInformation("Started Logging");
        //             if (context.Request.Path.StartsWithSegments("/mym"))
        //             {
        //                 await context.Response.WriteAsync("Hitt!!!");
        //                 logger.LogInformation("Finished Hit....");
        //             }
        //             else
        //             {
        //                 logger.LogInformation("Not able to execute the method.");
        //                 await next(context);

        //             }

        //         };

        //    });

        //    //app.Use((context, next) =>
        //    //{

        //    //    logger.LogInformation("Started Logging");
        //    //    if (context.Request.Path.StartsWithSegments("/mym"))
        //    //    {
        //    //        logger.LogInformation("Finished Hit....");
        //    //        return context.Response.WriteAsync("Hitt!!!");
        //    //    }
        //    //    else
        //    //    {
        //    //        logger.LogInformation("Not able to execute the method.");
        //    //        return next();

        //    //    }



        //    //});


        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync(
        //            $"Hello {CultureInfo.CurrentCulture.DisplayName}");
        //    });

        //}
    }
}
