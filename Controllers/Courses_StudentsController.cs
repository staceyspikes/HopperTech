using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HopperTech.Models;

namespace HopperTech.Controllers
{
    public class Courses_StudentsController : Controller
    {
        private HopperTechContext db = new HopperTechContext();

        // GET: Courses_Students
        public ActionResult Index()
        {
            var course_Student = db.Course_Student.Include(c => c.Course).Include(c => c.Student);
            return View(course_Student.ToList());
        }

        // GET: Courses_Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Student course_Student = db.Course_Student.Find(id);
            if (course_Student == null)
            {
                return HttpNotFound();
            }
            return View(course_Student);
        }

        // GET: Courses_Students/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name");
            return View();
        }

        // POST: Courses_Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,CourseID")] Course_Student course_Student)
        {
            if (ModelState.IsValid)
            {
                db.Course_Student.Add(course_Student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", course_Student.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", course_Student.StudentID);
            return View(course_Student);
        }

        // GET: Courses_Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Student course_Student = db.Course_Student.Find(id);
            if (course_Student == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", course_Student.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", course_Student.StudentID);
            return View(course_Student);
        }

        // POST: Courses_Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,CourseID")] Course_Student course_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Title", course_Student.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", course_Student.StudentID);
            return View(course_Student);
        }

        // GET: Courses_Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Student course_Student = db.Course_Student.Find(id);
            if (course_Student == null)
            {
                return HttpNotFound();
            }
            return View(course_Student);
        }

        // POST: Courses_Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Student course_Student = db.Course_Student.Find(id);
            db.Course_Student.Remove(course_Student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
