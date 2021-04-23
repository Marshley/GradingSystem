using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace GradingSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly GradingContext _db;
        public StudentsController(GradingContext db)
        {
            _db = db;    
        }
        public IActionResult Index()
        {
            var displaydata = _db.Student.ToList();
            return View(displaydata);
        }
    }
}
