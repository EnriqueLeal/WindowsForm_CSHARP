using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PROYECTO_HYUNDAI.Services
{
    public class IApp
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Descripcion { get; set; }
        public string Detalles { get; set; }
        public int Activo { get; set; }
    }

    public class IEmpleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Cargo { get; set; }
        public int Activo { get; set; }
        public string Usuario { get; set; }
    }


    public class IServive
    {
        
        public string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public List<IApp> GetApps()
        {
            try
            {

                List<IApp> aplicaciones = new List<IApp>();

                // Crear una conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear un comando para ejecutar la consulta SQL
                    //string query = "SELECT Id, Nombre, Descripcion, Detalles, Activo FROM Aplicaciones";
                    // SqlCommand command = new SqlCommand(query, connection);

                    SqlCommand command = new SqlCommand("GetApps", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Ejecutar la consulta y obtener un lector de datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Leer cada fila de resultados y crear una instancia de IApp para cada aplicación
                        while (reader.Read())
                        {
                            IApp app = new IApp
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombres = Convert.ToString(reader["Nombre"]),
                                Descripcion = Convert.ToString(reader["Descripcion"]),
                                Detalles = Convert.ToString(reader["Detalles"]),
                                Activo = Convert.ToInt32(reader["Activo"])
                            };

                            // Agregar la aplicación a la lista
                            aplicaciones.Add(app);
                        }
                    }
                }
                return aplicaciones;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Log", ex.Message);
                return null;
            }
           
        }

        public List<IEmpleados> GetEmpleados()
        {
            try
            {
                List<IEmpleados> empleados = new List<IEmpleados>();

                // Crear una conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear un comando para ejecutar el procedimiento almacenado
                    using (SqlCommand command = new SqlCommand("GetEmpleados", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Ejecutar el procedimiento almacenado y obtener un lector de datos
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Leer cada fila de resultados y crear una instancia de IEmpleados para cada empleado
                            while (reader.Read())
                            {
                                IEmpleados empleado = new IEmpleados
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = Convert.ToString(reader["Nombre"]),
                                    ApellidoPaterno = Convert.ToString(reader["ApellidoPaterno"]),
                                    ApellidoMaterno = Convert.ToString(reader["ApellidoMaterno"]),
                                    Cargo = Convert.ToString(reader["Cargo"]),
                                    Activo = Convert.ToInt32(reader["Activo"]),
                                    Usuario = Convert.ToString(reader["Usuario"])
                                };

                                // Agregar el empleado a la lista
                                empleados.Add(empleado);
                            }
                        }
                    }
                }
                return empleados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener empleados: " + ex.Message);
                return null;
            }
        }

        public string UpdateEmpleado(int id, string nombre, string apellidoPaterno, string apellidoMaterno, string cargo, int activo)
        {
            try
            {
                string mensaje = string.Empty;

                // Crear una conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear un comando para ejecutar el procedimiento almacenado
                    using (SqlCommand command = new SqlCommand("UpdateEmpleados", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        bool activoBool = activo == 1 ? true : false;

                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Ap_paterno", apellidoPaterno);
                        command.Parameters.AddWithValue("@Ap_materno", apellidoMaterno);
                        command.Parameters.AddWithValue("@Cargo", cargo);
                        command.Parameters.Add("@Activo", SqlDbType.Bit).Value = activoBool;

                        // Agregar parámetro de salida para el mensaje del procedimiento almacenado
                        SqlParameter mensajeParametro = new SqlParameter("@MensajeSucess", SqlDbType.NVarChar, 1000);
                        mensajeParametro.Direction = ParameterDirection.Output;
                        command.Parameters.Add(mensajeParametro);

                        // Ejecutar el comando
                        command.ExecuteNonQuery();

                        // Obtener el valor del parámetro de salida
                        mensaje = mensajeParametro.Value.ToString();
                    }
                }

                // Imprimir el mensaje
                Console.WriteLine("Mensaje del procedimiento almacenado: " + mensaje);

                return mensaje;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar empleado: " + ex.Message);
                return null;
            }
        }




    }
}
