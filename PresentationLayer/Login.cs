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
            Invoke(new Action(() =>
            {
                MessageBox.Show(message, "Datos Procesados");
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool loginSuccess = true;

            if (loginSuccess)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}