namespace SchoolApp.DTO
{
    public class AddUserDTO
    {
        public int id { get; set; }
        public IFormFile? SudentImage { get; set; }
        public string? StudentName { get; set; }
        public bool? AccountStatus { get; set; }    
        public string? FatherName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Cnic { get; set; }

        public string? Gender { get; set; }

        public int? Age { get; set; }

        public string? Address { get; set; }

        public string? ClassName { get; set; }
        public string? SectionName { get; set; }

        public string? City { get; set; }

        public string? Nationality { get; set; }

        public bool? AliveStatus { get; set; }

        public string? Password { get; set; }

        public string? PostalCode { get; set; }
        public string? Religion { get; set; }

        public string? PName { get; set; }

        public string? PFatherName { get; set; }

        public string? PEmail { get; set; }

        public string? PPhone { get; set; }

        public string? PCnic { get; set; }

        public string? PGender { get; set; }
        public string? PRelation { get; set; }
        public int? RoleId { get; set; }
        public int? FeeDecided { get; set; }
    }
}
