using SchoolApp.Entities;

namespace SchoolApp.DTO
{
    public class UpdateVisionandMissionDTO
    {
        public int Id { get; set; }
        public string? VisionText { get; set; }
        public string? MissionText { get; set; }
        public string? OurPlanText { get; set; }
        public IFormFile? VisionImage { get; set; }
        public IFormFile? MissionImage { get; set; }
        public IFormFile? MainImage { get; set; }
    }
}
