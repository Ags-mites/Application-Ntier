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

            try
            {
                var socketController = new SocketListenerController(); // Inicializa el controlador de sockets

                using (var loginForm = new Login())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new Form1(socketController)); // Pasa el controlador al constructor
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error en la aplicación: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
