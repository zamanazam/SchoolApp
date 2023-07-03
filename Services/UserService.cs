using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Helpers;
using SchoolApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolApp.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        int GetUserId();
    }

    public class UserService : IUserService
    {
        private readonly SchoolDbContext _dbContext;
        private readonly AppSettings _appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IOptions<AppSettings> appSettings, SchoolDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;

        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _dbContext.Users.Where(x=>x.Email == model.Email && x.Password == model.Password).Select(x => new UserDTO()
            {
                Name = x.Name,
                Image = x.Image,
                Id = x.Id,
                FatherName = x.FatherName,
                Email = x.Email,
                Password = x.Password,
                Status = x.Status,
                RoleId = x.UserRoles.Select(v => v.RoleId).First(),
                Age = x.Age,
                RoleName = x.UserRoles.Select(g => g.Role.RolesName).First(),
            }).FirstOrDefault();

            if (user == null) return null;

            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }
        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }
        public int GetUserId()
        {
            return (_httpContextAccessor.HttpContext.Items["User"] as User).Id;
        }
        private string generateJwtToken(UserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            var token = new JwtSecurityToken
            (
                claims: new List<Claim>()
                { new Claim("Id", user.Id.ToString()),
                  new Claim("UserName", user.Name),
                  new Claim("Email", user.Email),
                  new Claim("RoleId", ((user.RoleId ==null)? "null" : user.RoleId.ToString())),
                  new Claim("RoleName", ((user.RoleName== null)? "null" : user.RoleName)),
                },

                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            ) ;
            return tokenHandler.WriteToken(token);

        }
    }
}
