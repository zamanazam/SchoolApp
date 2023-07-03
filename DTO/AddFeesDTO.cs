namespace SchoolApp.DTO
{
    public class AddFeesDTO
    {
        public int StudentId { get; set; }  
        public int? MonthId { get; set; }   
        public int? Year { get; set;}
        public int? FeesGiven { get; set; } 
    }
}
