using PersistenceLayer;
using System.Security.Principal;

namespace BusinessLayer
{
    public class AccountService
    {
        private readonly AccountRepository _repository;

        public AccountService()
        {
            _repository = new AccountRepository();
        }

        public void AddAccount(Account account)
        {
            _repository.Create(account);
        }
        public List<AccountType> GetAccountTypes()
        {
            return _repository.GetAccountTypes();
        }
    }
}
