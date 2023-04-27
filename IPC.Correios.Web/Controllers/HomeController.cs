using System.Web.Mvc;

namespace IPC.Correios.Middleware.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Address()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Cep()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}