using IPC.Correios.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IPC.Correios.Middleware.Web.Controllers
{
    public class CepController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Consulta(string cep)
        {
            var cepObj = CepSearch.Busca(cep);

            return View(cepObj);
        }
    }
}