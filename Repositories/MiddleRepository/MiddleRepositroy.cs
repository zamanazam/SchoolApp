using SchoolApp.Entities;
using SchoolApp.Entities_Force;

namespace SchoolApp.Repositories.MiddleRepository
{
    public class MiddleRepositroy : IMiddleRepository
    {
        private readonly SchoolDbContext _dbContext;
        public MiddleRepositroy(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<MiddleEducation> GetAll() 
        {
            return _dbContext.MiddleEducation.ToList();
        }
        public MiddleEducation GetMiddleEducationbyId(int Id)
        {
            return _dbContext.MiddleEducation.Where(x => x.Id == Id).FirstOrDefault();
        }
        public int UpdateMiddleEducation(MiddleEducation middleEducation)
        {
            _dbContext.MiddleEducation.Update(middleEducation);
            return _dbContext.SaveChanges();
        }
    }
}
