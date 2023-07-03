namespace SchoolApp.DTO
{
    public class UpdateMiddleDTO
    {
        public int Id { get; set; }
        public IFormFile? MainImage { get; set; }
        public string? MainText { get; set; }
        public string? MiddleTextHeading { get; set; }
        public string? Text { get; set; }
        public IFormFile? MiddleImage { get; set; }
    }
}
