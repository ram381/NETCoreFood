using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NETCoreFood
{
    public class Program
    {

        /*This is the start up of the application. This is exactly like the console app
        where the static void main method gets called. This is because ASP.NET core application
        is structured as a console mode application.
        
        This is the entry point  for the web application and will pass arguments 

        This web host is placed behind the IIS, so IIS express acts like a proxy 
    
        */
    public static void Main(string[] args)
        {
            

            CreateWebHostBuilder(args).Build().Run();
        }

        

        // A web Host Builder is an object that know how to set up the web server environment
        // and defualtBuilder setsup the environment in the specif way by writting our own builder code.
        //
        /* 
         1. The Default Builder will setup the application to use Kestrel web server . Kestrel is the code name
         for the web server that ships with  as part of the ASP.NET Core and this is a cross platform web server
         It is this server that will listen to HTTP connections in our process and it this server that we use 
         to directly run from command prompt  
         2. Builder also setsup the iis integration ( if the application is running behind the IIS) . It is this integration 
         that allow IIS to pass through windows creds to Kestrel server that is running our application (process).
         ( this is good for intranet applications with in the firewall )
         3. Default web host builder will create an object that implements IConfiguration Interface . We access the 
         object throughout the application and we can retrive the config iinformation through this interface.
                Config values can come from different sources 
                    1.appsettings.JSON
                    2.UserSecrets
                    3.Envio Variables 

         
             
             
        */

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          
           
            WebHost.CreateDefaultBuilder(args)
            
                .UseStartup<Startup>();
    }
}
