using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GradingSystem.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        [Display(Name = "Student Name")]
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Display(Name = "Subject Name")]
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int? FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
