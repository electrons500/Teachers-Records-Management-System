using System;
using System.Collections.Generic;

namespace TeachersrRecordsManagementSystem.Models.Data.TrmsContext
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string Surname { get; set; }
        public string Othername { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
