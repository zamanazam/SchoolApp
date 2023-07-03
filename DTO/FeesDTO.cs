using SchoolApp.Entities;

namespace SchoolApp.DTO
{
    public class FeesDTO
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }
        public string? StudentName { get; set; }
        public int? ClassId { get; set; }
        public int? SectionId { get; set; }
        public string? SectionName { get; set; }

        public int? FeesDecided { get; set; }

        public int? FeesGiven { get; set; }

        public bool? FeeStatus { get; set; }

        public int? CollectedBy { get; set; }
        public string? CollectedByName { get; set; }

        public DateTime? CollectedOn { get; set; }
        public string? Month { get; set; }
        public int? Year { get; set; }

        public int? ModifiedBy { get; set; }
        public int? ModifiedByName { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public User? Student { get; set; }
    }
}
