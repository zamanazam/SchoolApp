using Microsoft.AspNetCore.Mvc;
using SchoolApp.DBServices.EducationSer;
using SchoolApp.DTO;
using SchoolApp.Entities_Force;
using SchoolApp.Repositories.MiddleRepository;
using SchoolApp.Repositories.NewFolder;
using SchoolApp.Repositories.OurTeamRepository;
using SchoolApp.Repositories.PrimaryRepository;
using SchoolApp.Repositories.SecondaryRepository;

namespace SchoolApp.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationServices _EducationSer;
        public EducationController(IEducationServices educationSer)
        {
            _EducationSer = educationSer;
        }
        public IActionResult PrimaryEducationView()
        {
            return View();
        }
        public IActionResult MiddleEducationView()
        {
            return View();
        }
        public IActionResult SecondaryEducationView()
        {
            return View();
        }
        public IActionResult VisionandMissionView()
        {
            return View();
        }
        public IActionResult OurTeamView()
        {
            return View();
        }
        public IActionResult GetPrimary()
        {
            List<PrimaryEducation> primary = _EducationSer.GetPrimary();
            return Json(primary);  
        }
        public IActionResult GetMiddle()
        {
            List<MiddleEducation> middles = _EducationSer.GetMiddle();   
                return Json(middles);
        }
        public IActionResult GetSecondary()
        {
            List<SecondaryEducation> secondary = _EducationSer.GetSecondary();   
                return Json(secondary);
        }
        public IActionResult GetOurTeam()
        {
            List<OurTeamDTO> ourTeams = _EducationSer.GetOurTeam();
                return Json(ourTeams);
        }
        [HttpPost]
        public IActionResult AddNewTeamMember([FromBody] AddOurTeamDTO team)
        {
           return Json(_EducationSer.AddNewTeamMember(team));
        }
        [HttpPost]
        public IActionResult DeleteTeamMemberbyId([FromBody] int id)
        {
            return Json(_EducationSer.RemoveOurTeamMemberbyId(id));
        }

        [HttpPost]
        public IActionResult UpdateOurTeambyId([FromBody]UpdateOurTeamDTO updateOurTeamDTO)
        {
            return Json(_EducationSer.UpdateOurTeambyId(updateOurTeamDTO));
        }

        [HttpPost]
        public IActionResult UpdatePrimaryEducation(UpdatePrimaryDTO primaryEducation)
        {
            return Json(_EducationSer.UpdatePrimaryEducation(primaryEducation));
        }

        [HttpPost]
        public IActionResult UpdateMiddleEducation(UpdateMiddleDTO middleEducation)
        {
            return Json(_EducationSer.UpdateMiddleEducation(middleEducation));
        }

        [HttpPost]
        public IActionResult UpdateSecondaryEducation(UpdateSecondaryDTO secondaryDTO)
        {
            return Json(_EducationSer.UpdateSecondaryEducation(secondaryDTO));
        }
        [HttpGet]
        public IActionResult GetNewTeachers()
        {
            return Json(_EducationSer.GetNewTeachers());
        }
      
    }
}
