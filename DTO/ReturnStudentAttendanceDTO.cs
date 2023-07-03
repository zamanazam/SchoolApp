namespace SchoolApp.DTO
{
    public class ReturnStudentAttendanceDTO
    {
        public int AttendanceId { get; set; } 
        public string? StudentName { get; set; } 
        public string? AttendanceStatus { get; set; }
        public string? AddedBy { get; set; }
        public int? Studentid { get; set; }
        public DateTime? AddOn { get; set; } 
        public DateTime? ForDate { get; set; }  
        public int? ClassId { get; set; }
        public string? SectionName { get; set; }
    }
}
