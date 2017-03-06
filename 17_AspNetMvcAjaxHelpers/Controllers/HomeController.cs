using _17_AspNetMvcAjaxHelpers.Models;
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

        public ActionResult Index2()
        {
            List<ToDoItem> list = null;
            if (Session["ToDoList"] != null)
            {
                list = Session["ToDoList"] as List<ToDoItem>;
            }
            else
            {
                list = new List<ToDoItem>();
            }
            ViewBag.list = list;
            return View(new ToDoItem());
        }

        [HttpPost]
        public PartialViewResult Index2(ToDoItem model)
        {
            List<ToDoItem> list = null;
            if (Session["ToDoList"] != null)
            {
                list = Session["ToDoList"] as List<ToDoItem>;
            }
            else
            {
                list = new List<ToDoItem>();
            }

            model.Id = Guid.NewGuid();  //model idsi olmadigindan gelen her text icin yeni id urettik.
            list.Add(model);

            Session["ToDoList"] = list;

            System.Threading.Thread.Sleep(3000);

            return PartialView("_ToDoItemPartialView", model);
        }
        public PartialViewResult LoadData()
        {

            List<string> listem = Session["listem"] as List<string>;
            System.Threading.Thread.Sleep(3000);
            return PartialView("_VeriListesiPartialView", listem);

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