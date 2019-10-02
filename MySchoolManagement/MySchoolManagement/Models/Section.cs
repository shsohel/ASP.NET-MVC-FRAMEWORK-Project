using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolManagement.Models
{
    public class Section 
    {
        [Key]
        public int SectionID { get; set; }
        public string ShiftName { get; set; }
        public string Time { get; set; }
      
        public virtual ICollection<Mclass> Mclasses { get; set; }




        //public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
    }
}