namespace SchoolApp.DTO
{
    public class AddResultDTO
    {
        public List<int> SubjectId { get; set; }
        public List<int> SubjectScore { get; set; }
        public List<int> TotalScore { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int MonthId { get; set; }
        public int Year { get; set; }
        public string SectionName { get; set; }
    }
}
