using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.Models
{
    public class SubCategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Category_Id { get; set; }

        public string Category_Name { get; set; }

        public CategoryModel Category { get; set; }
    }
}