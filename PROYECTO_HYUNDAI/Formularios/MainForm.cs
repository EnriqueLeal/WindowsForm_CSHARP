using PROYECTO_HYUNDAI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PROYECTO_HYUNDAI.Formularios
{
    public partial class MainForm : Form
    {
        private List<IApp> aplicaciones;
        private readonly IServive servicio = new IServive();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                aplicaciones = servicio.GetApps();
                if (aplicaciones != null)
                {
                    foreach (var app in aplicaciones)
                    {
                        TabPage tabPage = new TabPage(app.Nombres);
                        tabPage.Tag = app;
                        tabPage.Text = app.Nombres.ToString();
                        tabPage.Click += ButtonViewDetails_Click;
                        MessageBox.Show(app.Nombres);
                        /*Button buttonViewDetails = new Button();
                        buttonViewDetails.Text = "Ver Detalles";
                        buttonViewDetails.Tag = app;
                        buttonViewDetails.Click += ButtonViewDetails_Click;
                        tabPage.Controls.Add(buttonViewDetails);*/
                        tabControlAplicaciones.TabPages.Add(tabPage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las aplicaciones: " + ex.Message);
                RegistrarLog(ex.ToString());
            }
        }

        private void ButtonViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"{sender}");
                TabPage button = (TabPage)sender;
                if (button.Tag is IApp app)
                {
                    MessageBox.Show($"Nombre de la aplicación: {app.Nombres}");

                    // Obtener el tipo del formulario desde la propiedad Detalles
                    Type tipoFormulario = Type.GetType($"PROYECTO_HYUNDAI.Formularios.{app.Detalles}");


                    // Crear una instancia del formulario y mostrarlo
                    if (tipoFormulario != null)
                    {
                        Form formulario = (Form)Activator.CreateInstance(tipoFormulario);
                        formulario.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("El tipo del formulario no se encontró.");
                    }
                }
                else
                {
                    RegistrarLog("El Tag del botón no es de tipo IApp");
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error al convertir el Tag del botón a tipo IApp.");
                RegistrarLog("Error al convertir el Tag del botón a tipo IApp: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ver detalles de la aplicación: " + ex.Message);
                RegistrarLog(ex.ToString());
            }
        }



        private void RegistrarLog(string mensaje)
        {
            string nombreArchivo = "logs.txt";
            string rutaDirectorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

            if (!Directory.Exists(rutaDirectorio))
            {
                Directory.CreateDirectory(rutaDirectorio);
            }

            string rutaArchivo = Path.Combine(rutaDirectorio, nombreArchivo);

            using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error: " + mensaje);
            }
            Console.WriteLine("Se ha registrado un error en los logs.");
        }

        private void pnl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tab1_Click(object sender, EventArgs e)
        {

        }

        private void tab2_Click(object sender, EventArgs e)
        {

        }
    }
}
