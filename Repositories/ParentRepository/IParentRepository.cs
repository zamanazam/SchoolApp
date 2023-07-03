using SchoolApp.Entities;

namespace SchoolApp.Repositories.ParentRepository
{
    public interface IParentRepository
    {
        int AddParents(Parent parent);
        Parent ParentbyId(int Id);
        int UpdateParent(Parent parent);
    }
}
