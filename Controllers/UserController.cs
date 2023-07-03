using Microsoft.AspNetCore.Mvc;
using SchoolApp.DBServices.UserSer;
using SchoolApp.DTO;
using SchoolApp.Models;
using SchoolApp.Services;

namespace SchoolApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _currentUser;
        private readonly IUserServices _userService;
        public UserController(IUserService currentUser,IUserServices userServices)
        {
            _currentUser = currentUser;
            _userService = userServices;
        }
        [HttpPost]
        public IActionResult LogIn(AuthenticateRequest model)
        {
            var response = _currentUser.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);
        }
        public IActionResult AutocompleteStudetnFunction(string StudentName)
        {
            var result=_userService.AutocompleteStudetnFunction(StudentName);
            return Json(result);
        }

        public IActionResult AutocompleteTeacherFunction(string TeacherName)
        {
            var result = _userService.AutocompleteTeacherFunction(TeacherName);
            return Json(result);
        }
        [HttpPost]
        public IActionResult GetStudentbyConditions(SearchStudentDTO searchStudent)
        {
           return Json(_userService.GetStudentbyCondition(searchStudent));
        }
        [HttpPost]
        public IActionResult GetTeacherbyConditions(SearchStudentDTO searchTeacherDTO)
        {
            return Json(_userService.GetStaffbyStaffId(searchTeacherDTO.RollNo, searchTeacherDTO.MonthId,searchTeacherDTO.Year));
        }
    }
}
