using SchoolApp.Entities;

namespace SchoolApp.Entities_Force
{
    public class SubjectsName
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? AddedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual User? AddedByNavigation { get; set; }
        public virtual User? ModifiedByNavigation { get; set; }
        public virtual ICollection<SectionName> Sections { get; set; }    
    }
}
