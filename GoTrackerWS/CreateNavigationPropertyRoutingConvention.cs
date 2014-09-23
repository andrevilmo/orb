using Microsoft.Data.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Routing;
using System.Web.Http.OData.Routing.Conventions;

namespace GoTrackerWS
{
    // routing convention to handle POST requests to navigation properties.
    public class CreateNavigationPropertyRoutingConvention : EntitySetRoutingConvention
    {
        public override string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
        {
            if (odataPath.PathTemplate == "~/entityset/key/navigation" && controllerContext.Request.Method == HttpMethod.Post)
            {
                IEdmNavigationProperty navigationProperty = (odataPath.Segments[2] as NavigationPathSegment).NavigationProperty;
                controllerContext.RouteData.Values["key"] = (odataPath.Segments[1] as KeyValuePathSegment).Value; // set the key for model binding.
                return "PostTo" + navigationProperty.Name;
            }

            return null;
        }
    /*
        public  string SelectAction(Microsoft.Data.OData.Query.SemanticAst.ODataPath odataPath, System.Web.Http.Controllers.HttpControllerContext controllerContext, System.Linq.ILookup<string,System.Web.Http.Controllers.HttpActionDescriptor> actionMap)
            //SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
        {
            if (odataPath.PathTemplate == "~/entityset/key/navigation" && controllerContext.Request.Method == HttpMethod.Post)
            {
                IEdmNavigationProperty navigationProperty = (odataPath.Segments[2] as NavigationPathSegment).NavigationProperty;
                controllerContext.RouteData.Values["key"] = (odataPath.Segments[1] as KeyValuePathSegment).Value; // set the key for model binding.
                return "PostTo" + navigationProperty.Name;
            }

            return null;
        }*/
    }
}