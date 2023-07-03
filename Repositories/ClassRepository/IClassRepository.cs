using SchoolApp.Entities;

namespace SchoolApp.Repositories.ClassRepository
{
    public interface IClassRepository
    {
        List<ClassName> GetAllClasses();
    }
}
