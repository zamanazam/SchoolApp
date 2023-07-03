using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.DBServices.AttendanceSer
{
    public interface IAttendanceServices
    {
        List<User> GetStudentAttendancebyCourse(SearchStdAttendanceDTO searchStdAttendanceDTO);
        int AddAttendanceStudents(AddAttendanceDTO attendanceDTO);
        List<ReturnStudentAttendanceDTO> StudentAttendanceQueryAble(AddAttendanceDTO searchAttendance);
        int UpdateStudentAttendance(string AttendanceStatus, int AttendanceId);
        List<ReturnStudentAttendanceDTO> TeacherAttendanceQueryable(AddAttendanceDTO searchAttendance);
        List<User> GetTeacherAttendancebyDate(DateTime AttendanceDate);
    }
}
