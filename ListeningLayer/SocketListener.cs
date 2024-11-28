using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using BusinessLayer;
using ListeningLayer.interfaces;
using PersistenceLayer;

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

                        NotifyDataProcessed($"Datos recibidos: {data}");
                    }
                }
                catch (Exception ex)
                {
                    NotifyDataProcessed($"Error: {ex.Message}");
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using (client)
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    SendData(data);

                    NotifyDataProcessed("Datos procesados correctamente.");
                }
            }
            catch (Exception ex)
            {
                NotifyDataProcessed($"Error al procesar cliente: {ex.Message}");
            }
        }

        public void SendData(string accountData)
        {
            try
            {
                var parts = accountData.Split(';');
                if (parts.Length != 3) throw new ArgumentException("Datos no válidos: Se esperaban 3 campos separados por ';'.");

                var account = new Account
                {
                    code = parts[0],
                    name = parts[1],
                    account_type = int.Parse(parts[2]),
                    status = true,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                _accountService.AddAccount(account);

                Console.WriteLine("Cuenta procesada y almacenada con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar los datos: {ex.Message}");
                throw;
            }
        }

        private void NotifyDataProcessed(string message)
        {
            DataProcessed?.Invoke(message);
        }
    }
}