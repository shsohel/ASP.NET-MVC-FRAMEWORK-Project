using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MySchoolManagement.Models
{
    public class Teacher 
    {
        [Key]
        public int TeacherID { get; set; }

        [Display(Name =" Name")]
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage ="Name must between 3 to 30 Charecter!!!")]
        public string TeacherName { get; set; }

        [DataType(DataType.Date, ErrorMessage ="Must be inputed InternationAl Mail Type ")]
        public DateTime BirthofDate { get; set; }

       
        [Display(Name ="Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage ="Must be inputed Phone Number")]
        public string CellPhoneNo { get; set; }

        [Display(Name = "Confirm Cell Phone No")]
        [Compare("CellPhoneNo", ErrorMessage = "The Phone Number and confirmation Phone Number do not match.")]
        public string ConfirmPhoneNumber { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }      

        public string Address { get; set; }
     

        public string PicUrl { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual ICollection<Mclass> Mclasses { get; set; }
    }
}