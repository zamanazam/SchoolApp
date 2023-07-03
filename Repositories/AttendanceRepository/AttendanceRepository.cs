using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;
using SchoolApp.Services;
using System.Globalization;

namespace SchoolApp.Repositories.AttendanceRepository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly SchoolDbContext _dbContext;

        public AttendanceRepository (SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> GetStudentAttendancebyCourse (SearchStdAttendanceDTO stdAttendanceDTO) 
        {
            return _dbContext.Users.Where(x=>x.StudentCourses.Any(y=>y.Section.Name == stdAttendanceDTO.SectionName) && x.StudentCourses.Any(z=>z.Section.ClassId == stdAttendanceDTO.ClassId) 
                    && x.StudentCourses.Any(b=>b.BatchYear == stdAttendanceDTO.Year) && !x.UserAttendance.Any(k=>k.attendancedate.Value.Date == stdAttendanceDTO.AttendDate.Value.Date)).ToList();
        }

        public List<User> GetStaffAttendancebyDate (DateTime AttendanceDate)
        {
            return _dbContext.Users.Where(x=>x.UserRoles.Any(y=>y.RoleId == 2 || y.RoleId == 4 || y.RoleId == 5) && !x.UserAttendance.Any(k=>k.attendancedate.Value.Date == AttendanceDate.Date)).ToList();
        }

        public int AddstudentAttendance(Attendance attendance)
        {
            _dbContext.Attendance.Add(attendance);
            return _dbContext.SaveChanges();
        }
        public List<Attendance> StudentAttendanceQueryAble(AddAttendanceDTO searchAttendance)
        {
            IQueryable<Attendance> StudentAttendance = _dbContext.Attendance.AsQueryable<Attendance>();
            if(searchAttendance.Studentid.Count != 0)
            {
                StudentAttendance = StudentAttendance.Where(x=>x.UserId == Convert.ToInt32(searchAttendance.Studentid[0]));
            }
            if(searchAttendance.ForDate != null)
            {
                StudentAttendance = StudentAttendance.Where(y=>y.attendancedate.Value.Date == searchAttendance.ForDate.Value.Date);
            }
            return StudentAttendance.Include(k=>k.User).ThenInclude(l=>l.StudentCourses).ThenInclude(s=>s.Section).Include(m=>m.AddedByNavigation).ToList();
        }

        public List<Attendance> TeacherAttendanceQueryAble(AddAttendanceDTO searchAttendance)
        {
            IQueryable<Attendance> StudentAttendance = _dbContext.Attendance.AsQueryable<Attendance>();
            if (searchAttendance.Studentid.Count != 0)
            {
                StudentAttendance = StudentAttendance.Where(x => x.UserId == Convert.ToInt32(searchAttendance.Studentid[0]));
            }
            if (searchAttendance.ForDate != null)
            {
                StudentAttendance = StudentAttendance.Where(y => y.attendancedate.Value.Date == searchAttendance.ForDate.Value.Date);
            }
            return StudentAttendance.Include(k => k.User).ThenInclude(l => l.StudentCourses).ThenInclude(s => s.Section).Include(m => m.AddedByNavigation).ToList();
        }
        public Attendance GetAttendancebyAId(int AttendanceId)
        {
            return _dbContext.Attendance.Where(x => x.Id == AttendanceId).FirstOrDefault();
        }

        public int UpdateStudentAttendance(Attendance attendance)
        {
            _dbContext.Attendance.Update(attendance);
            return _dbContext.SaveChanges(); 
        }
    }
}
