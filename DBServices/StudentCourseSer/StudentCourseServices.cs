using Microsoft.EntityFrameworkCore;
using SchoolApp.Entities;
using SchoolApp.Repositories.StudentCourseRepository;

namespace SchoolApp.DBServices.StudentCourseSer
{
    public class StudentCourseServices : IStudentCourseServices
    {
        private readonly IStudentCourseRepository _studentCourseRepository;
        public StudentCourseServices(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }
        public SectionName GetSectionClassNamebyStudentId(int StudentId)
        {
            return _studentCourseRepository.GetSectionClassNamebyStudentId(StudentId);
        }
    }
}
