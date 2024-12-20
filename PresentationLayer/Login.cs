using System;
using System.Windows.Forms;
using PersistenceLayer;
using PersistenceLayer.ClientesyCiudad;

namespace PresentationLayer
{
    public partial class Login : Form
    {
        private Usuario _usuarioManager;

        public Login()
        {
            InitializeComponent();
            _usuarioManager = new Usuario(); // Instancia para manejar la tabla 'usuario'
        }

        // Evento para iniciar sesión
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBox1.Text.Trim(); // Usuario (textbox1)
            string contrasena = textBox2.Text.Trim();    // Contraseña (textbox2)

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuarios = _usuarioManager.ObtenerUsuarios(); // Obtiene los usuarios de la base de datos
                bool existe = usuarios.Select($"NOMBRE_USUARIO = '{nombreUsuario}' AND CONTRASENA = '{contrasena}'").Any();

                if (existe)
                {
                    MessageBox.Show("Inicio de sesión exitoso.", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para crear un nuevo usuario

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nuevoUsuario = textBox4.Text.Trim(); // Usuario (textbox4)
            string nuevaContrasena = textBox3.Text.Trim(); // Contraseña (textbox3)

            if (string.IsNullOrEmpty(nuevoUsuario) || string.IsNullOrEmpty(nuevaContrasena))
            {
                MessageBox.Show("Por favor, ingrese un usuario y contraseña para crear.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuarios = _usuarioManager.ObtenerUsuarios();
                bool yaExiste = usuarios.Select($"NOMBRE_USUARIO = '{nuevoUsuario}'").Any();

                if (yaExiste)
                {
                    MessageBox.Show("El nombre de usuario ya existe. Intente con otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    _usuarioManager.InsertarUsuario(nuevoUsuario, nuevaContrasena); // Crea un nuevo usuario
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpia los campos después de crear el usuario
                    textBox4.Text = string.Empty;
                    textBox3.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
