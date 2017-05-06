using EscolaWebApi.Filters;
using EscolaWebApi.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EscolaWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new LogMessageHandler());
            config.SuppressHostPrincipal();
            config.Filters.Add(new BasicAuthenticationFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
