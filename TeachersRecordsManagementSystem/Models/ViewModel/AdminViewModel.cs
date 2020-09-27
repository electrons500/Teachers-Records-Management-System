using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersrRecordsManagementSystem.Models.ViewModel
{
    public class AdminViewModel
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Please enter the required field")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter the required field")]
        public string Othername { get; set; }
        [Required(ErrorMessage = "Please enter the required field")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Please enter the required field")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
    }
}
