using ListeningLayer.interfaces;
using PersistenceLayer;

namespace PresentationLayer
{
    public partial class FormVoucher : Form
    {
        private readonly ISocketListener _socketListener;
        private bool _allowSelectionChanged = false;

        public FormVoucher(ISocketListener socketListener)
        {
            InitializeComponent();
            _socketListener = socketListener;
            ConfigureComboBox();
            ReloadData();
            ConfigureDataGridView();
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
            ReloadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_allowSelectionChanged)
                return;

            try
            {
                if (comboBox1.SelectedValue == null || comboBox1.SelectedIndex == -1 || comboBox1.SelectedValue.ToString() == "")
                {
                    dataGridView1.DataSource = null;
                    return;
                }

                var selecEntryDetailEditId = comboBox1.SelectedValue.ToString();

                var result = _socketListener.LoadEntryDetail("Load-EntryDetail", selecEntryDetailEditId);

                if (result == null || !result.Any())
                {
                    MessageBox.Show("No se encontraron datos para la selección.");
                    dataGridView1.DataSource = null;
                    return;
                }

                var allAccounts = _socketListener.LoadDataAccounts("Load-Accounts", null);
                var availableAccounts = new List<Account>(allAccounts);

                dataGridView1.Columns.Clear();

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

                var bindingSource = new BindingSource
                {
                    DataSource = result
                };

                dataGridView1.DataSource = bindingSource;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    var entryDetail = (EntryDetail)row.DataBoundItem;
                    var accountComboBoxCell = (DataGridViewComboBoxCell)row.Cells["AccountCode"];

                    var account = availableAccounts.FirstOrDefault(a => a.id == entryDetail.account);

                    if (account != null)
                    {
                        accountComboBoxCell.Value = account.id;
                    }
                    else
                    {
                        accountComboBoxCell.Value = DBNull.Value;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }



        private void btnEliminarAccount_Click(object sender, EventArgs e)
        {
            var selectedId = selectNameDelete.SelectedValue?.ToString() ?? string.Empty;
            var selectedVouchername = selectNameDelete.Text;

            try
            {

                MessageBox.Show($"Se eliminara la el Voucher con numeracion {selectedVouchername} ");
                if (selectedId == string.Empty)
                {
                    throw new Exception("No puede eliminar una cuenta sin antes seleccionarla");
                }

                MessageBox.Show($"El tipo de cuenta {selectedVouchername} fue eliminada");
                _socketListener.DeleteData(selectedId, "Delete-Voucher");

                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la cuenta: {ex.Message}");
            }
            ReloadData();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var searchVoucherData = $"{txtNameSearch.Text}";
                if (string.IsNullOrWhiteSpace(searchVoucherData))
                {
                    ReloadData();
                    return;
                }
                var result = _socketListener.LoadEntryHeader("Search-EntryHeader", searchVoucherData);
                MessageBox.Show("Datos enviados a la capa de escucha.");
                var bindingSource = new BindingSource();
                bindingSource.DataSource = result;
                dataGridView2.DataSource = bindingSource;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void FormVoucher_Load(object sender, EventArgs e)
        {

        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateVoucherEdit.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha seleccionada no puede ser anterior a la fecha actual.");
                    dateVoucherEdit.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTypeVoucherEdit.Text))
                {
                    MessageBox.Show("Por favor, es importante el tipo de comprobante.");
                    txtTypeVoucherEdit.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescriptionEdit.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar la descripción.");
                    txtDescriptionEdit.Focus();
                    return;
                }

                var voucherData = $"{txtTypeVoucherEdit.Text};{comboBox1.Text};{txtDescriptionEdit.Text};{dateVoucherEdit.Value.ToString("yyyy-MM-dd HH:mm:ss")}";
                var listRows = new List<string>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var accountCode = row.Cells["AccountCode"].Value?.ToString() ?? "";
                        var description = row.Cells["Description"].Value?.ToString() ?? "";
                        var debit = row.Cells["Debit"].Value?.ToString();
                        var credit = row.Cells["Credit"].Value?.ToString();
                        var rowId = row.Cells["Id"]?.Value?.ToString();

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

                        var rowCel = $"{accountCode};{description};{debit ?? "0"};{credit ?? "0"};{rowId ?? ""}";
                        listRows.Add(rowCel);
                    }
                }

                var voucherId = comboBox1.SelectedValue?.ToString();

                if (string.IsNullOrWhiteSpace(voucherId))
                {
                    MessageBox.Show("Debe seleccionar un comprobante a editar.");
                    return;
                }

                var data = voucherData + "|" + string.Join("|", listRows) + $"|{voucherId}";
                _socketListener.SendData(data, "Update-Voucher");
                MessageBox.Show("Comprobante editado correctamente.");

                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
