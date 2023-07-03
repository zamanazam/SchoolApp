using SchoolApp.DTO;
using SchoolApp.Entities;

namespace SchoolApp.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RoleName { get; set; }
        public string Image { get; set; }
        public int? RoleId { get; set; }


        public AuthenticateResponse(UserDTO user, string token)
        {
            Id = user.Id;
            UserName = user.Name;
            Password = user.Password;
            Email = user.Email;
            Token = token;
            RoleName = user.RoleName;
            RoleId = user.RoleId;
            Image = user.Image;
        }
    }
}
