using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersrRecordsManagementSystem.Models.ViewModel
{
    public class BankViewModel
    {
        [Key]
        [DisplayName("S/No")]
        public int BankId { get; set; }
        [DisplayName("Bank name")]
        [Required(ErrorMessage ="Please enter the required field")]
        public string BankName { get; set; }
    }
}
