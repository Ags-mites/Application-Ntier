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

        private void Form1_Load(object sender, EventArgs e)
        {
            var accounts = _socketListener.LoadData("Load-Account");
            comboBox1.DataSource = accounts;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "code";

            string[] accountStatus = { "Disponible", "No disponible" };
            comboBox2.Items.AddRange(accountStatus);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text) ||
                    comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, completa todos los campos.");
                    return;
                }

                var accountData = $"{textBox5.Text};{textBox6.Text};{comboBox1.SelectedItem};{comboBox2.SelectedItem}";
                _socketListener.SendData(accountData, "New-Account");

                MessageBox.Show("Datos enviados a la capa de escucha.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}