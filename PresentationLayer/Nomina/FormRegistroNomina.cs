using ListeningLayer.interfaces;
using PersistenceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FormRegistroNomina : Form
    {
        private readonly ISocketListener _socketListener;
        private bool _allowSelectionChanged = false;

        public FormRegistroNomina(ISocketListener socketListener)
        {
            InitializeComponent();
            _socketListener = socketListener;
            ConfigureComboBox();
            ReloadData();
            ConfigureDataGridView();
            txtNombreEmpleadoEdit.Enabled = false;
            txtNombreEmpleadoCrear.Enabled = false;
        }

        private void ConfigureComboBox()
        {
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            comboBox1.Items.Add(new { id = "", numeration = "--Seleccione una opción--" });
            comboBox1.DisplayMember = "numeration";
            comboBox1.ValueMember = "id";
            comboBox1.SelectedIndex = 0;

            _allowSelectionChanged = false;
        }

        public void ReloadData()
        {
            try
            {
                var voucherNumeration = _socketListener.LoadEntryHeader("Load-EntryHeaderRepository", null);
                var allAccountsEdit = new List<EntryHeader>
                {
                    new EntryHeader { id = 0, numeration = "--Seleccione una opción--" }
                };
                allAccountsEdit.AddRange(voucherNumeration);

                comboBox1.DataSource = allAccountsEdit;
                comboBox1.DisplayMember = "numeration";
                comboBox1.ValueMember = "id";
                comboBox1.SelectedIndex = 0;

                _allowSelectionChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del ComboBox: {ex.Message}");
            }

            var allEntryHeader = new List<EntryHeader>(_socketListener.LoadEntryHeader("Load-EntryHeaderRepository", null));
            selectNameDelete.DataSource = allEntryHeader;
            selectNameDelete.DisplayMember = "numeration";
            selectNameDelete.ValueMember = "id";


            var bindingSource = new BindingSource();
            bindingSource.DataSource = allEntryHeader;
            dataGridView2.DataSource = bindingSource;

        }
        private void ConfigureDataGridView()
        {
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AutoGenerateColumns = false;

            var allAccounts = _socketListener.LoadDataAccounts("Load-Accounts", null);
            var availableAccounts = new List<Account>(allAccounts);

            DataGridViewComboBoxColumn accountColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Cuenta",
                Name = "AccountCode",
                ValueType = typeof(int),
                DataSource = availableAccounts,
                DisplayMember = "name",
                ValueMember = "id"
            };
            dataGridView1.Columns.Add(accountColumn);

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Descripcion",
                Name = "Description",
                ValueType = typeof(string),
                DataPropertyName = "description"
            };
            dataGridView1.Columns.Add(descriptionColumn);


            DataGridViewTextBoxColumn debitColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Debe",
                Name = "Debit",
                ValueType = typeof(decimal),
                DataPropertyName = "debit_amount"
            };
            dataGridView1.Columns.Add(debitColumn);

            DataGridViewTextBoxColumn creditColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Haber",
                Name = "Credit",
                ValueType = typeof(decimal),
                DataPropertyName = "credit_amount"
            };
            dataGridView1.Columns.Add(creditColumn);

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Id",
                Name = "Id",
                ValueType = typeof(string),
                Visible = false
            };
            dataGridView1.Columns.Add(idColumn);

            //dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
        }
    }
}
