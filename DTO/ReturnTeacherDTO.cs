using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.DTO
{
    public class ReturnTeacherDTO
    {
        public int Id { get; set; }
        public string? TeacherImage { get; set; }
        public string? TeacherName { get; set; }

        public string? FatherName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Cnic { get; set; }

        public string? Gender { get; set; }

        public int? Age { get; set; }
        public int? SailoryDecided { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public int? RoleId { get; set; }
        public string? Nationality { get; set; }
        public string? Password { get; set; }
        public string? PostalCode { get; set; }
        public string? Religion { get; set; }
        public bool? AccountStatus { get; set; }
        public List<TeacherExperience>? TeacherExperience { get; set; }
        public List<TeacherQualification>? TeacherQualification { get; set; }
        public Account? Account { get; set; }
    }
}
