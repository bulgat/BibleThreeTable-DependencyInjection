using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ThreeBook.ActionFilter
{
    public class LogActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("0777 OnActionExecuting=", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("0777 OnActionExecuted=", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("0777 OnResultExecuting=", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("0777 OnResultExecuted=", filterContext.RouteData);
        }


        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            System.Diagnostics.Debug.WriteLine("00000555 "+message, "Action Filter Log");
            System.Diagnostics.Debug.WriteLine("00000555 ", "kol ");
            System.Diagnostics.Debug.WriteLine("00000555 " + message);
        }

    }
}