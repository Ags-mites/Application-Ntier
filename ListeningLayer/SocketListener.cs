using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using BusinessLayer;
using ListeningLayer.interfaces;
using PersistenceLayer;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ListeningLayer
{
    public class SocketListener : ISocketListener
    {
        private readonly AccountService _accountService;
        private readonly AccountTypeService _accountTypeService;
        private readonly VoucherService _voucherService;
        private readonly LoginService _loginService;

        public event Action<string> DataProcessed;

        public SocketListener()
        {
            _accountService = new AccountService();
            _accountTypeService = new AccountTypeService();
            _voucherService = new VoucherService();
            _loginService = new LoginService();
        }

        public void StartListening()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 13000);
            server.Start();
            NotifyDataProcessed("Servidor iniciado en el puerto 13000.");

            while (true)
            {
                try
                {
                    using (TcpClient client = server.AcceptTcpClient())
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        string action = Encoding.UTF8.GetString(buffer, 1, bytesRead);

                        SendData(data, action);
                        LoadDataAccounts(action);
                        LoadData(action);
                        DeleteData(data, action);
                        LoadEntryDetail(data, action);
                        LoadEntryHeader(data, action);
                        NotifyDataProcessed($"Datos recibidos: {data}");
                    }
                }
                catch (Exception ex)
                {
                    NotifyDataProcessed($"Error: {ex.Message}");
                }
            }
        }

        public bool Login(string username, string password) {
            var result = _loginService.ValidateUser(username, password);
            return result;
        }


        public void SendData(string accountData, string action)
        {
            try
            {
               
                switch (action) {
                    case "New-Account":
                        _accountService.AddAccount(accountData);
                    break;
                    case "Edit-Account":
                        _accountService.UpdateAccount(accountData);
                    break;
                    case "New-AccountType":
                        _accountTypeService.AddAccountType(accountData);
                    break;
                    case "Edit-AccountType":
                        _accountTypeService.UpdateAccountType(accountData);
                    break;
                    case "New-Voucher":
                        _voucherService.AddVoucher(accountData);
                        
                        break;
                    case "Update-Voucher":
                        _voucherService.UpdateVoucher(accountData);
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar los datos: {ex.Message}");
                throw;
            }
        }

        public List<Account> LoadDataAccounts(string action, string? keyword = null)
        {
            try
            {
                switch (action)
                {
                    
                    case "Load-AccountsRepository":
                        var accountsRepository = _accountService.GetAccountsRepository();
                        return accountsRepository;

                    case "Load-Accounts":
                        var Accounts = _accountService.GetAccounts();
                        return Accounts;

                    case "Search-Account":
                        var AccountResult = _accountService.SearchAccounts(keyword);
                    return AccountResult;

                    default:
                        NotifyDataProcessed("Acción no reconocida.");
                        return new List<Account>();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer los datos: {ex.Message}");
                throw;
            }
        }

        public List<AccountType> LoadDataAccountTypes(string action, string? keyword = null)
        {
            try
            {
                switch (action)
                {

                    case "Load-AccountTypesRepository":
                        var accountTypesRepository = _accountTypeService.GetAccountTypesRepository();
                        return accountTypesRepository;
                    case "Search-AccountType":
                        var AccountTypeResult = _accountTypeService.SearchAccountType(keyword);
                    return AccountTypeResult;

                    default:
                        NotifyDataProcessed("Acción no reconocida.");
                        return new List<AccountType>();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer los datos: {ex.Message}");
                throw;
            }
        }

        public List<EntryHeader> LoadEntryHeader(string action, string? keyword = null) {
            try
            {
                switch (action)
                {

                    case "Load-EntryHeaderRepository":
                        var entryHeaderRepository = _voucherService.GetEntryHeaderRepository();
                        return entryHeaderRepository;

                    case "Search-EntryHeader":
                        var entryHeaderResult = _voucherService.SearchEntryHeader(keyword);
                        return entryHeaderResult;

                    default:
                        NotifyDataProcessed("Acción no reconocida.");
                        return new List<EntryHeader>();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer los datos: {ex.Message}");
                throw;
            }
        }

        public List<EntryDetail> LoadEntryDetail(string action, string? keyword = null)
        {
            try
            {
                switch (action)
                {

                    case "Load-EntryDetail":
                        var loadEntryDetailsbyHeader = _voucherService.GetEntryDetailsbyEntryHeader(keyword);
                        return loadEntryDetailsbyHeader;
                    
                    default:
                        NotifyDataProcessed("Acción no reconocida.");
                        return new List<EntryDetail>();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer los datos: {ex.Message}");
                throw;
            }
        }


        public List<AccountType> LoadData( string action )
        {
            try
            {
                switch (action)
                {
                    case "Load-AccountType":
                        var accounts = _accountService.GetAccountTypes();
                        return accounts;

                    default:
                        NotifyDataProcessed("Acción no reconocida.");
                        return new List<AccountType>();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer los datos: {ex.Message}");
                throw;
            }
        }

        public void DeleteData(string id, string action)
        {
            try
            {
                switch (action)
                {
                    case "Delete-Account":
                        int accountId = Convert.ToInt32(id);
                        _accountService.DeleteAccount(accountId);
                     break;

                    case "Delete-AccountType":
                        int accountTypeId = Convert.ToInt32(id);
                        _accountTypeService.DeleteAccountType(accountTypeId);
                    break;
                    case "Delete-Voucher":
                        int deleteVoucherId = Convert.ToInt32(id);
                        _voucherService.DeleteVoucherId(deleteVoucherId);
                    break;

                    default:
                        NotifyDataProcessed("Acción no reconocida.");
                        break;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer los datos: {ex.Message}");
                throw;
            }
        }

        private void NotifyDataProcessed(string message)
        {
            DataProcessed?.Invoke(message);
        }
    }
}