using SchoolApp.Entities;

namespace SchoolApp.DTO
{
    public class StudentResultsDTO
    {
        public int Id { get; set; }
        public DateTime? UploadOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? UploadBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? SectionId { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public string? StudentName { get; set; }
        public int? ClassId { get; set; }
        public int? BatchYear { get; set; }
        public string? Month { get; set; }
        public string? SectionName { get;set; }
        public string? SubjectName { get; set; }    
        public int? Score { get; set; }
        public int? Total { get; set; }
        public virtual User? UploadByNavigation { get; set; }
        public virtual User? ModifiedByNavigation { get; set; }
        public virtual User? Student { get; set; }
        public virtual SectionName? Section { get; set; }
    }
}
