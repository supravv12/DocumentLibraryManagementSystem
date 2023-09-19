using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.DbOperations
{
    public class DashboardCountRepository
    {
        public DashboardCountModel DashCount()
        {
            using(var context =  new DLMSDatabaseEntities())
            {
                DashboardCountModel model = new DashboardCountModel()
                {
                    CategoryCount = context.Category.Count(),
                    SubCategoryCount = context.Sub_Category.Count(),
                    DocumentCount = context.Document.Count(),
                    DocumentTypeCount = context.Document_Type.Count(),
                    DocumentSourceCount = context.Document_Source.Count(),
                    FiscalYearCount = context.Fiscal_Year.Count()

               };
                return model;
            }

            


        }

    }
}