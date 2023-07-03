using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SchoolApp.DBServices.SectionSer;
using SchoolApp.DBServices.StudentCourseSer;
using SchoolApp.DBServices.UserSer;
using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;
using SchoolApp.Repositories.FeesRepository;
using SchoolApp.Repositories.NewFolder;
using SchoolApp.Services;

namespace SchoolApp.DBServices.FeesSer
{
    public class FeesServices : IFeesServices
    {
        private readonly IFeeRepository _feeRepository;
        private readonly IStudentCourseServices _studentCourseSer;
        private readonly IUserServices _userServices;
        private readonly IUserService _currentServices;
        private readonly IAccountRepository _accountRepo;
        public FeesServices(IFeeRepository feeRepository,ISectionServices sectionServices, IStudentCourseServices studentCourseServices,
                                                        IUserService currentService,IUserServices userServices, IAccountRepository accountRepo)
        {
            _feeRepository = feeRepository;
            _studentCourseSer = studentCourseServices;
            _userServices = userServices;
            _currentServices = currentService;
            _accountRepo = accountRepo;
        }
        public List<FeesDTO> GetAllFeesCurrentMonth(bool? Paid = false)
        {
            var data =_feeRepository.GetAllFeebyStatusCurrentMonth(Paid);
            return data.Select(x => new FeesDTO()
            {
                StudentName = x.User?.Name,
                StudentId = x.UserId,
                FeesDecided = x.FeesDecided,
                FeesGiven = x.FeesGiven,
                CollectedByName = x.CollectedByNavigation?.Name,
                CollectedBy = x.CollectedBy,
                CollectedOn = x.CollectedOn,
                ClassId = x.User.StudentCourses.FirstOrDefault().Section.ClassId,
                SectionName = x.User.StudentCourses.FirstOrDefault().Section.Name,
                Month = x.ForMonth?.Name,
                Year = x.Year,
                FeeStatus = x.FeeStatus,
                Id = x.Id
            }).ToList();
        }
        public List<FeesDTO> GetAllFeebyConditions(FeesSearchDTO feesSearch)
        {
            var data = _feeRepository.GetAllFeebyConditions(feesSearch);
            if (data.Count > 0) { 
            return data.Select(x => new FeesDTO()
            {
                StudentName = x.User?.Name,
                StudentId = x.UserId,
                FeesDecided = x.FeesDecided,
                FeesGiven = x.FeesGiven,
                CollectedByName = x.CollectedByNavigation?.Name,
                CollectedBy = x.CollectedBy,
                CollectedOn = x.CollectedOn,
                ClassId = x.User.StudentCourses.Select(g => g.Section.ClassId).FirstOrDefault(),
                SectionName = x.User.StudentCourses.Select(g => g.Section.Name).FirstOrDefault(),
                Month = x.ForMonth?.Name,
                Year = x.Year,
                FeeStatus = x.FeeStatus,
                Id = x.Id
            }).ToList();
            }
            return null;
        }
        public List<Month> GetAllMonths()
        {
            return _feeRepository.GetAllMonths();
        }

        public int AddFessbyRollNo(AddFeesDTO addFees)
        {
            var OldFees = _feeRepository.GetAllFeesbyStudentId(addFees.StudentId);
            Fee fee = new();
            fee.FeeStatus = true;
            fee.FeesGiven = addFees.FeesGiven;
            fee.FeesDecided = OldFees[0].FeesDecided;
            fee.UserId = addFees.StudentId;
            fee.CollectedOn = DateTime.Now;
            fee.CollectedBy = _currentServices.GetUserId();
            fee.MonthId = addFees.MonthId;
            fee.Year = addFees.Year;
            return _feeRepository.AddFeesbyRollNo(fee);
        } 

        public int AddPayRoll(AddPayDTO addPay)
        {
            Account account = _accountRepo.GetAccountbyId(addPay.StaffId);
            PayRollDetail LastPaid = _feeRepository.GetPayRollDetailbyAccountId(account.Id);
            PayRollDetail payRollDetail1 = _feeRepository.GetPayRollDetailbyCondition(addPay.MonthId, addPay.Year, addPay.StaffId);
            if(payRollDetail1 != null)
            {
                return 0;
            }
            PayRollDetail payRollDetail = new PayRollDetail();
            payRollDetail.AccountId = account.Id;
            payRollDetail.NewPayRoll = LastPaid.NewPayRoll;
            payRollDetail.PayRollStatus = true;
            payRollDetail.PayRollDecided = LastPaid.PayRollDecided;
            payRollDetail.PayRollGiven = addPay.PayGiven;
            payRollDetail.Monthid = addPay.MonthId;
            payRollDetail.Year = addPay.Year;
            payRollDetail.GivenOn = DateTime.Now;
            payRollDetail.GivenBy = _currentServices.GetUserId();
            return _feeRepository.AddPayRoll(payRollDetail);
        }
        public List<PayReturnDTO> GetPayRollDetailsQueryable(SearchPayDTO searchTeacherDTO)
        {
            var data = _feeRepository.GetPayRollIQueryable(searchTeacherDTO.MonthId,searchTeacherDTO.Year,searchTeacherDTO.StaffId);
            return data.Select(x=> new PayReturnDTO()
            {
                Id = x.Account.EmployeId,
                Name = x.Account.Employe.Name,
                FatherName = x.Account.Employe.FatherName,
                Phone = x.Account.Employe.Phone,
                Email = x.Account.Employe.Email,
                PayDecided = x.PayRollDecided,
                PayGivenAmount = x.PayRollGiven,
                MonthName = x.ForMonth.Name,
                BatchYear = x.Year,
                GivenOn = x.GivenOn,
                GivenBy = x.GivenByNavigation.Name.ToString(),
                RoleName = x.Account.Employe.UserRoles.Select(g=>g.Role.RolesName).Single(),
            }).ToList();
        }
    }
}
