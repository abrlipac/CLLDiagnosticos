using System.Diagnostics;
using System.Web.Mvc;
using WebClientNF.Models;

namespace WebClientNF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
