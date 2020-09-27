using System;
using System.Collections.Generic;

namespace TeachersrRecordsManagementSystem.Models.Data.TrmsContext
{
    public partial class Banks
    {
        public Banks()
        {
            Teachers = new HashSet<Teachers>();
        }

        public int BankId { get; set; }
        public string BankName { get; set; }

        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
