using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.SecondaryRepository
{
    public interface ISecondaryRepository
    {
        List<SecondaryEducation> GetAll();
        SecondaryEducation GetSecondaryEducationbyId(int Id);
        int UpdateSecondaryEducation(SecondaryEducation secondary);
    }
}
