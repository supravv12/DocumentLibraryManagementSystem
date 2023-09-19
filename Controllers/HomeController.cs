using DocumentLibraryManagementSystem.DbOperations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentLibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        DashboardCountRepository repository = null;

        public HomeController()
        {
            repository = new DashboardCountRepository();

        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SendData()
        {
            var result = repository.DashCount();
            var json = JsonConvert.SerializeObject(result);
            return Json(json,JsonRequestBehavior.AllowGet);
        }

        
    }
}