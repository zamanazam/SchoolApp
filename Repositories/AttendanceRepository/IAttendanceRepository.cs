using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.AttendanceRepository
{
    public interface IAttendanceRepository
    {
        List<User> GetStudentAttendancebyCourse(SearchStdAttendanceDTO stdAttendanceDTO);
        int AddstudentAttendance(Attendance attendance);
        List<Attendance> StudentAttendanceQueryAble(AddAttendanceDTO searchAttendance);
        int UpdateStudentAttendance(Attendance attendance);
        Attendance GetAttendancebyAId(int AttendanceId);
        List<Attendance> TeacherAttendanceQueryAble(AddAttendanceDTO searchAttendance);

        List<User> GetStaffAttendancebyDate(DateTime AttendanceDate);
    }
}
