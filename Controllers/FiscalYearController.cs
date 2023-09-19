using DocumentLibraryManagementSystem.DbOperations;
using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentLibraryManagementSystem.Controllers
{
    public class FiscalYearController : Controller
    {
        FiscalYearRepository repository = null;

        public FiscalYearController()
        {
            repository = new FiscalYearRepository();

        }
        // GET: FiscalYear
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FiscalYearModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddFiscalYear(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Added";
                }
            }
            return View();
        }

        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllFiscalYear();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var fiscal = repository.GetFiscalYear(id);
            return View(fiscal);
        }

        public ActionResult Edit(int id)
        {
            var fiscal = repository.GetFiscalYear(id);
            return View(fiscal);
        }


        [HttpPost]
        public ActionResult Edit(FiscalYearModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateFiscalYear(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            repository.DeleteFiscalYear(id);
            return RedirectToAction("GetAllRecords");
        }

    }
}