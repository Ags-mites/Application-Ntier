using PersistenceLayer;
using PersistenceLayer.DTO;
using System.Security.Principal;

namespace BusinessLayer
{
    public class AccountService
    {
        private readonly AccountRepository _repository;
        private readonly LogsService_EAMS _logs_eams;

        public AccountService()
        {
            _repository = new AccountRepository();
            _logs_eams = new LogsService_EAMS();
        }

        public void AddAccount(string accountData)
        {
            var parts = accountData.Split(';');
               if (parts.Length != 4) throw new ArgumentException("Datos no válidos: Se esperaban 4 campos separados por ';'.");

            var account = new Account
               {
                   code = parts[0],
                   name = parts[1],
                   account_type_id = int.Parse(parts[2]),
                   status = (parts[3] == "Disponible") ? "ACTIVE" : "INACTIVE",
                   created_at = DateTime.Now,
                   updated_at = DateTime.Now
               };

            _repository.Create(account);
            _logs_eams.RegisterLogs_EAMS("Create");
        }
        public List<AccountType> GetAccountTypes()
        {
            return _repository.GetAccountTypes();
        }
        public List<Account> GetAccounts()
        {
            return _repository.GetAccounts();
        }

        public void UpdateAccount(string accountData)
        {
            var parts = accountData.Split(';');
            if (parts.Length != 5) throw new ArgumentException("Datos no válidos: Se esperaban 5 campos separados por ';'.");
            
            var account = new Account
            {
                id = int.Parse(parts[0]),
                code = parts[1],
                name = parts[2],
                account_type_id = int.Parse(parts[3]),
                status = (parts[4] == "Disponible") ? "ACTIVE" : "INACTIVE",
                updated_at = DateTime.Now
            };
            
            _repository.Update(account);
        }

        public void DeleteAccount(int accountId)
        {
            _repository.Delete(accountId);
            _logs_eams.RegisterLogs_EAMS("Delete");
        }

        public List<Account> SearchAccounts(string keyword)
        {
            return _repository.Search(keyword);
        }

        public List<Account> GetAccountsRepository()
        {
            return _repository.GetAccountsRepository();
        }

    }
}
