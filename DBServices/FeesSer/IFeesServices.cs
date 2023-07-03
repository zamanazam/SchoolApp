using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.DBServices.FeesSer
{
    public interface IFeesServices
    {
        List<FeesDTO> GetAllFeesCurrentMonth(bool? Paid = false);
        List<FeesDTO> GetAllFeebyConditions(FeesSearchDTO feesSearch);
        List<Month> GetAllMonths();
        int AddFessbyRollNo(AddFeesDTO addFees);
        int AddPayRoll(AddPayDTO addPay);
        List<PayReturnDTO> GetPayRollDetailsQueryable(SearchPayDTO searchTeacherDTO);
    }
}
