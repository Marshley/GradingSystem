using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GradingSystem.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill up necessary fields")]
        [Display(Name = "Subject Code")]
        public string SubjectCode { get; set; }
        
        [Required (ErrorMessage = "Please fill up necessary fields")]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }
        public IEnumerable<Grade> Grade { get; set; }
    }
}
