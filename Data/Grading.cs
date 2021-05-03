using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GradingSystem.Data
{
    public class GradingContext : DbContext
    {
        public GradingContext(DbContextOptions<GradingContext> options)
            : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Grade> Grade { get; set; }
    }
    //public class ViewModel
    //{
    //    public IEnumerable<Student> Student {get; set;} 
    //    public IEnumerable<Subject> Subject { get; set; }
    //}
}
