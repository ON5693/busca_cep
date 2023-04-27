using IPC.Correios.Web;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IPC.Correios.Middleware.Web.Controllers
{
    public class AddressController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Popup(string uf, string city, string ad)
        {
            var adObj = AddressSearch.Busca(uf, city, ad);

            if (!String.IsNullOrEmpty(adObj.Message))
            {
                ViewBag.Message = adObj.Message;
                return PartialView();
            }
            else
            {
                return PartialView(adObj);
            }
        }
    }
}