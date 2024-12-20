using ListeningLayer;
using ListeningLayer.controllers;
using ListeningLayer.interfaces;


namespace PresentationLayer
{
    public partial class Login : Form
    {
        private readonly ISocketListener _socketListener;

        public Login(SocketListenerController socketController)
        {
            InitializeComponent();
            _socketListener = socketController.Listener;

            if (_socketListener is SocketListener listener)
            {
                listener.DataProcessed += OnDataProcessed;
            }
        }

        private void OnDataProcessed(string message)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(message, "Datos Procesados");
                }));
            }
            else
            {
                Console.WriteLine("El control aún no está creado.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            string username = txtUsername.Text; 
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.");
                return;
            }
            */

            //bool loginSuccess = _socketListener.Login(username, password);
            bool loginSuccess = true;

            if (!loginSuccess)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error");
                return;
            }

            MessageBox.Show("Inicio de sesión exitoso.", "Éxito");
            this.DialogResult = DialogResult.OK;
            this.Close();
           
        }
    }
}