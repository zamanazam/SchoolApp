using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;
using SchoolApp.Repositories.StudentResRepository;

namespace SchoolApp.DBServices.StudentResultSer
{
    public interface IStudentResultsServices
    {
        List<StudentResultsDTO> GetAllResults(int ClassId);
        List<StudentResultsDTO> GetResultbyStudentId(int StudentId);
        List<StudentResultsDTO> LastUpdatedResult();
        List<StudentResultsDTO> FilterStudentResult(int ClassId, string SectionName);
        int AddResultbyStudentId(AddResultDTO addResult);
    }
}
