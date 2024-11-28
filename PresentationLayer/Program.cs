using System;
using System.Windows.Forms;
using ListeningLayer.controllers;

namespace PresentationLayer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
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
