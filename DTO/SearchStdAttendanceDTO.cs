using Microsoft.VisualBasic;

namespace SchoolApp.DTO
{
    public class SearchStdAttendanceDTO
    {
        public int? ClassId { get; set; }
        public string? SectionName { get; set; }
        public int? Year { get; set; }
        public DateTime? AttendDate { get; set; }
    }
}
