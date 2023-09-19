using DocumentLibraryManagementSystem.DbOperations;
using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentLibraryManagementSystem.Controllers
{
    public class DocumentTypeController : Controller
    {
        DocumentTypeRepository repository = null;

        public DocumentTypeController()
        {
            repository = new DocumentTypeRepository();

        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DocumentTypeModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddDocumentType(model);
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
            var result = repository.GetAllDocumentTypes();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var category = repository.GetDocumentType(id);
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = repository.GetDocumentType(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(DocumentTypeModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateDocumentType(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            repository.DeleteDocumentType(id);
            return RedirectToAction("GetAllRecords");
        }

    }
}