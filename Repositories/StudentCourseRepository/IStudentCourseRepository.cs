using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.StudentCourseRepository
{
    public interface IStudentCourseRepository
    {
        int AddStudentCourse(List<int> SectionId, int StudentId);
        int UpdateStudentCourse(List<int> SectionId, int StudentId);
        List<SubjectsName> GetSubjectbyClassandSectionName(int ClassId, string SectionName);
        SectionName GetSectionClassNamebyStudentId(int StudentId);
    }
}
