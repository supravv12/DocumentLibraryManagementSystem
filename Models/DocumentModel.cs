using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public int Category_Id { get; set; }
        [DisplayName("Category")]

        public string Category_Name { get; set; }
        [Required]

        public int Sub_Category_Id { get; set; }
        [DisplayName("SubCategory")]

        public string Sub_Category_Name { get; set; }
        [Required]
        public int Document_Source_Id { get; set; }
        [DisplayName("Document Source")]

        public string Document_Source_Name { get;set; }
        [Required]
        public int Fiscal_Year_Id { get; set; }

        [DisplayName("Fiscal Year")]
        public string Fiscal_Year_Name { get;  set; }
        [Required]
        public int State_Id { get; set; }
        [DisplayName("State")]
        public string State_Name { get; set;}
        [Required]
        public int District_Id { get; set; }

        [DisplayName("District")]
        public string District_Name { get; set; }
        [Required]
        public int Palika_Id { get; set; }

        [DisplayName("Palika")]
        public string Palika_Name { get; set; }
        [Required]
        public int Document_Type_Id { get; set; }
        [DisplayName("Document Type")]
        public string Document_Type_Name { get; set; } 

        public List<DocumentFileModel> ImageFile { get; set;} = new List<DocumentFileModel>();


    }
}