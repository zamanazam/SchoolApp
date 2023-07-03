using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;
using SchoolApp.Models;
using SchoolApp.Repositories.ExperienceRepository;
using SchoolApp.Repositories.FeesRepository;
using SchoolApp.Repositories.NewFolder;
using SchoolApp.Repositories.QualificationRepository;
using SchoolApp.Repositories.SectionRepository;
using SchoolApp.Repositories.StudentCourseRepository;
using SchoolApp.Repositories.UserRepository;
using SchoolApp.Services;
using System.Linq;
using System.Numerics;
using static SchoolApp.Constants.Program;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolApp.DBServices.UserSer
{
    public class UserSerices : IUserServices
    {
        private readonly IUserService _currentUserService;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IQualificationRepository _QualificationRepository;
        private readonly IExperienceRepository _ExperienceRepository;
        private readonly IAccountRepository _AccountRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly IFeeRepository _feeRepository;
        public UserSerices(IUserRepository userRepository, IWebHostEnvironment hostingEnvironment, IQualificationRepository qualificationRepository, 
                                IExperienceRepository experienceRepository, IAccountRepository accountRepository, ISectionRepository sectionRepository,
                                IStudentCourseRepository studentCourseRepositroy, IUserService currentUserService, IFeeRepository feeRepository)
        {
            _userRepository = userRepository;
            _hostingEnvironment = hostingEnvironment;
            _QualificationRepository = qualificationRepository;
            _ExperienceRepository = experienceRepository;
            _AccountRepository = accountRepository;
            _sectionRepository = sectionRepository;
            _studentCourseRepository = studentCourseRepositroy;
            _currentUserService = currentUserService;
            _feeRepository = feeRepository;
        }

        public int CreateStudent(AddUserDTO userDTO ,int ParentId)
        {
            var OldUser = _userRepository.UserbyEmailPassword(userDTO.Password, userDTO.Email);
            if(OldUser != null)
            {
                return 0;
            }
            User user = new();
            user.Name = userDTO.StudentName;
            user.Email = userDTO.Email;
            user.Phone = userDTO.Phone;
            user.Address = userDTO.Address;
            user.City = userDTO.City;
            user.Cnic = userDTO.Cnic;
            user.Age = userDTO.Age;
            user.Status = true;
            user.Nationality = userDTO.Nationality;
            user.ParentId = ParentId;
            user.PostalCode = userDTO.PostalCode;
            user.Religion = userDTO.Religion;
            user.Gender = userDTO.Gender;
            user.CreatedOn = DateTime.Now;
            user.FatherName = userDTO.FatherName;
            user.Password = userDTO.Password;
            string imagespaths = "";
            if (userDTO.SudentImage != null)
            {
                string filepath = Path.GetFileName(userDTO.SudentImage.FileName);
                imagespaths = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + imagespaths, FileMode.Create);
                {
                    userDTO.SudentImage.CopyTo(stream);
                    stream.Dispose();
                }
            }
            user.Image = imagespaths;
            int StudentId = _userRepository.AddUser(user,(int)EnumRoles.Student);
            Fee fee = new Fee();
            fee.FeesGiven = userDTO.FeeDecided;
            fee.FeesDecided = userDTO.FeeDecided;
            fee.FeeStatus = true;
            fee.UserId = StudentId;
            fee.CollectedOn = DateTime.Now;
            fee.CollectedBy = _currentUserService.GetUserId();
            _feeRepository.AddFeebyStudentId(fee);
            var SectionId = GetCourse(Convert.ToInt32(userDTO.ClassName), userDTO.SectionName);
            _studentCourseRepository.AddStudentCourse(SectionId, StudentId);
            return ParentId;
        }

        public int UpdateStudent(UpdateStudentDTO userDTO)
        {
            User user = _userRepository.UserbyId(userDTO.id);
                user.Name = userDTO.StudentName;
                user.Email = userDTO.Email;
                user.Phone = userDTO.Phone;
                user.Address = userDTO.Address;
                user.City = userDTO.City;
                user.Cnic = userDTO.Cnic;
                user.Age = userDTO.Age;
                user.Status = userDTO.AccountStatus;
                user.Nationality = userDTO.Nationality;
                user.ParentId = userDTO.Pid;
                user.PostalCode = userDTO.PostalCode;
                user.Religion = userDTO.Religion;
                user.Gender = userDTO.Gender;
                user.CreatedOn = DateTime.Now;
                user.FatherName = userDTO.FatherName;
                user.Password = userDTO.Password;
                user.Image = user.Image;
                string imagespaths = "";
                if (userDTO.SudentImage != null)
                {
                    string filepath = Path.GetFileName(userDTO.SudentImage.FileName);
                    imagespaths = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                    string currentDirectory = _hostingEnvironment.WebRootPath;
                    EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                    using FileStream stream = new FileStream(currentDirectory + imagespaths, FileMode.Create);
                    {
                        userDTO.SudentImage.CopyTo(stream);
                        stream.Dispose();
                    }
                    user.Image = imagespaths;
                }
                user.CreatedOn = user.CreatedOn;
                user.ModifiedOn = DateTime.Now;
                Fee fee = _feeRepository.GetFeesbyStudentId(user.Id);
                fee.ModifiedOn = DateTime.Now;
                fee.ModifiedBy = _currentUserService.GetUserId();
                fee.FeesDecided = userDTO.NewFeesDecided;
                _feeRepository.UpdateFeebyId(fee);
                _userRepository.UpdateUserbyId(user);
                var SectionId = GetCourse(Convert.ToInt32(userDTO.ClassName), userDTO.SectionName);
                return _studentCourseRepository.UpdateStudentCourse(SectionId, userDTO.id);          
        }

        public int UpdateTeacher(AddTeacherDTO teacherDTO)
        {
            User Teacher = _userRepository.UserbyId(teacherDTO.TeacherId);
            Teacher.Name = teacherDTO.TeacherName;
            Teacher.FatherName = teacherDTO.FatherName;
            Teacher.Cnic = teacherDTO.Cnic;
            Teacher.Email = teacherDTO.Email;
            Teacher.Gender = teacherDTO.Gender;
            Teacher.Religion = teacherDTO.Religion;
            Teacher.Age = teacherDTO.Age;
            Teacher.Address = Teacher.Address;
            Teacher.PostalCode = teacherDTO.PostalCode;
            Teacher.CreatedOn = Teacher.CreatedOn;
            Teacher.City = teacherDTO.City;
            Teacher.Nationality = teacherDTO.Nationality;
            Teacher.Id = teacherDTO.TeacherId;
            Teacher.Status = teacherDTO.AccountStatus;
            Teacher.Image = Teacher.Image;
            string imagespaths = "";
            if (teacherDTO.TeacherImage != null) 
            {
                string filepath = Path.GetFileName(teacherDTO.TeacherImage.FileName);
                imagespaths = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + imagespaths, FileMode.Create);
                {
                    teacherDTO.TeacherImage.CopyTo(stream);
                    stream.Dispose();
                }
                Teacher.Image = imagespaths;
            }
            Teacher.ModifiedOn = DateTime.Now;
            Teacher.Password = teacherDTO.Password;
            Teacher.Phone = teacherDTO.Phone;
            _userRepository.UpdateUserbyId(Teacher);
            var OldExperience=_ExperienceRepository.GetTeacherExperiencebyId(Teacher.Id);
            if (OldExperience != null)
            {
                _ExperienceRepository.RemoveTeacherExperience(OldExperience);
                if (teacherDTO.ExpPosition.Count > 0)
                {
                     AddExperience(teacherDTO, teacherDTO.TeacherId);
                }
            }
            var OldQualification = _QualificationRepository.GetQualificationbyId(teacherDTO.TeacherId);
            if (OldQualification != null)
            {
                _QualificationRepository.RemoveQualifications(OldQualification);
                if(teacherDTO.DegreeName.Count > 0)
                {
                    AddQualification(teacherDTO, teacherDTO.TeacherId);
                }
            }

            Account account = _AccountRepository.GetAccountbyId(teacherDTO.TeacherId);
            if (account != null)
            {
                account.AccountNumber = teacherDTO.AccountNumber;
                account.AccountStatus = teacherDTO.AccountStatus;
                account.BankName = teacherDTO.BankName;
                account.CreatedOn = account.CreatedOn;
                account.CreatedBy = account.CreatedBy;
                account.ModifiedOn = DateTime.Now;
                account.ModifiedBy = _currentUserService.GetUserId(); 
            }

            PayRollDetail payRoll = _feeRepository.GetPayRollDetailbyAccountId(account.Id);
            if (payRoll != null)
            {
                payRoll.PayRollDecided = teacherDTO.SailoryDecided;
                payRoll.ModifiedOn = DateTime.Now;
                payRoll.ModifiedBy = _currentUserService.GetUserId();
                _feeRepository.UpdatePayRoll(payRoll);
            }
           return _AccountRepository.UpdateAccount(account);
        }

        public List<int> GetCourse(int Classid, string SectionName)
        {
            return _sectionRepository.GetSectionId(Classid, SectionName);
        }

        public int CreateTeacher(AddTeacherDTO addTeacher)
        {
            var OldUser = _userRepository.UserbyEmailPassword(addTeacher.Password, addTeacher.Email);
            if (OldUser != null)
            {
                return 0;
            }
            User user = new();
            user.Name = addTeacher.TeacherName;
            user.Email = addTeacher.Email;
            user.Phone = addTeacher.Phone;
            user.Address = addTeacher.Address;
            user.City = addTeacher.City;
            user.Nationality = addTeacher.Nationality;
            user.PostalCode = addTeacher.PostalCode;
            user.Religion = addTeacher.Religion;
            user.Cnic = addTeacher.Cnic;
            user.Age = addTeacher.Age;
            user.Gender = addTeacher.Gender;
            user.CreatedOn = DateTime.Now;
            user.FatherName = addTeacher.FatherName;
            user.Password = addTeacher.Password;
            string imagespaths = "";
            if (addTeacher.TeacherImage != null)
            {
                string filepath = Path.GetFileName(addTeacher.TeacherImage.FileName);
                imagespaths = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + imagespaths, FileMode.Create);
                {
                    addTeacher.TeacherImage.CopyTo(stream);
                    stream.Dispose();
                }
            }
            user.Image = imagespaths;
            _userRepository.AddUser(user, (int)EnumRoles.Teacher);
            int TeacherId = user.Id;
            if (addTeacher.DegreeName.Count > 0)
                AddQualification(addTeacher, TeacherId);

            if (addTeacher.ExpPosition.Count > 0)
                AddExperience(addTeacher, TeacherId);

            int AccountId = 0;
            if (addTeacher.AccountNumber != null)
                 AccountId =  AddAccount(addTeacher, TeacherId);
            
            PayRollDetail payRoll = new();
            if (addTeacher.SailoryDecided != null)
            {
                payRoll.PayRollDecided = addTeacher.SailoryDecided;
                payRoll.AccountId = AccountId;
                payRoll.GivenOn = DateTime.Now;
                payRoll.GivenBy = _currentUserService.GetUserId();
                payRoll.NewPayRoll = addTeacher.SailoryDecided;
                payRoll.PayRollStatus = false;
                payRoll.PayRollGiven = addTeacher.SailoryDecided;
                var Payrrollid = -_feeRepository.AddPayRoll(payRoll);
            }

            return TeacherId;
        }
        public int CreateOtherStaff(AddTeacherDTO addTeacher)
        {
            var OldUser = _userRepository.UserbyEmailPassword(addTeacher.Password, addTeacher.Email);
            if (OldUser != null)
            {
                return 0;
            }
            User user = new();
            user.Name = addTeacher.TeacherName;
            user.Email = addTeacher.Email;
            user.Phone = addTeacher.Phone;
            user.Address = addTeacher.Address;
            user.City = addTeacher.City;
            user.Age = addTeacher.Age;
            user.Cnic = addTeacher.Cnic;
            user.Nationality = addTeacher.Nationality;
            user.PostalCode = addTeacher.PostalCode;
            user.Religion = addTeacher.Religion;
            user.Gender = addTeacher.Gender;
            user.CreatedOn = DateTime.Now;
            user.FatherName = addTeacher.FatherName;
            user.Password = addTeacher.Password;
            string imagespaths = "";
            if (addTeacher.TeacherImage != null)
            {
                string filepath = Path.GetFileName(addTeacher.TeacherImage.FileName);
                imagespaths = Path.Combine(Directory.GetCurrentDirectory(), "\\images", filepath);
                string currentDirectory = _hostingEnvironment.WebRootPath;
                EnsureFolder(Path.Combine(currentDirectory, "\\images" ?? "Common"));
                using FileStream stream = new FileStream(currentDirectory + imagespaths, FileMode.Create);
                {
                    addTeacher.TeacherImage.CopyTo(stream);
                    stream.Dispose();
                }
            }
            user.Image = imagespaths;
            if(addTeacher.RoleId == 4)
                _userRepository.AddUser(user, (int)EnumRoles.Peon);
            
            if(addTeacher.RoleId == 5)
                 _userRepository.AddUser(user, (int)EnumRoles.Sweaper);
            
            int StaffId = user.Id;
            if (addTeacher.DegreeName.Count > 0)
                AddQualification(addTeacher, StaffId);

            if (addTeacher.ExpPosition.Count > 0)
                AddExperience(addTeacher, StaffId);

            int AccountId = 0;
            if (addTeacher.AccountNumber != null)
                    AccountId = AddAccount(addTeacher, StaffId);

            PayRollDetail payRoll = new();
            if (addTeacher.SailoryDecided != null)
            {
                payRoll.PayRollDecided = addTeacher.SailoryDecided;
                payRoll.AccountId = AccountId;
                payRoll.GivenOn = DateTime.Now;
                payRoll.GivenBy = _currentUserService.GetUserId();
                payRoll.NewPayRoll = addTeacher.SailoryDecided;
                payRoll.PayRollStatus = false;
                payRoll.PayRollGiven = addTeacher.SailoryDecided;
                var Payrrollid = -_feeRepository.AddPayRoll(payRoll);
            }
            return StaffId;
        }
        public int AddAccount(AddTeacherDTO addTeacher, int TeacherId)
        {
            Account account = new();
            account.AccountNumber = addTeacher.AccountNumber;
            if (addTeacher.AccountStatus != null)
                account.AccountStatus = true;
            account.BankName = addTeacher.BankName;
            account.CreatedOn = DateTime.Now;
            account.EmployeId = TeacherId;
            account.CreatedBy = _currentUserService.GetUserId();
           return _AccountRepository.AddAccount(account);
        }
        public void AddQualification(AddTeacherDTO addTeacher, int TeacherId)
        {
            for (int i = 0; i < addTeacher.DegreeName.Count; i++)
            {
                TeacherQualification qualification = new();
                qualification.DegreeName = addTeacher.DegreeName.ElementAtOrDefault(i);
                qualification.Institute = addTeacher.InstitutionName[i];
                qualification.PassingYear = addTeacher.PassingYear[i];
                qualification.TeacherId = TeacherId;
                qualification.UploadOn = DateTime.Now;
                _QualificationRepository.AddQualfication(qualification);
            }
        }
        public void AddExperience(AddTeacherDTO addTeacher, int TeacherId)
        {
            for (int i = 0; i < addTeacher.ExpPosition.Count; i++)
            {
                TeacherExperience experiences = new();
                experiences.Designation = addTeacher.ExpPosition[i];
                experiences.Institution = addTeacher.ExpInstitutionName[i];
                experiences.Duration = addTeacher.ExpDuration[i];
                experiences.TeacherId = TeacherId;
                experiences.UploadOn = DateTime.Now;
                _ExperienceRepository.AddExperience(experiences);
            }
        }
        private void EnsureFolder(string path)
        {
            var exists = Directory.Exists(path);
            if (!exists)
                Directory.CreateDirectory(path);
        }
        public List<Role> GetAllRoles()
        {
            var data = _userRepository.GetAllRoles();
            List<Role> roles = new List<Role>();
            for(int i =0; i <data.Count; i++)
            {
                if (data[i].Id == 4 || data[i].Id == 5)
                    roles.Add(data[i]);
            }
            return roles;
        }
        public List<UserDTO> GetAllUsers(string UserName)
        {
            if(UserName != null)
            {
                return _userRepository.GetUsersbyName(UserName);
            }
            return _userRepository.GetAllUsers();
        }

        public UserDTO BlockUserbyId(int id)
        {
            return _userRepository.BlockUserbyId(id);
        }
        public UserDTO GetUserbyId(int Id)
        {
            return _userRepository.GetUserbyId(Id);
        }
        public ReturnTeacherDTO GetTeacherbyId(int Id)
        {
            var data = _userRepository.GetTeacherORStaffbyUserId(Id);
            return data.Select(x => new ReturnTeacherDTO()
            {
                Account = x.AccountEmployes.FirstOrDefault(),
                TeacherExperience = x.TeacherExperienceses.ToList(),
                TeacherQualification = x.TeacherQualificationses.ToList(),
                TeacherName = x.Name,
                FatherName = x.FatherName,
                Email = x.Email,
                Phone = x.Phone,
                Address = x.Address,
                Id = x.Id,
                Cnic = x.Cnic,
                Age = x.Age,
                Gender = x.Gender,
                Religion = x.Religion,
                PostalCode = x.PostalCode,
                City = x.City,
                Nationality = x.Nationality,
                Password = x.Password,
                TeacherImage = x.Image,
                AccountStatus = x.AccountEmployes.Select(y => y.AccountStatus).FirstOrDefault(),
                SailoryDecided = x.AccountEmployes.Select(g => g.PayRollDetails.OrderByDescending(m => m.GivenOn).Select(k => k.PayRollDecided).LastOrDefault()).LastOrDefault(),
                
            }).FirstOrDefault();
            //var Teacher = _userRepository.GetUserbyId(Id);
            //var TeacherExperience = _ExperienceRepository.GetTeacherExperiencebyId(Teacher.Id);
            //var Qualification = _QualificationRepository.GetQualificationbyId(Teacher.Id);
            //var TeacherAccount = _AccountRepository.GetAccountbyId(Teacher.Id);
            //return (new ReturnTeacherDTO()
            //{
            //    Account = TeacherAccount,
            //    TeacherQualification = Qualification,
            //    TeacherExperience = TeacherExperience,
            //    TeacherName = Teacher.Name,
            //    FatherName = Teacher.FatherName,
            //    Email = Teacher.Email,
            //    Phone = Teacher.Phone,
            //    Address = Teacher.Address,
            //    Id = Teacher.Id,
            //    Cnic = Teacher.Cnic,
            //    Age = Teacher.Age,
            //    Gender = Teacher.Gender,
            //    Religion = Teacher.Religion,
            //    PostalCode = Teacher.PostalCode,
            //    City = Teacher.City,
            //    Nationality = Teacher.Nationality,
            //    Password = Teacher.Password,
            //    TeacherImage = Teacher.Image,
            //    AccountStatus = Teacher.Status,
            //});
        }
        public StudentSubjectsDTO GetStudentbyClassandSectionName(int ClassId, string SectionName, int MonthId, int BatchYear)
        {
            StudentSubjectsDTO studentSubjectsDTO = new();
            studentSubjectsDTO.Students = _userRepository.GetStudentbyClassandSection(ClassId, SectionName, MonthId, BatchYear);
            var subjectdata = _studentCourseRepository.GetSubjectbyClassandSectionName(ClassId, SectionName);
            studentSubjectsDTO.SubjectsNames = subjectdata.DistinctBy(x=>x.Id).ToList();
            return studentSubjectsDTO;
        }   
       public List<AutocompleteStudentDTO> AutocompleteStudetnFunction(string StudentName)
       {
            var data = _userRepository.AutocompleteStudetnFunction(StudentName);
            return data.Select(x => new AutocompleteStudentDTO()
            {
                Id = x.Id,
                StudentName = x.Name,
            }).ToList();
       }

        public List<AutocompleteStudentDTO> AutocompleteTeacherFunction(string TeacherName)
        {
            var data = _userRepository.AutocompleteTeacherFunction(TeacherName);
            return data.Select(x => new AutocompleteStudentDTO()
            {
                Id = x.Id,
                StudentName = x.Name,
            }).ToList();
        }
        public List<UserDTO> GetStudentbyCondition(SearchStudentDTO searchStudent)
        {
            var data= _userRepository.GetStudentbyCondition(searchStudent);
            return data.Select(x => new UserDTO()
            {
                Id = x.Id,
                Name = x.Name,
                FatherName = x.FatherName,
                Email = x.Email,
                Age = x.Age,
                Phone = x.Phone,
                Image = x.Image,
                ClassId = x.StudentCourses.Select(g => g.Section.ClassId).FirstOrDefault(),
                SectionName = x.StudentCourses.Select(h => h.Section.Name).FirstOrDefault(),
                FeesDecided = x.FeeUsers.Select(f => f.FeesDecided).FirstOrDefault(),
                LastOn = x.FeeUsers.Select(g=>g.CollectedOn).LastOrDefault(),
                LastGivenAmount = x.FeeUsers.Select(g=>g.FeesGiven).LastOrDefault()
            }).ToList();
        }

        public List<UserDTO> GetStaffbyStaffId(int StaffId, int? MonthId, int? BatchYear)
        {
            var data = _userRepository.GetStaffbyStaffId(StaffId, MonthId,BatchYear);
            return data.Select(x => new UserDTO()
            {
                Id = x.Id,
                Name = x.Name,
                FatherName = x.FatherName,
                Email = x.Email,
                Age = x.Age,
                Phone = x.Phone,
                Image = x.Image,
                MonthName = x.AccountEmployes.Where(l => l.EmployeId == x.Id).Select(y => y.PayRollDetails.OrderByDescending(m => m.Id).Select(m => m.ForMonth.Name).LastOrDefault()).SingleOrDefault(),
                MonthId = x.AccountEmployes.Where(l => l.EmployeId == x.Id).Select(y => y.PayRollDetails.OrderByDescending(m => m.Id).Select(m => m.Monthid).LastOrDefault()).SingleOrDefault(),
                BatchYear = x.AccountEmployes.Where(l => l.EmployeId == x.Id).Select(y => y.PayRollDetails.OrderByDescending(m => m.Id).Select(m => m.Year).LastOrDefault()).SingleOrDefault(),
                FeesDecided = x.AccountEmployes.Where(l => l.EmployeId == x.Id).Select(y => y.PayRollDetails.OrderByDescending(m => m.Id).Select(m => m.NewPayRoll).LastOrDefault()).SingleOrDefault(),
                LastOn = x.AccountEmployes.Where(l => l.EmployeId == x.Id).Select(y => y.PayRollDetails.OrderByDescending(m => m.Id).Select(m => m.GivenOn).LastOrDefault()).SingleOrDefault(),
                LastGivenAmount = x.AccountEmployes.Where(l => l.EmployeId == x.Id).Select(y => y.PayRollDetails.OrderByDescending(m => m.Id).Select(m => m.PayRollGiven).LastOrDefault()).SingleOrDefault()
            }).ToList();
        }
    }
}
