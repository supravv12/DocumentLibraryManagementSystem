using DocumentLibraryManagementSystem.DbOperations;
using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentLibraryManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository repository = null;
        
        public CategoryController()
        { 
            repository = new CategoryRepository();
             
        }
        // GET: Category
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddCategory(model);
                if(id>0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Added";
                }
            }
            return View();
        }

        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllCategories();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var category =  repository.GetCategory(id);
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category =  repository.GetCategory(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(CategoryModel model)
        {
            if(ModelState.IsValid)
            {
                repository.UpdateCategory(model.Id, model);

                return RedirectToAction("GetAllRecords");
            }
            return View();

        }


        public ActionResult Delete(int id)
        {
            repository.DeleteCategory(id);
            return RedirectToAction("GetAllRecords");
        }


    }
}