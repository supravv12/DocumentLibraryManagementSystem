using DocumentLibraryManagementSystem.DbOperations;
using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentLibraryManagementSystem.Controllers
{
    public class SubCategoryController : Controller
    {
        SubCategoryRepository repository = null;

        public SubCategoryController()
        {
            repository = new SubCategoryRepository();

        }
        // GET: Category
        public ActionResult Create()
        { 
            using(var con = new DLMSDatabaseEntities())
            {
                ViewBag.CategoryList = new SelectList(con.Category.ToList(),"Id","Name");
            }
            return View();

        }

        [HttpPost]
        public ActionResult Create(SubCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddSubCategory(model);
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
            var result = repository.GetAllSubCategories();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var category = repository.GetSubCategory(id);
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            using(var con = new DLMSDatabaseEntities())
            {
                ViewBag.CategoryList = new SelectList(con.Category.ToList(),"Id","Name");
            }
            var category = repository.GetSubCategory(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(SubCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateSubCategory(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            repository.DeleteSubCategory(id);
            return RedirectToAction("GetAllRecords");
        }
    }
}