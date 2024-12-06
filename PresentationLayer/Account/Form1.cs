using ListeningLayer;
using ListeningLayer.controllers;
using ListeningLayer.interfaces;
using PersistenceLayer;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

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

            var accountRepository = _socketListener.LoadDataAccount("Load-AllAccount");
            var bindingSource = new BindingSource();
            bindingSource.DataSource = accountRepository;
            dataGridView1.DataSource = bindingSource;

            var accounts = _socketListener.LoadData("Load-Account");
            selectTypeCreate.DataSource = accounts;
            selectTypeCreate.DisplayMember = "name";
            selectTypeCreate.ValueMember = "code";

            string[] accountStatus = { "Disponible", "No disponible" };
            selectStatusCreate.Items.AddRange(accountStatus);
        }

        //--------------btnCreateAccount-------------------------//
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodCreate.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar el código.");
                    txtCodCreate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNameCreate.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar el nombre de cuenta.");
                    txtNameCreate.Focus();
                    return;
                }

                if (selectTypeCreate.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, es importante seleccionar un tipo de cuenta.");
                    selectTypeCreate.Focus();
                    return;
                }

                if (selectStatusCreate.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, es importante seleccionar el estado de la cuenta.");
                    selectStatusCreate.Focus();
                    return;
                }

                var accountData = $"{txtCodCreate.Text};{txtNameCreate.Text};{selectTypeCreate.SelectedItem};{selectStatusCreate.SelectedItem}";
                _socketListener.SendData(accountData, "New-Account");

                MessageBox.Show("Datos enviados a la capa de escucha.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodCreate.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar el código.");
                    txtCodCreate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNameCreate.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar el nombre de cuenta.");
                    txtNameCreate.Focus();
                    return;
                }

                if (selectTypeCreate.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, es importante seleccionar un tipo de cuenta.");
                    selectTypeCreate.Focus();
                    return;
                }

                if (selectStatusCreate.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, es importante seleccionar el estado de la cuenta.");
                    selectStatusCreate.Focus();
                    return;
                }

                var accountData = $"{txtCodCreate.Text};{txtNameCreate.Text};{selectTypeCreate.SelectedItem};{selectStatusCreate.SelectedItem}";
                _socketListener.SendData(accountData, "New-Account");

                MessageBox.Show("Datos enviados a la capa de escucha.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}