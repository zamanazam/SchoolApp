using SchoolApp.Entities;

namespace SchoolApp.DTO
{
    public class PayReturnDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }

        public string? FatherName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Cnic { get; set; }
        public string? RoleName { get; set; }

        public string? Gender { get; set; }
        public int? MonthId { get; set; }
        public string? MonthName { get; set; }
        public int? BatchYear { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? Status { get; set; }
        public int? PayDecided { get; set; }
        public int? PayGivenAmount { get; set; }
        public string? GivenBy { get; set; }
        public DateTime? GivenOn { get; set; }
        public virtual Role? Roles { get; set; }
    }
}
