using SchoolApp.DTO;

namespace SchoolApp.DBServices.ParentSer
{
    public interface IParentServices
    {
        public int CreateParent(AddUserDTO userDTO);
        int UpdateParent(UpdateStudentDTO userDTO);
    }
}
