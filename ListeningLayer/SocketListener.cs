using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using BusinessLayer;
using ListeningLayer.interfaces;
using PersistenceLayer;
using static System.Collections.Specialized.BitVector32;

namespace ListeningLayer
{
    public class SocketListener : ISocketListener
    {
        private readonly AccountService _accountService;

        public event Action<string> DataProcessed;

        public SocketListener()
        {
            _accountService = new AccountService();
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

                        NotifyDataProcessed($"Datos recibidos: {data}");
                    }
                }
                catch (Exception ex)
                {
                    NotifyDataProcessed($"Error: {ex.Message}");
                }
            }
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
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar los datos: {ex.Message}");
                throw;
            }
        }

        public List<Account> LoadDataAccounts(string action)
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