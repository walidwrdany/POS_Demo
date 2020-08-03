using Microsoft.AspNet.Identity;
using POS_Demo.DataModels;
using POS_Demo.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_Demo.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }


        public DateTime GetDate => DateTime.Now;

        public int GetUserId => User.Identity.GetUserId<int>();


        protected override void OnException(ExceptionContext filterContext)
        {

            if (!Request.IsLocal)
            {

                filterContext.ExceptionHandled = true;
                string filePath = Files.CreateIfNotExist(@"~/Logs/Exception/[" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss tt") + "] " + filterContext.Exception.GetType().FullName + ".txt");
                using (var writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (filterContext.Exception != null)
                    {
                        writer.WriteLine("Exception Type : " + filterContext.Exception.GetType().FullName);
                        writer.WriteLine("CurrentUser : " + GetUserId);
                        writer.WriteLine("ActionName : " + filterContext.RouteData.Values["action"]);
                        writer.WriteLine("ControllerName : " + filterContext.RouteData.Values["controller"]);
                        writer.WriteLine("Message : " + filterContext.Exception.Message);
                        writer.WriteLine("StackTrace : " + filterContext.Exception.StackTrace);
                        writer.WriteLine("InnerException : " + filterContext.Exception.InnerException ?? filterContext.Exception.InnerException.ToString());
                        filterContext.Exception = filterContext.Exception.InnerException;
                    }
                }

                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml"
                };
            }
        }
    }
}