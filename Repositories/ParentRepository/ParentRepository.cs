using Microsoft.AspNetCore.Mvc;
using SchoolApp.Entities;

namespace SchoolApp.Repositories.ParentRepository
{
    public class ParentRepository: IParentRepository
    {
        private readonly SchoolDbContext _dbContext;
        public ParentRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddParents(Parent parent)
        {
            _dbContext.Parents.Add(parent);
            return ParentSaveChanges();
        }
        public int ParentSaveChanges()
        {
           return _dbContext.SaveChanges();
        }
        public Parent ParentbyId(int Id)
        {
            return _dbContext.Parents.Where(x => x.Id == Id).FirstOrDefault();
        }
        public int UpdateParent(Parent parent)
        {
            _dbContext.Parents.Update(parent);
           return ParentSaveChanges();
        }
    }
}
