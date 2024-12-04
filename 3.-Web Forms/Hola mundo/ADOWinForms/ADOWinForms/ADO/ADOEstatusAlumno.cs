using ADOWinForms.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADOWinForms.ADO
{
    internal class ADOEstatusAlumno : ICRUD
    {
        string stringConexion = ConfigurationManager.ConnectionStrings["TichDB"].ConnectionString;


        public void Actualizar(EstatusAlumno estatus)
        {
            string query = "updateEstatus";
            int idEstatus = estatus.id;

            try
            {

                using (SqlConnection conexion = new SqlConnection(stringConexion))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@clave", estatus.clave);
                    comando.Parameters.AddWithValue("@nombre", estatus.nombre);
                    comando.Parameters.AddWithValue("@id", estatus.id);


                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al actualizar datos: {ex.Message} ");
            }

        }

        public int Agregar(EstatusAlumno estatus)
        {
            string query = $"createEstatus";
            int idEstatus = 0;

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConexion))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@clave", estatus.clave);
                    comando.Parameters.AddWithValue("@nombre", estatus.nombre);

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    comando.Parameters.Add(returnValue);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    idEstatus = (int)returnValue.Value;
                    conexion.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al agregar datos : {ex.Message}");
            }


            return idEstatus;
        }

        public List<EstatusAlumno> Consultar()
        {
            List<EstatusAlumno> dataEstatus = new List<EstatusAlumno>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConexion))
                {
                    string query = "select * from EstatusAlumnos;";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.Text;
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        dataEstatus.Add(
                            new EstatusAlumno()
                            {
                                id = int.Parse(lector["id"].ToString()),
                                clave = lector["clave"].ToString(),
                                nombre = lector["nombre"].ToString()
                            }
                            );
                    }
                    conexion.Close();
                }
            }
            catch { Console.WriteLine("Error al realizar consulta global"); }


            return dataEstatus;
        }

        public EstatusAlumno Consultar(int id)
        {
            EstatusAlumno dataEstatus = new EstatusAlumno();

            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["TichDB"].ToString()))
                {
                    string query = $"select * from EstatusAlumnos where id = {id}";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.Text;
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        dataEstatus.id = int.Parse(lector["id"].ToString());
                        dataEstatus.clave = lector["clave"].ToString();
                        dataEstatus.nombre = lector["nombre"].ToString();
                    }

                    conexion.Close();
                }
            }
            catch
            {
                Console.WriteLine("Error al consultar los datos");
            }
            return dataEstatus;
        }

        public void Eliminar(int id)
        {
            string query = $" DELETE EstatusAlumnos WHERE id = {id} ";

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConexion))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.Text;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al eliminar el estatus: {ex.Message}");
            }
        }
    }
}
