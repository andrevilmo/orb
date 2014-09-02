using GoTrackerWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace GoTrackerWS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Cliente>("Cliente");
            builder.EntitySet<Equipamento>("Equipamento");
            builder.EntitySet<Veiculo>("Veiculo");
            builder.EntitySet<SimCard>("SimCards");
            builder.EntitySet<Usuario>("Usuario");
            builder.EntitySet<Perfil>("Perfil");
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
