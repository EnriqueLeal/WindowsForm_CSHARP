using PROYECTO_HYUNDAI.Formularios;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PROYECTO_HYUNDAI.Services
{
    public partial class Login : Form
    {
        // Cadena de conexión a la base de datos
        

        public Login()
        {
            InitializeComponent();
        }

        public void Login_Load(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            // Consulta SQL para verificar el usuario y la contraseña
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";

            try
            {
                IServive servive = new IServive();
               
                using (SqlConnection connection = new SqlConnection(servive.connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("ValidarUsuario", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    string mensaje = (string)command.ExecuteScalar();
                    if (mensaje == "Login exitoso")
                    {
                        MessageBox.Show("Inicio de sesión: " + mensaje);
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                        this.Hide();
                        // Aquí puedes abrir el formulario principal de tu aplicación o realizar otras acciones.
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
