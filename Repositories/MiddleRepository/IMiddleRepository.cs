using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.MiddleRepository
{
    public interface IMiddleRepository
    {
        List<MiddleEducation> GetAll();
        MiddleEducation GetMiddleEducationbyId(int Id);
        int UpdateMiddleEducation(MiddleEducation middleEducation);
    }
}
