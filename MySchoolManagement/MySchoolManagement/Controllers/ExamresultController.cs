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
    public class ExamresultController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Examresult
        public ActionResult Index()
        {
            var examresults = db.Examresults.Include(e => e.Student);
            return View(examresults.ToList());
        }

        // GET: Examresult/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examresult examresult = db.Examresults.Find(id);
            if (examresult == null)
            {
                return HttpNotFound();
            }
            return View(examresult);
        }

        // GET: Examresult/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName");
            return View();
        }

        // POST: Examresult/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Examresult examresult)
        {
            if (ModelState.IsValid)
            {
                db.Examresults.Add(examresult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", examresult.StudentID);
            return View(examresult);
        }

        // GET: Examresult/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examresult examresult = db.Examresults.Find(id);
            if (examresult == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", examresult.StudentID);
            return View(examresult);
        }

        // POST: Examresult/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Examresult examresult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examresult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", examresult.StudentID);
            return View(examresult);
        }

        // GET: Examresult/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examresult examresult = db.Examresults.Find(id);
            if (examresult == null)
            {
                return HttpNotFound();
            }
            return View(examresult);
        }

        // POST: Examresult/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examresult examresult = db.Examresults.Find(id);
            db.Examresults.Remove(examresult);
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
