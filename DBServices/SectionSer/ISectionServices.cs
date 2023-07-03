using SchoolApp.Entities;

namespace SchoolApp.DBServices.SectionSer
{
    public interface ISectionServices
    {
        List<SectionName> GetSections();
        List<SectionName> GetSectionsbyClassId(int ClassId);
    }
}
