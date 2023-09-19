using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.Models
{
    public class DocumentFileModel
    {
        public int Id { get; set; }

        [DisplayName("File Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("File Path")]
        [Required]
        public string File_Path { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        
    }
}