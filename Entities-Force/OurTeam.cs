using SchoolApp.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolApp.Entities_Force
{
    public class OurTeam
    {
        public int Id { get; set; }
        public DateTime? UploadOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public int? UploadBy { get; set; }
        public int? Teacherid { get; set; }
        public string? Text { get; set; }
        public string? Designation { get; set; }
        public virtual User? TeacherOurTeam { get; set; }
        public virtual User? ModifierOurTeam { get; set; }
        public virtual User? AddedOurTeam { get; set; }

    }
}
