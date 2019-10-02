using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySchoolManagement.Models;


namespace MySchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        //Create
        public ActionResult AddStudent()
        {
            ViewBag.MyClassID = new SelectList(db.Mclasses, "MyClassID", "MyClassName");


            return View();
        }

        //Save Data for Create 
        public ActionResult DataSava(Student student)
        {
            if (student.Address != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(student.ImageUpload.FileName);
                string extension = Path.GetExtension(student.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                student.PicUrl = fileName;
                student.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));
                db.Students.Add(student);
                db.SaveChanges();
            }
            var result = "Successfully Added";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: StudentsController2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.MyClassID = new SelectList(db.Mclasses, "MyClassID", "MyClassName", student.MyClassID);
            return View(student);
        }

        // POST: StudentsController2/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MyClassID = new SelectList(db.Mclasses, "MyClassID", "MyClassName", student.MyClassID);
            return View(student);
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: StudentsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: StudentsController2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
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