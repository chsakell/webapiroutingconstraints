using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace WebAPIRoutingConstraints
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var config = GlobalConfiguration.Configuration;

            //config.Routes.MapHttpRoute("DefaultHttpRoute", "api/{controller}/{abbreviation}",
            //    defaults: new { abbreviation = RouteParameter.Optional },
            //    constraints: new { abbreviation = @"[A-Za-z]{2}" }
            // );

            config.Routes.MapHttpRoute("DefaultHttpRoute", "api/{controller}/{abbreviation}",
                defaults: new { abbreviation = RouteParameter.Optional },
                constraints: new { abbreviation = new CustomRegExConstraint(@"[A-Za-z]{2}") }
            );
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}