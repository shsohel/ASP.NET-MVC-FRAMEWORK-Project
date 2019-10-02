using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using AutoMapper;


using MySchoolManagement.Models;
using MySchoolManagement.ViewModels;

namespace MySchoolManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Add New
            Mapper.Initialize(config =>
            {
                config.CreateMap<SubjectVM, Subject>();
                config.CreateMap<Subject, SubjectVM>();

            });

        }
    }
}
