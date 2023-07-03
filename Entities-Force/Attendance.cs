﻿using SchoolApp.Entities;

namespace SchoolApp.Entities_Force
{
    public class Attendance
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? AddedBy { get; set; }
        public string? AttendanceStatus { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? attendancedate { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual User? User { get; set; }
        public virtual User? AddedByNavigation { get; set; }
        public virtual User? ModifiedByNavigation { get; set; }
    }
}
