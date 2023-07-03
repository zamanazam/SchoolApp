using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.FeesRepository
{
    public interface IFeeRepository
    {
        int AddFeebyStudentId(Fee fee);
        int UpdateFeebyId(Fee fee);
        int DeleteFeebyId(int id);
        List<Fee> GetAllFees();
        List<Fee> GetAllFeesbyStudentId(int studentid);
        List<Fee> GetAllFeesbyCollectorId(int Collectorid);
        List<Fee> GetAllFeesbyStatus(bool? paid = false);
        List<Fee> GetAllFeebyStatusCurrentMonth(bool? paid = false);
        List<Fee> GetAllFeebyStatusbetweenDates(DateTime? FromDate, DateTime? ToDate, bool? paid = false);
        Month GetMonthbyId(int MonthId);
        List<Fee> GetAllFeebyConditions(FeesSearchDTO feesSearch);
        List<Month> GetAllMonths();
        int AddFeesbyRollNo(Fee fee);
        Fee GetFeesbyStudentId(int StudentId);
        int AddPayRoll(PayRollDetail payRollDetail);
        PayRollDetail GetPayRollDetailbyAccountId(int AccountId);
        int UpdatePayRoll(PayRollDetail payRollDetail);
        PayRollDetail GetPayRollDetailbyCondition(int? MontId, int? Year, int StaffId);
        List<PayRollDetail> GetPayRollIQueryable(int? MonthId, int? Year, int? AccountId);

    }
}
