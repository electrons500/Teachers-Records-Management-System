using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersrRecordsManagementSystem.Models.ViewModel
{
    public class TitleViewModel
    {
        [Key]
        public int TitleId { get; set; }
        public string TitleName { get; set; }

    }
}
