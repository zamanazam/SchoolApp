using SchoolApp.Entities;

namespace SchoolApp.DBServices.ClassSer
{
    public interface IClassServices
    {
        List<ClassName> GetAllClasses();
    }
}
