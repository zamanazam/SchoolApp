using SchoolApp.DTO;
using SchoolApp.Entities;

namespace SchoolApp.DBServices.UserSer
{
    public interface IUserServices
    {
        int CreateStudent(AddUserDTO userDTO, int ParentId);
        int CreateTeacher(AddTeacherDTO addTeacher);
        List<Role> GetAllRoles();
        List<UserDTO> GetAllUsers(string UserName);
        UserDTO BlockUserbyId(int id);
        UserDTO GetUserbyId(int Id);
        int UpdateStudent(UpdateStudentDTO userDTO);
        ReturnTeacherDTO GetTeacherbyId(int Id);
        int UpdateTeacher(AddTeacherDTO teacherDTO);
        StudentSubjectsDTO GetStudentbyClassandSectionName(int ClassId, string SectionName, int MonthId, int BatchYear);
        List<AutocompleteStudentDTO> AutocompleteStudetnFunction(string StudentName);
        List<UserDTO> GetStudentbyCondition(SearchStudentDTO searchStudent);
        int AddAccount(AddTeacherDTO addTeacher, int TeacherId);
        List<AutocompleteStudentDTO> AutocompleteTeacherFunction(string TeacherName);
        List<UserDTO> GetStaffbyStaffId(int StaffId, int? MonthId, int? BatchYear);
    }
}