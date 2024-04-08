using PROYECTO_HYUNDAI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_HYUNDAI.Formularios
{
    public partial class Empleados : Form
    {
        private List<IEmpleados> empleados;
        private readonly IServive servicio = new IServive();

        public Empleados()
        {
            InitializeComponent();
        }

        private void DataGridEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == DataGridEmpleados.Columns["VerDetallesColumn"]?.Index && e.RowIndex >= 0)
                {
                    // Obtener el empleado seleccionado
                    IEmpleados empleado = DataGridEmpleados.Rows[e.RowIndex].DataBoundItem as IEmpleados;

                    // Mostrar detalles del empleado
                    MessageBox.Show($"Detalles del empleado: {empleado.Nombre} {empleado.ApellidoPaterno} {empleado.ApellidoMaterno}, Cargo: {empleado.Cargo}");

                    TxtBoxActivo.Text = empleado.Activo.ToString();
                    TxtBoxNombre.Text = empleado.Nombre;
                    TxtBoxAp_paterno.Text = empleado.ApellidoPaterno;
                    TxtBoxAp_materno.Text = empleado.ApellidoMaterno;
                    TxtBoxCargo.Text = empleado.Cargo;
                    TxtBoxID.Text = empleado.Id.ToString();
                    btnGuardar.Text = "Actualizar";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar detalles del empleado: " + ex.Message);
            }
        }


        private void CargarEmpleadosEnDataGrid()
        {
            try
            {
                // Obtener la lista de empleados desde la base de datos
                empleados = servicio.GetEmpleados();
                // Verificar si se obtuvieron empleados correctamente
                if (empleados != null)
                {
                    // Enlazar la lista de empleados al control DataGridView
                    DataGridEmpleados.DataSource = empleados;

                    // Opcionalmente, puedes ocultar la columna de Id si no deseas que sea visible en el DataGridView
                    DataGridEmpleados.Columns["Id"].Visible = false;
                }
                else
                {
                    MessageBox.Show("No se pudieron obtener los empleados.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            btnGuardar.Text = "Crear";
            CargarEmpleadosEnDataGrid();
            DataGridEmpleados.AutoGenerateColumns = false;

            // Agregar la columna VerDetallesColumn
            DataGridViewButtonColumn verDetallesColumn = new DataGridViewButtonColumn();
            verDetallesColumn.HeaderText = "Ver Detalles";
            verDetallesColumn.Name = "VerDetallesColumn";
            verDetallesColumn.Text = "Ver Detalles";
            verDetallesColumn.UseColumnTextForButtonValue = true; // Esto es importante para mostrar texto en lugar de un botón vacío
            DataGridEmpleados.Columns.Add(verDetallesColumn);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TxtBoxActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o una tecla de control (por ejemplo, borrar)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, cancelar el evento de pulsación de tecla
                e.Handled = true;
            }

            // Verificar la longitud del texto en el TextBox
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 1 && !char.IsControl(e.KeyChar))
            {
                // Si el texto ya tiene un dígito y la tecla presionada no es una tecla de control, cancelar el evento de pulsación de tecla
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var Mensaje = servicio.UpdateEmpleado(Convert.ToInt32(TxtBoxID.Text), TxtBoxNombre.Text, TxtBoxAp_paterno.Text, TxtBoxAp_materno.Text, TxtBoxCargo.Text, Convert.ToInt32(TxtBoxActivo.Text));
                MessageBox.Show(Mensaje);
                CargarEmpleadosEnDataGrid();
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
