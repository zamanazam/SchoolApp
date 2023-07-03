using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.ExperienceRepository
{
    public interface IExperienceRepository
    {
        void AddExperience(TeacherExperience teacherExperiences);
        List<TeacherExperience> GetTeacherExperiencebyId(int id);
        void RemoveTeacherExperience(List<TeacherExperience> list);
    }
}
