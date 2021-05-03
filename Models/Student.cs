using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GradingSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill up properly")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please fill up properly")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please fill up properly")]
        [Display(Name = "Middle Name")]
        public string Middlename { get; set; }
        [Required(ErrorMessage = "Please fill up properly")]
        public string Course { get; set; }
        public virtual IEnumerable<Grade> Grade { get; set; }

    }
}
