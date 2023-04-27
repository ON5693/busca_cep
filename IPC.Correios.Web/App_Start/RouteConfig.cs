using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IPC.Correios.Middleware.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "buscaporcep",
                "buscaporcep",
                new { controller = "Cep", action = "Index" }
            );

            routes.MapRoute(
                "buscaporendereco",
                "buscaporendereco",
                new { controller = "Address", action = "Index" }
            );

            routes.MapRoute(
                "resultendereco",
                "Address/Popup/{uf}/{city}/{ad}",
                new { controller = "Address", action = "Popup", uf = "", city = "", ad = "" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
