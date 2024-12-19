using ListeningLayer.controllers;
using ListeningLayer.interfaces;
using PersistenceLayer;

namespace PresentationLayer
{
    public partial class FormAccountType : Form
    {
        private readonly ISocketListener _socketListener;

        public FormAccountType(ISocketListener socketListener)
        {
            InitializeComponent();
            _socketListener = socketListener;
            ReloadData();
        }

        private void btnCreateAccountType_Click(object sender, EventArgs e)
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

                if (selectStatusCreate.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, es importante seleccionar el estado de la cuenta.");
                    selectStatusCreate.Focus();
                    return;
                }
                var accountTypeData = $"{txtCodCreate.Text};{txtNameCreate.Text};{selectStatusCreate.SelectedItem}";
                _socketListener.SendData(accountTypeData, "New-AccountType");
                ReloadData();
                MessageBox.Show("Datos enviados a la capa de escucha.");
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
                    MessageBox.Show($"Datos a editar {selectCodEdit.SelectedItem}");
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

                if (selectStatusEdit.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, es importante seleccionar el estado de la cuenta.");
                    selectStatusEdit.Focus();
                    return;
                }

                var accountTypeData = $"{selectedEditId};{txtNameEdit.Text};{selectStatusEdit.SelectedItem}";
                _socketListener.SendData(accountTypeData, "Edit-AccountType");
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
            var selectedAccountType = selectNameDelete.Text;

            try
            {

                MessageBox.Show($"Se eliminara la cuenta {selectedAccountType} ");
                if (selectedId == string.Empty)
                {
                    throw new Exception("No puede eliminar una cuenta sin antes seleccionarla");
                }

                MessageBox.Show($"El tipo de cuenta {selectedAccountType} fue eliminada");
                _socketListener.DeleteData(selectedId, "Delete-AccountType");

                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la cuenta: {ex.Message}");
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
                var result = _socketListener.LoadDataAccountTypes("Search-AccountType", searchAccountData);
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
            var reportAccountTypesRepository = _socketListener.LoadDataAccountTypes("Load-AccountTypesRepository", null);
            var bindingSource = new BindingSource();
            bindingSource.DataSource = reportAccountTypesRepository;
            dataGridView1.DataSource = bindingSource;

            var accountsType = _socketListener.LoadData("Load-AccountType");

            string[] accountStatus = { "Disponible", "No disponible" };
            selectStatusCreate.Items.Clear();
            selectStatusCreate.Items.AddRange(accountStatus);

            selectStatusEdit.Items.Clear();
            selectStatusEdit.Items.AddRange(accountStatus);

            var allAccountTypes = _socketListener.LoadDataAccountTypes("Load-AccountTypesRepository", null);
            var allAccountTypesEdit = new List<AccountType>(allAccountTypes);
            var allAccountTypesDelete = new List<AccountType>(allAccountTypes);

            selectCodEdit.DataSource = allAccountTypesEdit;
            selectCodEdit.DisplayMember = "code";
            selectCodEdit.ValueMember = "id";

            selectNameDelete.DataSource = allAccountTypesDelete;
            selectNameDelete.DisplayMember = "name";
            selectNameDelete.ValueMember = "id";

        }

    }
}
