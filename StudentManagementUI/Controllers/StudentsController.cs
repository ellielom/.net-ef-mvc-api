using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBModel;
using StudentManagementUI.Models;

namespace StudentManagementUI.Controllers
{
    public class StudentsController : Controller
    {
        //private StudentDBModelContainer db = new StudentDBModelContainer();
        //private StudentRepoEF sr = new StudentRepoEF();
        //private StudentRepoJson sr = new StudentRepoJson();

        private IStudentRepo sr; 

        public StudentsController(IStudentRepo isr)
        {
            sr = isr;
        }

        public StudentsController()
        {
            sr = new StudentRepoEF();
        }

        // GET: Students
        public ActionResult Index()
        {
            //return View(db.Students.ToList());
            //return View(sr.GetStudents());
            return View("Index", sr.GetStudents());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);

            // converted because our method here accepts a null but our repo method doesn't 
            Student student = sr.GetStudent(Convert.ToInt32(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Students.Add(student);
                //db.SaveChanges();

                sr.Add(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);

            Student student = sr.GetStudent(Convert.ToInt32(id));

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(student).State = EntityState.Modified;
                //db.SaveChanges();

                sr.Edit(student);

                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = sr.GetStudent(Convert.ToInt32(id));
            

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Student student = db.Students.Find(id);
            //db.Students.Remove(student);
            //db.SaveChanges();

            sr.Delete(Convert.ToInt32(id));

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                sr.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
