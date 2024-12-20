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
        bool Login(string username, string password);
        List<AccountType> LoadData(string acction);
        List<Account> LoadDataAccounts( string acction, string? data);
        List<AccountType> LoadDataAccountTypes( string acction, string? data);
        List<EntryDetail> LoadEntryDetail( string acction, string? data);
        List<EntryHeader> LoadEntryHeader( string acction, string? data);

        List<MOTIVO_INGRESO_EGRESO> LoadDataMotivo(string acction, string? data);
        List<Empleados> LoadDataEmpleado(string acction, string? data);

        event Action<string> DataProcessed;
    }
}

