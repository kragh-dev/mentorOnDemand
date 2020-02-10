using System;
using System.Collections.Generic;

namespace MODWebApiMentor.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long ContactNumber { get; set; }
        public string RegCode { get; set; }
        public string Role { get; set; }
        public string LinkedinUrl { get; set; }
        public int YearsOfExperience { get; set; }
        public bool Active { get; set; }
        public bool Reject { get; set; }
        public string Comments { get; set; }
    }
}
