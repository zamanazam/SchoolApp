using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolApp.DBServices.UserSer;
using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Services;
using static SchoolApp.Constants.Program;

namespace SchoolApp.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly SchoolDbContext _dbContext;
        private readonly IUserService _currentUserService;

        public UserRepository(SchoolDbContext dbContext,IUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }
        public int AddUser(User user, int Roleid)
        {
            _dbContext.Users.Add(user);
            UserSaveChanges();  
            UserRole userRole = new();
            userRole.UserId = user.Id;
            userRole.RoleId = Roleid;
            userRole.CreatedOn = DateTime.Now;
            userRole.CreatedBy = _currentUserService.GetUserId();
            _dbContext.UserRoles.Add(userRole);
            UserSaveChanges();
            return user.Id;
        }

        public void UserSaveChanges()
        {
           _dbContext.SaveChanges();
        }
        public List<Role> GetAllRoles()
        {
            return _dbContext.Roles.ToList();
        }
        public List<UserDTO> GetAllUsers()
        {
             return _dbContext.Users.Select(c => new UserDTO()
            {
                Id = c.Id,
                Parent = c.Parent,
                Name = c.Name,
                FatherName = c.Name,
                Email = c.Email,
                Address = c.Address,
                Phone = c.Phone,
                Age = c.Age,
                Gender = c.Gender,
                Cnic = c.Cnic,
                CreatedOn = c.CreatedOn,
                Image = c.Image,
                Status =c.Status,
                City = c.City,
                Nationality = c.Nationality,
                PostalCode = c.PostalCode,
                Roles = c.UserRoles.Where(v => v.UserId == c.Id).Select(v => v.Role).FirstOrDefault(),

            }).ToList();
        }
        public List<UserDTO> GetUsersbyName(string UserName)
        {
           return _dbContext.Users.Where(x=>x.Name.Contains(UserName)).Select(c=> new UserDTO()
            {
                Id = c.Id,
                Parent = c.Parent,
                Name =c.Name,
                FatherName = c.Name,
                Email = c.Email,
                Address = c.Address,
                Phone = c.Phone,
                Age = c.Age,
                Gender = c.Gender,
                Cnic = c.Cnic,
                CreatedOn = c.CreatedOn,
                Image = c.Image,
                Status = c.Status,
                City = c.City,
                Nationality = c.Nationality,
                PostalCode =c.PostalCode,
                Roles = c.UserRoles.Where(v=>v.UserId == c.Id).Select(v=>v.Role).FirstOrDefault(),
                
            }).ToList();
        }
        public UserDTO BlockUserbyId(int id)
        {
            User user = _dbContext.Users.Where(x=>x.Id == id).FirstOrDefault();
            user.Status = false;
            _dbContext.Users.Update(user);
            UserSaveChanges();
            return _dbContext.Users.Where(x => x.Id == id).Select(c => new UserDTO()
            {
                Id = c.Id,
                Parent = c.Parent,
                Name = c.Name,
                FatherName = c.Name,
                Email = c.Email,
                Address = c.Address,
                Phone = c.Phone,
                Age = c.Age,
                Gender = c.Gender,
                Cnic = c.Cnic,
                CreatedOn = c.CreatedOn,
                Image = c.Image,
                Status = c.Status,
                City = c.City,
                Nationality = c.Nationality,
                PostalCode = c.PostalCode,
                Roles = c.UserRoles.Where(v => v.UserId == c.Id).Select(v => v.Role).FirstOrDefault(),

            }).First();
        }
        public UserDTO GetUserbyId(int Id)
        {
            return _dbContext.Users.Where(x => x.Id == Id).Select(c => new UserDTO()
            {
                Id = c.Id,
                Parent = c.Parent,
                Name = c.Name,
                SectionName = c.StudentCourses.Select(h=>h.Section.Name).First(),
                ClassId = c.StudentCourses.Select(g=>g.Section.ClassId).First(),
                FatherName = c.Name,
                Email = c.Email,
                Address = c.Address,
                Phone = c.Phone,
                Password = c.Password,
                Religion = c.Religion,
                Age = c.Age,
                Gender = c.Gender,
                Cnic = c.Cnic,
                CreatedOn = c.CreatedOn,
                Image = c.Image,
                Status = c.Status,
                City = c.City,
                Nationality = c.Nationality,
                PostalCode = c.PostalCode,
                Roles = c.UserRoles.Where(v => v.UserId == c.Id).Select(v => v.Role).FirstOrDefault(),
                FeesDecided = c.FeeUsers.Select(g=>g.FeesDecided).FirstOrDefault(),

            }).First();
        }
        
        public List<User> GetTeacherORStaffbyUserId(int UserId)
        {
            return _dbContext.Users.Where(x => x.Id == UserId).Include(a => a.AccountEmployes).ThenInclude(a => a.PayRollDetails).Include(y => y.TeacherExperienceses)
                                                                                    .Include(t => t.TeacherQualificationses).ToList();
        }
        public User UserbyId(int Id)
        {
            return _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
        }
        public User UserbyEmailPassword(string Email,string Password)
        {
            return _dbContext.Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
        }
        public void UpdateUserbyId(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }
        public List<User> GetStudentbyClassandSection(int ClassId, string SectionName, int MonthId,int BatchYear)
        {
            var Data = _dbContext.Users.Where(x => x.StudentCourses.Any(y => y.Section.Name == SectionName) && x.StudentCourses.Any(g => g.Section.ClassId == ClassId) 
                                                                                                && x.StudentCourses.Any(j=>j.BatchYear == BatchYear )&& 
                                            (x.StudentResults.Any(c => MonthId != c.MonthId) || !_dbContext.StudentResults.Any(s=>s.StudentId == x.Id))).ToList();
            var result = Data.DistinctBy(x => x.Id).ToList();
            return result;
        }

        public List<User> GetNewTeachers()
        {
            var data = _dbContext.OurTeam.Select(x=>x.Teacherid).ToList();
            var newteachers = _dbContext.Users.Where(x => !data.Contains(x.Id) &&
                                ((x.UserRoles.Any(y => y.RoleId == (int)EnumRoles.Teacher)) || x.UserRoles.Any(g=>g.RoleId == (int)EnumRoles.Admin))).ToList();
            return newteachers;
        }

        public List<User> AutocompleteStudetnFunction(string StudentName)
        {
            return _dbContext.Users.Where(x => x.Name.Contains(StudentName) && x.UserRoles.Any(y => y.RoleId == (int)EnumRoles.Student)).ToList();
        }

        public List<User> AutocompleteTeacherFunction(string TeacherName)
        {
            return _dbContext.Users.Where(x => x.Name.Contains(TeacherName) &&( x.UserRoles.Any(y => y.RoleId == (int)EnumRoles.Teacher) ||
                                    x.UserRoles.Any(g=>g.RoleId == (int)EnumRoles.Sweaper)|| x.UserRoles.Any(k=>k.RoleId == (int)EnumRoles.Peon ))).ToList();
        }
        public List<User> GetStudentbyCondition(SearchStudentDTO studentDTO)
        {
            IQueryable<User> Users = _dbContext.Users.AsQueryable<User>();
            if (studentDTO.RollNo != 0)
            {
                Users = Users.Where(x => x.Id == studentDTO.RollNo);
            }
            if (studentDTO.Year != 0)
            {
                Users = Users.Where(x => x.FeeUsers.Any(y => y.Year == studentDTO.Year));
            }
            if (studentDTO.ClassId != 0)
            {
                Users = Users.Where(x => x.StudentCourses.Any(y => y.Section.ClassId == studentDTO.ClassId));
            }
            if (studentDTO.SectionName != null)
            {
                Users = Users.Where(x => x.StudentCourses.Any(y => y.Section.Name == studentDTO.SectionName));
            }
            if (studentDTO.MonthId != 0)
            {
                Users = Users.Where(x => x.FeeUsers.Any(y => y.MonthId == studentDTO.MonthId));
            }
            return Users.Include(g=>g.StudentCourses).ThenInclude(g=>g.Section).Include(f=>f.FeeUsers).ToList();
        }
        public List<User> GetStaffbyStaffId(int StaffId, int? MonthId, int? BatchYear)
        {
            IQueryable<User> Users = _dbContext.Users.AsQueryable<User>();
            if(StaffId != 0)
            {
              Users = Users.Where(x => x.AccountEmployes.Any(e=>e.EmployeId == StaffId));
              //  Users = Users.Where(x => x.AccountEmployes.Any(y => y.PayRollDetails.Any(g => g.AccountId == y.Id)));
            }
            if(MonthId != null)
            {
                Users = Users.Where(x=>x.AccountEmployes.Any(y=>y.PayRollDetails.Any(g=>g.Monthid == MonthId)));
            }
            if(BatchYear != null)
            {
                Users = Users.Where(x => x.AccountEmployes.Any(y => y.PayRollDetails.Any(k => k.Year == BatchYear)));
            }
            return Users.Include(g => g.AccountEmployes).ThenInclude(k => k.PayRollDetails).ThenInclude(l=>l.ForMonth).ToList();
        }
    }
}
