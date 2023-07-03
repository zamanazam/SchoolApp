using SchoolApp.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolApp.Entities_Force
{
    public partial class PrimaryEducation
    {
        public int Id { get; set; }
        public DateTime? UploadOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string? MainImage { get; set; }
        public string? MainText { get; set; }
        public string? PrimaryTextHeading { get; set; }   
        public string? Text { get; set; }   
        public string? PrimaryImage { get; set; }
        public virtual User? Modifier { get; set; }

    }
}
