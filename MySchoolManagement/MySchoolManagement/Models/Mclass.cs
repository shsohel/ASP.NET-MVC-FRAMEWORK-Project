using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolManagement.Models
{
    public class Mclass
    {
        [Key]
        public int MyClassID { get; set; }

        [Required]
        [Display(Name ="Class Name")]
        public string MyClassName { get; set; }

        [Required]
        [Display(Name ="Subject")]
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }

        [Required]
        [Display(Name = "Section")]
        public int SectionID { get; set; }       
        public virtual Section Section { get; set; }

        [Required]
        [Display(Name = "Teacher")]
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}