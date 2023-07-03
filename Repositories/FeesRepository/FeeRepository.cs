using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.FeesRepository
{
    public class FeeRepository : IFeeRepository
    {
        private readonly SchoolDbContext _dbContext;
        public FeeRepository (SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddFeebyStudentId(Fee fee)
        {
            _dbContext.Fees.Add(fee);
            return _dbContext.SaveChanges();
        }
        public int UpdateFeebyId(Fee fee)
        {
            _dbContext.Fees.Update(fee);
            return _dbContext.SaveChanges();
        }
        public int DeleteFeebyId(int id)
        {
            Fee fee=_dbContext.Fees.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Fees.Remove(fee);
            return _dbContext.SaveChanges();
        }
        public List<Fee> GetAllFees()
        {
            return _dbContext.Fees.ToList();
        }
        public List<Fee> GetAllFeesbyStudentId(int studentid)
        {
            return _dbContext.Fees.Where(x=>x.UserId == studentid).ToList();
        }
        public List<Fee> GetAllFeesbyCollectorId(int Collectorid)
        {
            return _dbContext.Fees.Where(x => x.CollectedBy == Collectorid).ToList();
        }
        public List<Fee> GetAllFeesbyStatus(bool? paid = false)
        {
            if(paid == false)
            {
                return _dbContext.Fees.Where(x => x.FeeStatus == null || x.FeeStatus != true).ToList();
            }
            else
            {
                return _dbContext.Fees.Where(x => x.FeeStatus == true).ToList();
            }
        }
        public List<Fee> GetAllFeebyStatusCurrentMonth(bool? paid = false)
        {
            if(paid == false)
            {
                var currentmonth = DateTime.Now.Month;
                return  _dbContext.Fees.AsQueryable().Include(v => v.User.StudentCourses).ThenInclude(g=>g.Section).Include(f=>f.ForMonth).Include(c=>c.CollectedByNavigation).Where(x => (x.FeeStatus == null || x.FeeStatus != true) && x.CollectedOn.Value.Month == currentmonth).ToList();
            }
            else
            {
                var currentmonth = DateTime.Now.Month;
                return _dbContext.Fees.AsQueryable().Include(v => v.User.StudentCourses).ThenInclude(g=> g.Section).Include(f => f.ForMonth).Include(c => c.CollectedByNavigation).Where(x => x.FeeStatus == true && x.CollectedOn.Value.Month == currentmonth).ToList();
            }
           
        }
        public List<Fee> GetAllFeebyStatusbetweenDates(DateTime? FromDate, DateTime? ToDate , bool? paid = false)
        {
            if(paid == false)
            {
                return _dbContext.Fees.Where(x=>x.CollectedOn.Value.Date >= FromDate.Value.Date && ToDate.Value.Date >= x.CollectedOn.Value.Date 
                                                                                             && (x.FeeStatus == null || x.FeeStatus != true)).ToList();
            }
            else
            {
                return _dbContext.Fees.Where(x => x.CollectedOn.Value.Date >= FromDate.Value.Date && ToDate.Value.Date >= x.CollectedOn.Value.Date &&
                                                                                                                            x.FeeStatus == true).ToList();
            }
        }
        public Month GetMonthbyId(int MonthId)
        {
            return _dbContext.Month.Where(x => x.Id == MonthId).FirstOrDefault();
        }

        public List<Fee> GetAllFeebyConditions(FeesSearchDTO feesSearch)
        {
            IQueryable<Fee> FeesData = _dbContext.Fees.AsQueryable<Fee>();

            if(feesSearch.RollNo != 0)
            {
                FeesData = FeesData.Where(x => x.UserId == feesSearch.RollNo);
            }
            if(feesSearch.ClassId != 0)
            {
                FeesData = FeesData.Where(x => x.User.StudentCourses.Any(v => v.Section.ClassId == feesSearch.ClassId));
            }
            if(feesSearch.SectionName != null)
            {
                FeesData = FeesData.Where(x => x.User.StudentCourses.Any(g => g.Section.Name == feesSearch.SectionName));
            }
            if(feesSearch.FromDate != null)
            {
                FeesData = FeesData.Where(x=>x.CollectedOn >= Convert.ToDateTime(feesSearch.FromDate));
            }
            if (feesSearch.ToDate != null)
            {
                FeesData = FeesData.Where(x => Convert.ToDateTime(feesSearch.ToDate) >= x.CollectedOn);
            }
            if(feesSearch.Paid == true)
            {
                FeesData = FeesData.Where(x => x.FeeStatus == true);
            }
            if(feesSearch.Paid == false)
            {
                FeesData = FeesData.Where(x => x.FeeStatus == false);
            }
            return FeesData.AsQueryable().Include(v => v.User.StudentCourses).ThenInclude(g => g.Section).Include(f => f.ForMonth).Include(c => c.CollectedByNavigation).ToList();
        }
        public List<Month> GetAllMonths()
        {
            return _dbContext.Month.ToList();
        }
        public int AddFeesbyRollNo(Fee fee)
        {
            _dbContext.Fees.Add(fee);
            return _dbContext.SaveChanges();
        }
        public Fee GetFeesbyStudentId(int StudentId)
        {
            return _dbContext.Fees.OrderByDescending(y=>y.CollectedOn).Where(x => x.UserId == StudentId).LastOrDefault();
        }
        public int AddPayRoll(PayRollDetail payRollDetail)
        {
            _dbContext.PayRollDetails.Add(payRollDetail);
            return _dbContext.SaveChanges();
        }
        public PayRollDetail GetPayRollDetailbyAccountId(int AccountId)
        {
            return _dbContext.PayRollDetails.OrderByDescending(y=>y.GivenOn).Where(x => x.AccountId == AccountId).LastOrDefault();
        }
        public PayRollDetail GetPayRollDetailbyCondition(int? MontId,int? Year, int StaffId)
        {
            return _dbContext.PayRollDetails.Where(x => x.Monthid == MontId && x.Year == Year && x.Account.EmployeId == StaffId).FirstOrDefault();
        }
        public int UpdatePayRoll(PayRollDetail payRollDetail)
        {
            _dbContext.PayRollDetails.Update(payRollDetail);
            return _dbContext.SaveChanges();
        }

        public List<PayRollDetail> GetPayRollIQueryable(int? MonthId, int? Year, int? StaffId)
        {
            IQueryable<PayRollDetail> payRollDetails = _dbContext.PayRollDetails.AsQueryable<PayRollDetail>();
            if(MonthId != null)
            {
                payRollDetails = payRollDetails.Where(x => x.Monthid == MonthId);
            }
            if(Year != null)
            {
                payRollDetails = payRollDetails.Where(y => y.Year == Year);
            }
            if(StaffId != null)
            {
                payRollDetails = payRollDetails.Where(z => z.Account.EmployeId == StaffId);
            }
            return payRollDetails.Include(m=>m.ForMonth).Include(g=>g.GivenByNavigation).Include(a => a.Account).ThenInclude(e => e.Employe).ThenInclude(u=>u.UserRoles).ThenInclude(r=>r.Role).ToList();
        }
    }
}
