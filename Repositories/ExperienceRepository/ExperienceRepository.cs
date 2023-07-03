using Microsoft.Identity.Client;
using SchoolApp.Entities;
using SchoolApp.Entities_Force;
using SchoolApp.Repositories.QualificationRepository;

namespace SchoolApp.Repositories.ExperienceRepository
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly SchoolDbContext _dbContext;
        public ExperienceRepository( SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddExperience(TeacherExperience teacherExperiences)
        {
            _dbContext.TeacherExperience.AddRange(teacherExperiences);
            SaveChanges();
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public List<TeacherExperience> GetTeacherExperiencebyId(int id)
        {
            return _dbContext.TeacherExperience.Where(x => x.TeacherId == id).ToList();
        }
        public void RemoveTeacherExperience(List<TeacherExperience> list)
        {
            _dbContext.TeacherExperience.RemoveRange(list);
        }
    }
}
