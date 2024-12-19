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
    public partial class Nómina : Form
    {
        private readonly ISocketListener _socketListener;

        public Nómina(ISocketListener socketListener)
        {
            InitializeComponent();
            _socketListener = socketListener;
            ReloadData();

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Por favor, es importante ingresar el nombre del empleado.");
                    txtNameCreate.Focus();
                    return;
                }

                var nominaData = $"{txtCodCreate.Text};{txtNameCreate.Text}";
                _socketListener.SendData(nominaData, "New-Motivo");
                MessageBox.Show("Datos enviados a la capa de escucha.");


                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        public void ReloadData()
        {

            var reportAccountsRepository = _socketListener.LoadDataAccounts("Load-MotivosRepository", null);
            var bindingSource = new BindingSource();
            bindingSource.DataSource = reportAccountsRepository;
            dataGridView1.DataSource = bindingSource;

            var allMotivo = _socketListener.LoadDataMotivo("Load-Nomina", null);
            var allMotivoEdit = new List<MOTIVO_INGRESO_EGRESO>(allMotivo);
            var allMotivoDelete = new List<MOTIVO_INGRESO_EGRESO>(allMotivo);
            selectCodEdit.DataSource = allMotivoEdit;
            selectCodEdit.DisplayMember = "Codigo";
            selectCodEdit.ValueMember = "id";

            selectNameDelete.DataSource = allMotivoEdit;
            selectNameDelete.DisplayMember = "Nombre";
            selectNameDelete.ValueMember = "id";

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

                var motivoData = $"{selectedEditId};{selectCodEdit.SelectedValue};{txtNameEdit.Text}";
                _socketListener.SendData(motivoData, "Edit-Motivo");
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
            var selectedMotivo = selectNameDelete.Text;

            try
            {

                MessageBox.Show($"Se eliminara el perfil {selectedMotivo} ");
                if (selectedId == string.Empty)
                {
                    throw new Exception("No puede eliminar un empleado sin antes seleccionarla");
                }

                MessageBox.Show($"El perfil {selectedMotivo} fue eliminado");
                _socketListener.DeleteData(selectedId, "Delete-Motivo");



                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el perfil {selectedMotivo}");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var searchMotivoData = $"{txtNameSearch.Text}";
                if (string.IsNullOrWhiteSpace(searchMotivoData))
                {
                    ReloadData();
                    return;
                }
                var result = _socketListener.LoadDataMotivo("Search-Nomina", searchMotivoData);
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
