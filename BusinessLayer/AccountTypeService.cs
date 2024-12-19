using PersistenceLayer;
using PersistenceLayer.DTO;


namespace BusinessLayer
{
    public class AccountTypeService
    {

        private readonly AccountTypeRepository _repository;

        public AccountTypeService()
        {
            _repository = new AccountTypeRepository();
        }

        public void AddAccountType(string accountData)
        {
            var parts = accountData.Split(';');
            if (parts.Length != 3) throw new ArgumentException("Datos no válidos: Se esperaban 3 campos separados por ';'.");

            var accountType = new AccountType
            {
                code = parts[0],
                name = parts[1],
                status = (parts[2] == "Disponible") ? "ACTIVE" : "INACTIVE",
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            _repository.Create(accountType);
        }

        public void UpdateAccountType(string accountData)
        {
            var parts = accountData.Split(';');
            if (parts.Length != 3) throw new ArgumentException("Datos no válidos: Se esperaban 4 campos separados por ';'.");
            var accountType = new AccountType
            {
                id = int.Parse(parts[0]),
                name = parts[1],
                status = (parts[2] == "Disponible") ? "ACTIVE" : "INACTIVE",
                updated_at = DateTime.Now
            };

            _repository.Update(accountType);
        }

        public void DeleteAccountType(int accountId)
        {

            _repository.Delete(accountId);
        }

        
        public List<AccountType> GetAccountTypesRepository()
        {
            return _repository.GetAccountTypesRepository();
        }

        public List<AccountType> SearchAccountType(string keyword)
        {
            return _repository.Search(keyword);
        }

        /*public List<Account> GetAccounts()
        {
            return _repository.GetAccounts();
        }

       

        public void DeleteAccount(int accountId)
        {
            _repository.Delete(accountId);
        }

       

        public List<Account> GetAccountsRepository()
        {
            return _repository.GetAccountsRepository();
        }
        */

    }
}
