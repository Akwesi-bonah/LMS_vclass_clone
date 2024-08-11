using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;


namespace vclass_clone
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["LastActivityTime"] = DateTime.Now;
        }

        //protected void Application_AcquireRequestState(object sender, EventArgs e)
        //{
        //    var path = Request.Url.AbsolutePath.ToLower();

        //    if (Session["UserId"] != null)
        //    {
        //        var lastActivity = Session["LastActivityTime"] as DateTime?;
        //        if (lastActivity.HasValue && (DateTime.Now - lastActivity.Value).TotalMinutes > 20)
        //        {
        //            // Session expired, redirect to login page
        //            Session.Abandon();
        //            Response.Redirect("~/web_form/auth/login.aspx");
        //        }
        //        else
        //        {
        //            // Update last activity time
        //            Session["LastActivityTime"] = DateTime.Now;
        //        }
        //    }
        //    else
        //    {
        //        if (path != "/web_form/auth/login.aspx" && !path.EndsWith("/login.aspx"))
        //        {
        //            Response.Redirect("~/web_form/auth/login.aspx");
        //        }
        //    }
        //}

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    Server.ClearError();
        //    Response.Redirect("~/ErrorPage.aspx"); 
        //}

        //protected void Session_End(object sender, EventArgs e)
        //{
        //    var userId = Session["UserId"] as string;
        //    if (!string.IsNullOrEmpty(userId))
        //    {
        //        LogSessionEnd(userId);
        //    }

        //}

        private void LogSessionEnd(string userId)
        {
          
            System.Diagnostics.Debug.WriteLine($"Session ended for user: {userId}");
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}