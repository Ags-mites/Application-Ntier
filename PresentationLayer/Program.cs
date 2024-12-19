using System;
using System.Text;
using System.Windows.Forms;
using ListeningLayer.controllers;
using System.Security.Cryptography;

namespace PresentationLayer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            /*
            string password = "123456";
            string salt = "abc123";
            string saltedPassword = password + salt;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder hashString = new StringBuilder();
                foreach (byte b in hash)
                {
                    hashString.Append(b.ToString("x2"));
                }

                Console.WriteLine($"Salt: {salt}");
                Console.WriteLine($"Hash: {hashString}");
            }
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var socketController = new SocketListenerController();

            using (var loginForm = new Login(socketController))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1(socketController));
                }
            }
        }
    }
}
