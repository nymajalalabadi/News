using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace News.Web.Controllers
{
    public class HomeController : SiteBaseController
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
