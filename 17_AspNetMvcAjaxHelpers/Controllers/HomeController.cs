using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17_AspNetMvcAjaxHelpers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()

        {
            List<string> veriler = new List<string>() { "Galatasaray", "bir", "markadır", "devredilemez!" };
            Session["listem"] = veriler;
            return View();
        }

        public PartialViewResult LoadData()
        {

            List<string> listem = Session["listem"] as List<string>;
            System.Threading.Thread.Sleep(3000);
            return PartialView("_VeriListesiPartialView",listem);

        }

        public MvcHtmlString RemoveData(int id)
        {
            List<string> listem = Session["listem"] as List<string>;
        
            listem.RemoveAt(id);  //gonderilen indexi session listesinden sil.
            Session["listem"] = listem;
            System.Threading.Thread.Sleep(3000);

            return MvcHtmlString.Empty;
        }
    }
}