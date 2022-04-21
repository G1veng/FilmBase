using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      
      routes.MapRoute(
          name: "Values",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Values", action = UrlParameter.Optional, id = UrlParameter.Optional }
      );
      routes.MapRoute(
          name: "Film",
          url: "api/{controller}/{action}/{id}",
          defaults: new { controller = "Film", action = UrlParameter.Optional, id = UrlParameter.Optional }
      );
      routes.MapRoute(
          name: "Home",
          url: "api/{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = UrlParameter.Optional, id = UrlParameter.Optional }
      );
      routes.MapPageRoute(
        "Default",
        "film/index.cshtml",
        "~/Film/Index.cshtml");
    }
  }
}
