using SchoolApp.Entities;
using SchoolApp.Repositories.SectionRepository;

namespace SchoolApp.DBServices.SectionSer
{
    public class SectionServices : ISectionServices
    {
        private readonly ISectionRepository _sectionRepository;
        public SectionServices(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public List<SectionName> GetSections()
        {
            var Data = _sectionRepository.GetSections();
          return Data.Select(x => new SectionName()
             {
                 Name = x.Name,
                 SubjectId = x.SubjectId,
                 ClassId = x.ClassId,
                 Id = x.Id,
                 CreatedBy = x.CreatedBy,
                 ModifiedBy = x.ModifiedBy,
                 CreatedOn = x.CreatedOn,
                 ModifiedOn = x.ModifiedOn
             }).DistinctBy(c=>c.Name).ToList();
        }
        public List<SectionName> GetSectionsbyClassId(int ClassId)
        {
            var data = _sectionRepository.GetSectionsbyClassId(ClassId);
            return (data.DistinctBy(x => x.Name).ToList());
        }
     
    }
}
