using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentProgram.Models
{
    public class StudentModel
    {
        [Display(Name = "Id")]
        public int id { get; set;}

        [Required(ErrorMessage ="Name is mandetory.")]
        public string name { get; set; }

        [Required(ErrorMessage ="Address is required.")]
        public string address { get; set; }

        [Required(ErrorMessage ="Please fill this field.")]
        public string city { get; set; }

    }
}