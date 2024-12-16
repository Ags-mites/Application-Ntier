using PersistenceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeningLayer.interfaces
{
    public interface ISocketListener
    {
        void StartListening();
        void SendData(string data, string acction);
        void DeleteData(string data, string acction);
        List<AccountType> LoadData(string acction);
        List<Account> LoadDataAccounts( string acction, string? data);
        List<AccountType> LoadDataAccountTypes( string acction, string? data);
        event Action<string> DataProcessed;
    }
}
