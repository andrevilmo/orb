using GoTrackerModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Routing.Conventions;

namespace GoTrackerWS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            
            config.MapHttpAttributeRoutes();
            /*
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/
            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var routingConventions = ODataRoutingConventions.CreateDefault();
            routingConventions.Insert(0, new CreateNavigationPropertyRoutingConvention());

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Cliente>("Cliente");
            builder.EntitySet<Equipamento>("Equipamento");
            builder.EntitySet<Motorista>("Motorista");
            builder.EntitySet<Veiculo>("Veiculo");
            builder.EntitySet<SimCard>("SimCard");
            builder.EntitySet<Usuario>("Usuario");
            builder.EntitySet<Perfil>("Perfil");
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
