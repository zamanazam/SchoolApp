using SchoolApp.Entities;

namespace SchoolApp.DBServices.StudentCourseSer
{
    public interface IStudentCourseServices
    {
        SectionName GetSectionClassNamebyStudentId(int StudentId);
    }
}
