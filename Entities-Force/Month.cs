using SchoolApp.Entities;

namespace SchoolApp.Entities_Force
{
    public class Month
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Fee> FeesForMonth { get; set; }
        public ICollection<StudentResults> ResultOnMonth { get; set; }
        public ICollection<PayRollDetail> PayForMonth { get; set; }
    }
}
