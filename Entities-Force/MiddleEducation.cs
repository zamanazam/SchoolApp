using SchoolApp.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolApp.Entities_Force
{
    public class MiddleEducation
    {
        public int Id { get; set; }
        public DateTime? UploadOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string? MainImage { get; set; }
        public string? MainText { get; set; }
        public string? MiddleTextHeading { get; set; }
        public string? Text { get; set; }
        public string? MiddleImage { get; set; }
        public virtual User? Modifier { get; set; }

    }
}
