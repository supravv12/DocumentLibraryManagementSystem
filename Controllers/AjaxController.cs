using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentLibraryManagementSystem.Controllers
{
    public class AjaxController : Controller
    {

        DLMSDatabaseEntities context = new DLMSDatabaseEntities();
        // GET: Ajax
        public JsonResult District(int Sid)
        {

            var result = context.District.Where(x => x.State_Id == Sid).ToList();

            var selectList = new SelectList(result, "Id", "Name")
;
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Palika(int Pid)
        {

            var result = context.Palika.Where(x => x.District_Id == Pid).ToList();

            var selectList = new SelectList(result, "Id", "Name")
;
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult SubCategoryAjax(int Scid)
        {

            var result = context.Sub_Category.Where(x => x.Category_Id == Scid).ToList();

            var selectList = new SelectList(result, "Id", "Name")
;
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }
        //public SelectList District(int Sid)
        //{
        //    using (var context = new DLMSDatabaseEntities())
        //    {
        //        var result = context.District.Where(x => x.State_Id == Sid).ToList();


        //        return new SelectList(result, "Id", "Name");
        //    }
        //}
    }
}