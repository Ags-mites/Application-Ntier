﻿using PersistenceLayer;
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

        public void AddAccount(string accountData)
        {
            var parts = accountData.Split(';');
               if (parts.Length != 4) throw new ArgumentException("Datos no válidos: Se esperaban 4 campos separados por ';'.");

               var account = new Account
               {
                   code = parts[0],
                   name = parts[1],
                   account_type_id = int.Parse(parts[2]),
                   status = "ACTIVE",
                   created_at = DateTime.Now,
                   updated_at = DateTime.Now
               };

            _repository.Create(account);
        }
        public List<AccountType> GetAccountTypes()
        {
            return _repository.GetAccountTypes();
        }
        public List<Account> ReadAllAccounts()
        {
            return _repository.ReadAll();
        }

        public void UpdateAccount(Account account)
        {
            _repository.Update(account);
        }

        public void DeleteAccount(int accountId)
        {
            _repository.Delete(accountId);
        }

        public List<Account> SearchAccounts(string keyword)
        {
            return _repository.Search(keyword);
        }

    }
}
