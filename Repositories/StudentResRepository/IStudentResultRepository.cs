using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.StudentResRepository
{
    public interface IStudentResultRepository
    {
        List<StudentResults> GetAllResults(int ClassId);
        List<StudentResults> GetResultbyStudentId(int StudentId);
        List<StudentResults> LastUpdatedResult();
        List<StudentResults> FilterStudentResult(int ClassId, string SectionName);
        int AddResultbyStudentId(StudentResults addResult);
        List<StudentResults> FindResultDatabyStudentIdExitCurrentMonth(int StudentId, int Classid, string SectionName, int Year, int Monthid);
    }
}
