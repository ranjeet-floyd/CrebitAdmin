using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
namespace CrebitAdminPanelNew.App_start
{
    // Web API configuration and services
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            // Attribute routing.
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                  routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}