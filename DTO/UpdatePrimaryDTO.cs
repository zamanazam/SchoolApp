using SchoolApp.Entities;

namespace SchoolApp.DTO
{
    public class UpdatePrimaryDTO
    {
        public int Id { get; set; }
        public IFormFile? MainImage { get; set; }
        public string? MainText { get; set; }
        public string? PrimaryTextHeading { get; set; }
        public string? Text { get; set; }
        public IFormFile? PrimaryImage { get; set; }
    }
}
