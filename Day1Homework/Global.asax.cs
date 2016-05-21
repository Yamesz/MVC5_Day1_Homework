using Day1Homework.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Day1Homework
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // 清除所有 View Engine
            ViewEngines.Engines.Clear();
            // 重新註冊 RazorViewEngine，如果你使用的是 WebForm ViewEngine 則是加入 WebFormViewEngine
            ViewEngines.Engines.Add(new RazorViewEngine());


            AutoMapperConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
