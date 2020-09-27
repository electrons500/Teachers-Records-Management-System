using System;
using System.Collections.Generic;

namespace TeachersrRecordsManagementSystem.Models.Data.TrmsContext
{
    public partial class Gender
    {
        public Gender()
        {
            Teachers = new HashSet<Teachers>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
