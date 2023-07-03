using SchoolApp.Entities;

namespace SchoolApp.Entities_Force
{
    public class VisionandMission
    {
        public int Id { get; set; }
        public DateTime? UploadOn { get; set; }
        public DateTime? ModifiedOn { get; set; }  
        public int? ModifiedBy { get; set; }
        public string? VisionText { get; set; }
        public string? MissionText { get; set; }
        public string? OurPlanText { get; set; }
        public string? VisionImage { get; set; }
        public string? MissionImage { get; set; }
        public string? MainImage { get; set; }
        public virtual User? ModifierVisionandMission { get; set; }

    }
}
