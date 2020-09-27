using System;
using System.Collections.Generic;

namespace TeachersrRecordsManagementSystem.Models.Data.TrmsContext
{
    public partial class Photo
    {
        public Photo()
        {
            Teachers = new HashSet<Teachers>();
        }

        public int ImageId { get; set; }
        public byte[] TeacherImage { get; set; }

        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
