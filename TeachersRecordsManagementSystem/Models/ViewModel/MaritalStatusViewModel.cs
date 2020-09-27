using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersrRecordsManagementSystem.Models.ViewModel
{
    public class MaritalStatusViewModel
    {
        [Key]
        public int MaritalId { get; set; }
        public string MaritalStatusName { get; set; }
    }
}
