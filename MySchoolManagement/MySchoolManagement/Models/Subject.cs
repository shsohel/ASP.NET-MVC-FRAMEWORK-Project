using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolManagement.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public virtual ICollection<Mclass> Mclasses { get; set; }




        //public virtual ICollection<Teacher> Teachers { get; set; }

        //public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }

    }
}