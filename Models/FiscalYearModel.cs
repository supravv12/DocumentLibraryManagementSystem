using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.Models
{
    public class FiscalYearModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        
        public bool Active { get; set; }
    }
}