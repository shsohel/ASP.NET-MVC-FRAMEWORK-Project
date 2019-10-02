using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySchoolManagement.Models;

namespace MySchoolManagement.ViewModels
{
    public class SubjectVM
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public virtual ICollection<Mclass> Mclasses { get; set; }
    }
}