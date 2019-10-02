using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySchoolManagement.Models;

namespace MySchoolManagement.Controllers
{
    public class MclassController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mclass
        public ActionResult Index()
        {
            var mclasses = db.Mclasses.Include(m => m.Section).Include(m => m.Subject).Include(m => m.Teacher);
            return View(mclasses.ToList());
        }

        // GET: Mclass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mclass mclass = db.Mclasses.Find(id);
            if (mclass == null)
            {
                return HttpNotFound();
            }
            return View(mclass);
        }

        // GET: Mclass/Create
        public ActionResult Create()
        {
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "ShiftName");
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName");
            return View();
        }

        // POST: Mclass/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MyClassID,MyClassName,SubjectID,SectionID,TeacherID")] Mclass mclass)
        {
            if (ModelState.IsValid)
            {
                db.Mclasses.Add(mclass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "ShiftName", mclass.SectionID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", mclass.SubjectID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", mclass.TeacherID);
            return View(mclass);
        }

        // GET: Mclass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mclass mclass = db.Mclasses.Find(id);
            if (mclass == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "ShiftName", mclass.SectionID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", mclass.SubjectID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", mclass.TeacherID);
            return View(mclass);
        }

        // POST: Mclass/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Mclass mclass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mclass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "ShiftName", mclass.SectionID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", mclass.SubjectID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", mclass.TeacherID);
            return View(mclass);
        }

        // GET: Mclass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mclass mclass = db.Mclasses.Find(id);
            if (mclass == null)
            {
                return HttpNotFound();
            }
            return View(mclass);
        }

        // POST: Mclass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mclass mclass = db.Mclasses.Find(id);
            db.Mclasses.Remove(mclass);
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
