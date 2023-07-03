using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;
using SchoolApp.Repositories.AttendanceRepository;
using SchoolApp.Services;

namespace SchoolApp.DBServices.AttendanceSer
{
    public class AttendanceServices : IAttendanceServices
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IUserService _currentUserService;
        public AttendanceServices(IAttendanceRepository attendanceRepo, IUserService currentUserService)
        {
            _attendanceRepo = attendanceRepo;
            _currentUserService = currentUserService;
        }
        public List<User> GetStudentAttendancebyCourse(SearchStdAttendanceDTO searchStdAttendanceDTO)
        {
            return _attendanceRepo.GetStudentAttendancebyCourse(searchStdAttendanceDTO);
        }
        public int AddAttendanceStudents(AddAttendanceDTO attendanceDTO)
        {

            int id = 0;
            for (int i = 0; i < attendanceDTO.Studentid.Count; i++)
            {
                var datastatus = attendanceDTO.AttendanceStatus[i].Split(',');
                var dataids = attendanceDTO.Studentid[i].Split(',');
                for (int x = 0; x < dataids.Length; x++)
                {
                    Attendance attendance = new Attendance();
                    attendance.attendancedate = attendanceDTO.ForDate;
                    attendance.AddedOn = DateTime.Now;
                    attendance.AddedBy = _currentUserService.GetUserId();
                    attendance.UserId = Convert.ToInt32(dataids[x]);
                    attendance.AttendanceStatus = datastatus[x];
                    id = _attendanceRepo.AddstudentAttendance(attendance);
                }
            }
            return id;
        }
        public List<ReturnStudentAttendanceDTO> StudentAttendanceQueryAble(AddAttendanceDTO searchAttendance)
        {
            var data = _attendanceRepo.StudentAttendanceQueryAble(searchAttendance);
            return data.Select(x => new ReturnStudentAttendanceDTO()
            {
                AttendanceId = x.Id,
                AttendanceStatus = x.AttendanceStatus,
                StudentName = x.User.Name,
                Studentid = x.User.Id,
                AddedBy = x.AddedByNavigation.Name,
                AddOn = x.AddedOn,
                ForDate = x.attendancedate,
                ClassId = x.User.StudentCourses.Select(u => u.Section.ClassId).FirstOrDefault(),
                SectionName = x.User.StudentCourses.Select(s => s.Section.Name).FirstOrDefault(),
            }).ToList();
        }
        public List<ReturnStudentAttendanceDTO> TeacherAttendanceQueryable(AddAttendanceDTO searchAttendance)
        {
            var data = _attendanceRepo.TeacherAttendanceQueryAble(searchAttendance);
            return data.Select(x => new ReturnStudentAttendanceDTO()
            {
                AttendanceId = x.Id,
                AttendanceStatus = x.AttendanceStatus,
                StudentName = x.User.Name,
                Studentid = x.User.Id,
                AddedBy = x.AddedByNavigation.Name,
                AddOn = x.AddedOn,
                ForDate = x.attendancedate,
            }).ToList();
        }
        public int UpdateStudentAttendance(string? AttendanceStatus, int AttendanceId)
        {
            Attendance attendance = _attendanceRepo.GetAttendancebyAId(AttendanceId);
            attendance.AttendanceStatus = AttendanceStatus;
            attendance.ModifiedOn = DateTime.Now;
            attendance.ModifiedBy = _currentUserService.GetUserId();
            return _attendanceRepo.UpdateStudentAttendance(attendance);
        }
        public List<User> GetTeacherAttendancebyDate(DateTime AttendanceDate)
        {
            return _attendanceRepo.GetStaffAttendancebyDate(AttendanceDate);
        }
    }
}
