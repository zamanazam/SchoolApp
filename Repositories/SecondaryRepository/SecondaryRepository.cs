using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.SecondaryRepository
{
    public class SecondaryRepository : ISecondaryRepository
    {
        private readonly SchoolDbContext _dbContext;
        public SecondaryRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SecondaryEducation> GetAll()
        {
            return _dbContext.SecondaryEducation.ToList();
        }
        public SecondaryEducation GetSecondaryEducationbyId(int Id)
        {
            return _dbContext.SecondaryEducation.Where(x => x.Id == Id).FirstOrDefault();
        }
        public int UpdateSecondaryEducation(SecondaryEducation secondary)
        {
            _dbContext.SecondaryEducation.Update(secondary);
            return _dbContext.SaveChanges();
        }
    }
}
