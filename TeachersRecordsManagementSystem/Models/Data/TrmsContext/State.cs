using System;
using System.Collections.Generic;

namespace TeachersrRecordsManagementSystem.Models.Data.TrmsContext
{
    public partial class State
    {
        public State()
        {
            Teachers = new HashSet<Teachers>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
