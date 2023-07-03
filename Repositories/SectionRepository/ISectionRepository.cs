using SchoolApp.Entities;

namespace SchoolApp.Repositories.SectionRepository
{
    public interface ISectionRepository
    {
        List<int> GetSectionId(int ClassId, string SectionName);
        List<SectionName> GetSections();
        List<SectionName> GetSectionsbyClassId(int ClassId);
        int GetSectionIdbyClassidSecionNameandSubjectId(int ClassId, string SectionName, int SubjectId);
    }
}
