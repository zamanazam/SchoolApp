using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.PrimaryRepository
{
    public interface IPrimaryRepository
    {
        List<PrimaryEducation> GetAll();
        PrimaryEducation GetPrimaryEducationbyId(int id);
        int UpdatePrimaryEducation(PrimaryEducation primaryEducation);
    }
}
