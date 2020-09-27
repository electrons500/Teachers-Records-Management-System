using System;
using System.Collections.Generic;

namespace TeachersrRecordsManagementSystem.Models.Data.TrmsContext
{
    public partial class Title
    {
        public Title()
        {
            Teachers = new HashSet<Teachers>();
        }

        public int TitleId { get; set; }
        public string TitleName { get; set; }

        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
