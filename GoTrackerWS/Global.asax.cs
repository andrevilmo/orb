using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GoTrackerWS
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());
        }
        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {

                //Response.Headers.Add("Access-Control-Allow-Origin", "*");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET, PUT, POST, DELETE, HEAD, OPTIONS");
                Response.Flush();
                Response.End();
            }
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            // Get the exception object.
            Exception exc = Server.GetLastError();

            // Handle HTTP errors
            if (exc.GetType() == typeof(HttpException))
            {
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                    return;

                //Redirect HTTP errors to HttpError page
                //Server.Transfer("HttpErrorPage.aspx");
                return;
            }
        }
    }
}
