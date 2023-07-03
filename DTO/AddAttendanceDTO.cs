namespace SchoolApp.DTO
{
    public class AddAttendanceDTO
    {
        public List<string?> Studentid { get; set; }
        public List<string?> AttendanceStatus { get; set; }
        public DateTime? ForDate { get; set; }
    }
}
