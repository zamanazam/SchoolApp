using SchoolApp.Entities;

namespace SchoolApp.Entities_Force
{
    public class TeacherExperience
    {
        public int Id { get; set; }
        public string? Designation { get; set; }
        public string? Institution { get; set; }
        public string? Duration { get; set; }
        public DateTime? UploadOn { get; set; }
        public int? TeacherId { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual User? TeacherExperiences { get; set; }
        public virtual User? ModifiedByNavigation { get; set; }
    }
}
