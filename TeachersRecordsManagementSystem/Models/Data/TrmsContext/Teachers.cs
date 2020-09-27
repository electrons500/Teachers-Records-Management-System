using System;
using System.Collections.Generic;

namespace TeachersrRecordsManagementSystem.Models.Data.TrmsContext
{
    public partial class Teachers
    {
        public int TeacherId { get; set; }
        public int TitleId { get; set; }
        public string Surname { get; set; }
        public string Othernames { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public string Hometown { get; set; }
        public string Contact { get; set; }
        public int MaritalId { get; set; }
        public string AcademicQualification { get; set; }
        public string ProfessionalQualification { get; set; }
        public string StaffId { get; set; }
        public string RegisteredNumber { get; set; }
        public string Ssfno { get; set; }
        public int BankId { get; set; }
        public string AccountName { get; set; }
        public DateTime FirstAppointmentDate { get; set; }
        public int StateId { get; set; }
        public string ImageName { get; set; }

        public virtual Banks Bank { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual MaritalStatus Marital { get; set; }
        public virtual State State { get; set; }
        public virtual Title Title { get; set; }
    }
}
