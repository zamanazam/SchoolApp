using SchoolApp.Entities;

namespace SchoolApp.Entities_Force
{
    public partial class StudentResults
    {
        public int Id { get; set; }
        public DateTime? UploadOn { get; set; }
        public DateTime? ModifiedOn { get; set;}
        public int? UploadBy { get; set;}
        public int? ModifiedBy { get; set; }
        public int? SectionId { get; set; }
        public int? BatchYear { get; set; } 
        public int? MonthId { get; set; } 
        public int? StudentId { get; set; }
        public int? Score { get; set; }
        public int? Total { get; set;}
        public virtual User? UploadByNavigation { get; set; }
        public virtual User? ModifiedByNavigation { get; set; }
        public virtual User? Student { get; set; }
        public virtual SectionName? Section { get; set; }
        public virtual Month? OnMonth { get;}

    }
}
