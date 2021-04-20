using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GradingSystem.Data
{
    public class Grading
    {
    }

    public class GradingContext : DbContext
    {
        public GradingContext (DbContextOptions<GradingContext> options)
            :base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
    }
}
