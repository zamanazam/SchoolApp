namespace SchoolApp.DTO
{
    public class AddTeacherDTO
    {
        public int TeacherId { get; set; }  
        public IFormFile? TeacherImage { get; set; }
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
        public string? AccountNumber { get; set; } 
        public string? BankName { get; set; }
        public string? BankAccountStatus { get; set; }
        public bool? AccountStatus { get; set; }

        public List<string> ExpPosition { get; set; }    
        public List<string> ExpInstitutionName { get; set; }    
        public List<string> ExpDuration { get; set; }    
        public List<string> DegreeName { get; set; }    
        public List<string> InstitutionName { get; set; }
        public List<string> PassingYear { get; set; }
        

    }
}
