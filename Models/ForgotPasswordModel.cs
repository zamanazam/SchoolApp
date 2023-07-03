using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class ForgotPasswordModel
    {
        [Keyless]
        public class ForgetPasswordModel
        {
            [Required, EmailAddress, Display(Name = "Register Email Address")]

            public string Email { get; set; }
            public bool EmailSent { get; set; }
        }
    }
}
