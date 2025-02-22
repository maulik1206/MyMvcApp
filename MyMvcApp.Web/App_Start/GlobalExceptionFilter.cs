using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MyMvcApp.Web.App_Start
{
    public class GlobalExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            // Log the exception (Optional: Use Serilog, NLog, etc.)
            var exception = filterContext.Exception;

            // Set the error message
            filterContext.Controller.ViewData["GlobalErrorMessage"] = "An unexpected error occurred: " + exception.Message;

            // Mark the exception as handled
            filterContext.ExceptionHandled = true;

            // Redirect to the same view with the error message
            filterContext.Result = new ViewResult
            {
                ViewName = filterContext.RouteData.Values["action"].ToString(),
                ViewData = filterContext.Controller.ViewData,
                TempData = filterContext.Controller.TempData
            };
        }
    }

}