using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.DBServices.ClassSer;
using SchoolApp.DBServices.ParentSer;
using SchoolApp.DBServices.SectionSer;
using SchoolApp.DBServices.StudentResultSer;
using SchoolApp.DBServices.UserSer;
using SchoolApp.DTO;

namespace SchoolApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IParentServices _parentServices;
        private readonly IClassServices _classServices;
        private readonly ISectionServices _sectionServices;
        private readonly IStudentResultsServices _studentResultService;

        public AdminController (ISectionServices sectionServices,IClassServices classServices,IUserServices userServices, 
                                            IParentServices parentServices,IStudentResultsServices studentResultServices)
        {
            _classServices = classServices;
            _userServices = userServices;
            _parentServices = parentServices;
            _sectionServices = sectionServices;
            _studentResultService = studentResultServices;
        }
        public IActionResult AddUserPage()
        {
            return View();
        }
        public IActionResult AllUsersData()
        {
            return View();
        }

        public IActionResult EditUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(AddUserDTO userDTO)
        {
            int ParentId = CreateParent(userDTO);
            return Json (_userServices.CreateStudent(userDTO, ParentId));
        }
       
        public int CreateParent(AddUserDTO userDTO)
        {
            return _parentServices.CreateParent(userDTO);
        }
        [HttpGet]
        public IActionResult GetClassSectionsData()
        {
            ReturnClassSection data = new();
            data.Class = _classServices.GetAllClasses();
            data.Sections = _sectionServices.GetSections();
            return Json(data);
        }
        [HttpPost]
        public int CreateTeacher(AddTeacherDTO addTeacher)
        {
           return _userServices.CreateTeacher(addTeacher);
        }
        [HttpPost]
        public int CreateOtherStaff(AddTeacherDTO addTeacher)
        {
           return _userServices.CreateTeacher(addTeacher);
        }
        public IActionResult GetAllRoles()
        {
           return  Json(_userServices.GetAllRoles());
        }
        public IActionResult GetAllUsers(string UserName)
        {
           return Json(_userServices.GetAllUsers(UserName));  
        }

        public IActionResult BlockUserbyId(int id)
        {
            return Json(_userServices.BlockUserbyId(id));
        }
        public IActionResult GetUserbyId(int id)
        {
            return Json(_userServices.GetUserbyId(id));
        }
        public IActionResult GetTeacherbyId(int id)
        {
            var data = _userServices.GetTeacherbyId(id);
            return Json(data);
        }
        public IActionResult UpdateStudent(UpdateStudentDTO userDTO)
        {
            _parentServices.UpdateParent(userDTO);
            return Json(_userServices.UpdateStudent(userDTO));
        }
        public IActionResult UpdateTeacher(AddTeacherDTO teacherDTO) 
        {
            return Json(_userServices.UpdateTeacher(teacherDTO));
        }
        public IActionResult CheckResultPage()
        {
            return View();
        }
        public IActionResult AddNewResultPage()
        {
            return View();
        }
        public IActionResult AllResult(int ClassId)
        {
            var data = _studentResultService.GetAllResults(ClassId);
            var result = data.GroupBy(x => x.StudentId).ToList();
            return Json(result);
        }

        public IActionResult LastUpdatedResult()
        {
            var data = _studentResultService.LastUpdatedResult();
            var result = data.GroupBy(c => new { c.UploadOn.Value.Hour, c.StudentId }).ToList();
            return Json(result);
        }

        public IActionResult GetResultbyStudentId(int studentId)
        {
            var data =_studentResultService.GetResultbyStudentId(studentId);
            var result = data.GroupBy(c=>c.UploadOn.Value.Hour).ToList();
            return Json(result);
        }

        public IActionResult GetSectionNames(int ClassId)
        {
            return Json(_sectionServices.GetSectionsbyClassId(ClassId));
        }

        public IActionResult FilterStudentResult(int ClassId, string SectionName)
        {
            var data = _studentResultService.FilterStudentResult(ClassId, SectionName);
            var result = data.GroupBy(c=> new {c.UploadOn.Value.Hour , c.StudentId}).ToList();
            return Json(result);
        }
        public IActionResult GetStudentsSubjects(int ClassId, string SectionName, int MonthId, int BatchYear)
        {
            return Json(_userServices.GetStudentbyClassandSectionName(ClassId, SectionName, MonthId, BatchYear));
        }
        [HttpPost]
        public IActionResult AddResultbyStudentId(AddResultDTO addResult)
        {
          return Json(_studentResultService.AddResultbyStudentId(addResult));
        }
    }
   
}
