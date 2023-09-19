using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.Models
{
    public class DashboardCountModel
    {
        public int CategoryCount { get; set; }
        public int SubCategoryCount { get; set; }
        public int DocumentCount { get; set; }
        public int DocumentSourceCount { get; set; }
        public int DocumentTypeCount { get; set; }

        public int FiscalYearCount { get; set; }
    }
}