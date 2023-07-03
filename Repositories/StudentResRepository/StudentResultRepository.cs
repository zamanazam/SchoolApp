using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.StudentResRepository
{
    public class StudentResultRepository : IStudentResultRepository
    {
        private readonly SchoolDbContext _dbContext;
        public StudentResultRepository(SchoolDbContext dbContext) 
        { 
            _dbContext = dbContext; 
        }
        public List<StudentResults> GetAllResults(int ClassId)
        {
            return _dbContext.StudentResults.AsQueryable().Include(x => x.OnMonth).Include(x => x.ModifiedByNavigation).Include(x => x.Student)
                                                            .Include(x => x.Section).ThenInclude(x => x.SubjectsName).Where(x => x.Section.ClassId == ClassId).ToList();
         
        }
        public List<StudentResults> GetResultbyStudentId(int StudentId) 
        {
            return _dbContext.StudentResults.AsQueryable().Include(x => x.OnMonth).Include(b => b.ModifiedByNavigation).Include(c => c.Student).Include(d=>d.UploadByNavigation)
                                                            .Include(e => e.Section).ThenInclude(e => e.SubjectsName).Where(g => g.StudentId == StudentId).ToList();
        }
        public List<StudentResults> LastUpdatedResult()
        {
            int? Classid= _dbContext.StudentResults.OrderBy(x=>x.UploadOn).Select(x=>x.Section.ClassId).LastOrDefault();
            string? SectionName= _dbContext.StudentResults.OrderBy(x => x.UploadOn).Select(x=>x.Section.Name).LastOrDefault();
            List<int> Ids = _dbContext.StudentResults.Where(x=>x.Section.ClassId == Classid && x.Section.Name == SectionName).Select(x=>x.Id).ToList(); 
            return _dbContext.StudentResults.AsQueryable().Include(x => x.OnMonth).Include(x => x.ModifiedByNavigation).Include(x => x.Student)
                                                            .Include(x => x.Section).ThenInclude(x => x.SubjectsName).Where(x =>x.Section.ClassId == Classid && x.Section.Name == SectionName).ToList();
        }

        public List<StudentResults> FilterStudentResult(int ClassId, string SectionName) 
        {
            return _dbContext.StudentResults.AsQueryable().Include(x => x.OnMonth).Include(x => x.ModifiedByNavigation).Include(x => x.Student)
                       .Include(x => x.Section).ThenInclude(x => x.SubjectsName).Where(x=>x.Section.ClassId == ClassId && x.Section.Name == SectionName).ToList();
        }
        public int AddResultbyStudentId(StudentResults addResult)
        {
            _dbContext.StudentResults.Add(addResult);
            return SaveChanges();   
        }
        public int SaveChanges()
        {
           return _dbContext.SaveChanges();
        }
        public List<StudentResults> FindResultDatabyStudentIdExitCurrentMonth(int StudentId, int Classid, string SectionName, int Year , int Monthid)
        {
            var CurrentMonth = DateTime.Now.Month;
            return _dbContext.StudentResults.Where(x=>x.StudentId == StudentId && x.Section.ClassId == Classid &&
                                x.Section.Name == SectionName&& x.MonthId == Monthid  && x.BatchYear == Year).ToList();
        }
    }
}
