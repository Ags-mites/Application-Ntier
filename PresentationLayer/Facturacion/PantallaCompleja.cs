using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using PersistenceLayer.ClientesyCiudad;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer.Facturacion
{
    public partial class PantallaCompleja : Form
    {
        private CiudadEntregaRepository ciudadEntregaRepository;
        private ClienteRepository clienteRepository;
        public PantallaCompleja()
        {
            InitializeComponent();
            ciudadEntregaRepository = new CiudadEntregaRepository();  // Inicializa el repositorio de ciudades
            clienteRepository = new ClienteRepository();
        }


        private void PantallaCompleja_Load_1(object sender, EventArgs e)
        {
            try
            {

                // Cargar ciudades y asignarlas al ComboBox
                CargarCiudadesEntrega();

                // Cargar clientes y asignarlos al ComboBox
                CargarClientes(); // Llama al nuevo método para cargar clientes


                // Cargar artículos
                CargarArticulos();
                lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                pantallaCargada = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
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
                    string query = "SELECT RUC, NOMBRE, DIRECCION FROM cliente";
                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                Ruc = reader["RUC"].ToString(),
                                Nombre = reader["NOMBRE"].ToString(),
                                Direccion = reader["DIRECCION"].ToString()
                            };
                            Console.WriteLine($"Cliente leído: {cliente.Ruc} - {cliente.Nombre} - {cliente.Direccion}");
                            clientes.Add(cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer clientes: {ex.Message}");
            }

            return clientes;
        }

        private void CargarClientes()
        {
            try
            {
                var clientes = LeerClientes(); // Leer clientes desde la base de datos

                if (clientes != null && clientes.Any())
                {
                    comboBox2.DataSource = clientes;
                    comboBox2.DisplayMember = "Nombre";
                    comboBox2.ValueMember = "Ruc";
                }
                else
                {
                    MessageBox.Show("No se encontraron clientes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}");
            }
        }

        private void CargarCiudadesEntrega()
        {
            try
            {
                var ciudades = ciudadEntregaRepository.LeerCiudadesEntrega();
                if (ciudades != null && ciudades.Any())
                {
                    var bindingSourceCiudades = new BindingSource { DataSource = ciudades };
                    comboBox1.DataSource = bindingSourceCiudades;
                    comboBox1.DisplayMember = "Nombre";  // Mostrar el nombre de la ciudad
                    comboBox1.ValueMember = "Codigo";   // El valor será el código de la ciudad
                }
                else
                {
                    MessageBox.Show("No se encontraron ciudades.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ComboBox de ciudades: {ex.Message}");
            }
        }

        private void CargarArticulos()
        {
            try
            {
                var articulos = Articulo.ObtenerTodos(); // Obtener todos los artículos

                if (articulos != null && articulos.Any())
                {
                    // Asignar la lista completa de artículos al ComboBox
                    comboBox3.DataSource = articulos;
                    comboBox3.DisplayMember = "Codigo"; // Mostrar el código en el ComboBox
                    comboBox3.ValueMember = "Codigo";   // El valor será el código
                }
                else
                {
                    MessageBox.Show("No se encontraron artículos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los artículos: {ex.Message}");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el artículo seleccionado
            var selectedArticulo = comboBox3.SelectedItem as Articulo;

            // Mostrar el precio en el TextBox
            if (selectedArticulo != null)
            {
                textBox1.Text = selectedArticulo.Precio.ToString("C"); // Formato de moneda
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si los campos necesarios están llenos
                if (comboBox3.SelectedItem == null || string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                // Obtener el artículo seleccionado y la cantidad ingresada
                var selectedArticulo = comboBox3.SelectedItem as Articulo;
                var cantidad = int.Parse(txtCantidad.Text); // Convierte la cantidad ingresada

                // Calcular el precio total para el artículo seleccionado
                decimal precioArticulo = selectedArticulo.Precio; // Asegúrate de que Precio sea de tipo decimal
                decimal totalArticulo = precioArticulo * cantidad; // Total para este artículo

                // Sumar el total del artículo al costo total
                costoTotal += totalArticulo;

                // Crear una nueva fila con los datos
                var nuevaFila = new
                {
                    Codigo = selectedArticulo.Codigo,
                    Nombre = selectedArticulo.Nombre,
                    Ciudad = comboBox1.Text, // Ciudad seleccionada
                    Cantidad = cantidad,
                    Precio = totalArticulo.ToString("C") // Formato de moneda
                };

                // Obtener la lista existente de filas en el DataGridView, si existe
                var listaArticulos = (List<dynamic>)dataGridView1.DataSource ?? new List<dynamic>();

                // Agregar la nueva fila a la lista existente
                listaArticulos.Add(nuevaFila);

                // Asignar la lista actualizada al DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listaArticulos;

                // Limpiar el campo txtCantidad después de agregar la fila
                //txtCantidad.Clear();

                // Actualizar lblCostoApagar con el costo total
                lblCostoApagar.Text = costoTotal.ToString("C"); // Formato de moneda

                // Asegurarse de que los controles no se reinicien o desaparezcan
                // No limpiar comboBox3, ya que debe mantener el artículo seleccionado
                // No limpiar txtCantidad para que el usuario pueda seguir trabajando con el valor que introdujo
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la fila: {ex.Message}");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Asegúrate de que lblCostoApagar tenga un valor numérico
                decimal costoApagar = decimal.Parse(lblCostoApagar.Text, NumberStyles.Currency);
                decimal cantidadPagada = decimal.Parse(textBox3.Text);

                // Calcular la devolución
                decimal devolucion = cantidadPagada - costoApagar;

                // Mostrar la devolución
                lbldevolucion.Text = devolucion.ToString("C"); // Formato de moneda
            }
            catch
            {
                lbldevolucion.Text = "$0.00"; // Mostrar 0 en formato de moneda
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pantallaCargada)
                return;
            if (comboBox2.SelectedItem is Cliente clienteSeleccionado)
            {
                MessageBox.Show($"Cliente seleccionado: {clienteSeleccionado.Nombre}, RUC: {clienteSeleccionado.Ruc}");
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el artículo está seleccionado
                var selectedArticulo = comboBox3.SelectedItem as Articulo;
                if (selectedArticulo == null)
                {
                    MessageBox.Show("Por favor, selecciona un artículo.");
                    return;
                }

                // Verificar si el cliente está seleccionado
                string clienteRuc = comboBox2.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(clienteRuc))
                {
                    MessageBox.Show("Por favor, selecciona un cliente.");
                    return;
                }

                // Obtener los datos necesarios
                var cantidad = int.Parse(txtCantidad.Text);  // Cantidad ingresada
                decimal precioArticulo = selectedArticulo.Precio;
                decimal totalArticulo = precioArticulo * cantidad;

                // Insertar en la tabla ReportePorClienteArticulo
                var insertarReportePorClienteArticulo = new InsertarReportePorClienteArticulo();
                insertarReportePorClienteArticulo.Insertar(clienteRuc, selectedArticulo.Codigo, totalArticulo);

                // Actualizar la interfaz después de la venta
                MessageBox.Show("Venta registrada en ReportePorClienteArticulo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la venta a cliente: {ex.Message}");
            }
        }

        private void btnCiudad_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el artículo está seleccionado
                var selectedArticulo = comboBox3.SelectedItem as Articulo;
                if (selectedArticulo == null)
                {
                    MessageBox.Show("Por favor, selecciona un artículo.");
                    return;
                }

                // Obtener los datos necesarios
                var cantidad = int.Parse(txtCantidad.Text);  // Cantidad ingresada
                decimal precioArticulo = selectedArticulo.Precio;
                decimal totalArticulo = precioArticulo * cantidad;

                // Obtener la ciudad seleccionada
                string ciudad = comboBox1.Text;

                // Insertar en la tabla VentasPorCiudad
                var insertarVentaPorCiudad = new InsertarVentaPorCiudad();
                insertarVentaPorCiudad.Insertar(ciudad, totalArticulo);

                // Actualizar la interfaz después de la venta
                MessageBox.Show("Venta registrada en VentasPorCiudad.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la venta en ciudad: {ex.Message}");
            }
        }
    }
}
