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
            ReloadData();
        }

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
                var accountData = $"{txtCodCreate.Text};{txtNameCreate.Text};{selectTypeCreate.SelectedValue};{selectStatusCreate.SelectedItem}";
                _socketListener.SendData(accountData, "New-Account");
                MessageBox.Show("Datos enviados a la capa de escucha.");
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            var selectedEditId = selectCodEdit.SelectedValue?.ToString() ?? string.Empty;
            try
            {
                if (selectCodEdit.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, es importante seleccionar el código.");
                    selectCodEdit.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNameEdit.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar el nombre de cuenta.");
                    txtNameEdit.Focus();
                    return;
                }

                if (selectTypeEdit.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, es importante seleccionar un tipo de cuenta.");
                    selectTypeEdit.Focus();
                    return;
                }

                if (selectStatusEdit.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, es importante seleccionar el estado de la cuenta.");
                    selectStatusEdit.Focus();
                    return;
                }

                var accountData = $"{selectedEditId};{selectCodEdit.SelectedValue};{txtNameEdit.Text};{selectTypeEdit.SelectedValue};{selectStatusEdit.SelectedItem}";
                _socketListener.SendData(accountData, "Edit-Account");
                MessageBox.Show($"Datos a editar {selectedEditId}");
                MessageBox.Show("Datos enviados a la capa de escucha.");
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminarAccount_Click(object sender, EventArgs e)
        {
            var selectedId = selectNameDelete.SelectedValue?.ToString() ?? string.Empty;
            var selectedAccount = selectNameDelete.Text;

            try
            {

                MessageBox.Show($"Se eliminara la cuenta {selectedAccount} ");
                if (selectedId == string.Empty)
                {
                    throw new Exception("No puede eliminar una cuenta sin antes seleccionarla");
                }

                MessageBox.Show($"La cuenta {selectedAccount} fue eliminada");
                _socketListener.DeleteData(selectedId, "Delete-Account");

                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la cuenta {selectedAccount}");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var searchAccountData = $"{txtNameSearch.Text}";
                if (string.IsNullOrWhiteSpace(searchAccountData))
                {
                    ReloadData();
                    return;
                }
                var result = _socketListener.LoadDataAccounts("Search-Account", searchAccountData);
                MessageBox.Show("Datos enviados a la capa de escucha.");
                var bindingSource = new BindingSource();
                bindingSource.DataSource = result;
                dataGridView1.DataSource = bindingSource;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void ReloadData()
        {
            var reportAccountsRepository = _socketListener.LoadDataAccounts("Load-AccountsRepository", null);
            var bindingSource = new BindingSource();
            bindingSource.DataSource = reportAccountsRepository;
            dataGridView1.DataSource = bindingSource;

            var accountsType = _socketListener.LoadData("Load-AccountType");
            var accountsTypeCreate = new List<AccountType>(accountsType);
            var accountsTypeEdit = new List<AccountType>(accountsType);

            selectTypeCreate.DataSource = accountsTypeCreate;
            selectTypeCreate.DisplayMember = "name";
            selectTypeCreate.ValueMember = "id";

            selectTypeEdit.DataSource = accountsTypeEdit;
            selectTypeEdit.DisplayMember = "name";
            selectTypeEdit.ValueMember = "id";

            string[] accountStatus = { "Disponible", "No disponible" };
            selectStatusCreate.Items.Clear();
            selectStatusCreate.Items.AddRange(accountStatus);

            selectStatusEdit.Items.Clear();
            selectStatusEdit.Items.AddRange(accountStatus);

            var allAccounts = _socketListener.LoadDataAccounts("Load-Accounts", null);
            var allAccountsEdit = new List<Account>(allAccounts);
            var allAccountsDelete = new List<Account>(allAccounts);

            selectCodEdit.DataSource = allAccountsEdit;
            selectCodEdit.DisplayMember = "code";
            selectCodEdit.ValueMember = "id";

            selectNameDelete.DataSource = allAccountsDelete;
            selectNameDelete.DisplayMember = "name";
            selectNameDelete.ValueMember = "id";
        }

        private void AccountType_Click(object sender, EventArgs e)
        {
            var formAccountType = new FormAccountType(_socketListener);
            formAccountType.FormClosed += (s, args) =>
            {
                ReloadData();
                this.Show();
            };
            formAccountType.Show();
            this.Hide();
        }

        private void Voucher_Click(object sender, EventArgs e)
        {
            var fomrVoucher = new FormVoucher(_socketListener);
            fomrVoucher.FormClosed += (s, args) =>
            {
                ReloadData();
                this.Show();
            };
            fomrVoucher.Show();
            this.Hide();

        }
    }
}