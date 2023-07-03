using Microsoft.AspNetCore.Mvc;
using SchoolApp.DBServices.FeesSer;
using SchoolApp.DTO;

namespace SchoolApp.Controllers
{
    public class FeesController : Controller
    {
        private readonly IFeesServices _feesService;
        public FeesController(IFeesServices feesService)
        {
            _feesService = feesService;
        }
        public IActionResult GetViewForFees()
        {
            return View();
        }
        [SchoolApp.Helpers.Authorize]
        public IActionResult GetFeesData() 
        {
            bool? Paid = true;
            return Json(_feesService.GetAllFeesCurrentMonth(Paid));
        }
        [SchoolApp.Helpers.Authorize]
        [HttpPost]
        public IActionResult GetFeesDatabyConditions(FeesSearchDTO feesSearch) 
        {
            return Json(_feesService.GetAllFeebyConditions(feesSearch));
        }
        public IActionResult GetAllMonthsName()
        {
            return Json(_feesService.GetAllMonths());
        }
        public IActionResult AddFeesView() 
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult AddFeesbyRollNo(AddFeesDTO addFees)
        {
            return Json(_feesService.AddFessbyRollNo(addFees));
        }
        public IActionResult AddPayRollView()
        {
            return View();
        }

        public IActionResult PayRollView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetPayRollQueryable(SearchPayDTO payDTO)
        {
            if(payDTO.StaffId == null)
            {
                return View();
            }
            return Json(_feesService.GetPayRollDetailsQueryable(payDTO));
        }
        [HttpPost]
        public IActionResult AddPayRollbyStaffId(AddPayDTO payDTO)
        {
            var data = _feesService.AddPayRoll(payDTO);
            if (data != 0)
            {
                return Json(data);  
            }
            return View();
        }
    }
}
