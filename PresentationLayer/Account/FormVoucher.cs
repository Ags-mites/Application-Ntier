using ListeningLayer.interfaces;
using PersistenceLayer;

namespace PresentationLayer
{
    public partial class FormVoucher : Form
    {
        private readonly ISocketListener _socketListener;

        public FormVoucher(ISocketListener socketListener)
        {
            InitializeComponent();
            _socketListener = socketListener;
            ReloadData();
            ConfigureDataGridView();
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
                ValueType = typeof(string),
                DataSource = availableAccounts,
                DisplayMember = "code",
                ValueMember = "id",
            };
            dataGridView1.Columns.Add(accountColumn);

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Descripcion",
                Name = "Description",
                ValueType = typeof(string)
            };
            dataGridView1.Columns.Add(descriptionColumn);

            DataGridViewTextBoxColumn debitColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Debe",
                Name = "Debit",
                ValueType = typeof(decimal)
            };
            dataGridView1.Columns.Add(debitColumn);

            DataGridViewTextBoxColumn creditColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Haber",
                Name = "Credit",
                ValueType = typeof(decimal)
            };
            dataGridView1.Columns.Add(creditColumn);
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Debit"].Index)
            {
                var debitValue = dataGridView1.Rows[e.RowIndex].Cells["Debit"].Value;
                if (debitValue != null && !string.IsNullOrEmpty(debitValue.ToString()))
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Credit"].ReadOnly = true;
                    dataGridView1.Rows[e.RowIndex].Cells["Credit"].Value = null;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Credit"].ReadOnly = false;
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Credit"].Index)
            {
                var creditValue = dataGridView1.Rows[e.RowIndex].Cells["Credit"].Value;
                if (creditValue != null && !string.IsNullOrEmpty(creditValue.ToString()))
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Debit"].ReadOnly = true;
                    dataGridView1.Rows[e.RowIndex].Cells["Debit"].Value = null;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Debit"].ReadOnly = false;
                }
            }
        }



        public void ReloadData()
        {

        }

        private void btnCreateVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateVoucherCreate.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha seleccionada no puede ser anterior a la fecha actual.");
                    dateVoucherCreate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTypeVoucherCreate.Text))
                {
                    MessageBox.Show("Por favor, es importante el tipo de comprobante.");
                    txtTypeVoucherCreate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNumerationCreate.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar la numeración del comprobante.");
                    txtNumerationCreate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescriptionCreate.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar la descripción.");
                    txtDescriptionCreate.Focus();
                    return;
                }

                var voucherData = $"{txtTypeVoucherCreate.Text};{txtNumerationCreate.Text};{txtDescriptionCreate.Text};{dateVoucherCreate.Value.ToShortDateString()}";

                var listRows = new List<string>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var accountCode = row.Cells["AccountCode"].Value?.ToString() ?? "";
                        var description = row.Cells["Description"].Value?.ToString() ?? "";
                        var debit = row.Cells["Debit"].Value?.ToString();
                        var credit = row.Cells["Credit"].Value?.ToString();

                        if (!string.IsNullOrWhiteSpace(debit) && !string.IsNullOrWhiteSpace(credit))
                        {
                            MessageBox.Show($"Error en la fila {row.Index + 1}: Débito y Crédito no pueden tener valores simultáneamente.");
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(debit) && string.IsNullOrWhiteSpace(credit))
                        {
                            MessageBox.Show($"Error en la fila {row.Index + 1}: Débito o Crédito deben tener un valor.");
                            return;
                        }

                        var rowCel = $"{accountCode};{description};{debit ?? "0"};{credit ?? "0"}";
                        listRows.Add(rowCel);
                    }
                }

                var data = voucherData + "|" + string.Join("|", listRows);

                _socketListener.SendData(data, "New-Voucher");

                MessageBox.Show("Datos enviados correctamente a la capa de escucha.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
