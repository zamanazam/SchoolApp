using SchoolApp.Entities;

namespace SchoolApp.DTO
{
    public class UpdateSecondaryDTO
    {
        public int Id { get; set; }
        public IFormFile? MainImage { get; set; }
        public string? MainText { get; set; }
        public string? SecondaryTextHeading { get; set; }
        public string? Text { get; set; }
        public IFormFile? SecondaryImage { get; set; }
    }
}
