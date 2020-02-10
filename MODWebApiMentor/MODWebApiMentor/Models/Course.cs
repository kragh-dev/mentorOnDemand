using System;
using System.Collections.Generic;

namespace MODWebApiMentor.Models
{
    public partial class Course
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public long SkillId { get; set; }
        public string SkillName { get; set; }
        public long MentorId { get; set; }
        public string MentorName { get; set; }
        public int MentorYearsOfExp { get; set; }
        public double Fees { get; set; }
        public double CommissionAmount { get; set; }
        public int Rating { get; set; }
        public bool Approved { get; set; }
        public int Duration { get; set; }
    }
}
