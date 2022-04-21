using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  public class HomeController : Controller
  {
    public string FirstIndex(int id)
    {
      return "FirstIndex";
    }
    public string IndexTwo()
    {
      return "IndexTwo";
    }
  }
}
