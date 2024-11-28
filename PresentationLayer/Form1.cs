using ListeningLayer;
using ListeningLayer.controllers;
using ListeningLayer.interfaces;
using System.Net.Sockets;
using System.Text;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private readonly ISocketListener _socketListener;

        public Form1(SocketListenerController socketController)
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
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.");
                    return;
                }

                var accountData = $"{textBox1.Text};{textBox2.Text};{textBox3.Text}";
                _socketListener.SendData(accountData);

                MessageBox.Show("Datos enviados a la capa de escucha.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}