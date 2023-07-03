using Microsoft.AspNetCore.Mvc;
using SchoolApp.DBServices.EducationSer;
using SchoolApp.DBServices.VisionMissionSer;
using SchoolApp.DTO;
using SchoolApp.Entities_Force;

namespace SchoolApp.Controllers
{
    public class VisionandMissionController : Controller
    {
        private readonly IEducationServices _EducationSer;
        private readonly IVisionandMissionServices _visionandMissionSer;
        public VisionandMissionController(IEducationServices educationSer, IVisionandMissionServices visionandMissionSer)
        {
            _EducationSer = educationSer;
            _visionandMissionSer = visionandMissionSer;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VisionandMission()
        {
            List<VisionandMission> visionandMissions = _EducationSer.GetVisionandMission();
            return Json(visionandMissions);
        }
        public IActionResult VisionandMissionView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateVisionMission(UpdateVisionandMissionDTO visionandMissionDTO)
        {
           return Json( _visionandMissionSer.UpdateVisionandMissionbyId(visionandMissionDTO));
        }
    }
}
