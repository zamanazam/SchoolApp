namespace SchoolApp.DTO
{
    public class SearchStudentDTO
    {
        public int RollNo { get; set; }
        public int? ClassId { get; set; }
        public int? MonthId { get; set; }
        public int? Year { get; set; }
        public string? SectionName { get; set; }
    }
}
