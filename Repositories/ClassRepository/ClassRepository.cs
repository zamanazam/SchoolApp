using Microsoft.AspNetCore.Mvc;
using SchoolApp.Entities;

namespace SchoolApp.Repositories.ClassRepository
{
    public class ClassRepository : IClassRepository
    {
        private readonly SchoolDbContext _dbContext;
        public ClassRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ClassName> GetAllClasses()
        {
            return _dbContext.ClassNames.ToList();
        }
    }
}
