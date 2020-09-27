using System;
using System.Collections.Generic;

namespace TeachersrRecordsManagementSystem.Models.Data.TrmsContext
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            Teachers = new HashSet<Teachers>();
        }

        public int MaritalId { get; set; }
        public string MaritalStatusName { get; set; }

        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
