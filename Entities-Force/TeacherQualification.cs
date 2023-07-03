using SchoolApp.Entities;

namespace SchoolApp.Entities_Force
{
    public class TeacherQualification
    {
        public int Id { get; set; }
        public string? DegreeName { get; set; }
        public string? Institute { get; set; }
        public string? PassingYear { get; set; }
        public DateTime? UploadOn { get; set; }
        public int? TeacherId { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual User? TeacherQualifications { get; set; }
        public virtual User? ModifiedByNavigation { get; set; }

    }
}
