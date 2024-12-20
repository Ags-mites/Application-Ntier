using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using System.Timers;
using Oracle.ManagedDataAccess.Client;
using PersistenceLayer.ClientesyCiudad;

namespace PresentationLayer.Facturacion
{
    public partial class Reportes : Form
    {
        private InsertarVentaPorCiudad _insertarVentaPorCiudad;
        private InsertarReportePorClienteArticulo _insertarReportePorClienteArticulo;
        private System.Windows.Forms.Timer _timer; // Usar Timer de WinForms
        private PrintDocument _printDocument; // Objeto para imprimir

        public Reportes()
        {
            InitializeComponent();
            _insertarVentaPorCiudad = new InsertarVentaPorCiudad();
            _insertarReportePorClienteArticulo = new InsertarReportePorClienteArticulo();

            // Inicializar el temporizador de WinForms
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 5000; // 5 segundos
            _timer.Tick += Timer_Tick; // Asignar el evento Tick

            // Inicializar el objeto PrintDocument
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            CargarVentasPorCiudad();
            CargarReportePorClienteArticulo();
        }

        private void CargarVentasPorCiudad()
        {
            try
            {
                var ventasPorCiudad = _insertarVentaPorCiudad.ObtenerTodos(); // Método que debes implementar
                dataGridView1.DataSource = ventasPorCiudad; // Asigna los datos al DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas por ciudad: {ex.Message}");
            }
        }

        private void CargarReportePorClienteArticulo()
        {
            try
            {
                var reportePorClienteArticulo = _insertarReportePorClienteArticulo.ObtenerTodos(); // Método que debes implementar
                dataGridView2.DataSource = reportePorClienteArticulo; // Asigna los datos al DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reporte por cliente y artículo: {ex.Message}");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Mostrar el mensaje de "Imprimiendo reportes"
            lblEstado.Text = "Imprimiendo reportes..."; // Usa un Label en lugar de MessageBox
            lblEstado.Visible = true; // Asegúrate de que el Label esté visible

            // Iniciar el proceso de impresión
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = _printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.Print(); // Inicia la impresión
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}");
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Aquí defines lo que se imprimirá
            // Por ejemplo, puedes imprimir el contenido de un DataGridView
            Bitmap bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Detener el temporizador
            _timer.Stop();

            // Cambiar el mensaje en el Label
            lblEstado.Text = "Se imprimió con éxito."; // Actualiza el texto del Label
            MessageBox.Show("Se imprimió con éxito.");             // Opcionalmente, ocultar el Label después de un tiempo
            // lblEstado.Visible = false; // Si deseas ocultarlo después de unos segundos
        }
    }
}