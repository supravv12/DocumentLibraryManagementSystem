using DocumentLibraryManagementSystem.DbOperations;
using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentLibraryManagementSystem.Controllers
{
    public class DocumentSourceController : Controller
    {
        DocumentSourceRepository repository = null;

        public DocumentSourceController()
        {
            repository = new DocumentSourceRepository();

        }
        // GET: Category
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DocumentSourceModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddDocumentSource(model);
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
            var result = repository.GetAllDocumentSource();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var category = repository.GetDocumentSource(id);
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var docsource = repository.GetDocumentSource(id);
            return View(docsource);
        }


        [HttpPost]
        public ActionResult Edit(DocumentSourceModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateDocumentSource(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            repository.DeleteDocumentSource(id);
            return RedirectToAction("GetAllRecords");
        }
    }
}