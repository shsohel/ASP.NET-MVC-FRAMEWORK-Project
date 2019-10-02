using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySchoolManagement.Models;



using MySchoolManagement.ViewModels;
using AutoMapper;
using PagedList;
using System.Threading.Tasks;

namespace MySchoolManagement.Controllers
{
    public class SubjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subject
        //public ActionResult Index()
        //{
        //    return View(db.Subjects.ToList());
        //}

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            if (searchString != null)
            {
                page = 1;
            }
            else { searchString = currentFilter; }
            ViewBag.CurrentFilter = searchString;

            var trainees = from s in db.Subjects
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                trainees = trainees.Where(s => s.SubjectName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    trainees = trainees.OrderByDescending(s => s.SubjectName);
                    break;
                default:
                    trainees = trainees.OrderBy(s => s.SubjectName);
                    break;
            }

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(trainees.ToPagedList(pageNumber, pageSize));
        }


        // GET: Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(SubjectVM subjectVM)
        {
            if (ModelState.IsValid)
            {
                var trn = Mapper.Map<Subject>(subjectVM);
                db.Subjects.Add(trn);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subjectVM);
        }

        // GET: Subject/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subjectVM = new SubjectVM();
            {
                Subject subject = await db.Subjects.SingleOrDefaultAsync(c => c.SubjectID == id);

                if (subject == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                subjectVM.SubjectID = subject.SubjectID;
                subjectVM.SubjectName = subject.SubjectName;

            }
            return View(subjectVM);
        }


        // POST: Subject/Edit/5    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SubjectVM subjectVM)
        {
            if (ModelState.IsValid)
            {
                var trn = Mapper.Map<Subject>(subjectVM);
                db.Entry(trn).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subjectVM);
        }

        // GET: Subject/Delete/5
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subjectVM = new SubjectVM();
            {
                Subject subject = await db.Subjects.SingleOrDefaultAsync(c => c.SubjectID == id);

                if (subject == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                subjectVM.SubjectID = subject.SubjectID;
                subjectVM.SubjectName = subject.SubjectName;

            }
            return View(subjectVM);
        }





        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(int id)
        {
            var subjectVM = new SubjectVM();
            Subject subject = await db.Subjects.SingleOrDefaultAsync(c => c.SubjectID == id);
            db.Subjects.Remove(subject);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //Get: Details 
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subjectVM = new SubjectVM();
            {
                Subject subject = await db.Subjects.SingleOrDefaultAsync(c => c.SubjectID == id);

                if (subject == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                subjectVM.SubjectID = subject.SubjectID;
                subjectVM.SubjectName = subject.SubjectName;

            }
            return View(subjectVM);
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
