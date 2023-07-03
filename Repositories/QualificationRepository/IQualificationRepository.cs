using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.QualificationRepository
{
    public interface IQualificationRepository
    {
        void AddQualfication(TeacherQualification teacherQualification);
        List<TeacherQualification> GetQualificationbyId(int Id);
        void RemoveQualifications(List<TeacherQualification> qualifications);
    }
}
