using Microsoft.AspNetCore.Mvc;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.QualificationRepository
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly SchoolDbContext _dbContext;
        public QualificationRepository( SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddQualfication(TeacherQualification teacherQualification)
        {
            _dbContext.TeacherQualification.AddRange(teacherQualification);
            SaveChanges();
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public List<TeacherQualification> GetQualificationbyId(int Id)
        {
            return _dbContext.TeacherQualification.Where(x => x.TeacherId == Id).ToList();
        }
        public void RemoveQualifications(List<TeacherQualification> qualifications)
        {
            _dbContext.TeacherQualification.RemoveRange(qualifications);
        }
    }
}
