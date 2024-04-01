using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManagement.Context;
using SchoolManagement.Models;
using System.Linq;

namespace SchoolManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var data = _context.Course.Where(course => !course.deleted).ToList();
            return View(data);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var data = _context.Course.FirstOrDefault(c => c.Id == id);
            return View(data);
        }

        // GET: CourseController/Create
        public IActionResult Create()
        {

           return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Courses courses)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _context.Course.Add(courses);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _context.Course.FirstOrDefault(c => c.Id == id);
            return View(data);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Courses courses)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _context.Course.Update(courses);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var data = _context.Course.FirstOrDefault(c => c.Id == id);
                if (data != null)
                {
                    data.deleted = true;
                    _context.Course.Update(data);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CourseController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, Courses courses)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var data = _context.Course.FirstOrDefault(c => c.Id == id);
        //            if (data != null)
        //            {
        //                data.deleted = true;
        //                _context.Course.Update(data);
        //                _context.SaveChanges();
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
