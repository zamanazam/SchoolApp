using Microsoft.AspNetCore.Mvc;
using SchoolApp.DBServices.AttendanceSer;
using SchoolApp.DTO;
using SchoolApp.Entities_Force;
using SchoolApp.Models;
using System.Diagnostics;

namespace SchoolApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAttendanceServices _attendServices;

        public HomeController(ILogger<HomeController> logger, IAttendanceServices attendServices)
        {
            _logger = logger;
            _attendServices = attendServices;
        }
        public IActionResult LogInPage()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AttendancePageView()
        {
            return View();
        }
        public IActionResult UpdateAttendancePageView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetStudentsAttendancebybatch(SearchStdAttendanceDTO searchStdAttendanceDTO)
        {
            return Json(_attendServices.GetStudentAttendancebyCourse(searchStdAttendanceDTO));
        }
        [HttpPost]
        public IActionResult AddAttendance(AddAttendanceDTO addAttendance)
        {
            return Json(_attendServices.AddAttendanceStudents(addAttendance));
        }
        [HttpPost]
        public IActionResult UpdateAttendance(Attendance attendance)
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentAttedanceQueryable(AddAttendanceDTO searchAttendance)
        {
            return Json(_attendServices.StudentAttendanceQueryAble(searchAttendance));
        }

        [HttpPost]
        public IActionResult TeacherAttendanceQueryable(AddAttendanceDTO searchAttendance)
        {
            return Json(_attendServices.TeacherAttendanceQueryable(searchAttendance));
        }
        [HttpPost]
        public IActionResult UpdateStudentAttendance(string AttendanceStatus, int AttendanceId)
        {
           return Json(_attendServices.UpdateStudentAttendance(AttendanceStatus, AttendanceId));
        }

        public IActionResult AddTeacherAttendance()
        {
            return View();
        }
        public IActionResult TeacherAttendancePageView()
        {
            return View();
        }
        public IActionResult StudentAttendancePageView()
        {
            return View();
        }
        public IActionResult UpdateStudentPageView()
        {
            return View();
        }
        public IActionResult GetTeachersAttendancebyDate(DateTime AttendanceDate)
        {
            return Json(_attendServices.GetTeacherAttendancebyDate(AttendanceDate));
        }
    }
}