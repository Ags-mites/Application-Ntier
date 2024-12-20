using ListeningLayer;
using ListeningLayer.interfaces;
using PersistenceLayer;


namespace PresentationLayer.Nomina
{
    public partial class Workers : Form
    {
        private readonly ISocketListener _socketListener;

        public Workers(ISocketListener socketListener)
        {
            InitializeComponent();
            _socketListener = socketListener;
            ReloadData();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha seleccionada no puede ser anterior a la fecha actual.");
                    dateVoucherCreate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCodCreate.Text))
                {
                    MessageBox.Show("Por favor, es importante el tipo de comprobante.");
                    txtCodCreate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNameCreate.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar la numeración del comprobante.");
                    txtNameCreate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar la descripción.");
                    textBox1.Focus();
                    return;
                }

                var newempleado = $"{txtCodCreate.Text};{txtNameCreate.Text};{textBox1.Text};{dateTimePicker1.Value.ToShortDateString()}";

                _socketListener.SendData(newempleado, "New-empleado");

                MessageBox.Show("Datos enviados correctamente a la capa de escucha.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            ReloadData();
        }

        public void ReloadData()
        {

            var EmpleadosRepository = _socketListener.LoadDataEmpleado("Load-EmpleadosRepository", null);
            var bindingSource = new BindingSource();
            bindingSource.DataSource = EmpleadosRepository;
            dataGridView1.DataSource = bindingSource;

            var allempleados = _socketListener.LoadDataEmpleado("Load-EmpleadosRepository", null);
            var allEmpleadosEdit = new List<Empleados>(allempleados);
            var allEmpleadosDelete = new List<Empleados>(allempleados);

            selectCodEdit.DataSource = allEmpleadosEdit;
            selectCodEdit.DisplayMember = "nombre";
            selectCodEdit.ValueMember = "id";

            selectNameDelete.DataSource = allEmpleadosDelete;
            selectNameDelete.DisplayMember = "nombre";
            selectNameDelete.ValueMember = "id";



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

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Por favor, es importante ingresar el nombre de cuenta.");
                    txtNameEdit.Focus();
                    return;
                }
                if (dateVoucherCreate.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha seleccionada no puede ser anterior a la fecha actual.");
                    dateVoucherCreate.Focus();
                    return;
                }

                var editworkerData = $"{selectedEditId};{selectCodEdit.Text};{txtNameEdit.Text};{textBox2.Text};{dateVoucherCreate.Value.ToShortDateString()}";
                _socketListener.SendData(editworkerData, "Edit-Worker");
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
            var selectedWorker = selectNameDelete.Text;

            try
            {

                MessageBox.Show($"Se eliminara la cuenta {selectedWorker} ");
                if (selectedId == string.Empty)
                {
                    throw new Exception("No puede eliminar una cuenta sin antes seleccionarla");
                }

                MessageBox.Show($"El tipo de cuenta {selectedWorker} fue eliminada");
                _socketListener.DeleteData(selectedId, "Delete-worker");

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
                var searchWorkerData = $"{txtNameSearch.Text}";
                if (string.IsNullOrWhiteSpace(searchWorkerData))
                {
                    ReloadData();
                    return;
                }
                var result = _socketListener.LoadDataEmpleado("Search-Worker", searchWorkerData);
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
    }
}
