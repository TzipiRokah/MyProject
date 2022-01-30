using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Bll;

namespace LunaParkProject
{
    public class WebApiApplication : System.Web.HttpApplication
    { //C:\Users\b\Documents\הנדסאים\פרויקט גמר\LunaParkProject\LunaParkProject\Global.asax 
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bll.QueuesBll.RunPrepareDaily(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour, DateTime.Now.Minute+1, 0));//קריאה לפונקציה שתעיר פונקציה כל יום ב 23:45
        }
        protected void Application_BeginRequest()
        {
            Response.AddHeader("Access-Control-Allow-Origin", "*");
            Response.AddHeader("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE");
            Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authorization ");

            if (Request.Headers.AllKeys.Contains("Origin", StringComparer.CurrentCultureIgnoreCase)
                && Request.HttpMethod == "OPTIONS")
            {
                Response.End();
            }
        }
    }
}
