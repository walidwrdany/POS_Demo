using POS_Demo.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace POS_Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //-----------------------------------------------------------
            ViewEngines.Engines.Clear();

            ExtendedRazorViewEngine engine = new ExtendedRazorViewEngine();
            engine.AddViewLocationFormat("~/Views/{1}/{0}.cshtml");
            engine.AddViewLocationFormat("~/Views/{1}/{0}.vbhtml");

            // Add a shared location too, as the lines above are controller specific
            engine.AddPartialViewLocationFormat("~/Views/Shared/Theme/{0}.cshtml");
            engine.AddPartialViewLocationFormat("~/Views/Shared/Theme/{0}.vbhtml");
            engine.AddPartialViewLocationFormat("~/Views/Shared/FormInputs/{0}.cshtml");
            engine.AddPartialViewLocationFormat("~/Views/Shared/FormInputs/{0}.vbhtml");
            engine.AddPartialViewLocationFormat("~/Views/Shared/Theme/AsideMenu/{0}.cshtml");
            engine.AddPartialViewLocationFormat("~/Views/Shared/Theme/AsideMenu/{0}.vbhtml");
            engine.AddPartialViewLocationFormat("~/Views/Shared/Theme/HeaderTopbarItems/{0}.cshtml");
            engine.AddPartialViewLocationFormat("~/Views/Shared/Theme/HeaderTopbarItems/{0}.vbhtml");

            ViewEngines.Engines.Add(engine);
            //-----------------------------------------------------------

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
