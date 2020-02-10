using System;
using System.Collections.Generic;

namespace MODWebApiMentor.Models
{
    public partial class Training
    {
        public long Id { get; set; }
        public bool Completed { get; set; }
        public int Progress { get; set; }
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public long SkillId { get; set; }
        public string SkillName { get; set; }
        public long MentorId { get; set; }
        public string MentorName { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public bool Approved { get; set; }
        public bool Rejected { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool PartOne { get; set; }
        public bool PartTwo { get; set; }
        public bool PartThree { get; set; }
        public bool PartFour { get; set; }
        public int Rating { get; set; }
        public bool PaymentStatus { get; set; }
        public long? PaymentId { get; set; }
        public double? AmountPaid { get; set; }
        public double Fees { get; set; }
        public double CommissionAmount { get; set; }
    }
}
