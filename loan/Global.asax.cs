using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace loan
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

          

            routes.MapRoute(
             "AdminNoControl",
             "admin/{action}/{id}",
             new { controller = "admin", action = "Index", id = UrlParameter.Optional },
             new[] { "loan.Controllers" });//无AdminControl的匹配

            routes.MapRoute(
              "WireLessNoControl",
              "WireLess/{action}.html",
              new { controller = "wireless", action = "Index", id = UrlParameter.Optional },
              new[] { "loan.Controllers" });//无WireLessControl的匹配


            routes.MapRoute(
                 "DefaultHtml", // 静态化路由
                 "{controller}/{action}/{id}.html", // 带有参数的 URL
                 new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 new[] { "loan.Controllers" });// 参数默认值

            routes.MapRoute(
                 "NewsList", // 静态化路由
                 "{action}/{type}_{pageIndex}.html", // 带有参数的 URL
                 new { controller = "Home", action = "News_list", type = UrlParameter.Optional, pageIndex = UrlParameter.Optional },
                 new[] { "loan.Controllers" });// 参数默认值

            routes.MapRoute(
                "HasID", // 静态化路由
                "{action}/{id}.html", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "loan.Controllers" });// 参数默认值


            routes.MapRoute(
                "NoController",
                "{action}.html",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "loan.Controllers" });//无Control的匹配

            routes.MapRoute(
                "Root",
                "",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "loan.Controllers" });//根目录匹配

            routes.MapRoute(
                "NoAction",
                "{controller}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "loan.Controllers" });//根目录匹配

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // 默认情况下对 Entity Framework 使用 LocalDB
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);


        }
    }
}