using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersrRecordsManagementSystem.Models.ViewModel
{
    public class TeachersViewModel
    {
        [Key]
        public int TeacherId { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Please select the required field")]
        public int TitleId { get; set; }
        [NotMapped]
        public SelectList TitleList { get; set; }
        [NotMapped]      
        public string TitleName { get; set; }

        [Required(ErrorMessage = "Please enter the required field")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter the required field")]
        public string Othernames { get; set; }

        [DisplayName("Name")]
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Please select the required field")]
        public int GenderId { get; set; }
        [NotMapped]
        public SelectList GenderList { get; set; }
        [NotMapped]
        public string GenderName { get; set; }

        [Required(ErrorMessage = "Please enter the required field")]
        public string Hometown { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter the required field")]
        public string Contact { get; set; }

        [DisplayName("Marital Status")]
        [Required(ErrorMessage = "Please enter the required field")]
        public int MaritalId { get; set; }
        [NotMapped]
        public SelectList MaritalList { get; set; }
        [NotMapped]
        public string MaritalStatusName { get; set; }

        [DisplayName("Academic Qualification")]
        [Required(ErrorMessage = "Please enter the required field")]
        public string AcademicQualification { get; set; }
        [DisplayName("Professional Qualification")]
        [Required(ErrorMessage = "Please enter the required field")]
        public string ProfessionalQualification { get; set; }
        [DisplayName("Staff ID No.")]
        [Required(ErrorMessage = "Please enter the required field")]
        public string StaffId { get; set; }
        [DisplayName("Registered Number")]
        [Required(ErrorMessage = "Please enter the required field")]
        public string RegisteredNumber { get; set; }
        [Required(ErrorMessage = "Please enter the required field")]
        public string Ssfno { get; set; }

        [DisplayName("Bank")]
        [Required(ErrorMessage = "Please enter the required field")]
        public int BankId { get; set; }
        [NotMapped]
        public SelectList BankList { get; set; }
        [NotMapped]
        public string BankName { get; set; }
        [DisplayName("Account Number")]
        [Required(ErrorMessage = "Please enter the required field")]
        public string AccountName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("First Appointment")]
        public DateTime FirstAppointmentDate { get; set; }

        [DisplayName("Current status")]
          [Required(ErrorMessage ="Please enter the required field")]
        public int StateId { get; set; }
        [NotMapped]
        public SelectList StateList { get; set; }
        [NotMapped]
        public string StateName { get; set; }


      
       
        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile TeacherImage { get; set; }
        

      

    }
}
