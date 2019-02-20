using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//  provides instructions about how a web application is compiled and run.
// These import built-in .NET namespaces required in creating a web application. They do things like help us construct HTTP requests, configure our project, or ensure necessary built-in functionality is present in the correct areas.

namespace FriendLetter
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder() //This definitely doesn't look like constructors we've created previously. Its job is to create an iteration of the Startup class that contains specific settings and variables to run the project successfully.
          .SetBasePath(env.ContentRootPath)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; } // This begins the process of adding custom configurations to our project. We'll continue configuring by adding a ConfigureServices() method below it:

    public void ConfigureServices(IServiceCollection services) // ConfigureServices() is a required built-in method used to set up an application's server. Within it, we configure other framework services.
    {
      services.AddMvc();  // , adds the MVC service to the project. 
    }

    public void Configure(IApplicationBuilder app) // The Configure() method is built-in, and required in all ASP.NET Core apps. ASP.NET calls Configure() when the app launches. It's responsible for telling our app how to handle requests to the server.
    {
        app.UseMvc( routes => //We include app.UseMvc(...) to tell our app that it will be using the MVC framework to respond to HTTP requests. 
        {                       //This block of code also sets up our default routing. It tells the project to use the Index action of the Home Controller as the default route (which is essentially the homepage
            routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
        });

        app.Run(async (context) => // Run(...). This code is not actually required to successfully launch our project, but it allows us to later test that our Configure() method is working properly
        {
            await context.Response.WriteAsync("Something went wrong...");
        });
    }

  }
}