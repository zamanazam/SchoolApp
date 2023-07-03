using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;
using SchoolApp.Repositories.SectionRepository;
using SchoolApp.Repositories.StudentResRepository;
using SchoolApp.Repositories.UserRepository;
using SchoolApp.Services;
using static System.Collections.Specialized.BitVector32;
using static System.Formats.Asn1.AsnWriter;

namespace SchoolApp.DBServices.StudentResultSer
{
    public class StudentResultsServices : IStudentResultsServices
    {
        private readonly IStudentResultRepository _studentResultRepo;
        private readonly IUserRepository _userRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly IUserService _currentService;
        public StudentResultsServices(IStudentResultRepository studentResultRepo, IUserRepository userRepository, 
                                                                ISectionRepository sectionRepository, IUserService currentService)
        {
            _studentResultRepo = studentResultRepo;
            _userRepository = userRepository;
            _sectionRepository = sectionRepository;
            _currentService = currentService;
        }
        public List<StudentResultsDTO> GetAllResults(int ClassId)
        {
            var data = _studentResultRepo.GetAllResults(ClassId);
            return data.Select(x => new StudentResultsDTO()
            {
                Id = x.Id,
               // Student = x.Student,
                StudentName = x.Student.Name,
                SubjectName = x.Section.SubjectsName.Name,
                SectionName = x.Section.Name,
                ClassId = x.Section.ClassId,
                //SectionId = x.SectionId,
                //Section = x.Section,
                Score = x.Score,
                Total = x.Total,
                StudentId = x.StudentId,
               // SubjectId = x.Section.SubjectId,
                UploadOn = x.UploadOn,
                UploadBy = x.UploadBy,
                //ModifiedBy = x.ModifiedBy,
                //ModifiedOn = x.ModifiedOn,
                Month = x.OnMonth.Name,
                BatchYear = x.BatchYear,

            }).ToList();
        }
        public List<StudentResultsDTO> GetResultbyStudentId(int StudentId)
        {
            var data = _studentResultRepo.GetResultbyStudentId(StudentId);
            return data.Select(x => new StudentResultsDTO()
            {
                Id = x.Id,
                //Student = x.Student,
                StudentName = x.Student.Name,
                SubjectName = x.Section.SubjectsName.Name,
                SectionName = x.Section.Name,
                ClassId = x.Section.ClassId,
                //SectionId = x.SectionId,
                //Section = x.Section,
                Score = x.Score,
                Total = x.Total,
                StudentId = x.StudentId,
                //SubjectId = x.Section.SubjectId,
                UploadOn = x.UploadOn,
                UploadBy = x.UploadBy,
                //ModifiedBy = x.ModifiedBy,
                //ModifiedOn = x.ModifiedOn,
                Month = x.OnMonth.Name,
                BatchYear = x.BatchYear,
            }).ToList();

        }
        public List<StudentResultsDTO> LastUpdatedResult()
        {
            var data= _studentResultRepo.LastUpdatedResult();
            return data.Select(x => new StudentResultsDTO()
            {
                Id = x.Id,
               // Student = x.Student,
                StudentName = x.Student.Name,
                SubjectName = x.Section.SubjectsName.Name,
                SectionName = x.Section.Name,
                ClassId = x.Section.ClassId,
                //SectionId = x.SectionId,
                //Section = x.Section,
                Score = x.Score,
                Total = x.Total,
                StudentId = x.StudentId,
                //SubjectId = x.Section.SubjectId,
                UploadOn = x.UploadOn,
                UploadBy = x.UploadBy,
                //ModifiedBy = x.ModifiedBy,
                //ModifiedOn = x.ModifiedOn,
                Month = x.OnMonth.Name,
                BatchYear = x.BatchYear,

            }).ToList();
        }
        public List<StudentResultsDTO> FilterStudentResult(int ClassId, string SectionName)
        {
            var data = _studentResultRepo.FilterStudentResult(ClassId, SectionName);
            return data.Select(x => new StudentResultsDTO()
            {
                Id = x.Id,
               // Student = x.Student,
                StudentName = x.Student.Name,
                SubjectName = x.Section.SubjectsName.Name,
                SectionName = x.Section.Name,
                ClassId = x.Section.ClassId,
                //SectionId = x.SectionId,
                //Section = x.Section,
                Score = x.Score,
                Total = x.Total,
                StudentId = x.StudentId,
                //SubjectId = x.Section.SubjectId,
                UploadOn = x.UploadOn,
                UploadBy = x.UploadBy,
                //ModifiedBy = x.ModifiedBy,
                //ModifiedOn = x.ModifiedOn,
                Month = x.OnMonth.Name,
                BatchYear = x.BatchYear,
            }).ToList();
        }
        public int AddResultbyStudentId(AddResultDTO addResult)
        {
            int id = 0;
            var PrevoiusResult = _studentResultRepo.FindResultDatabyStudentIdExitCurrentMonth(addResult.StudentId, addResult.ClassId, addResult.SectionName,addResult.Year,addResult.MonthId);
            if(PrevoiusResult.Count != 0)
            {
                return 0;
            }
     
            for (int i=0; i < addResult.SubjectId.Count; i++)
            {
                StudentResults results = new();
                results.StudentId = addResult.StudentId;
                results.Score = addResult.SubjectScore.ElementAtOrDefault(i);
                results.SectionId = _sectionRepository.GetSectionIdbyClassidSecionNameandSubjectId(addResult.ClassId, addResult.SectionName, addResult.SubjectId[i]);
                results.Total = addResult.TotalScore.ElementAtOrDefault(i);
                results.UploadOn = DateTime.Now;
                results.BatchYear = addResult.Year;
                results.MonthId = addResult.MonthId;
                results.UploadBy = _currentService.GetUserId();
                id= _studentResultRepo.AddResultbyStudentId(results);
            }
            return id;
        }
    }
}
