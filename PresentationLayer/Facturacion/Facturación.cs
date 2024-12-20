using ListeningLayer;
using ListeningLayer.interfaces;
using Oracle.ManagedDataAccess.Client;
using PersistenceLayer;
using PersistenceLayer.ClientesyCiudad; // Incluir el espacio de nombres de tus repositorios
using PersistenceLayer.ClientesyCiudad;
using PresentationLayer.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Facturación : Form
    {
        private readonly ISocketListener _socketListener;

        public Facturación(ISocketListener socketListener)
        {
            InitializeComponent();
            _socketListener = socketListener ?? throw new ArgumentNullException(nameof(socketListener));
        }

        // Método para recargar los datos (similitudes con el método ReloadData en Form1)
        public void ReloadData()
        {
            try
            {
                // Cargar datos de clientes
                var clientes = LeerClientes();
                if (clientes == null || clientes.Count == 0)
                {
                    MessageBox.Show("No se encontraron clientes.");
                    return;
                }

                var bindingSource = new BindingSource { DataSource = clientes };
                dataGridView1.DataSource = bindingSource;

                selectCodEdit.DataSource = clientes;
                selectCodEdit.DisplayMember = "Ruc";
                selectCodEdit.ValueMember = "Ruc";

                selectNameDelete.DataSource = clientes;
                selectNameDelete.DisplayMember = "nombre";
                selectNameDelete.ValueMember = "Ruc";

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

        public List<Cliente> LeerClientes()
        {
            var clientes = new List<Cliente>();

            try
            {
                using (var connection = Conexion.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT Ruc, nombre, direccion FROM cliente";
                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                Ruc = reader["Ruc"].ToString(),
                                Nombre = reader["nombre"].ToString(),
                                Direccion = reader["direccion"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer clientes: {ex.Message}");
            }

            return clientes;  // Siempre devuelve la lista, aunque esté vacía
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
        private void Facturación_Load(object sender, EventArgs e)
        {
            ReloadData();

        }

        // Evento para la creación de una cuenta (cliente)
        private void btnCreateAccount_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodCreate.Text) || string.IsNullOrWhiteSpace(txtNameCreate.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                var clienteRepo = new ClienteRepository();
                clienteRepo.InsertarCliente(txtCodCreate.Text, txtNameCreate.Text, textBox1.Text);

                RegistrarLog.GuardarLog("Inserción");

                MessageBox.Show("Cliente creado correctamente.");
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear cliente: {ex.Message}");
            }
        }

        // evento de búsqueda de clientes
        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el valor de búsqueda desde el TextBox
                string searchTerm = txtNameSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    MessageBox.Show("Por favor ingrese un término de búsqueda.");
                    return;
                }

                // Buscar los clientes que coincidan con el término de búsqueda (por nombre o RUC)
                ClienteRepository clienteRepo = new ClienteRepository();
                var clientes = clienteRepo.BuscarClientes(searchTerm);

                if (clientes.Count == 0)
                {
                    MessageBox.Show("No se encontraron clientes con ese término.");
                }
                else
                {
                    // Mostrar los clientes encontrados en el DataGridView
                    var bindingSource = new BindingSource();
                    bindingSource.DataSource = clientes;
                    dataGridView1.DataSource = bindingSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}");
            }
        }

        // Evento para el botón de edición de cuenta (cliente)
        private void btnEditAccount_Click_1(object sender, EventArgs e)
        {
            try
            {
                var selectedRuc = selectCodEdit.SelectedValue?.ToString();
                var nombre = txtNameEdit.Text;
                var direccion = textBox6.Text; // Usamos el mismo nombre para la dirección

                if (string.IsNullOrWhiteSpace(selectedRuc) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(direccion))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                // Verificar que el RUC existe
                if (string.IsNullOrWhiteSpace(selectedRuc))
                {
                    MessageBox.Show("RUC no válido.");
                    return;
                }

                // Llamar al repositorio para actualizar el cliente
                var clienteRepo = new ClienteRepository();
                clienteRepo.ActualizarCliente(selectedRuc, nombre, direccion);

                MessageBox.Show("Cliente actualizado correctamente.");
                ReloadData();  // Recargar los datos después de la actualización
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cliente: {ex.Message}");
            }
        }

        // Similar a un botón para eliminar cuenta
        private void btnEliminarAccount_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRuc = selectNameDelete.SelectedValue?.ToString(); // Obtener el RUC, no el nombre
                if (string.IsNullOrWhiteSpace(selectedRuc))
                {
                    MessageBox.Show("Por favor, seleccione un cliente para eliminar.");
                    return;
                }

                var clienteRepo = new ClienteRepository();
                clienteRepo.EliminarCliente(selectedRuc);  // Pasar el Ruc al método de eliminación

                RegistrarLog.GuardarLog("Eliminación");

                MessageBox.Show("Cliente eliminado correctamente.");
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar cliente: {ex.Message}");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var imprimirForm = new Reportes();
            imprimirForm.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var pantallaVender = new PantallaCompleja();
            pantallaVender.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                // Asegúrate de tener una instancia de ISocketListener
                ISocketListener socketListener = new SocketListener(); // Reemplaza con tu implementación real

                // Crear una nueva instancia de Ciudad y pasar el socketListener
                var pantallaCiudad = new Ciudad(socketListener);
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
            Application.Exit(); ; // Cerrar la aplicación
        }
    }
}
