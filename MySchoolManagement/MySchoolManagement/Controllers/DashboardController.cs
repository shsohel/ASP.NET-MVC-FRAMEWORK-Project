using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using PagedList;


using MySchoolManagement.Models;
using System.Data.Entity;

namespace MySchoolManagement.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Dashboard
       
        [AllowAnonymous]
        public ActionResult Dashbord()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult examResult()
        {
            return View(db.Examresults.ToList());
        }

        public ActionResult studentExmaResult()
        {
            return View();
        }


        public ActionResult classSchedule()
        {
            return View(db.Mclasses.ToList());
        }


        public ActionResult ProjectOverView()
        {
            return View();
        }
    }
}