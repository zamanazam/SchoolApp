using SchoolApp.Entities;

namespace SchoolApp.Repositories.NewFolder
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SchoolDbContext _dbContext;
        public AccountRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddAccount(Account account) 
        { 
            _dbContext.Accounts.Add(account);
            SaveChanes();
            return account.Id;
        }
        public void SaveChanes()
        {
            _dbContext.SaveChanges();   
        }
        public Account GetAccountbyId(int Id)
        {
            return _dbContext.Accounts.Where(x=>x.EmployeId == Id).FirstOrDefault();
        }
        public int UpdateAccount(Account account)
        {
             _dbContext.Accounts.Update(account);
            return _dbContext.SaveChanges();
        }
    }
}
