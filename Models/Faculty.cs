using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GradingSystem.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill up necessary fields")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please fill up necessary fields")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please fill up necessary fields")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        public IEnumerable<Grade> Grade { get; set; }
    }
}
