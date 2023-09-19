using DocumentLibraryManagementSystem.DbOperations;
using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentLibraryManagementSystem.Controllers
{
    public class DocumentController : Controller
    {
        DocumentRepository repository = null;

        public DocumentController()
        {
            repository = new DocumentRepository();

        }
        // GET: Category
        public ActionResult Create()
        {
            using (var con = new DLMSDatabaseEntities())
            {
                ViewBag.CategoryList = new SelectList(con.Category.ToList(), "Id", "Name");
                ViewBag.SubCategoryList = new SelectList(con.Sub_Category.ToList(), "Id", "Name");
                ViewBag.DocumentSource = new SelectList(con.Document_Source.ToList(), "Id", "Name");
                ViewBag.FiscalYear = new SelectList(con.Fiscal_Year.ToList(), "Id", "Name");
                ViewBag.StateList = new SelectList(con.State.ToList(), "Id", "Name");
                ViewBag.DistrictList = new SelectList(con.District.ToList(), "Id", "Name");
                ViewBag.PalikaList = new SelectList(con.Palika.ToList(), "Id", "Name");
                ViewBag.DocumentType = new SelectList(con.Document_Type.ToList(), "Id", "Name");



            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(DocumentModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddDocument(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Added";
                }
            }
            return RedirectToAction("GetAllRecords");
        }

        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllDocuments();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var doc = repository.GetDocument(id);
            return View(doc);
        }

        public ActionResult Edit(int id)
        {
            using (var con = new DLMSDatabaseEntities())
            {
                ViewBag.CategoryList = new SelectList(con.Category.ToList(), "Id", "Name");
                ViewBag.SubCategoryList = new SelectList(con.Sub_Category.ToList(), "Id", "Name");
                ViewBag.DocumentSource = new SelectList(con.Document_Source.ToList(), "Id", "Name");
                ViewBag.FiscalYear = new SelectList(con.Fiscal_Year.ToList(), "Id", "Name");
                ViewBag.StateList = new SelectList(con.State.ToList(), "Id", "Name");
                ViewBag.DistrictList = new SelectList(con.District.ToList(), "Id", "Name");
                ViewBag.PalikaList = new SelectList(con.Palika.ToList(), "Id", "Name");
                ViewBag.DocumentType = new SelectList(con.Document_Type.ToList(), "Id", "Name");


            }
            var doc = repository.GetDocument(id);
            return View(doc);
        }


        [HttpPost]
        public ActionResult Edit(DocumentModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateDocument(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            repository.DeleteDocument(id);
            return RedirectToAction("GetAllRecords");
        }

        [HttpPost]
        public ActionResult Upload(DocumentFileModel model)
        {

            var imagePath = "/File/";

            using (var con = new DLMSDatabaseEntities())
            {
                if (model.ImageFile != null)
                {


                    var fileName = Path.GetFileName(model.ImageFile.FileName);
                    var path = Path.Combine(Server.MapPath(imagePath), fileName);
                    model.ImageFile.SaveAs(path);
                    model.File_Path = imagePath + model.ImageFile.FileName;
                    Document_File document_File = new Document_File()
                    {
                        File_Path = model.File_Path,
                        Name = fileName,
                    };
                    con.Document_File.Add(document_File);
                    con.SaveChanges();



                }

            }



            return View();
        }

        //public ActionResult GetCountry()
        //{
        //    List<State> Statelist = db.State.ToList();
        //    ViewBag.StateList = new SelectList(Statelist, "Id", "Name");
        //    return View();
        //}




    }
}