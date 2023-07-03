namespace SchoolApp.DTO
{
    public class FeesSearchDTO
    {
        public int RollNo { get; set; } 
        public int? ClassId { get; set; }
        public int? MonthId { get; set; }
        public int? Year { get; set; }
        public string? SectionName { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public bool? Paid { get; set; }
    }
}
