using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradingSystem.Data;
using GradingSystem.Models;

namespace GradingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly GradingContext _db;

        public AdminController(GradingContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displayStudents = _db.Student.ToList();
            return View(displayStudents);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student createStudent)
        {
            if (ModelState.IsValid)
            {
                _db.Add(createStudent);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(createStudent);
        }
        
        public async Task<IActionResult> Edit(int? Id)
        {
            if(Id == null)
            {
                return RedirectToAction("Index");
            }
            var getStudentDetails = await _db.Student.FindAsync(Id);
            return View(getStudentDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student editStudent)
        {
            if (ModelState.IsValid)
            {
                _db.Update(editStudent);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(editStudent);
        }
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            var getStudentDetails = await _db.Student.FindAsync(Id);
            return View(getStudentDetails);
        }
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            var getStudentDetails = await _db.Student.FindAsync(Id);
            return View(getStudentDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var getStudentDetails = await _db.Student.FindAsync(Id);
            _db.Student.Remove(getStudentDetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult SubjectView()
        {
            var viewsubject = _db.Subject.ToList();
            return View(viewsubject);
        }
        public IActionResult CreateSubject()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubject(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _db.Add(subject);
                await _db.SaveChangesAsync();
                return RedirectToAction("SubjectView");
            }
            return View(subject);
        }
        public async Task<IActionResult> EditSubject(int? Id)
        {
            if(Id == null)
            {
                return View("SubjectView");
            }
            var getSubject = await _db.Subject.FindAsync(Id);
            return View(getSubject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubject(Subject editsubject)
        {
            if (ModelState.IsValid)
            {
                _db.Update(editsubject);
                await _db.SaveChangesAsync();
                return RedirectToAction("SubjectView");
            }
            return View(editsubject);
        }
        
        public IActionResult ViewFaculty()
        {
            var viewfaculty = _db.Faculty.ToList();
            return View(viewfaculty);
        }
        public IActionResult CreateFaculty()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFaculty(Faculty createfaculty)
        {
            if (ModelState.IsValid)
            {
                _db.Add(createfaculty);
                await _db.SaveChangesAsync();
                return RedirectToAction("ViewFaculty");
            }
            return View(createfaculty);
        }
        public async Task<IActionResult> EditFaculty(int? Id)
        {
            if(Id == null)
            {
                return View("ViewFaculty");
            }
            var getFaculty = await _db.Faculty.FindAsync(Id);
            return View(getFaculty); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFaculty(Faculty editfaculty)
        {
            if (ModelState.IsValid)
            {
                _db.Update(editfaculty);
                await _db.SaveChangesAsync();
                return RedirectToAction("ViewFaculty");
            }
            return View(editfaculty);
        }
        public IActionResult AssignSubjectToStudent()
        {
            var std = _db.Student.ToList();
            ViewData["students"] = std;
            var subj = _db.Subject.ToList();
            ViewData["subjects"] = subj;
            //var faculty = _db.Faculty.ToList();
            //ViewData["faculties"] = faculty;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignSubjectToStudent(Grade grade)
        {
            if (ModelState.IsValid)
            {
                _db.Add(grade);
                await _db.SaveChangesAsync();
                return RedirectToAction("ViewGrade");
            }
            return View(grade);
        }
        public IActionResult ViewGrade()
        {
            var displaygrade = _db.Grade.Include(d => d.Student).Include(d => d.Faculty).Include(d => d.Subject);
            return View(displaygrade.ToList());
        }
        public async Task<IActionResult> AssignToFaculty(int? Id){
            if(Id == null)
            {
                return View("ViewGrade");
            }
            var getStudent = await _db.Grade.FindAsync(Id);
            var faculty = _db.Faculty.ToList();
            ViewData["faculties"] = faculty;
            return View(getStudent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignToFaculty(Grade assignFaculty)
        {
            if (ModelState.IsValid)
            {
                _db.Update(assignFaculty);
                await _db.SaveChangesAsync();
                return RedirectToAction("ViewGrade");
            }
            return View(assignFaculty);
        }
        public async Task<IActionResult> Score(int? Id)
        {
            if (Id == null)
            {
                return View("ViewGrade");
            }
            var getGrade = await _db.Grade.FindAsync(Id);
            return View(getGrade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Score(Grade editGrade)
        {
            if (ModelState.IsValid)
            {
                _db.Update(editGrade);
                await _db.SaveChangesAsync();
                return RedirectToAction("ViewGrade");
            }
            return View(editGrade);
        }
        public async Task<IActionResult> GradeDetails(int? Id)
        {
            if (Id == null)
            {
                return View("ViewGrade");
            }
            var getGrade = await _db.Grade.FindAsync(Id);
            var std = _db.Student.ToList();
            ViewData["students"] = std;
            var subj = _db.Subject.ToList();
            ViewData["subjects"] = subj;
            var faculty = _db.Faculty.ToList();
            ViewData["faculties"] = faculty;
            return View(getGrade);
        }
    }
}
