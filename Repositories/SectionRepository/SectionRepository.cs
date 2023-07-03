using SchoolApp.Entities;

namespace SchoolApp.Repositories.SectionRepository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly SchoolDbContext _dbContext;
        public SectionRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SectionName> GetSections()
        {
            return _dbContext.SectionNames.ToList();
        }
        public List<int> GetSectionId(int ClassId, string SectionName)
        {
            return _dbContext.SectionNames.Where(x=>x.ClassId == ClassId && x.Name == SectionName).Select(x=>x.Id).ToList();
        }
        public List<SectionName> GetSectionsbyClassId(int ClassId)
        {
            return _dbContext.SectionNames.Where(x=>x.ClassId == ClassId).ToList();
        }
        public int GetSectionIdbyClassidSecionNameandSubjectId(int ClassId, string SectionName,int SubjectId)
        {
            return _dbContext.SectionNames.Where(x => x.ClassId == ClassId && x.Name == SectionName && x.SubjectId == SubjectId).Select(x => x.Id).First();
        }
    }
}
