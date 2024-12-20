using ListeningLayer.interfaces;
using Oracle.ManagedDataAccess.Client;
using PersistenceLayer.ClientesyCiudad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using PresentationLayer.Facturacion;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListeningLayer;

namespace PresentationLayer.Facturacion
{
    public partial class Ciudad : Form
    {
        private readonly ISocketListener _socketListener;
        public Ciudad(ISocketListener socketListener)
        {
            InitializeComponent();
            _socketListener = socketListener ?? throw new ArgumentNullException(nameof(socketListener));
        }
        // Método para recargar los datos (similitudes con el método ReloadData en Form1)
        public void ReloadData()
        {
            try
            {

                // Cargar tipos de cuenta
                LoadAccountTypes();

                // Configurar estados
                if (selectStatusCreate != null)
                {
                    selectStatusCreate.Items.Clear();
                    selectStatusCreate.Items.AddRange(new string[] { "Disponible", "No disponible" });
                }
                else
                {
                    MessageBox.Show("El control selectStatusCreate no está inicializado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recargar datos: {ex.Message}");
            }
        }

        // Método para cargar tipos de cuenta (similar al de Form1)
        private void LoadAccountTypes()
        {
            try
            {
                var accountsType = _socketListener.LoadData("Load-AccountType");
                if (selectTypeCreate != null)
                {
                    selectTypeCreate.DataSource = accountsType;
                    selectTypeCreate.DisplayMember = "name";
                    selectTypeCreate.ValueMember = "id";
                }
                else
                {
                    MessageBox.Show("selectTypeCreate is not initialized.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de cuenta: {ex.Message}");
            }
        }

        // Cargar datos al iniciar el formulario
        private void Ciudad_Load(object sender, EventArgs e)
        {
            ReloadData();
            CargarCiudadesEntrega();

        }


        //Segunda Pantalla del código:

        private void CargarCiudadesEntrega()
        {
            try
            {
                var repo = new CiudadEntregaRepository();
                var ciudades = repo.LeerCiudadesEntrega();

                // Cargar datos en el ComboBox de edición
                if (comboBoxCodigoEditar != null)
                {
                    comboBoxCodigoEditar.DataSource = new BindingSource(ciudades, null);
                    comboBoxCodigoEditar.DisplayMember = "Codigo";
                    comboBoxCodigoEditar.ValueMember = "Codigo";
                }

                // Cargar datos en el ComboBox de eliminación
                if (comboBoxNombreEliminar != null)
                {
                    comboBoxNombreEliminar.DataSource = new BindingSource(ciudades, null);
                    comboBoxNombreEliminar.DisplayMember = "Nombre";
                    comboBoxNombreEliminar.ValueMember = "Codigo"; // Si quieres eliminar basado en el código
                }

                // Cargar datos en el DataGridView
                if (dataGridView2 != null)
                {
                    var bindingSource = new BindingSource { DataSource = ciudades };
                    dataGridView2.DataSource = bindingSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ComboBox de ciudades: {ex.Message}");
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigoCiudad.Text.Trim();
                string nombre = txtNombreCiudad.Text.Trim();

                if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Por favor complete todos los campos.");
                    return;
                }

                var repo = new CiudadEntregaRepository();
                repo.InsertarCiudadEntrega(codigo, nombre);

                MessageBox.Show("Ciudad de entrega agregada correctamente.");
                CargarCiudadesEntrega(); // Recargar datos
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar ciudad de entrega: {ex.Message}");
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                string codigo = comboBoxCodigoEditar.SelectedValue?.ToString(); // Obtener el código seleccionado
                string nombre = txtNombreCiudadEditar.Text.Trim();

                if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Por favor complete todos los campos.");
                    return;
                }

                var repo = new CiudadEntregaRepository();
                repo.ActualizarCiudadEntrega(codigo, nombre);

                MessageBox.Show("Ciudad de entrega actualizada correctamente.");
                CargarCiudadesEntrega(); // Recargar datos
                //CargarComboBoxCiudades(); // Recargar ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar ciudad de entrega: {ex.Message}");
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                string codigo = comboBoxNombreEliminar.SelectedValue?.ToString(); // Obtener el código basado en el nombre seleccionado

                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MessageBox.Show("Por favor seleccione una ciudad para eliminar.");
                    return;
                }

                var repo = new CiudadEntregaRepository();
                repo.EliminarCiudadEntrega(codigo);

                MessageBox.Show("Ciudad de entrega eliminada correctamente.");
                CargarCiudadesEntrega(); // Recargar datos
                //CargarComboBoxCiudades(); // Recargar ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar ciudad de entrega: {ex.Message}");
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtBuscarCiudad.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    MessageBox.Show("Por favor ingrese un término de búsqueda.");
                    return;
                }

                var repo = new CiudadEntregaRepository();
                var ciudades = repo.LeerCiudadesEntrega()
                                   .Where(c => c.Nombre.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                                   .ToList();

                var bindingSource = new BindingSource();
                bindingSource.DataSource = ciudades;

                dataGridView2.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar ciudades de entrega: {ex.Message}");
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            var imprimirForm = new Reportes();
            imprimirForm.ShowDialog();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            var pantallaVender = new PantallaCompleja();
            pantallaVender.ShowDialog();
        }

        private void Cliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Asegúrate de tener una instancia de ISocketListener
                ISocketListener socketListener = new SocketListener(); // Reemplaza con tu implementación real

                // Crear una nueva instancia de Ciudad y pasar el socketListener
                var pantallaCiudad = new Facturación(socketListener);
                pantallaCiudad.Show(); // Mostrar la ventana

                // Cerrar la ventana actual (facturación)
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la pantalla de ciudad: {ex.Message}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cerrar la aplicación
        }
    }
}
