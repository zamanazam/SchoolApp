using SchoolApp.Entities;

namespace SchoolApp.Entities_Force
{
    public class StudentCourse
    {
        public int Id { get; set; } 
        public int? StudentId { get; set;}
        public int? SectionId { get; set; }
        public int? AddedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? BatchYear { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual User? AddedByNavigation { get; set; }
        public virtual User? ModifiedByNavigation { get; set; }
        public virtual User? Student { get; set; }
        public virtual SectionName? Section { get; set; }
    }
}
