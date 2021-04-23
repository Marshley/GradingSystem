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

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }

        public string Course { get; set; }

    }
}
