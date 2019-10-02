using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using UniqueAttribute.Attribute;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchoolManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int MyClassID { get; set; }
        public virtual Mclass Mclass { get; set; }

       
        public int RoleNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthofDate { get; set; }
        public string CellPhoneNo { get; set; }
        public string Address { get; set; }

        
        public string PicUrl { get; set; }

        public virtual ICollection<Examresult> Examresults { get; set; }


        [NotMapped]    
        public HttpPostedFileBase ImageUpload { get; set; }
   
    }
}