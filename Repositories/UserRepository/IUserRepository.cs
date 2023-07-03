using SchoolApp.DTO;
using SchoolApp.Entities;

namespace SchoolApp.Repositories.UserRepository
{
    public interface IUserRepository
    {
        int AddUser(User user, int RoleId);
        List<Role> GetAllRoles();
        List<UserDTO> GetAllUsers();
        List<UserDTO> GetUsersbyName(string UserName);
        UserDTO BlockUserbyId(int id);
        UserDTO GetUserbyId(int Id);
        void UpdateUserbyId(User user);
        User UserbyId(int Id);
        List<User> GetStudentbyClassandSection(int ClassId, string SectionName, int MonthId, int BatchYear);
        User UserbyEmailPassword(string Email, string Password);
        List<User> GetNewTeachers();
        List<User> AutocompleteStudetnFunction(string StudentName);
        List<User> GetStudentbyCondition(SearchStudentDTO studentDTO);
        List<User> GetTeacherORStaffbyUserId(int UserId);
        List<User> AutocompleteTeacherFunction(string TeacherName);
        List<User> GetStaffbyStaffId(int StaffId, int? MonthId, int? BatchYear); 
    }
}
