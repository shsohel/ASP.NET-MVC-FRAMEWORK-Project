using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolManagement.Models
{
    public class Schedule
    {
        [Key]
        public int ClassScheduleID { get; set; }              
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }

        //public int SubjectID { get; set; }
        //public virtual Subject Subject { get; set; }

        //public int SectionID { get; set; }
        //public virtual Section Section { get; set; }
    }
}