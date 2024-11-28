using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.interfaces
{
    public interface IAccountRepository
    {
        void Create(Account account);
        List<AccountType> GetAccountTypes();
    }
}
