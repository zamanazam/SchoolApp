using SchoolApp.Entities;

namespace SchoolApp.Repositories.NewFolder
{
    public interface IAccountRepository
    {
        int AddAccount(Account account);
        Account GetAccountbyId(int Id);
        int UpdateAccount(Account account);
    }
}
