using SchoolApp.Entities;

namespace SchoolApp.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? ClassId { get; set; }
        public string? SectionName { get; set; }
        public string? RoleName { get; set; }
        public string? Name { get; set; }

        public string? FatherName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Cnic { get; set; }

        public string? Gender { get; set; }

        public int? Age { get; set; }
        public int? MonthId { get; set; }
        public string? MonthName { get; set; }
        public int? BatchYear { get; set; }
        public string? Address { get; set; }

        public string? Image { get; set; }

        public string? City { get; set; }

        public string? Nationality { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? Status { get; set; }

        public string? Password { get; set; }

        public string? PostalCode { get; set; }

        public string? Otp { get; set; }

        public string? SecretKey { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? Religion { get; set; }

        public int? ParentId { get; set; }
        public int? FeesDecided { get; set; }
        public int? LastGivenAmount { get; set; }
        public DateTime? LastOn { get; set; }
        public virtual Parent? Parent { get; set; }
        public virtual Role? Roles { get; set; }


    }
}
