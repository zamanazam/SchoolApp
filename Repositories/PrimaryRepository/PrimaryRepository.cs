using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.PrimaryRepository
{
    public class PrimaryRepository : IPrimaryRepository
    {
        private readonly SchoolDbContext _dbContext;

        public PrimaryRepository(SchoolDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public List<PrimaryEducation> GetAll()
        {
            return _dbContext.PrimaryEducation.ToList();
        }
        public PrimaryEducation GetPrimaryEducationbyId(int id)
        {
            return _dbContext.PrimaryEducation.Where(x => x.Id == id).FirstOrDefault();
        }
        public int UpdatePrimaryEducation(PrimaryEducation primaryEducation)
        {
            _dbContext.PrimaryEducation.Update(primaryEducation);
            return _dbContext.SaveChanges();
        }
    }
}

