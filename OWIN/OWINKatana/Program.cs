using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static OWINKatana.Program;

[assembly: OwinStartup(typeof(OWINKatana.Program.Startup))]
namespace OWINKatana
{

    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldMiddleware>();
        }
    }

    class Program
    {
        //Comment: SystemWeb IIS
        //static void Main(string[] args)
        //{
        //    string uri = "http://localhost:8080";

        //    using (WebApp.Start<Startup>(uri))
        //    {
        //        Console.WriteLine("Started!");
        //        Console.ReadKey();
        //        Console.WriteLine("Stopping!");
        //    }
        //}

        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.Use(async (context, next) =>
                {
                    Console.WriteLine("Requesting : " + context.Request.Path);

                    await next();

                    Console.WriteLine("Response: " + context.Response.StatusCode);
                });

                ConfigureWebApi(app);

                //app.Use<HelloWorldMiddleware>();
                app.UseHelloWorld();

                //app.UseWelcomePage();
            }

            private void ConfigureWebApi(IAppBuilder app)
            {
                var config = new HttpConfiguration();

                config.Routes.MapHttpRoute(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional });

                app.UseWebApi(config);
            }
        }

        public class HelloWorldMiddleware : OwinMiddleware
        {
            public HelloWorldMiddleware(OwinMiddleware next)
                : base(next)
            {

            }

            public override Task Invoke(IOwinContext context)
            {
                //TODO: Add process action

                //await Next.Invoke(context);

                using (var writter = new StreamWriter(context.Response.Body))
                {
                    return writter.WriteAsync("Hello!");
                }
            }
        }
    }
}
