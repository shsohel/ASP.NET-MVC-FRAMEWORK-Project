using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolManagement.Models
{
    public class Examresult
    {
        [Key]
        public int ExamresultID { get; set; }

        [Required]
        [Display(Name ="Exam Type")]
        public string ExamType { get; set; }

        [Required]
        [Display(Name ="Student Name")]
        public int StudentID { get; set; }
        public virtual Student Student {get; set;}

        [Display(Name = " Bangla")]
        public int MarkInBangla { get; set; }

        [Display(Name = "English")]
        public int MarkInEnglish { get; set; }

        [Display(Name = "Math")]
        public int MarkInMath { get; set; }

        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int TotalMarks
        {
            get
            {
                return MarkInBangla + MarkInEnglish+ MarkInMath;
            }
        }


    }
}